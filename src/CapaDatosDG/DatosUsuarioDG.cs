using CapaEntidadesDG;
using Microsoft.Data.SqlClient;

namespace CapaDatosDG
{
    // Acceso a la tabla UsuariosDG
    public class DatosUsuarioDG
    {
        // Busca un usuario activo por nombre; devuelve null si no existe
        public UsuarioDG FncBuscarUsuarioActivoDG(string pStrUsuarioDG)
        {
            const string lStrConsultaDG =
                "SELECT IdUsuarioDG, UsuarioDG, HashClaveDG, ActivoDG FROM dbo.UsuariosDG " +
                "WHERE UsuarioDG = @UsuarioDG AND ActivoDG = 1";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@UsuarioDG", pStrUsuarioDG);
                lObjConexionDG.Open();
                using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                {
                    if (!lObjLectorDG.Read()) return null;
                    return new UsuarioDG
                    {
                        gIntIdUsuarioDG = lObjLectorDG.GetInt32(0),
                        gStrUsuarioDG = lObjLectorDG.GetString(1),
                        gStrHashClaveDG = lObjLectorDG.GetString(2),
                        gBlnActivoDG = lObjLectorDG.GetBoolean(3)
                    };
                }
            }
        }
    }
}
