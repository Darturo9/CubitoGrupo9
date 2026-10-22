using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidadesDG
{
    public class ItemCompraEC
    {
        public int IdArticulo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public string Unidad { get; set; }
        public decimal Stock { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal StockMaximo { get; set; }
        public decimal CantidadSugerida { get; set; }   // Máximo − Stock
        public decimal CostoUnitario { get; set; }
        public decimal CostoEstimado { get; set; }      // Sugerida × CostoUnitario
        public string Estado { get; set; }              // Agotado / Stock bajo
        public string ComprarTexto { get; set; }        // Ej: "8.50 kg"
    }
}

