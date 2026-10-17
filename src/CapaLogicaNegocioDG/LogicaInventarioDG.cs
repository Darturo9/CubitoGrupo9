using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatosDG;
using CapaEntidadesDG;

namespace CapaLogicaNegocioDG
{
    // Reglas del inventario: artículos, movimientos (kardex) y alertas de reorden
    public class LogicaInventarioDG
    {
        public static readonly string[] gArrUnidadesDG = { "Unidad", "ml", "g", "Hoja", "Metro" };

        private readonly DatosArticuloDG gObjDatosArticuloDG = new DatosArticuloDG();
        private readonly DatosMovimientoDG gObjDatosMovimientoDG = new DatosMovimientoDG();

        public List<ArticuloDG> FncListarArticulosDG(string pStrFiltroDG, bool pBlnSoloAlertasDG)
        {
            return gObjDatosArticuloDG.FncListarArticulosDG(pStrFiltroDG, pBlnSoloAlertasDG);
        }

        public ArticuloDG FncBuscarArticuloDG(int pIntIdArticuloDG)
        {
            return gObjDatosArticuloDG.FncBuscarPorIdDG(pIntIdArticuloDG);
        }

        public List<MovimientoInventarioDG> FncObtenerKardexDG(int pIntIdArticuloDG)
        {
            return gObjDatosMovimientoDG.FncListarKardexDG(pIntIdArticuloDG);
        }

        // ---------------- Artículos ----------------

        public bool FncValidarArticuloDG(ArticuloDG pObjArticuloDG, decimal pDcmStockInicialDG, out string pStrMensajeDG)
        {
            pStrMensajeDG = string.Empty;
            if (pObjArticuloDG == null) { pStrMensajeDG = "No se recibió información del artículo."; return false; }

            string lStrCodigoDG = (pObjArticuloDG.gStrCodigoDG ?? string.Empty).Trim();
            if (lStrCodigoDG.Length == 0) { pStrMensajeDG = "Ingrese el código del artículo."; return false; }
            if (lStrCodigoDG.Length > 20) { pStrMensajeDG = "El código no puede tener más de 20 caracteres."; return false; }
            if (lStrCodigoDG.Contains(" ")) { pStrMensajeDG = "El código no puede tener espacios. Use guiones, por ejemplo PLA-BL-M."; return false; }
            if (string.IsNullOrWhiteSpace(pObjArticuloDG.gStrNombreDG)) { pStrMensajeDG = "Ingrese el nombre del artículo."; return false; }
            if (pObjArticuloDG.gStrNombreDG.Trim().Length > 100) { pStrMensajeDG = "El nombre no puede tener más de 100 caracteres."; return false; }
            if (pObjArticuloDG.gStrTipoDG != ArticuloDG.TipoPrendaDG && pObjArticuloDG.gStrTipoDG != ArticuloDG.TipoInsumoDG)
            { pStrMensajeDG = "Seleccione si es prenda o insumo."; return false; }
            if (pObjArticuloDG.gStrTipoDG == ArticuloDG.TipoPrendaDG && string.IsNullOrWhiteSpace(pObjArticuloDG.gStrTallaDG))
            { pStrMensajeDG = "Las prendas deben tener talla."; return false; }
            if (string.IsNullOrWhiteSpace(pObjArticuloDG.gStrUnidadDG)) { pStrMensajeDG = "Seleccione la unidad de medida."; return false; }
            if (pObjArticuloDG.gStrTipoDG == ArticuloDG.TipoPrendaDG && pObjArticuloDG.gStrUnidadDG != "Unidad")
            { pStrMensajeDG = "Las prendas se cuentan por unidad."; return false; }
            if (pObjArticuloDG.gDcmStockMinimoDG < 0) { pStrMensajeDG = "El stock mínimo no puede ser negativo."; return false; }
            if (pObjArticuloDG.gDcmStockMaximoDG < pObjArticuloDG.gDcmStockMinimoDG)
            { pStrMensajeDG = "El stock máximo debe ser mayor o igual al mínimo."; return false; }
            if (pObjArticuloDG.gDcmCostoUnitarioDG < 0) { pStrMensajeDG = "El costo no puede ser negativo."; return false; }
            if (pDcmStockInicialDG < 0) { pStrMensajeDG = "El stock inicial no puede ser negativo."; return false; }
            if (pObjArticuloDG.gBlnUsaCantidadEnteraDG &&
                (FncTieneDecimalesDG(pDcmStockInicialDG) || FncTieneDecimalesDG(pObjArticuloDG.gDcmStockMinimoDG) || FncTieneDecimalesDG(pObjArticuloDG.gDcmStockMaximoDG)))
            { pStrMensajeDG = "Este artículo se cuenta por unidades: use cantidades sin decimales."; return false; }
            if (gObjDatosArticuloDG.FncExisteCodigoDG(lStrCodigoDG, pObjArticuloDG.gIntIdArticuloDG))
            { pStrMensajeDG = "Ya existe un artículo con el código " + lStrCodigoDG.ToUpperInvariant() + "."; return false; }
            return true;
        }

        // Inserta si es nuevo (con su stock inicial) o actualiza si ya existe
        public bool FncGuardarArticuloDG(ArticuloDG pObjArticuloDG, decimal pDcmStockInicialDG, out string pStrMensajeDG)
        {
            if (pObjArticuloDG != null && pObjArticuloDG.gIntIdArticuloDG != 0) pDcmStockInicialDG = 0;
            if (!FncValidarArticuloDG(pObjArticuloDG, pDcmStockInicialDG, out pStrMensajeDG)) return false;

            if (pObjArticuloDG.gIntIdArticuloDG == 0)
                pObjArticuloDG.gIntIdArticuloDG = gObjDatosArticuloDG.FncInsertarArticuloDG(pObjArticuloDG, pDcmStockInicialDG);
            else
                gObjDatosArticuloDG.SubActualizarArticuloDG(pObjArticuloDG);

            pStrMensajeDG = "Artículo guardado correctamente.";
            return true;
        }

        public void SubDesactivarArticuloDG(int pIntIdArticuloDG)
        {
            gObjDatosArticuloDG.SubDesactivarArticuloDG(pIntIdArticuloDG);
        }

        // ---------------- Movimientos ----------------

        public bool FncRegistrarMovimientoDG(MovimientoInventarioDG pObjMovimientoDG, out string pStrMensajeDG)
        {
            pStrMensajeDG = string.Empty;
            if (pObjMovimientoDG == null) { pStrMensajeDG = "No se recibió información del movimiento."; return false; }

            ArticuloDG lObjArticuloDG = gObjDatosArticuloDG.FncBuscarPorIdDG(pObjMovimientoDG.gIntIdArticuloDG);
            if (lObjArticuloDG == null || !lObjArticuloDG.gBlnActivoDG) { pStrMensajeDG = "El artículo no existe o está desactivado."; return false; }

            string lStrTipoDG = pObjMovimientoDG.gStrTipoDG;
            if (lStrTipoDG != MovimientoInventarioDG.TipoEntradaDG && lStrTipoDG != MovimientoInventarioDG.TipoSalidaDG && lStrTipoDG != MovimientoInventarioDG.TipoAjusteDG)
            { pStrMensajeDG = "Seleccione el tipo de movimiento."; return false; }
            if (lStrTipoDG == MovimientoInventarioDG.TipoAjusteDG && pObjMovimientoDG.gDcmCantidadDG == 0)
            { pStrMensajeDG = "El ajuste no puede ser cero."; return false; }
            if (lStrTipoDG != MovimientoInventarioDG.TipoAjusteDG && pObjMovimientoDG.gDcmCantidadDG <= 0)
            { pStrMensajeDG = "La cantidad debe ser mayor que cero."; return false; }
            if (lObjArticuloDG.gBlnUsaCantidadEnteraDG && FncTieneDecimalesDG(pObjMovimientoDG.gDcmCantidadDG))
            { pStrMensajeDG = "Este artículo se cuenta por unidades: use cantidades sin decimales."; return false; }
            if (string.IsNullOrWhiteSpace(pObjMovimientoDG.gStrMotivoDG)) { pStrMensajeDG = "Ingrese el motivo del movimiento."; return false; }
            if (pObjMovimientoDG.gStrMotivoDG.Trim().Length > 200) { pStrMensajeDG = "El motivo no puede tener más de 200 caracteres."; return false; }

            decimal lDcmStockFinalDG = lObjArticuloDG.gDcmStockDG + pObjMovimientoDG.gDcmVariacionStockDG;
            if (lDcmStockFinalDG < 0)
            {
                pStrMensajeDG = "No hay stock suficiente. Disponible: " + lObjArticuloDG.gDcmStockDG.ToString("0.##") + " " + lObjArticuloDG.gStrUnidadDG + ".";
                return false;
            }

            try
            {
                gObjDatosMovimientoDG.SubRegistrarMovimientoDG(pObjMovimientoDG);
            }
            catch (InvalidOperationException lObjErrorDG)
            {
                // Otro usuario pudo registrar una salida al mismo tiempo; la base de datos lo impidió
                pStrMensajeDG = lObjErrorDG.Message;
                return false;
            }

            pStrMensajeDG = "Movimiento registrado. Stock actual: " + lDcmStockFinalDG.ToString("0.##") + " " + lObjArticuloDG.gStrUnidadDG + ".";
            if (lDcmStockFinalDG <= lObjArticuloDG.gDcmStockMinimoDG)
                pStrMensajeDG += " Atención: el artículo quedó en alerta de reorden.";
            return true;
        }

        // ---------------- Alertas ----------------

        public int FncContarAlertasDG(IEnumerable<ArticuloDG> pLstArticulosDG)
        {
            return pLstArticulosDG.Count(lObjArticuloDG => lObjArticuloDG.gBlnRequiereReordenDG);
        }

        private static bool FncTieneDecimalesDG(decimal pDcmValorDG)
        {
            return decimal.Truncate(pDcmValorDG) != pDcmValorDG;
        }
    }
}
