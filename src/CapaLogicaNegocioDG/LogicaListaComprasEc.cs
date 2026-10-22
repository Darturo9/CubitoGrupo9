using CapaDatosDG;
using CapaEntidadesDG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaLogicaNegocioDG
{
    public class LogicaListaComprasEc
    {
        private readonly DatosListaComprasEC gObjDatosEC = new DatosListaComprasEC();

        public List<ItemCompraEC> FncObtenerListaComprasEC()
        {
            List<ItemCompraEC> lLstItemsEC = gObjDatosEC.FncObtenerArticulosAReponerEC();

            foreach (ItemCompraEC lObjItemEC in lLstItemsEC)
            {
                lObjItemEC.CantidadSugerida = lObjItemEC.StockMaximo - lObjItemEC.Stock;
                lObjItemEC.CostoEstimado = lObjItemEC.CantidadSugerida * lObjItemEC.CostoUnitario;
                lObjItemEC.Estado = lObjItemEC.Stock <= 0 ? "Agotado" : "Stock bajo";
                lObjItemEC.ComprarTexto = lObjItemEC.CantidadSugerida.ToString("N2") + " " + lObjItemEC.Unidad;
            }
            return lLstItemsEC;
        }

        // pStrTipoEC: "Todos", "Prenda" o "Insumo"
        public List<ItemCompraEC> FncFiltrarPorTipoEC(List<ItemCompraEC> pLstItemsEC, string pStrTipoEC)
        {
            if (string.IsNullOrEmpty(pStrTipoEC) || pStrTipoEC == "Todos")
                return pLstItemsEC;
            return pLstItemsEC.Where(x => x.Tipo == pStrTipoEC).ToList();
        }

        public decimal FncCalcularTotalEC(List<ItemCompraEC> pLstItemsEC)
        {
            return pLstItemsEC.Sum(x => x.CostoEstimado);
        }

        public int FncContarAgotadosEC(List<ItemCompraEC> pLstItemsEC)
        {
            return pLstItemsEC.Count(x => x.Stock <= 0);
        }
    }
}
