using System;

namespace CapaEntidadesDG
{
    // Cada entrada, salida o ajuste de un artículo (kardex)
    public class MovimientoInventarioDG
    {
        public const string TipoEntradaDG = "Entrada";
        public const string TipoSalidaDG = "Salida";
        public const string TipoAjusteDG = "Ajuste";

        public int gIntIdMovimientoDG { get; set; }
        public int gIntIdArticuloDG { get; set; }
        public string gStrTipoDG { get; set; }
        public decimal gDcmCantidadDG { get; set; }
        public string gStrMotivoDG { get; set; }
        public int? gIntIdPedidoDG { get; set; }
        public DateTime gDtmFechaDG { get; set; }

        // Solo para el kardex: código del pedido relacionado y saldo después del movimiento
        public string gStrCodigoPedidoDG { get; set; }
        public decimal gDcmSaldoDG { get; set; }

        // Cuánto cambia el stock: las salidas restan, entradas y ajustes llevan su propio signo
        public decimal gDcmVariacionStockDG
        {
            get { return gStrTipoDG == TipoSalidaDG ? -gDcmCantidadDG : gDcmCantidadDG; }
        }

        public MovimientoInventarioDG()
        {
            gStrTipoDG = TipoEntradaDG;
            gStrMotivoDG = string.Empty;
            gStrCodigoPedidoDG = string.Empty;
            gDtmFechaDG = DateTime.Now;
        }
    }
}
