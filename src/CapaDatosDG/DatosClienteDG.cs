using System.Collections.Generic;
using CapaEntidadesDG;
using Microsoft.Data.SqlClient;

namespace CapaDatosDG
{
    // Acceso a la tabla ClientesDG.
    // Sirve de ejemplo para las demás clases de datos: siempre consultas parametrizadas.
    public class DatosClienteDG
    {
        // Lista los clientes activos; el filtro busca por nombre o teléfono
        public List<ClienteDG> FncListarClientesDG(string pStrFiltroDG)
        {
            const string lStrConsultaDG =
                "SELECT IdClienteDG, NombreDG, TelefonoDG, CorreoDG, FechaRegistroDG, ActivoDG " +
                "FROM dbo.ClientesDG " +
                "WHERE ActivoDG = 1 AND (@FiltroDG = '' OR NombreDG LIKE '%' + @FiltroDG + '%' OR TelefonoDG LIKE '%' + @FiltroDG + '%') " +
                "ORDER BY NombreDG";

            List<ClienteDG> lLstClientesDG = new List<ClienteDG>();
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@FiltroDG", (pStrFiltroDG ?? string.Empty).Trim());
                lObjConexionDG.Open();
                using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                {
                    while (lObjLectorDG.Read())
                    {
                        lLstClientesDG.Add(new ClienteDG
                        {
                            gIntIdClienteDG = lObjLectorDG.GetInt32(0),
                            gStrNombreDG = lObjLectorDG.GetString(1),
                            gStrTelefonoDG = lObjLectorDG.GetString(2),
                            gStrCorreoDG = lObjLectorDG.IsDBNull(3) ? string.Empty : lObjLectorDG.GetString(3),
                            gDtmFechaRegistroDG = lObjLectorDG.GetDateTime(4),
                            gBlnActivoDG = lObjLectorDG.GetBoolean(5)
                        });
                    }
                }
            }
            return lLstClientesDG;
        }

        // Inserta un cliente y devuelve el Id generado
        public int FncInsertarClienteDG(ClienteDG pObjClienteDG)
        {
            const string lStrConsultaDG =
                "INSERT INTO dbo.ClientesDG (NombreDG, TelefonoDG, CorreoDG) " +
                "OUTPUT INSERTED.IdClienteDG VALUES (@NombreDG, @TelefonoDG, @CorreoDG)";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@NombreDG", pObjClienteDG.gStrNombreDG.Trim());
                lObjComandoDG.Parameters.AddWithValue("@TelefonoDG", pObjClienteDG.gStrTelefonoDG.Trim());
                lObjComandoDG.Parameters.AddWithValue("@CorreoDG", ConexionDG.FncTextoONuloDG(pObjClienteDG.gStrCorreoDG));
                lObjConexionDG.Open();
                return (int)lObjComandoDG.ExecuteScalar();
            }
        }

        // Actualiza nombre, teléfono y correo de un cliente existente
        public void SubActualizarClienteDG(ClienteDG pObjClienteDG)
        {
            const string lStrConsultaDG =
                "UPDATE dbo.ClientesDG SET NombreDG = @NombreDG, TelefonoDG = @TelefonoDG, CorreoDG = @CorreoDG " +
                "WHERE IdClienteDG = @IdClienteDG";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@IdClienteDG", pObjClienteDG.gIntIdClienteDG);
                lObjComandoDG.Parameters.AddWithValue("@NombreDG", pObjClienteDG.gStrNombreDG.Trim());
                lObjComandoDG.Parameters.AddWithValue("@TelefonoDG", pObjClienteDG.gStrTelefonoDG.Trim());
                lObjComandoDG.Parameters.AddWithValue("@CorreoDG", ConexionDG.FncTextoONuloDG(pObjClienteDG.gStrCorreoDG));
                lObjConexionDG.Open();
                lObjComandoDG.ExecuteNonQuery();
            }
        }

        // Indica si otro cliente activo ya usa ese teléfono (idExcluir = el cliente que se está editando)
        public bool FncExisteTelefonoDG(string pStrTelefonoDG, int pIntIdExcluirDG)
        {
            const string lStrConsultaDG =
                "SELECT COUNT(*) FROM dbo.ClientesDG WHERE ActivoDG = 1 AND TelefonoDG = @TelefonoDG AND IdClienteDG <> @IdExcluirDG";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@TelefonoDG", (pStrTelefonoDG ?? string.Empty).Trim());
                lObjComandoDG.Parameters.AddWithValue("@IdExcluirDG", pIntIdExcluirDG);
                lObjConexionDG.Open();
                return (int)lObjComandoDG.ExecuteScalar() > 0;
            }
        }

        // Desactiva el cliente: deja de aparecer en las listas, pero su historial se conserva
        public void SubDesactivarClienteDG(int pIntIdClienteDG)
        {
            const string lStrConsultaDG = "UPDATE dbo.ClientesDG SET ActivoDG = 0 WHERE IdClienteDG = @IdClienteDG";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@IdClienteDG", pIntIdClienteDG);
                lObjConexionDG.Open();
                lObjComandoDG.ExecuteNonQuery();
            }
        }
    }
}
