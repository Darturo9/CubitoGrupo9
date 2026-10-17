namespace CapaEntidadesDG
{
    // Prenda o insumo que se guarda en bodega
    public class ArticuloDG
    {
        public const string TipoPrendaDG = "Prenda";
        public const string TipoInsumoDG = "Insumo";

        public int gIntIdArticuloDG { get; set; }
        public string gStrCodigoDG { get; set; }
        public string gStrNombreDG { get; set; }
        public string gStrTipoDG { get; set; }
        public string gStrTallaDG { get; set; }
        public string gStrColorDG { get; set; }
        public string gStrUnidadDG { get; set; }
        public decimal gDcmStockDG { get; set; }
        public decimal gDcmStockMinimoDG { get; set; }
        public decimal gDcmStockMaximoDG { get; set; }
        public decimal gDcmCostoUnitarioDG { get; set; }
        public bool gBlnActivoDG { get; set; }

        // Alerta de reorden: el stock llegó al mínimo o menos
        public bool gBlnRequiereReordenDG
        {
            get { return gDcmStockDG <= gDcmStockMinimoDG; }
        }

        // Cantidad sugerida para volver al stock máximo
        public decimal gDcmCantidadSugeridaDG
        {
            get { return gDcmStockMaximoDG - gDcmStockDG > 0 ? gDcmStockMaximoDG - gDcmStockDG : 0; }
        }

        public ArticuloDG()
        {
            gStrCodigoDG = string.Empty;
            gStrNombreDG = string.Empty;
            gStrTipoDG = TipoPrendaDG;
            gStrTallaDG = string.Empty;
            gStrColorDG = string.Empty;
            gStrUnidadDG = "Unidad";
            gBlnActivoDG = true;
        }
    }
}
