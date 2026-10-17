using System;
using Microsoft.Data.SqlClient;

namespace CapaDatosDG
{
    // Punto único para obtener conexiones a SQL Server Express.
    // El escritorio y el portal asignan la cadena al iniciar.
    public static class ConexionDG
    {
        public static string gStrCadenaConexionDG { get; set; }

        public static SqlConnection FncCrearConexionDG()
        {
            if (string.IsNullOrWhiteSpace(gStrCadenaConexionDG))
                throw new InvalidOperationException("No se configuró la cadena de conexión a la base de datos.");
            return new SqlConnection(gStrCadenaConexionDG);
        }

        // Convierte un valor de texto vacío en NULL para SQL
        public static object FncTextoONuloDG(string pStrValorDG)
        {
            if (string.IsNullOrWhiteSpace(pStrValorDG)) return DBNull.Value;
            return pStrValorDG.Trim();
        }
    }
}
