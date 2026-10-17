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

        public MovimientoInventarioDG()
        {
            gStrTipoDG = TipoEntradaDG;
            gStrMotivoDG = string.Empty;
            gDtmFechaDG = DateTime.Now;
        }
    }
}
