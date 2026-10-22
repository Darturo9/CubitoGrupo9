using CapaEntidadesDG;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;


namespace CapaDatosDG
{
   public  class DatosListaComprasEC
    {
        public List<ItemCompraEC> FncObtenerArticulosAReponerEC()
        {
            var lLstItemsEC = new List<ItemCompraEC>();

            const string lStrSqlEC = @"
                SELECT IdArticulo, Codigo, Nombre, Tipo, Talla, Color, Unidad,
                       Stock, StockMinimo, StockMaximo, CostoUnitario
                FROM   ArticulosDG
                WHERE  Activo = 1
                  AND  Stock <= StockMinimo
                  AND  StockMaximo > Stock
                ORDER BY Stock ASC, Nombre ASC;";

            // AJUSTAR: usa la misma forma de obtener la conexión que DatosClienteDG.cs
            using (SqlConnection lObjConexionEc = ConexionDG.FncCrearConexionDG())
            using (var lObjComandoEC = new SqlCommand(lStrSqlEC, lObjConexionEc))
            {
                lObjConexionEc.Open();
                using (var lObjLectorEC = lObjComandoEC.ExecuteReader())
                {
                    while (lObjLectorEC.Read())
                    {
                        lLstItemsEC.Add(new ItemCompraEC
                        {
                            IdArticulo = System.Convert.ToInt32(lObjLectorEC["IdArticulo"]),
                            Codigo = lObjLectorEC["Codigo"].ToString(),
                            Nombre = lObjLectorEC["Nombre"].ToString(),
                            Tipo = lObjLectorEC["Tipo"].ToString(),
                            Talla = lObjLectorEC["Talla"] == System.DBNull.Value ? "" : lObjLectorEC["Talla"].ToString(),
                            Color = lObjLectorEC["Color"] == System.DBNull.Value ? "" : lObjLectorEC["Color"].ToString(),
                            Unidad = lObjLectorEC["Unidad"].ToString(),
                            Stock = System.Convert.ToDecimal(lObjLectorEC["Stock"]),
                            StockMinimo = System.Convert.ToDecimal(lObjLectorEC["StockMinimo"]),
                            StockMaximo = System.Convert.ToDecimal(lObjLectorEC["StockMaximo"]),
                            CostoUnitario = System.Convert.ToDecimal(lObjLectorEC["CostoUnitario"])
                        });
                    }
                }
            }
            return lLstItemsEC;
        }
    }
}
