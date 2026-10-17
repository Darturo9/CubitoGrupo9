using System;
using System.Collections.Generic;
using CapaEntidadesDG;
using Microsoft.Data.SqlClient;

namespace CapaDatosDG
{
    // Acceso a PagosDG
    public class DatosPagoDG
    {
        // Pagos de un pedido, del más antiguo al más reciente
        public List<PagoDG> FncListarPagosDG(int pIntIdPedidoDG)
        {
            const string lStrConsultaDG =
                "SELECT IdPagoDG, IdPedidoDG, MontoDG, MetodoDG, FechaDG FROM dbo.PagosDG " +
                "WHERE IdPedidoDG = @IdPedidoDG ORDER BY FechaDG, IdPagoDG";

            List<PagoDG> lLstPagosDG = new List<PagoDG>();
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@IdPedidoDG", pIntIdPedidoDG);
                lObjConexionDG.Open();
                using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                {
                    while (lObjLectorDG.Read())
                    {
                        lLstPagosDG.Add(new PagoDG
                        {
                            gIntIdPagoDG = lObjLectorDG.GetInt32(0),
                            gIntIdPedidoDG = lObjLectorDG.GetInt32(1),
                            gDcmMontoDG = lObjLectorDG.GetDecimal(2),
                            gStrMetodoDG = lObjLectorDG.GetString(3),
                            gDtmFechaDG = lObjLectorDG.GetDateTime(4)
                        });
                    }
                }
            }
            return lLstPagosDG;
        }

        // Registra el pago solo si el pedido acepta pagos y el monto no supera el saldo.
        // La condición va en el mismo INSERT para que dos pagos al mismo tiempo no pasen del total.
        public int FncInsertarPagoDG(PagoDG pObjPagoDG)
        {
            const string lStrConsultaDG =
                "INSERT INTO dbo.PagosDG (IdPedidoDG, MontoDG, MetodoDG) " +
                "OUTPUT INSERTED.IdPagoDG, INSERTED.FechaDG " +
                "SELECT p.IdPedidoDG, @MontoDG, @MetodoDG FROM dbo.PedidosDG p WITH (UPDLOCK) " +
                "WHERE p.IdPedidoDG = @IdPedidoDG " +
                "AND p.EstadoDG IN (N'Aprobado', N'En producción', N'Listo') " +
                "AND p.TotalDG - (SELECT ISNULL(SUM(MontoDG), 0) FROM dbo.PagosDG WHERE IdPedidoDG = p.IdPedidoDG) >= @MontoDG";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@IdPedidoDG", pObjPagoDG.gIntIdPedidoDG);
                lObjComandoDG.Parameters.AddWithValue("@MontoDG", pObjPagoDG.gDcmMontoDG);
                lObjComandoDG.Parameters.AddWithValue("@MetodoDG", pObjPagoDG.gStrMetodoDG);
                lObjConexionDG.Open();
                using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                {
                    if (!lObjLectorDG.Read())
                        throw new InvalidOperationException("El pedido cambió mientras lo tenías abierto (estado o saldo). Vuelve a abrirlo.");
                    pObjPagoDG.gIntIdPagoDG = lObjLectorDG.GetInt32(0);
                    pObjPagoDG.gDtmFechaDG = lObjLectorDG.GetDateTime(1);
                }
            }
            return pObjPagoDG.gIntIdPagoDG;
        }

        // Borra un pago registrado por error; no se permite si el pedido ya se entregó o canceló
        public void SubEliminarPagoDG(int pIntIdPagoDG)
        {
            const string lStrConsultaDG =
                "DELETE pg FROM dbo.PagosDG pg JOIN dbo.PedidosDG p ON p.IdPedidoDG = pg.IdPedidoDG " +
                "WHERE pg.IdPagoDG = @IdPagoDG AND p.EstadoDG IN (N'Aprobado', N'En producción', N'Listo')";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@IdPagoDG", pIntIdPagoDG);
                lObjConexionDG.Open();
                if (lObjComandoDG.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException("El pago ya no se puede eliminar: el pedido cambió de estado o el pago ya no existe.");
            }
        }

        // Suma de los pagos recibidos en un día
        public decimal FncTotalCobradoDG(DateTime pDtmFechaDG)
        {
            const string lStrConsultaDG =
                "SELECT ISNULL(SUM(MontoDG), 0) FROM dbo.PagosDG WHERE FechaDG >= @DesdeDG AND FechaDG < @HastaDG";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@DesdeDG", pDtmFechaDG.Date);
                lObjComandoDG.Parameters.AddWithValue("@HastaDG", pDtmFechaDG.Date.AddDays(1));
                lObjConexionDG.Open();
                return (decimal)lObjComandoDG.ExecuteScalar();
            }
        }
    }
}
