using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatosDG;
using CapaEntidadesDG;

namespace CapaLogicaNegocioDG
{
    // Reglas de pedidos: validaciones, total y cambios de estado
    public class LogicaPedidoDG
    {
        public static readonly string[] gArrTecnicasDG =
            { DetallePedidoDG.TecnicaSerigrafiaDG, DetallePedidoDG.TecnicaSublimacionDG, DetallePedidoDG.TecnicaDtfDG };

        public static readonly string[] gArrEstadosDG =
        {
            PedidoDG.EstadoCotizacionDG, PedidoDG.EstadoAprobadoDG, PedidoDG.EstadoEnProduccionDG,
            PedidoDG.EstadoListoDG, PedidoDG.EstadoEntregadoDG, PedidoDG.EstadoCanceladoDG
        };

        private readonly DatosPedidoDG gObjDatosPedidoDG = new DatosPedidoDG();
        private readonly DatosArticuloDG gObjDatosArticuloDG = new DatosArticuloDG();

        public List<PedidoDG> FncListarPedidosDG(string pStrFiltroDG, string pStrEstadoDG)
        {
            return gObjDatosPedidoDG.FncListarPedidosDG(pStrFiltroDG, pStrEstadoDG);
        }

        public PedidoDG FncBuscarPedidoDG(int pIntIdPedidoDG)
        {
            return gObjDatosPedidoDG.FncBuscarPedidoDG(pIntIdPedidoDG);
        }

        // Prendas activas del inventario que se pueden usar en un pedido
        public List<ArticuloDG> FncListarPrendasDG()
        {
            return gObjDatosArticuloDG.FncListarArticulosDG(string.Empty, false)
                .Where(lObjArticuloDG => lObjArticuloDG.gStrTipoDG == ArticuloDG.TipoPrendaDG)
                .ToList();
        }

        // Total = suma de (cantidad x precio) de todas las líneas
        public decimal FncCalcularTotalDG(IEnumerable<DetallePedidoDG> pLstDetallesDG)
        {
            return pLstDetallesDG.Sum(lObjDetalleDG => lObjDetalleDG.gDcmSubtotalDG);
        }

        // A qué estados puede pasar el pedido desde su estado actual
        public List<string> FncEstadosSiguientesDG(string pStrEstadoActualDG)
        {
            switch (pStrEstadoActualDG)
            {
                case PedidoDG.EstadoCotizacionDG: return new List<string> { PedidoDG.EstadoAprobadoDG, PedidoDG.EstadoCanceladoDG };
                case PedidoDG.EstadoAprobadoDG: return new List<string> { PedidoDG.EstadoEnProduccionDG, PedidoDG.EstadoCanceladoDG };
                case PedidoDG.EstadoEnProduccionDG: return new List<string> { PedidoDG.EstadoListoDG, PedidoDG.EstadoCanceladoDG };
                case PedidoDG.EstadoListoDG: return new List<string> { PedidoDG.EstadoEntregadoDG };
                default: return new List<string>();   // Entregado y Cancelado son finales
            }
        }

        // ---------------- Validar y guardar ----------------

        public bool FncValidarPedidoDG(PedidoDG pObjPedidoDG, out string pStrMensajeDG)
        {
            pStrMensajeDG = string.Empty;
            if (pObjPedidoDG == null) { pStrMensajeDG = "No se recibió información del pedido."; return false; }
            if (pObjPedidoDG.gIntIdClienteDG <= 0) { pStrMensajeDG = "Seleccione el cliente."; return false; }
            if (pObjPedidoDG.gLstDetallesDG.Count == 0) { pStrMensajeDG = "Agregue al menos una línea al pedido."; return false; }
            if ((pObjPedidoDG.gStrObservacionesDG ?? string.Empty).Trim().Length > 300)
            { pStrMensajeDG = "Las observaciones no pueden tener más de 300 caracteres."; return false; }
            if (pObjPedidoDG.gDtmFechaEntregaDG.HasValue && pObjPedidoDG.gDtmFechaEntregaDG.Value.Date < pObjPedidoDG.gDtmFechaPedidoDG.Date)
            { pStrMensajeDG = "La fecha de entrega no puede ser anterior a la fecha del pedido."; return false; }

            for (int lIntIndiceDG = 0; lIntIndiceDG < pObjPedidoDG.gLstDetallesDG.Count; lIntIndiceDG++)
            {
                DetallePedidoDG lObjDetalleDG = pObjPedidoDG.gLstDetallesDG[lIntIndiceDG];
                string lStrLineaDG = "Línea " + (lIntIndiceDG + 1) + ": ";
                if (!gArrTecnicasDG.Contains(lObjDetalleDG.gStrTecnicaDG)) { pStrMensajeDG = lStrLineaDG + "seleccione la técnica."; return false; }
                if (string.IsNullOrWhiteSpace(lObjDetalleDG.gStrDescripcionDG)) { pStrMensajeDG = lStrLineaDG + "describa el diseño (por ejemplo: logo al frente)."; return false; }
                if (lObjDetalleDG.gStrDescripcionDG.Trim().Length > 200) { pStrMensajeDG = lStrLineaDG + "la descripción no puede tener más de 200 caracteres."; return false; }
                if (lObjDetalleDG.gIntCantidadDG <= 0 || lObjDetalleDG.gIntCantidadDG > 10000) { pStrMensajeDG = lStrLineaDG + "la cantidad debe estar entre 1 y 10,000."; return false; }
                if (lObjDetalleDG.gDcmPrecioUnitarioDG < 0) { pStrMensajeDG = lStrLineaDG + "el precio no puede ser negativo."; return false; }
                if (decimal.Round(lObjDetalleDG.gDcmPrecioUnitarioDG, 2) != lObjDetalleDG.gDcmPrecioUnitarioDG)
                { pStrMensajeDG = lStrLineaDG + "el precio solo puede tener dos decimales."; return false; }
                if (pObjPedidoDG.gStrEstadoDG == PedidoDG.EstadoAprobadoDG && lObjDetalleDG.gDcmPrecioUnitarioDG == 0)
                { pStrMensajeDG = lStrLineaDG + "un pedido aprobado no puede tener líneas sin precio."; return false; }

                if (lObjDetalleDG.gIntIdArticuloDG.HasValue)
                {
                    ArticuloDG lObjArticuloDG = gObjDatosArticuloDG.FncBuscarPorIdDG(lObjDetalleDG.gIntIdArticuloDG.Value);
                    if (lObjArticuloDG == null || !lObjArticuloDG.gBlnActivoDG || lObjArticuloDG.gStrTipoDG != ArticuloDG.TipoPrendaDG)
                    { pStrMensajeDG = lStrLineaDG + "la prenda seleccionada no existe o está desactivada."; return false; }
                }
            }
            return true;
        }

        // Crea el pedido (queda en Cotización) o guarda los cambios si todavía es editable
        public bool FncGuardarPedidoDG(PedidoDG pObjPedidoDG, out string pStrMensajeDG)
        {
            if (pObjPedidoDG != null && pObjPedidoDG.gIntIdPedidoDG != 0 && !pObjPedidoDG.gBlnEsEditableDG)
            {
                pStrMensajeDG = "Un pedido en estado " + pObjPedidoDG.gStrEstadoDG + " ya no se puede modificar.";
                return false;
            }
            if (!FncValidarPedidoDG(pObjPedidoDG, out pStrMensajeDG)) return false;

            try
            {
                if (pObjPedidoDG.gIntIdPedidoDG == 0)
                    gObjDatosPedidoDG.FncInsertarPedidoDG(pObjPedidoDG);
                else
                    gObjDatosPedidoDG.SubActualizarPedidoDG(pObjPedidoDG);
            }
            catch (InvalidOperationException lObjErrorDG)
            {
                pStrMensajeDG = lObjErrorDG.Message;
                return false;
            }

            pStrMensajeDG = "Pedido " + pObjPedidoDG.gStrCodigoDG + " guardado. Total: Q" + pObjPedidoDG.gDcmTotalDG.ToString("N2");
            return true;
        }

        // ---------------- Cambios de estado ----------------

        public bool FncCambiarEstadoDG(int pIntIdPedidoDG, string pStrEstadoNuevoDG, string pStrMotivoDG, out string pStrMensajeDG)
        {
            pStrMensajeDG = string.Empty;
            // Siempre se trabaja con la versión actual de la base, no con lo que tiene la pantalla
            PedidoDG lObjPedidoDG = gObjDatosPedidoDG.FncBuscarPedidoDG(pIntIdPedidoDG);
            if (lObjPedidoDG == null) { pStrMensajeDG = "El pedido no existe."; return false; }

            if (!FncEstadosSiguientesDG(lObjPedidoDG.gStrEstadoDG).Contains(pStrEstadoNuevoDG))
            {
                pStrMensajeDG = "No se puede pasar de " + lObjPedidoDG.gStrEstadoDG + " a " + pStrEstadoNuevoDG + ".";
                return false;
            }

            switch (pStrEstadoNuevoDG)
            {
                case PedidoDG.EstadoAprobadoDG:
                    if (lObjPedidoDG.gLstDetallesDG.Any(lObjDetalleDG => lObjDetalleDG.gDcmPrecioUnitarioDG <= 0) || lObjPedidoDG.gDcmTotalDG <= 0)
                    {
                        pStrMensajeDG = "Para aprobar, todas las líneas deben tener precio.";
                        return false;
                    }
                    break;

                case PedidoDG.EstadoEnProduccionDG:
                    if (!FncHayStockParaProducirDG(lObjPedidoDG, out pStrMensajeDG)) return false;
                    break;

                case PedidoDG.EstadoEntregadoDG:
                    if (lObjPedidoDG.gDcmSaldoDG > 0)
                    {
                        pStrMensajeDG = "No se puede entregar: falta cobrar Q" + lObjPedidoDG.gDcmSaldoDG.ToString("N2") + ".";
                        return false;
                    }
                    break;

                case PedidoDG.EstadoCanceladoDG:
                    if (string.IsNullOrWhiteSpace(pStrMotivoDG)) { pStrMensajeDG = "Indique el motivo de la cancelación."; return false; }
                    if (pStrMotivoDG.Trim().Length > 200) { pStrMensajeDG = "El motivo no puede tener más de 200 caracteres."; return false; }
                    break;
            }

            try
            {
                if (pStrEstadoNuevoDG == PedidoDG.EstadoEnProduccionDG)
                    gObjDatosPedidoDG.SubIniciarProduccionDG(lObjPedidoDG);
                else
                    gObjDatosPedidoDG.SubCambiarEstadoDG(pIntIdPedidoDG, lObjPedidoDG.gStrEstadoDG, pStrEstadoNuevoDG, pStrMotivoDG);
            }
            catch (InvalidOperationException lObjErrorDG)
            {
                pStrMensajeDG = lObjErrorDG.Message;
                return false;
            }

            pStrMensajeDG = "Pedido " + lObjPedidoDG.gStrCodigoDG + " ahora está " + pStrEstadoNuevoDG + ".";
            if (pStrEstadoNuevoDG == PedidoDG.EstadoEnProduccionDG && lObjPedidoDG.gLstDetallesDG.Any(lObjDetalleDG => lObjDetalleDG.gIntIdArticuloDG.HasValue))
                pStrMensajeDG += " Se descontaron las prendas del inventario.";
            if (pStrEstadoNuevoDG == PedidoDG.EstadoCanceladoDG && lObjPedidoDG.gStrEstadoDG == PedidoDG.EstadoEnProduccionDG)
                pStrMensajeDG += " Las prendas ya usadas no regresan solas al inventario; si alguna se recupera, regístrela con una entrada.";
            if (pStrEstadoNuevoDG == PedidoDG.EstadoCanceladoDG && lObjPedidoDG.gDcmTotalPagadoDG > 0)
                pStrMensajeDG += " El cliente había pagado Q" + lObjPedidoDG.gDcmTotalPagadoDG.ToString("N2") + "; si corresponde, devuélvale el dinero.";
            return true;
        }

        // Suma lo que pide el pedido por artículo y lo compara con el stock disponible
        private bool FncHayStockParaProducirDG(PedidoDG pObjPedidoDG, out string pStrMensajeDG)
        {
            pStrMensajeDG = string.Empty;
            var lLstNecesidadesDG = pObjPedidoDG.gLstDetallesDG
                .Where(lObjDetalleDG => lObjDetalleDG.gIntIdArticuloDG.HasValue)
                .GroupBy(lObjDetalleDG => lObjDetalleDG.gIntIdArticuloDG.Value)
                .Select(lObjGrupoDG => new { IdArticuloDG = lObjGrupoDG.Key, CantidadDG = lObjGrupoDG.Sum(lObjDetalleDG => lObjDetalleDG.gIntCantidadDG) });

            List<string> lLstFaltantesDG = new List<string>();
            foreach (var lObjNecesidadDG in lLstNecesidadesDG)
            {
                ArticuloDG lObjArticuloDG = gObjDatosArticuloDG.FncBuscarPorIdDG(lObjNecesidadDG.IdArticuloDG);
                if (lObjArticuloDG == null || !lObjArticuloDG.gBlnActivoDG)
                {
                    lLstFaltantesDG.Add("una prenda que ya no está activa en el inventario");
                    continue;
                }
                if (lObjArticuloDG.gDcmStockDG < lObjNecesidadDG.CantidadDG)
                    lLstFaltantesDG.Add(DatosPedidoDG.FncDescribirPrendaDG(lObjArticuloDG.gStrNombreDG, lObjArticuloDG.gStrTallaDG, lObjArticuloDG.gStrColorDG) +
                        " (necesita " + lObjNecesidadDG.CantidadDG + ", hay " + lObjArticuloDG.gDcmStockDG.ToString("0.##") + ")");
            }

            if (lLstFaltantesDG.Count == 0) return true;
            pStrMensajeDG = "No hay stock suficiente para producir:\n- " + string.Join("\n- ", lLstFaltantesDG);
            return false;
        }
    }
}
