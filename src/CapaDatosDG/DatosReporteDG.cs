using System;
using System.Collections.Generic;
using CapaEntidadesDG;
using Microsoft.Data.SqlClient;

namespace CapaDatosDG
{
    // Consultas de resumen para los reportes (solo lectura)
    public class DatosReporteDG
    {
        // Estados que cuentan como venta: el cliente ya aprobó el precio
        private const string gStrEstadosVentaDG = "(N'Aprobado', N'En producción', N'Listo', N'Entregado')";

        // Resumen entre @DesdeDG (incluido) y @HastaDG (excluido)
        public ResumenMesDG FncObtenerResumenDG(DateTime pDtmDesdeDG, DateTime pDtmHastaDG)
        {
            ResumenMesDG lObjResumenDG = new ResumenMesDG { gDtmMesDG = pDtmDesdeDG };
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            {
                lObjConexionDG.Open();

                using (SqlCommand lObjComandoDG = FncComandoDG(lObjConexionDG, pDtmDesdeDG, pDtmHastaDG,
                    "SELECT ISNULL(SUM(TotalDG), 0), COUNT(*) FROM dbo.PedidosDG " +
                    "WHERE EstadoDG IN " + gStrEstadosVentaDG + " AND FechaPedidoDG >= @DesdeDG AND FechaPedidoDG < @HastaDG"))
                using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                {
                    lObjLectorDG.Read();
                    lObjResumenDG.gDcmVentasDG = lObjLectorDG.GetDecimal(0);
                    lObjResumenDG.gIntPedidosDG = lObjLectorDG.GetInt32(1);
                }

                using (SqlCommand lObjComandoDG = FncComandoDG(lObjConexionDG, pDtmDesdeDG, pDtmHastaDG,
                    "SELECT ISNULL(SUM(MontoDG), 0) FROM dbo.PagosDG WHERE FechaDG >= @DesdeDG AND FechaDG < @HastaDG"))
                    lObjResumenDG.gDcmCobradoDG = (decimal)lObjComandoDG.ExecuteScalar();

                using (SqlCommand lObjComandoDG = FncComandoDG(lObjConexionDG, pDtmDesdeDG, pDtmHastaDG,
                    "SELECT ISNULL(SUM(MontoDG), 0) FROM dbo.GastosDG WHERE FechaDG >= @DesdeDG AND FechaDG < @HastaDG"))
                    lObjResumenDG.gDcmGastosDG = (decimal)lObjComandoDG.ExecuteScalar();

                lObjResumenDG.gLstTecnicasDG = FncLeerFilasDG(lObjConexionDG, pDtmDesdeDG, pDtmHastaDG,
                    "SELECT d.TecnicaDG, SUM(d.CantidadDG), SUM(d.SubtotalDG) FROM dbo.DetallePedidosDG d " +
                    "JOIN dbo.PedidosDG p ON p.IdPedidoDG = d.IdPedidoDG " +
                    "WHERE p.EstadoDG IN " + gStrEstadosVentaDG + " AND p.FechaPedidoDG >= @DesdeDG AND p.FechaPedidoDG < @HastaDG " +
                    "GROUP BY d.TecnicaDG ORDER BY SUM(d.SubtotalDG) DESC");

                lObjResumenDG.gLstClientesDG = FncLeerFilasDG(lObjConexionDG, pDtmDesdeDG, pDtmHastaDG,
                    "SELECT TOP 5 c.NombreDG, COUNT(*), SUM(p.TotalDG) FROM dbo.PedidosDG p " +
                    "JOIN dbo.ClientesDG c ON c.IdClienteDG = p.IdClienteDG " +
                    "WHERE p.EstadoDG IN " + gStrEstadosVentaDG + " AND p.FechaPedidoDG >= @DesdeDG AND p.FechaPedidoDG < @HastaDG " +
                    "GROUP BY c.IdClienteDG, c.NombreDG ORDER BY SUM(p.TotalDG) DESC");

                lObjResumenDG.gLstCategoriasDG = FncLeerFilasDG(lObjConexionDG, pDtmDesdeDG, pDtmHastaDG,
                    "SELECT CategoriaDG, COUNT(*), SUM(MontoDG) FROM dbo.GastosDG " +
                    "WHERE FechaDG >= @DesdeDG AND FechaDG < @HastaDG GROUP BY CategoriaDG ORDER BY SUM(MontoDG) DESC");
            }
            return lObjResumenDG;
        }

        private static SqlCommand FncComandoDG(SqlConnection pObjConexionDG, DateTime pDtmDesdeDG, DateTime pDtmHastaDG, string pStrConsultaDG)
        {
            SqlCommand lObjComandoDG = new SqlCommand(pStrConsultaDG, pObjConexionDG);
            lObjComandoDG.Parameters.AddWithValue("@DesdeDG", pDtmDesdeDG.Date);
            lObjComandoDG.Parameters.AddWithValue("@HastaDG", pDtmHastaDG.Date);
            return lObjComandoDG;
        }

        // Lee consultas de tres columnas: concepto, cantidad y monto
        private static List<FilaReporteDG> FncLeerFilasDG(SqlConnection pObjConexionDG, DateTime pDtmDesdeDG, DateTime pDtmHastaDG, string pStrConsultaDG)
        {
            List<FilaReporteDG> lLstFilasDG = new List<FilaReporteDG>();
            using (SqlCommand lObjComandoDG = FncComandoDG(pObjConexionDG, pDtmDesdeDG, pDtmHastaDG, pStrConsultaDG))
            using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
            {
                while (lObjLectorDG.Read())
                {
                    lLstFilasDG.Add(new FilaReporteDG
                    {
                        gStrConceptoDG = lObjLectorDG.GetString(0),
                        gIntCantidadDG = lObjLectorDG.GetInt32(1),
                        gDcmMontoDG = lObjLectorDG.GetDecimal(2)
                    });
                }
            }
            return lLstFilasDG;
        }
    }
}
