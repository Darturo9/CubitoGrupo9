using System;

namespace CapaEntidadesDG
{
    // Gasto del taller: insumos, luz, renta, transporte, etc.
    public class GastoDG
    {
        public int gIntIdGastoDG { get; set; }
        public string gStrCategoriaDG { get; set; }
        public string gStrDescripcionDG { get; set; }
        public decimal gDcmMontoDG { get; set; }
        public DateTime gDtmFechaDG { get; set; }

        public GastoDG()
        {
            gStrCategoriaDG = string.Empty;
            gStrDescripcionDG = string.Empty;
            gDtmFechaDG = DateTime.Today;
        }
    }
}
