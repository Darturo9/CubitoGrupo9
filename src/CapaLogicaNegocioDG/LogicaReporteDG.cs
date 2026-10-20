using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CapaDatosDG;
using CapaEntidadesDG;

namespace CapaLogicaNegocioDG
{
    // Resumen del mes: ventas, cobros, gastos y ganancia
    public class LogicaReporteDG
    {
        private static readonly CultureInfo gObjCulturaDG = new CultureInfo("es-GT");
        private readonly DatosReporteDG gObjDatosReporteDG = new DatosReporteDG();

        public ResumenMesDG FncResumenMesDG(int pIntAnioDG, int pIntMesDG)
        {
            DateTime lDtmDesdeDG = new DateTime(pIntAnioDG, pIntMesDG, 1);
            return gObjDatosReporteDG.FncObtenerResumenDG(lDtmDesdeDG, lDtmDesdeDG.AddMonths(1));
        }

        // "▲ 12 % vs septiembre" para comparar con el mes anterior
        public string FncComparacionDG(decimal pDcmActualDG, decimal pDcmAnteriorDG, DateTime pDtmMesAnteriorDG)
        {
            string lStrMesDG = pDtmMesAnteriorDG.ToString("MMMM", gObjCulturaDG);
            if (pDcmAnteriorDG == 0)
                return pDcmActualDG == 0 ? "Igual que " + lStrMesDG : "Sin datos de " + lStrMesDG;
            decimal lDcmCambioDG = Math.Round((pDcmActualDG - pDcmAnteriorDG) / Math.Abs(pDcmAnteriorDG) * 100, 0);
            if (lDcmCambioDG == 0) return "Igual que " + lStrMesDG;
            return (lDcmCambioDG > 0 ? "▲ " : "▼ ") + Math.Abs(lDcmCambioDG).ToString("0") + " % vs " + lStrMesDG;
        }

        // Texto CSV para abrir en Excel: separador coma y números con punto decimal
        public string FncGenerarCsvDG(ResumenMesDG pObjResumenDG)
        {
            StringBuilder lObjTextoDG = new StringBuilder();
            string lStrMesDG = pObjResumenDG.gDtmMesDG.ToString("MMMM yyyy", gObjCulturaDG);
            lObjTextoDG.AppendLine(FncCsvDG("Cubito - Resumen de " + lStrMesDG));
            lObjTextoDG.AppendLine();
            lObjTextoDG.AppendLine("Concepto,Monto (Q)");
            lObjTextoDG.AppendLine(FncCsvDG("Ventas (" + pObjResumenDG.gIntPedidosDG + " pedidos)") + "," + FncNumeroDG(pObjResumenDG.gDcmVentasDG));
            lObjTextoDG.AppendLine("Cobrado," + FncNumeroDG(pObjResumenDG.gDcmCobradoDG));
            lObjTextoDG.AppendLine("Gastos," + FncNumeroDG(pObjResumenDG.gDcmGastosDG));
            lObjTextoDG.AppendLine(FncCsvDG("Ganancia (cobrado - gastos)") + "," + FncNumeroDG(pObjResumenDG.gDcmGananciaDG));

            SubAgregarTablaDG(lObjTextoDG, "Ventas por técnica", "Técnica,Prendas,Monto (Q)", pObjResumenDG.gLstTecnicasDG);
            SubAgregarTablaDG(lObjTextoDG, "Mejores clientes", "Cliente,Pedidos,Monto (Q)", pObjResumenDG.gLstClientesDG);
            SubAgregarTablaDG(lObjTextoDG, "Gastos por categoría", "Categoría,Gastos,Monto (Q)", pObjResumenDG.gLstCategoriasDG);
            return lObjTextoDG.ToString();
        }

        private static void SubAgregarTablaDG(StringBuilder pObjTextoDG, string pStrTituloDG, string pStrEncabezadoDG, List<FilaReporteDG> pLstFilasDG)
        {
            pObjTextoDG.AppendLine();
            pObjTextoDG.AppendLine(FncCsvDG(pStrTituloDG));
            pObjTextoDG.AppendLine(pStrEncabezadoDG);
            foreach (FilaReporteDG lObjFilaDG in pLstFilasDG)
                pObjTextoDG.AppendLine(FncCsvDG(lObjFilaDG.gStrConceptoDG) + "," + lObjFilaDG.gIntCantidadDG + "," + FncNumeroDG(lObjFilaDG.gDcmMontoDG));
        }

        private static string FncNumeroDG(decimal pDcmValorDG)
        {
            return pDcmValorDG.ToString("0.00", CultureInfo.InvariantCulture);
        }

        // Encierra en comillas el texto que trae comas o comillas
        private static string FncCsvDG(string pStrTextoDG)
        {
            if (pStrTextoDG.IndexOfAny(new[] { ',', '"', '\n' }) < 0) return pStrTextoDG;
            return "\"" + pStrTextoDG.Replace("\"", "\"\"") + "\"";
        }
    }
}
