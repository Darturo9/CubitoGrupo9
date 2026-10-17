using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatosDG;
using CapaEntidadesDG;

namespace CapaLogicaNegocioDG
{
    // Reglas de pagos: anticipos, saldo y cuentas por cobrar
    public class LogicaPagoDG
    {
        public static readonly string[] gArrMetodosDG = { PagoDG.MetodoEfectivoDG, PagoDG.MetodoTransferenciaDG };

        private readonly DatosPagoDG gObjDatosPagoDG = new DatosPagoDG();
        private readonly DatosPedidoDG gObjDatosPedidoDG = new DatosPedidoDG();

        // Solo se cobra a pedidos aprobados que todavía no se entregan.
        // En Cotización el precio aún puede cambiar; Entregado y Cancelado son finales.
        public static bool FncAceptaPagosDG(string pStrEstadoDG)
        {
            return pStrEstadoDG == PedidoDG.EstadoAprobadoDG
                || pStrEstadoDG == PedidoDG.EstadoEnProduccionDG
                || pStrEstadoDG == PedidoDG.EstadoListoDG;
        }

        public List<PagoDG> FncListarPagosDG(int pIntIdPedidoDG)
        {
            return gObjDatosPagoDG.FncListarPagosDG(pIntIdPedidoDG);
        }

        // Pedidos activos con saldo pendiente. Primero los listos (ya se pueden cobrar y entregar),
        // luego por fecha de entrega más cercana.
        public List<PedidoDG> FncListarCuentasPorCobrarDG(string pStrFiltroDG)
        {
            return gObjDatosPedidoDG.FncListarPedidosDG(pStrFiltroDG, string.Empty)
                .Where(lObjPedidoDG => FncAceptaPagosDG(lObjPedidoDG.gStrEstadoDG) && lObjPedidoDG.gDcmSaldoDG > 0)
                .OrderBy(lObjPedidoDG => lObjPedidoDG.gStrEstadoDG == PedidoDG.EstadoListoDG ? 0 : 1)
                .ThenBy(lObjPedidoDG => lObjPedidoDG.gDtmFechaEntregaDG ?? DateTime.MaxValue)
                .ThenBy(lObjPedidoDG => lObjPedidoDG.gIntIdPedidoDG)
                .ToList();
        }

        public decimal FncCobradoHoyDG()
        {
            return gObjDatosPagoDG.FncTotalCobradoDG(DateTime.Today);
        }

        // ---------------- Registrar ----------------

        public bool FncValidarPagoDG(PagoDG pObjPagoDG, PedidoDG pObjPedidoDG, out string pStrMensajeDG)
        {
            pStrMensajeDG = string.Empty;
            if (pObjPagoDG == null) { pStrMensajeDG = "No se recibió información del pago."; return false; }
            if (pObjPedidoDG == null) { pStrMensajeDG = "El pedido no existe."; return false; }
            if (!FncAceptaPagosDG(pObjPedidoDG.gStrEstadoDG))
            {
                pStrMensajeDG = pObjPedidoDG.gStrEstadoDG == PedidoDG.EstadoCotizacionDG
                    ? "Primero apruebe la cotización; después se pueden registrar anticipos."
                    : "Un pedido " + pObjPedidoDG.gStrEstadoDG.ToLower() + " ya no recibe pagos.";
                return false;
            }
            if (!gArrMetodosDG.Contains(pObjPagoDG.gStrMetodoDG)) { pStrMensajeDG = "Seleccione el método de pago."; return false; }
            if (pObjPagoDG.gDcmMontoDG <= 0) { pStrMensajeDG = "El monto debe ser mayor a cero."; return false; }
            if (decimal.Round(pObjPagoDG.gDcmMontoDG, 2) != pObjPagoDG.gDcmMontoDG)
            { pStrMensajeDG = "El monto solo puede tener dos decimales."; return false; }
            if (pObjPedidoDG.gDcmSaldoDG <= 0) { pStrMensajeDG = "Este pedido ya está pagado por completo."; return false; }
            if (pObjPagoDG.gDcmMontoDG > pObjPedidoDG.gDcmSaldoDG)
            {
                pStrMensajeDG = "El monto (Q" + pObjPagoDG.gDcmMontoDG.ToString("N2") + ") es mayor al saldo pendiente (Q" +
                    pObjPedidoDG.gDcmSaldoDG.ToString("N2") + ").";
                return false;
            }
            return true;
        }

        public bool FncRegistrarPagoDG(PagoDG pObjPagoDG, out string pStrMensajeDG)
        {
            // Se valida contra el pedido actual de la base, no contra lo que muestra la pantalla
            PedidoDG lObjPedidoDG = pObjPagoDG == null ? null : gObjDatosPedidoDG.FncBuscarPedidoDG(pObjPagoDG.gIntIdPedidoDG);
            if (!FncValidarPagoDG(pObjPagoDG, lObjPedidoDG, out pStrMensajeDG)) return false;

            try
            {
                gObjDatosPagoDG.FncInsertarPagoDG(pObjPagoDG);
            }
            catch (InvalidOperationException lObjErrorDG)
            {
                pStrMensajeDG = lObjErrorDG.Message;
                return false;
            }

            decimal lDcmSaldoDG = lObjPedidoDG.gDcmSaldoDG - pObjPagoDG.gDcmMontoDG;
            pStrMensajeDG = "Pago de Q" + pObjPagoDG.gDcmMontoDG.ToString("N2") + " registrado. " +
                (lDcmSaldoDG == 0 ? "El pedido " + lObjPedidoDG.gStrCodigoDG + " quedó pagado por completo." : "Saldo pendiente: Q" + lDcmSaldoDG.ToString("N2") + ".");
            return true;
        }

        public bool FncEliminarPagoDG(PagoDG pObjPagoDG, out string pStrMensajeDG)
        {
            pStrMensajeDG = string.Empty;
            if (pObjPagoDG == null || pObjPagoDG.gIntIdPagoDG <= 0) { pStrMensajeDG = "Seleccione el pago a eliminar."; return false; }

            try
            {
                gObjDatosPagoDG.SubEliminarPagoDG(pObjPagoDG.gIntIdPagoDG);
            }
            catch (InvalidOperationException lObjErrorDG)
            {
                pStrMensajeDG = lObjErrorDG.Message;
                return false;
            }

            pStrMensajeDG = "Se eliminó el pago de Q" + pObjPagoDG.gDcmMontoDG.ToString("N2") + ".";
            return true;
        }
    }
}
