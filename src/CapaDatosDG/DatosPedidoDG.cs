using System;
using System.Collections.Generic;
using CapaEntidadesDG;
using Microsoft.Data.SqlClient;

namespace CapaDatosDG
{
    // Acceso a PedidosDG y DetallePedidosDG
    public class DatosPedidoDG
    {
        private const string gStrConsultaPedidosDG =
            "SELECT p.IdPedidoDG, p.CodigoDG, p.IdClienteDG, c.NombreDG, p.EstadoDG, p.FechaPedidoDG, p.FechaEntregaDG, " +
            "       p.TotalDG, ISNULL(pg.PagadoDG, 0), p.OrigenDG, p.ObservacionesDG, p.MotivoCancelacionDG " +
            "FROM dbo.PedidosDG p " +
            "JOIN dbo.ClientesDG c ON c.IdClienteDG = p.IdClienteDG " +
            "OUTER APPLY (SELECT SUM(MontoDG) AS PagadoDG FROM dbo.PagosDG WHERE IdPedidoDG = p.IdPedidoDG) pg ";

        // Lista pedidos; el filtro busca por código o nombre del cliente y el estado vacío significa todos
        public List<PedidoDG> FncListarPedidosDG(string pStrFiltroDG, string pStrEstadoDG)
        {
            string lStrConsultaDG = gStrConsultaPedidosDG +
                "WHERE (@FiltroDG = '' OR p.CodigoDG LIKE '%' + @FiltroDG + '%' OR c.NombreDG LIKE '%' + @FiltroDG + '%') " +
                "AND (@EstadoDG = '' OR p.EstadoDG = @EstadoDG) " +
                "ORDER BY p.IdPedidoDG DESC";

            List<PedidoDG> lLstPedidosDG = new List<PedidoDG>();
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@FiltroDG", (pStrFiltroDG ?? string.Empty).Trim());
                lObjComandoDG.Parameters.AddWithValue("@EstadoDG", pStrEstadoDG ?? string.Empty);
                lObjConexionDG.Open();
                using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                {
                    while (lObjLectorDG.Read()) lLstPedidosDG.Add(FncLeerPedidoDG(lObjLectorDG));
                }
            }
            return lLstPedidosDG;
        }

        // Pedido completo con sus líneas; null si no existe
        public PedidoDG FncBuscarPedidoDG(int pIntIdPedidoDG)
        {
            const string lStrDetalleDG =
                "SELECT d.IdDetalleDG, d.TecnicaDG, d.IdArticuloDG, d.DescripcionDG, d.CantidadDG, d.PrecioUnitarioDG, " +
                "       a.NombreDG, a.TallaDG, a.ColorDG " +
                "FROM dbo.DetallePedidosDG d LEFT JOIN dbo.ArticulosDG a ON a.IdArticuloDG = d.IdArticuloDG " +
                "WHERE d.IdPedidoDG = @IdPedidoDG ORDER BY d.IdDetalleDG";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            {
                lObjConexionDG.Open();
                PedidoDG lObjPedidoDG;
                using (SqlCommand lObjComandoDG = new SqlCommand(gStrConsultaPedidosDG + "WHERE p.IdPedidoDG = @IdPedidoDG", lObjConexionDG))
                {
                    lObjComandoDG.Parameters.AddWithValue("@IdPedidoDG", pIntIdPedidoDG);
                    using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                    {
                        if (!lObjLectorDG.Read()) return null;
                        lObjPedidoDG = FncLeerPedidoDG(lObjLectorDG);
                    }
                }

                using (SqlCommand lObjComandoDG = new SqlCommand(lStrDetalleDG, lObjConexionDG))
                {
                    lObjComandoDG.Parameters.AddWithValue("@IdPedidoDG", pIntIdPedidoDG);
                    using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                    {
                        while (lObjLectorDG.Read())
                        {
                            DetallePedidoDG lObjDetalleDG = new DetallePedidoDG
                            {
                                gIntIdDetalleDG = lObjLectorDG.GetInt32(0),
                                gIntIdPedidoDG = pIntIdPedidoDG,
                                gStrTecnicaDG = lObjLectorDG.GetString(1),
                                gIntIdArticuloDG = lObjLectorDG.IsDBNull(2) ? (int?)null : lObjLectorDG.GetInt32(2),
                                gStrDescripcionDG = lObjLectorDG.GetString(3),
                                gIntCantidadDG = lObjLectorDG.GetInt32(4),
                                gDcmPrecioUnitarioDG = lObjLectorDG.GetDecimal(5)
                            };
                            lObjDetalleDG.gStrPrendaDG = lObjLectorDG.IsDBNull(6)
                                ? "Prenda del cliente"
                                : FncDescribirPrendaDG(lObjLectorDG.GetString(6),
                                    lObjLectorDG.IsDBNull(7) ? string.Empty : lObjLectorDG.GetString(7),
                                    lObjLectorDG.IsDBNull(8) ? string.Empty : lObjLectorDG.GetString(8));
                            lObjPedidoDG.gLstDetallesDG.Add(lObjDetalleDG);
                        }
                    }
                }
                return lObjPedidoDG;
            }
        }

        // Crea el pedido con sus líneas en una transacción; devuelve el Id y llena el código generado
        public int FncInsertarPedidoDG(PedidoDG pObjPedidoDG)
        {
            const string lStrConsultaDG =
                "INSERT INTO dbo.PedidosDG (IdClienteDG, FechaEntregaDG, OrigenDG, ObservacionesDG) " +
                "OUTPUT INSERTED.IdPedidoDG, INSERTED.CodigoDG, INSERTED.EstadoDG, INSERTED.FechaPedidoDG " +
                "VALUES (@IdClienteDG, @FechaEntregaDG, @OrigenDG, @ObservacionesDG)";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            {
                lObjConexionDG.Open();
                using (SqlTransaction lObjTransaccionDG = lObjConexionDG.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG, lObjTransaccionDG))
                        {
                            lObjComandoDG.Parameters.AddWithValue("@IdClienteDG", pObjPedidoDG.gIntIdClienteDG);
                            lObjComandoDG.Parameters.AddWithValue("@FechaEntregaDG", (object)pObjPedidoDG.gDtmFechaEntregaDG?.Date ?? DBNull.Value);
                            lObjComandoDG.Parameters.AddWithValue("@OrigenDG", pObjPedidoDG.gStrOrigenDG);
                            lObjComandoDG.Parameters.AddWithValue("@ObservacionesDG", ConexionDG.FncTextoONuloDG(pObjPedidoDG.gStrObservacionesDG));
                            using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                            {
                                lObjLectorDG.Read();
                                pObjPedidoDG.gIntIdPedidoDG = lObjLectorDG.GetInt32(0);
                                pObjPedidoDG.gStrCodigoDG = lObjLectorDG.GetString(1);
                                pObjPedidoDG.gStrEstadoDG = lObjLectorDG.GetString(2);
                                pObjPedidoDG.gDtmFechaPedidoDG = lObjLectorDG.GetDateTime(3);
                            }
                        }
                        SubGuardarLineasDG(pObjPedidoDG, lObjConexionDG, lObjTransaccionDG);
                        lObjTransaccionDG.Commit();
                        return pObjPedidoDG.gIntIdPedidoDG;
                    }
                    catch
                    {
                        lObjTransaccionDG.Rollback();
                        pObjPedidoDG.gIntIdPedidoDG = 0;
                        pObjPedidoDG.gStrCodigoDG = string.Empty;
                        throw;
                    }
                }
            }
        }

        // Actualiza cabecera y líneas. Solo funciona si el pedido sigue en Cotización o Aprobado.
        public void SubActualizarPedidoDG(PedidoDG pObjPedidoDG)
        {
            const string lStrConsultaDG =
                "UPDATE dbo.PedidosDG SET IdClienteDG = @IdClienteDG, FechaEntregaDG = @FechaEntregaDG, " +
                "ObservacionesDG = @ObservacionesDG, FechaActualizacionDG = SYSDATETIME() " +
                "WHERE IdPedidoDG = @IdPedidoDG AND EstadoDG IN (N'Cotización', N'Aprobado')";

            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            {
                lObjConexionDG.Open();
                using (SqlTransaction lObjTransaccionDG = lObjConexionDG.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG, lObjTransaccionDG))
                        {
                            lObjComandoDG.Parameters.AddWithValue("@IdPedidoDG", pObjPedidoDG.gIntIdPedidoDG);
                            lObjComandoDG.Parameters.AddWithValue("@IdClienteDG", pObjPedidoDG.gIntIdClienteDG);
                            lObjComandoDG.Parameters.AddWithValue("@FechaEntregaDG", (object)pObjPedidoDG.gDtmFechaEntregaDG?.Date ?? DBNull.Value);
                            lObjComandoDG.Parameters.AddWithValue("@ObservacionesDG", ConexionDG.FncTextoONuloDG(pObjPedidoDG.gStrObservacionesDG));
                            if (lObjComandoDG.ExecuteNonQuery() == 0)
                                throw new InvalidOperationException("El pedido ya no se puede modificar: alguien cambió su estado.");
                        }
                        using (SqlCommand lObjComandoDG = new SqlCommand("DELETE FROM dbo.DetallePedidosDG WHERE IdPedidoDG = @IdPedidoDG", lObjConexionDG, lObjTransaccionDG))
                        {
                            lObjComandoDG.Parameters.AddWithValue("@IdPedidoDG", pObjPedidoDG.gIntIdPedidoDG);
                            lObjComandoDG.ExecuteNonQuery();
                        }
                        SubGuardarLineasDG(pObjPedidoDG, lObjConexionDG, lObjTransaccionDG);
                        lObjTransaccionDG.Commit();
                    }
                    catch
                    {
                        lObjTransaccionDG.Rollback();
                        throw;
                    }
                }
            }
        }

        // Cambio de estado simple. Solo se aplica si el pedido sigue en el estado esperado.
        public void SubCambiarEstadoDG(int pIntIdPedidoDG, string pStrEstadoActualDG, string pStrEstadoNuevoDG, string pStrMotivoDG)
        {
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            {
                lObjConexionDG.Open();
                SubCambiarEstadoDG(pIntIdPedidoDG, pStrEstadoActualDG, pStrEstadoNuevoDG, pStrMotivoDG, lObjConexionDG, null);
            }
        }

        // Pasa el pedido a En producción y descuenta del inventario las prendas del taller.
        // Todo en una transacción: si falta stock de una sola prenda, no se descuenta nada.
        public void SubIniciarProduccionDG(PedidoDG pObjPedidoDG)
        {
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            {
                lObjConexionDG.Open();
                using (SqlTransaction lObjTransaccionDG = lObjConexionDG.BeginTransaction())
                {
                    try
                    {
                        SubCambiarEstadoDG(pObjPedidoDG.gIntIdPedidoDG, PedidoDG.EstadoAprobadoDG, PedidoDG.EstadoEnProduccionDG, null, lObjConexionDG, lObjTransaccionDG);

                        DatosMovimientoDG lObjDatosMovimientoDG = new DatosMovimientoDG();
                        foreach (DetallePedidoDG lObjDetalleDG in pObjPedidoDG.gLstDetallesDG)
                        {
                            if (lObjDetalleDG.gIntIdArticuloDG == null) continue;   // la prenda la trae el cliente
                            lObjDatosMovimientoDG.SubRegistrarMovimientoDG(new MovimientoInventarioDG
                            {
                                gIntIdArticuloDG = lObjDetalleDG.gIntIdArticuloDG.Value,
                                gStrTipoDG = MovimientoInventarioDG.TipoSalidaDG,
                                gDcmCantidadDG = lObjDetalleDG.gIntCantidadDG,
                                gStrMotivoDG = "Producción del pedido " + pObjPedidoDG.gStrCodigoDG,
                                gIntIdPedidoDG = pObjPedidoDG.gIntIdPedidoDG
                            }, lObjConexionDG, lObjTransaccionDG);
                        }
                        lObjTransaccionDG.Commit();
                    }
                    catch
                    {
                        lObjTransaccionDG.Rollback();
                        throw;
                    }
                }
            }
        }

        private static void SubCambiarEstadoDG(int pIntIdPedidoDG, string pStrEstadoActualDG, string pStrEstadoNuevoDG, string pStrMotivoDG,
            SqlConnection pObjConexionDG, SqlTransaction pObjTransaccionDG)
        {
            const string lStrConsultaDG =
                "UPDATE dbo.PedidosDG SET EstadoDG = @EstadoNuevoDG, FechaActualizacionDG = SYSDATETIME(), " +
                "MotivoCancelacionDG = CASE WHEN @EstadoNuevoDG = N'Cancelado' THEN @MotivoDG ELSE MotivoCancelacionDG END " +
                "WHERE IdPedidoDG = @IdPedidoDG AND EstadoDG = @EstadoActualDG";

            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, pObjConexionDG, pObjTransaccionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@IdPedidoDG", pIntIdPedidoDG);
                lObjComandoDG.Parameters.AddWithValue("@EstadoActualDG", pStrEstadoActualDG);
                lObjComandoDG.Parameters.AddWithValue("@EstadoNuevoDG", pStrEstadoNuevoDG);
                lObjComandoDG.Parameters.AddWithValue("@MotivoDG", ConexionDG.FncTextoONuloDG(pStrMotivoDG));
                if (lObjComandoDG.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException("El pedido cambió de estado mientras lo tenías abierto. Vuelve a abrirlo.");
            }
        }

        // Inserta las líneas y recalcula el total en SQL a partir de los subtotales
        private static void SubGuardarLineasDG(PedidoDG pObjPedidoDG, SqlConnection pObjConexionDG, SqlTransaction pObjTransaccionDG)
        {
            const string lStrLineaDG =
                "INSERT INTO dbo.DetallePedidosDG (IdPedidoDG, TecnicaDG, IdArticuloDG, DescripcionDG, CantidadDG, PrecioUnitarioDG) " +
                "OUTPUT INSERTED.IdDetalleDG " +
                "VALUES (@IdPedidoDG, @TecnicaDG, @IdArticuloDG, @DescripcionDG, @CantidadDG, @PrecioUnitarioDG)";
            const string lStrTotalDG =
                "UPDATE dbo.PedidosDG SET TotalDG = (SELECT ISNULL(SUM(SubtotalDG), 0) FROM dbo.DetallePedidosDG WHERE IdPedidoDG = @IdPedidoDG) " +
                "OUTPUT INSERTED.TotalDG WHERE IdPedidoDG = @IdPedidoDG";

            foreach (DetallePedidoDG lObjDetalleDG in pObjPedidoDG.gLstDetallesDG)
            {
                using (SqlCommand lObjComandoDG = new SqlCommand(lStrLineaDG, pObjConexionDG, pObjTransaccionDG))
                {
                    lObjComandoDG.Parameters.AddWithValue("@IdPedidoDG", pObjPedidoDG.gIntIdPedidoDG);
                    lObjComandoDG.Parameters.AddWithValue("@TecnicaDG", lObjDetalleDG.gStrTecnicaDG);
                    lObjComandoDG.Parameters.AddWithValue("@IdArticuloDG", (object)lObjDetalleDG.gIntIdArticuloDG ?? DBNull.Value);
                    lObjComandoDG.Parameters.AddWithValue("@DescripcionDG", lObjDetalleDG.gStrDescripcionDG.Trim());
                    lObjComandoDG.Parameters.AddWithValue("@CantidadDG", lObjDetalleDG.gIntCantidadDG);
                    lObjComandoDG.Parameters.AddWithValue("@PrecioUnitarioDG", lObjDetalleDG.gDcmPrecioUnitarioDG);
                    lObjDetalleDG.gIntIdDetalleDG = (int)lObjComandoDG.ExecuteScalar();
                    lObjDetalleDG.gIntIdPedidoDG = pObjPedidoDG.gIntIdPedidoDG;
                }
            }

            using (SqlCommand lObjComandoDG = new SqlCommand(lStrTotalDG, pObjConexionDG, pObjTransaccionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@IdPedidoDG", pObjPedidoDG.gIntIdPedidoDG);
                pObjPedidoDG.gDcmTotalDG = (decimal)lObjComandoDG.ExecuteScalar();
            }
        }

        public static string FncDescribirPrendaDG(string pStrNombreDG, string pStrTallaDG, string pStrColorDG)
        {
            string lStrTextoDG = pStrNombreDG;
            if (pStrTallaDG.Length > 0) lStrTextoDG += " " + pStrTallaDG;
            if (pStrColorDG.Length > 0) lStrTextoDG += " " + pStrColorDG;
            return lStrTextoDG;
        }

        private static PedidoDG FncLeerPedidoDG(SqlDataReader pObjLectorDG)
        {
            return new PedidoDG
            {
                gIntIdPedidoDG = pObjLectorDG.GetInt32(0),
                gStrCodigoDG = pObjLectorDG.GetString(1),
                gIntIdClienteDG = pObjLectorDG.GetInt32(2),
                gStrNombreClienteDG = pObjLectorDG.GetString(3),
                gStrEstadoDG = pObjLectorDG.GetString(4),
                gDtmFechaPedidoDG = pObjLectorDG.GetDateTime(5),
                gDtmFechaEntregaDG = pObjLectorDG.IsDBNull(6) ? (DateTime?)null : pObjLectorDG.GetDateTime(6),
                gDcmTotalDG = pObjLectorDG.GetDecimal(7),
                gDcmTotalPagadoDG = pObjLectorDG.GetDecimal(8),
                gStrOrigenDG = pObjLectorDG.GetString(9),
                gStrObservacionesDG = pObjLectorDG.IsDBNull(10) ? string.Empty : pObjLectorDG.GetString(10),
                gStrMotivoCancelacionDG = pObjLectorDG.IsDBNull(11) ? string.Empty : pObjLectorDG.GetString(11)
            };
        }
    }
}
