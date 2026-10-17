using System.Collections.Generic;
using CapaEntidadesDG;
using Microsoft.Data.SqlClient;

namespace CapaDatosDG
{
    // Acceso a la tabla ArticulosDG
    public class DatosArticuloDG
    {
        private const string gStrColumnasDG =
            "IdArticuloDG, CodigoDG, NombreDG, TipoDG, TallaDG, ColorDG, UnidadDG, " +
            "StockDG, StockMinimoDG, StockMaximoDG, CostoUnitarioDG, ActivoDG";

        // Lista artículos activos; el filtro busca por código o nombre
        public List<ArticuloDG> FncListarArticulosDG(string pStrFiltroDG, bool pBlnSoloAlertasDG)
        {
            string lStrConsultaDG =
                "SELECT " + gStrColumnasDG + " FROM dbo.ArticulosDG " +
                "WHERE ActivoDG = 1 " +
                "AND (@FiltroDG = '' OR CodigoDG LIKE '%' + @FiltroDG + '%' OR NombreDG LIKE '%' + @FiltroDG + '%') " +
                "AND (@SoloAlertasDG = 0 OR StockDG <= StockMinimoDG) " +
                "ORDER BY NombreDG, TallaDG, ColorDG";

            List<ArticuloDG> lLstArticulosDG = new List<ArticuloDG>();
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@FiltroDG", (pStrFiltroDG ?? string.Empty).Trim());
                lObjComandoDG.Parameters.AddWithValue("@SoloAlertasDG", pBlnSoloAlertasDG);
                lObjConexionDG.Open();
                using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                {
                    while (lObjLectorDG.Read()) lLstArticulosDG.Add(FncLeerArticuloDG(lObjLectorDG));
                }
            }
            return lLstArticulosDG;
        }

        public ArticuloDG FncBuscarPorIdDG(int pIntIdArticuloDG)
        {
            string lStrConsultaDG = "SELECT " + gStrColumnasDG + " FROM dbo.ArticulosDG WHERE IdArticuloDG = @IdArticuloDG";
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@IdArticuloDG", pIntIdArticuloDG);
                lObjConexionDG.Open();
                using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                {
                    return lObjLectorDG.Read() ? FncLeerArticuloDG(lObjLectorDG) : null;
                }
            }
        }

        // Revisa si otro artículo ya usa el código
        public bool FncExisteCodigoDG(string pStrCodigoDG, int pIntIdExcluirDG)
        {
            const string lStrConsultaDG =
                "SELECT COUNT(*) FROM dbo.ArticulosDG WHERE CodigoDG = @CodigoDG AND IdArticuloDG <> @IdExcluirDG";
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@CodigoDG", pStrCodigoDG.Trim());
                lObjComandoDG.Parameters.AddWithValue("@IdExcluirDG", pIntIdExcluirDG);
                lObjConexionDG.Open();
                return (int)lObjComandoDG.ExecuteScalar() > 0;
            }
        }

        // Crea el artículo con stock 0 y, si hay stock inicial, lo registra como entrada del kardex.
        // Ambas cosas van en la misma transacción.
        public int FncInsertarArticuloDG(ArticuloDG pObjArticuloDG, decimal pDcmStockInicialDG)
        {
            const string lStrConsultaDG =
                "INSERT INTO dbo.ArticulosDG (CodigoDG, NombreDG, TipoDG, TallaDG, ColorDG, UnidadDG, StockDG, StockMinimoDG, StockMaximoDG, CostoUnitarioDG) " +
                "OUTPUT INSERTED.IdArticuloDG " +
                "VALUES (@CodigoDG, @NombreDG, @TipoDG, @TallaDG, @ColorDG, @UnidadDG, 0, @StockMinimoDG, @StockMaximoDG, @CostoUnitarioDG)";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            {
                lObjConexionDG.Open();
                using (SqlTransaction lObjTransaccionDG = lObjConexionDG.BeginTransaction())
                {
                    try
                    {
                        int lIntIdArticuloDG;
                        using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG, lObjTransaccionDG))
                        {
                            SubAgregarParametrosDG(lObjComandoDG, pObjArticuloDG);
                            lIntIdArticuloDG = (int)lObjComandoDG.ExecuteScalar();
                        }

                        if (pDcmStockInicialDG > 0)
                        {
                            MovimientoInventarioDG lObjMovimientoDG = new MovimientoInventarioDG
                            {
                                gIntIdArticuloDG = lIntIdArticuloDG,
                                gStrTipoDG = MovimientoInventarioDG.TipoEntradaDG,
                                gDcmCantidadDG = pDcmStockInicialDG,
                                gStrMotivoDG = "Stock inicial"
                            };
                            new DatosMovimientoDG().SubRegistrarMovimientoDG(lObjMovimientoDG, lObjConexionDG, lObjTransaccionDG);
                        }

                        lObjTransaccionDG.Commit();
                        return lIntIdArticuloDG;
                    }
                    catch
                    {
                        lObjTransaccionDG.Rollback();
                        throw;
                    }
                }
            }
        }

        // Actualiza los datos del artículo. El stock no se edita aquí: solo cambia con movimientos.
        public void SubActualizarArticuloDG(ArticuloDG pObjArticuloDG)
        {
            const string lStrConsultaDG =
                "UPDATE dbo.ArticulosDG SET CodigoDG = @CodigoDG, NombreDG = @NombreDG, TipoDG = @TipoDG, TallaDG = @TallaDG, " +
                "ColorDG = @ColorDG, UnidadDG = @UnidadDG, StockMinimoDG = @StockMinimoDG, StockMaximoDG = @StockMaximoDG, " +
                "CostoUnitarioDG = @CostoUnitarioDG WHERE IdArticuloDG = @IdArticuloDG";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                SubAgregarParametrosDG(lObjComandoDG, pObjArticuloDG);
                lObjComandoDG.Parameters.AddWithValue("@IdArticuloDG", pObjArticuloDG.gIntIdArticuloDG);
                lObjConexionDG.Open();
                lObjComandoDG.ExecuteNonQuery();
            }
        }

        // No se borra: se desactiva para conservar el kardex y los pedidos históricos
        public void SubDesactivarArticuloDG(int pIntIdArticuloDG)
        {
            const string lStrConsultaDG = "UPDATE dbo.ArticulosDG SET ActivoDG = 0 WHERE IdArticuloDG = @IdArticuloDG";
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@IdArticuloDG", pIntIdArticuloDG);
                lObjConexionDG.Open();
                lObjComandoDG.ExecuteNonQuery();
            }
        }

        private static void SubAgregarParametrosDG(SqlCommand pObjComandoDG, ArticuloDG pObjArticuloDG)
        {
            pObjComandoDG.Parameters.AddWithValue("@CodigoDG", pObjArticuloDG.gStrCodigoDG.Trim().ToUpperInvariant());
            pObjComandoDG.Parameters.AddWithValue("@NombreDG", pObjArticuloDG.gStrNombreDG.Trim());
            pObjComandoDG.Parameters.AddWithValue("@TipoDG", pObjArticuloDG.gStrTipoDG);
            pObjComandoDG.Parameters.AddWithValue("@TallaDG", ConexionDG.FncTextoONuloDG(pObjArticuloDG.gStrTallaDG));
            pObjComandoDG.Parameters.AddWithValue("@ColorDG", ConexionDG.FncTextoONuloDG(pObjArticuloDG.gStrColorDG));
            pObjComandoDG.Parameters.AddWithValue("@UnidadDG", pObjArticuloDG.gStrUnidadDG.Trim());
            pObjComandoDG.Parameters.AddWithValue("@StockMinimoDG", pObjArticuloDG.gDcmStockMinimoDG);
            pObjComandoDG.Parameters.AddWithValue("@StockMaximoDG", pObjArticuloDG.gDcmStockMaximoDG);
            pObjComandoDG.Parameters.AddWithValue("@CostoUnitarioDG", pObjArticuloDG.gDcmCostoUnitarioDG);
        }

        private static ArticuloDG FncLeerArticuloDG(SqlDataReader pObjLectorDG)
        {
            return new ArticuloDG
            {
                gIntIdArticuloDG = pObjLectorDG.GetInt32(0),
                gStrCodigoDG = pObjLectorDG.GetString(1),
                gStrNombreDG = pObjLectorDG.GetString(2),
                gStrTipoDG = pObjLectorDG.GetString(3),
                gStrTallaDG = pObjLectorDG.IsDBNull(4) ? string.Empty : pObjLectorDG.GetString(4),
                gStrColorDG = pObjLectorDG.IsDBNull(5) ? string.Empty : pObjLectorDG.GetString(5),
                gStrUnidadDG = pObjLectorDG.GetString(6),
                gDcmStockDG = pObjLectorDG.GetDecimal(7),
                gDcmStockMinimoDG = pObjLectorDG.GetDecimal(8),
                gDcmStockMaximoDG = pObjLectorDG.GetDecimal(9),
                gDcmCostoUnitarioDG = pObjLectorDG.GetDecimal(10),
                gBlnActivoDG = pObjLectorDG.GetBoolean(11)
            };
        }
    }
}
