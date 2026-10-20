using System;
using System.Collections.Generic;

namespace CapaEntidadesDG
{
    // Una fila de los cuadros del reporte: técnica, cliente o categoría de gasto
    public class FilaReporteDG
    {
        public string gStrConceptoDG { get; set; }
        public int gIntCantidadDG { get; set; }
        public decimal gDcmMontoDG { get; set; }

        public FilaReporteDG()
        {
            gStrConceptoDG = string.Empty;
        }
    }

    // Resumen financiero de un mes
    public class ResumenMesDG
    {
        public DateTime gDtmMesDG { get; set; }
        public decimal gDcmVentasDG { get; set; }      // total de pedidos aprobados del mes
        public int gIntPedidosDG { get; set; }         // cuántos pedidos forman las ventas
        public decimal gDcmCobradoDG { get; set; }     // pagos recibidos en el mes
        public decimal gDcmGastosDG { get; set; }      // gastos registrados en el mes

        public List<FilaReporteDG> gLstTecnicasDG { get; set; }
        public List<FilaReporteDG> gLstClientesDG { get; set; }
        public List<FilaReporteDG> gLstCategoriasDG { get; set; }

        // Ganancia del mes como flujo de caja: lo que entró menos lo que salió
        public decimal gDcmGananciaDG
        {
            get { return gDcmCobradoDG - gDcmGastosDG; }
        }

        public ResumenMesDG()
        {
            gLstTecnicasDG = new List<FilaReporteDG>();
            gLstClientesDG = new List<FilaReporteDG>();
            gLstCategoriasDG = new List<FilaReporteDG>();
        }
    }
}
