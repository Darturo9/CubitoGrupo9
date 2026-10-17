using System;

namespace CapaEntidadesDG
{
    // Pago o anticipo recibido para un pedido
    public class PagoDG
    {
        public const string MetodoEfectivoDG = "Efectivo";
        public const string MetodoTransferenciaDG = "Transferencia";

        public int gIntIdPagoDG { get; set; }
        public int gIntIdPedidoDG { get; set; }
        public decimal gDcmMontoDG { get; set; }
        public string gStrMetodoDG { get; set; }
        public DateTime gDtmFechaDG { get; set; }

        public PagoDG()
        {
            gStrMetodoDG = MetodoEfectivoDG;
            gDtmFechaDG = DateTime.Now;
        }
    }
}
