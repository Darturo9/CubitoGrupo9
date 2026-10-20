using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatosDG;
using CapaEntidadesDG;

namespace CapaLogicaNegocioDG
{
    // Reglas de los gastos del taller
    public class LogicaGastoDG
    {
        public static readonly string[] gArrCategoriasDG =
        {
            "Insumos y materiales", "Prendas", "Servicios básicos", "Alquiler", "Transporte", "Mantenimiento", "Otros"
        };

        private readonly DatosGastoDG gObjDatosGastoDG = new DatosGastoDG();

        // Gastos de un mes; la categoría vacía significa todas
        public List<GastoDG> FncListarGastosMesDG(int pIntAnioDG, int pIntMesDG, string pStrCategoriaDG)
        {
            DateTime lDtmDesdeDG = new DateTime(pIntAnioDG, pIntMesDG, 1);
            return gObjDatosGastoDG.FncListarGastosDG(lDtmDesdeDG, lDtmDesdeDG.AddMonths(1).AddDays(-1), pStrCategoriaDG);
        }

        // Categoría en la que más se gastó; vacío si no hay gastos
        public string FncCategoriaPrincipalDG(IEnumerable<GastoDG> pLstGastosDG)
        {
            return pLstGastosDG
                .GroupBy(lObjGastoDG => lObjGastoDG.gStrCategoriaDG)
                .OrderByDescending(lObjGrupoDG => lObjGrupoDG.Sum(lObjGastoDG => lObjGastoDG.gDcmMontoDG))
                .Select(lObjGrupoDG => lObjGrupoDG.Key)
                .FirstOrDefault() ?? string.Empty;
        }

        public bool FncValidarGastoDG(GastoDG pObjGastoDG, out string pStrMensajeDG)
        {
            pStrMensajeDG = string.Empty;
            if (pObjGastoDG == null) { pStrMensajeDG = "No se recibió información del gasto."; return false; }
            if (!gArrCategoriasDG.Contains(pObjGastoDG.gStrCategoriaDG)) { pStrMensajeDG = "Seleccione la categoría."; return false; }
            if (pObjGastoDG.gDcmMontoDG <= 0) { pStrMensajeDG = "El monto debe ser mayor a cero."; return false; }
            if (pObjGastoDG.gDcmMontoDG > 1000000) { pStrMensajeDG = "El monto no puede ser mayor a Q1,000,000.00."; return false; }
            if (decimal.Round(pObjGastoDG.gDcmMontoDG, 2) != pObjGastoDG.gDcmMontoDG) { pStrMensajeDG = "El monto solo puede tener dos decimales."; return false; }
            if (pObjGastoDG.gDtmFechaDG.Date > DateTime.Today) { pStrMensajeDG = "La fecha no puede ser futura."; return false; }
            if ((pObjGastoDG.gStrDescripcionDG ?? string.Empty).Trim().Length > 200) { pStrMensajeDG = "La descripción no puede tener más de 200 caracteres."; return false; }
            return true;
        }

        public bool FncGuardarGastoDG(GastoDG pObjGastoDG, out string pStrMensajeDG)
        {
            if (!FncValidarGastoDG(pObjGastoDG, out pStrMensajeDG)) return false;
            try
            {
                if (pObjGastoDG.gIntIdGastoDG == 0) gObjDatosGastoDG.FncInsertarGastoDG(pObjGastoDG);
                else gObjDatosGastoDG.SubActualizarGastoDG(pObjGastoDG);
            }
            catch (InvalidOperationException lObjErrorDG)
            {
                pStrMensajeDG = lObjErrorDG.Message;
                return false;
            }
            pStrMensajeDG = "Gasto de Q" + pObjGastoDG.gDcmMontoDG.ToString("N2") + " guardado.";
            return true;
        }

        public bool FncEliminarGastoDG(GastoDG pObjGastoDG, out string pStrMensajeDG)
        {
            pStrMensajeDG = string.Empty;
            if (pObjGastoDG == null || pObjGastoDG.gIntIdGastoDG <= 0) { pStrMensajeDG = "Seleccione el gasto."; return false; }
            try
            {
                gObjDatosGastoDG.SubEliminarGastoDG(pObjGastoDG.gIntIdGastoDG);
            }
            catch (InvalidOperationException lObjErrorDG)
            {
                pStrMensajeDG = lObjErrorDG.Message;
                return false;
            }
            pStrMensajeDG = "Se eliminó el gasto de Q" + pObjGastoDG.gDcmMontoDG.ToString("N2") + ".";
            return true;
        }
    }
}
