using System;
using System.Collections.Generic;
using CapaEntidadesDG;
using Microsoft.Data.SqlClient;

namespace CapaDatosDG
{
    // Acceso a GastosDG
    public class DatosGastoDG
    {
        // Gastos entre dos fechas (incluidas); la categoría vacía significa todas
        public List<GastoDG> FncListarGastosDG(DateTime pDtmDesdeDG, DateTime pDtmHastaDG, string pStrCategoriaDG)
        {
            const string lStrConsultaDG =
                "SELECT IdGastoDG, CategoriaDG, DescripcionDG, MontoDG, FechaDG FROM dbo.GastosDG " +
                "WHERE FechaDG BETWEEN @DesdeDG AND @HastaDG AND (@CategoriaDG = '' OR CategoriaDG = @CategoriaDG) " +
                "ORDER BY FechaDG DESC, IdGastoDG DESC";

            List<GastoDG> lLstGastosDG = new List<GastoDG>();
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@DesdeDG", pDtmDesdeDG.Date);
                lObjComandoDG.Parameters.AddWithValue("@HastaDG", pDtmHastaDG.Date);
                lObjComandoDG.Parameters.AddWithValue("@CategoriaDG", pStrCategoriaDG ?? string.Empty);
                lObjConexionDG.Open();
                using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                {
                    while (lObjLectorDG.Read())
                    {
                        lLstGastosDG.Add(new GastoDG
                        {
                            gIntIdGastoDG = lObjLectorDG.GetInt32(0),
                            gStrCategoriaDG = lObjLectorDG.GetString(1),
                            gStrDescripcionDG = lObjLectorDG.IsDBNull(2) ? string.Empty : lObjLectorDG.GetString(2),
                            gDcmMontoDG = lObjLectorDG.GetDecimal(3),
                            gDtmFechaDG = lObjLectorDG.GetDateTime(4)
                        });
                    }
                }
            }
            return lLstGastosDG;
        }

        public int FncInsertarGastoDG(GastoDG pObjGastoDG)
        {
            const string lStrConsultaDG =
                "INSERT INTO dbo.GastosDG (CategoriaDG, DescripcionDG, MontoDG, FechaDG) " +
                "OUTPUT INSERTED.IdGastoDG VALUES (@CategoriaDG, @DescripcionDG, @MontoDG, @FechaDG)";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                SubAgregarParametrosDG(lObjComandoDG, pObjGastoDG);
                lObjConexionDG.Open();
                pObjGastoDG.gIntIdGastoDG = (int)lObjComandoDG.ExecuteScalar();
                return pObjGastoDG.gIntIdGastoDG;
            }
        }

        public void SubActualizarGastoDG(GastoDG pObjGastoDG)
        {
            const string lStrConsultaDG =
                "UPDATE dbo.GastosDG SET CategoriaDG = @CategoriaDG, DescripcionDG = @DescripcionDG, MontoDG = @MontoDG, FechaDG = @FechaDG " +
                "WHERE IdGastoDG = @IdGastoDG";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                SubAgregarParametrosDG(lObjComandoDG, pObjGastoDG);
                lObjComandoDG.Parameters.AddWithValue("@IdGastoDG", pObjGastoDG.gIntIdGastoDG);
                lObjConexionDG.Open();
                if (lObjComandoDG.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException("El gasto ya no existe.");
            }
        }

        public void SubEliminarGastoDG(int pIntIdGastoDG)
        {
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand("DELETE FROM dbo.GastosDG WHERE IdGastoDG = @IdGastoDG", lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@IdGastoDG", pIntIdGastoDG);
                lObjConexionDG.Open();
                if (lObjComandoDG.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException("El gasto ya no existe.");
            }
        }

        private static void SubAgregarParametrosDG(SqlCommand pObjComandoDG, GastoDG pObjGastoDG)
        {
            pObjComandoDG.Parameters.AddWithValue("@CategoriaDG", pObjGastoDG.gStrCategoriaDG);
            pObjComandoDG.Parameters.AddWithValue("@DescripcionDG", ConexionDG.FncTextoONuloDG(pObjGastoDG.gStrDescripcionDG));
            pObjComandoDG.Parameters.AddWithValue("@MontoDG", pObjGastoDG.gDcmMontoDG);
            pObjComandoDG.Parameters.AddWithValue("@FechaDG", pObjGastoDG.gDtmFechaDG.Date);
        }
    }
}
