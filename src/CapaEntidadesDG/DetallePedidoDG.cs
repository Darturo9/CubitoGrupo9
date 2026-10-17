namespace CapaEntidadesDG
{
    // Una línea del pedido: técnica, prenda, cantidad y precio
    public class DetallePedidoDG
    {
        public const string TecnicaSerigrafiaDG = "Serigrafía";
        public const string TecnicaSublimacionDG = "Sublimación";
        public const string TecnicaDtfDG = "DTF";

        public int gIntIdDetalleDG { get; set; }
        public int gIntIdPedidoDG { get; set; }
        public string gStrTecnicaDG { get; set; }
        public int? gIntIdArticuloDG { get; set; }   // null cuando el cliente trae su prenda
        public string gStrDescripcionDG { get; set; }
        public int gIntCantidadDG { get; set; }
        public decimal gDcmPrecioUnitarioDG { get; set; }

        public decimal gDcmSubtotalDG
        {
            get { return gIntCantidadDG * gDcmPrecioUnitarioDG; }
        }

        public DetallePedidoDG()
        {
            gStrTecnicaDG = TecnicaSerigrafiaDG;
            gStrDescripcionDG = string.Empty;
        }
    }
}
