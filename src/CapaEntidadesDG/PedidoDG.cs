using System;
using System.Collections.Generic;

namespace CapaEntidadesDG
{
    // Pedido de un cliente; empieza como cotización
    public class PedidoDG
    {
        public const string EstadoCotizacionDG = "Cotización";
        public const string EstadoAprobadoDG = "Aprobado";
        public const string EstadoEnProduccionDG = "En producción";
        public const string EstadoListoDG = "Listo";
        public const string EstadoEntregadoDG = "Entregado";
        public const string EstadoCanceladoDG = "Cancelado";

        public const string OrigenEscritorioDG = "Escritorio";
        public const string OrigenPortalDG = "Portal";

        public int gIntIdPedidoDG { get; set; }
        public string gStrCodigoDG { get; set; }
        public int gIntIdClienteDG { get; set; }
        public string gStrNombreClienteDG { get; set; }
        public string gStrEstadoDG { get; set; }
        public DateTime gDtmFechaPedidoDG { get; set; }
        public DateTime? gDtmFechaEntregaDG { get; set; }
        public decimal gDcmTotalDG { get; set; }
        public decimal gDcmTotalPagadoDG { get; set; }
        public string gStrOrigenDG { get; set; }
        public string gStrObservacionesDG { get; set; }
        public string gStrMotivoCancelacionDG { get; set; }
        public List<DetallePedidoDG> gLstDetallesDG { get; set; }

        // Saldo pendiente = Total - pagos realizados
        public decimal gDcmSaldoDG
        {
            get { return gDcmTotalDG - gDcmTotalPagadoDG; }
        }

        public PedidoDG()
        {
            gStrCodigoDG = string.Empty;
            gStrNombreClienteDG = string.Empty;
            gStrEstadoDG = EstadoCotizacionDG;
            gDtmFechaPedidoDG = DateTime.Now;
            gStrOrigenDG = OrigenEscritorioDG;
            gStrObservacionesDG = string.Empty;
            gStrMotivoCancelacionDG = string.Empty;
            gLstDetallesDG = new List<DetallePedidoDG>();
        }
    }
}
