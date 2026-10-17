using System;
using System.Collections.Generic;
using CapaEntidadesDG;
using Microsoft.Data.SqlClient;

namespace CapaDatosDG
{
    // Acceso a MovimientosInventarioDG (kardex) y actualización del stock
    public class DatosMovimientoDG
    {
        // Registra un movimiento en su propia transacción: o se guarda todo, o nada
        public void SubRegistrarMovimientoDG(MovimientoInventarioDG pObjMovimientoDG)
        {
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            {
                lObjConexionDG.Open();
                using (SqlTransaction lObjTransaccionDG = lObjConexionDG.BeginTransaction())
                {
                    try
                    {
                        SubRegistrarMovimientoDG(pObjMovimientoDG, lObjConexionDG, lObjTransaccionDG);
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

        // Versión que participa en una transacción abierta por otra operación
        // (por ejemplo, al pasar un pedido a En producción se descuentan varias prendas juntas)
        public void SubRegistrarMovimientoDG(MovimientoInventarioDG pObjMovimientoDG, SqlConnection pObjConexionDG, SqlTransaction pObjTransaccionDG)
        {
            // La condición del WHERE impide dejar stock negativo, incluso si dos usuarios registran a la vez
            const string lStrActualizarDG =
                "UPDATE dbo.ArticulosDG SET StockDG = StockDG + @VariacionDG " +
                "WHERE IdArticuloDG = @IdArticuloDG AND ActivoDG = 1 AND StockDG + @VariacionDG >= 0";
            const string lStrInsertarDG =
                "INSERT INTO dbo.MovimientosInventarioDG (IdArticuloDG, TipoDG, CantidadDG, MotivoDG, IdPedidoDG) " +
                "OUTPUT INSERTED.IdMovimientoDG, INSERTED.FechaDG " +
                "VALUES (@IdArticuloDG, @TipoDG, @CantidadDG, @MotivoDG, @IdPedidoDG)";

            using (SqlCommand lObjComandoDG = new SqlCommand(lStrActualizarDG, pObjConexionDG, pObjTransaccionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@VariacionDG", pObjMovimientoDG.gDcmVariacionStockDG);
                lObjComandoDG.Parameters.AddWithValue("@IdArticuloDG", pObjMovimientoDG.gIntIdArticuloDG);
                if (lObjComandoDG.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException("No hay stock suficiente para registrar el movimiento.");
            }

            using (SqlCommand lObjComandoDG = new SqlCommand(lStrInsertarDG, pObjConexionDG, pObjTransaccionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@IdArticuloDG", pObjMovimientoDG.gIntIdArticuloDG);
                lObjComandoDG.Parameters.AddWithValue("@TipoDG", pObjMovimientoDG.gStrTipoDG);
                lObjComandoDG.Parameters.AddWithValue("@CantidadDG", pObjMovimientoDG.gDcmCantidadDG);
                lObjComandoDG.Parameters.AddWithValue("@MotivoDG", pObjMovimientoDG.gStrMotivoDG.Trim());
                lObjComandoDG.Parameters.AddWithValue("@IdPedidoDG", (object)pObjMovimientoDG.gIntIdPedidoDG ?? DBNull.Value);
                using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                {
                    lObjLectorDG.Read();
                    pObjMovimientoDG.gIntIdMovimientoDG = lObjLectorDG.GetInt32(0);
                    pObjMovimientoDG.gDtmFechaDG = lObjLectorDG.GetDateTime(1);
                }
            }
        }

        // Kardex de un artículo en orden cronológico, con el saldo después de cada movimiento
        public List<MovimientoInventarioDG> FncListarKardexDG(int pIntIdArticuloDG)
        {
            const string lStrConsultaDG =
                "SELECT m.IdMovimientoDG, m.TipoDG, m.CantidadDG, m.MotivoDG, m.IdPedidoDG, m.FechaDG, p.CodigoDG, " +
                "       SUM(CASE WHEN m.TipoDG = N'Salida' THEN -m.CantidadDG ELSE m.CantidadDG END) " +
                "       OVER (ORDER BY m.FechaDG, m.IdMovimientoDG ROWS UNBOUNDED PRECEDING) AS SaldoDG " +
                "FROM dbo.MovimientosInventarioDG m " +
                "LEFT JOIN dbo.PedidosDG p ON p.IdPedidoDG = m.IdPedidoDG " +
                "WHERE m.IdArticuloDG = @IdArticuloDG " +
                "ORDER BY m.FechaDG, m.IdMovimientoDG";

            List<MovimientoInventarioDG> lLstMovimientosDG = new List<MovimientoInventarioDG>();
            using (SqlConnection lObjConexionDG = ConexionDG.FncCrearConexionDG())
            using (SqlCommand lObjComandoDG = new SqlCommand(lStrConsultaDG, lObjConexionDG))
            {
                lObjComandoDG.Parameters.AddWithValue("@IdArticuloDG", pIntIdArticuloDG);
                lObjConexionDG.Open();
                using (SqlDataReader lObjLectorDG = lObjComandoDG.ExecuteReader())
                {
                    while (lObjLectorDG.Read())
                    {
                        lLstMovimientosDG.Add(new MovimientoInventarioDG
                        {
                            gIntIdMovimientoDG = lObjLectorDG.GetInt32(0),
                            gIntIdArticuloDG = pIntIdArticuloDG,
                            gStrTipoDG = lObjLectorDG.GetString(1),
                            gDcmCantidadDG = lObjLectorDG.GetDecimal(2),
                            gStrMotivoDG = lObjLectorDG.GetString(3),
                            gIntIdPedidoDG = lObjLectorDG.IsDBNull(4) ? (int?)null : lObjLectorDG.GetInt32(4),
                            gDtmFechaDG = lObjLectorDG.GetDateTime(5),
                            gStrCodigoPedidoDG = lObjLectorDG.IsDBNull(6) ? string.Empty : lObjLectorDG.GetString(6),
                            gDcmSaldoDG = lObjLectorDG.GetDecimal(7)
                        });
                    }
                }
            }
            return lLstMovimientosDG;
        }
    }
}
