using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Inicio: indicadores del día y acceso a cada módulo
    public partial class frmPrincipalDG : Form
    {
        private static readonly CultureInfo gObjCulturaDG = new CultureInfo("es-GT");

        private readonly LogicaPedidoDG gObjLogicaPedidoDG = new LogicaPedidoDG();
        private readonly LogicaPagoDG gObjLogicaPagoDG = new LogicaPagoDG();
        private readonly LogicaInventarioDG gObjLogicaInventarioDG = new LogicaInventarioDG();

        public frmPrincipalDG(UsuarioDG pObjUsuarioDG)
        {
            InitializeComponent();
            TemaDG.SubAplicarTemaDG(this);
            pnlLateralDG.BackColor = TemaDG.gObjTintaDG;

            lblUsuarioDG.Text = "      " + pObjUsuarioDG.gStrUsuarioDG;
            lblUsuarioDG.Image = TemaDG.FncIconoDG(IconoDG.UsuarioDG, 18, Color.White);
            lblSaludoDG.Text = FncSaludoDG() + ", " + pObjUsuarioDG.gStrUsuarioDG;
            string lStrFechaDG = DateTime.Today.ToString("dddd, d 'de' MMMM 'de' yyyy", gObjCulturaDG);
            lblFechaDG.Text = char.ToUpper(lStrFechaDG[0]) + lStrFechaDG.Substring(1);

            // Botón de salir sobre el panel oscuro: transparente con borde tenue
            btnSalirDG.BackColor = TemaDG.gObjTintaDG;
            btnSalirDG.ForeColor = Color.White;
            btnSalirDG.FlatAppearance.BorderColor = TemaDG.gObjTinta2DG;
            btnSalirDG.FlatAppearance.MouseOverBackColor = TemaDG.gObjTinta2DG;
            btnSalirDG.FlatAppearance.MouseDownBackColor = TemaDG.gObjTinta2DG;
            btnSalirDG.Image = TemaDG.FncIconoDG(IconoDG.SalirDG, 16, Color.White);
            btnSalirDG.TextImageRelation = TextImageRelation.ImageBeforeText;

            SubConfigurarTarjetaDG(tarActivosDG, IconoDG.PedidosDG, TemaDG.gObjCianDG);
            SubConfigurarTarjetaDG(tarPorCobrarDG, IconoDG.PagosDG, TemaDG.gObjMagentaDG);
            SubConfigurarTarjetaDG(tarListosDG, IconoDG.ListoDG, TemaDG.gObjVerdeDG);
            SubConfigurarTarjetaDG(tarAlertasDG, IconoDG.AlertaDG, Color.FromArgb(0xC7, 0x8A, 0x00));

            SubConfigurarTarjetaDG(tarPedidosDG, IconoDG.PedidosDG, TemaDG.gObjMagentaDG);
            SubConfigurarTarjetaDG(tarPagosDG, IconoDG.PagosDG, TemaDG.gObjCianDG);
            SubConfigurarTarjetaDG(tarInventarioDG, IconoDG.InventarioDG, TemaDG.gObjVerdeDG);
            SubConfigurarTarjetaDG(tarClientesDG, IconoDG.ClientesDG, TemaDG.gObjCianDG);
            SubConfigurarTarjetaDG(tarGastosDG, IconoDG.GastosDG, Color.FromArgb(0xC7, 0x8A, 0x00));
            SubConfigurarTarjetaDG(tarReportesDG, IconoDG.ReportesDG, TemaDG.gObjMagentaDG);
        }

        private static void SubConfigurarTarjetaDG(TarjetaBaseDG pObjTarjetaDG, string pStrIconoDG, Color pObjColorDG)
        {
            pObjTarjetaDG.gStrIconoDG = pStrIconoDG;
            pObjTarjetaDG.gObjColorAcentoDG = pObjColorDG;
        }

        private static string FncSaludoDG()
        {
            int lIntHoraDG = DateTime.Now.Hour;
            if (lIntHoraDG < 12) return "Buenos días";
            if (lIntHoraDG < 19) return "Buenas tardes";
            return "Buenas noches";
        }

        private void SubFrmPrincipalLoadDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubCargarIndicadoresDG();
        }

        // Resumen del taller; se vuelve a calcular cada vez que se cierra un módulo
        private void SubCargarIndicadoresDG()
        {
            try
            {
                List<PedidoDG> lLstPedidosDG = gObjLogicaPedidoDG.FncListarPedidosDG(string.Empty, string.Empty);
                int lIntActivosDG = lLstPedidosDG.Count(lObjPedidoDG => LogicaPagoDG.FncAceptaPagosDG(lObjPedidoDG.gStrEstadoDG));
                int lIntCotizacionesDG = lLstPedidosDG.Count(lObjPedidoDG => lObjPedidoDG.gStrEstadoDG == PedidoDG.EstadoCotizacionDG);
                int lIntListosDG = lLstPedidosDG.Count(lObjPedidoDG => lObjPedidoDG.gStrEstadoDG == PedidoDG.EstadoListoDG);
                tarActivosDG.gStrValorIndicadorDG = lIntActivosDG.ToString();
                tarActivosDG.gStrDetalleIndicadorDG = lIntCotizacionesDG == 1 ? "1 cotización pendiente" : lIntCotizacionesDG + " cotizaciones pendientes";
                tarListosDG.gStrValorIndicadorDG = lIntListosDG.ToString();
                tarListosDG.gStrDetalleIndicadorDG = lIntListosDG == 0 ? "Nada pendiente de entregar" : "Avise al cliente";

                List<PedidoDG> lLstCuentasDG = gObjLogicaPagoDG.FncListarCuentasPorCobrarDG(string.Empty);
                tarPorCobrarDG.gStrValorIndicadorDG = "Q" + lLstCuentasDG.Sum(lObjPedidoDG => lObjPedidoDG.gDcmSaldoDG).ToString("N2");
                tarPorCobrarDG.gStrDetalleIndicadorDG = "Cobrado hoy: Q" + gObjLogicaPagoDG.FncCobradoHoyDG().ToString("N2");

                int lIntAlertasDG = gObjLogicaInventarioDG.FncContarAlertasDG(gObjLogicaInventarioDG.FncListarArticulosDG(string.Empty, false));
                tarAlertasDG.gStrValorIndicadorDG = lIntAlertasDG.ToString();
                tarAlertasDG.gStrDetalleIndicadorDG = lIntAlertasDG == 0 ? "Stock en orden" : (lIntAlertasDG == 1 ? "1 artículo por reordenar" : lIntAlertasDG + " artículos por reordenar");
            }
            catch (Exception)
            {
                // Sin conexión los indicadores quedan en blanco; los módulos muestran su propio aviso
                foreach (TarjetaIndicadorDG lObjTarjetaDG in new[] { tarActivosDG, tarPorCobrarDG, tarListosDG, tarAlertasDG })
                {
                    lObjTarjetaDG.gStrValorIndicadorDG = "—";
                    lObjTarjetaDG.gStrDetalleIndicadorDG = "Sin conexión";
                }
            }
        }

        // Cada integrante reemplaza este mensaje por la apertura de su formulario,
        // por ejemplo: using (frmClientesXX lObjFormularioXX = new frmClientesXX()) lObjFormularioXX.ShowDialog(this);
        private void SubMostrarPendienteDG(string pStrModuloDG)
        {
            MessageBox.Show(this, "El módulo " + pStrModuloDG + " está en construcción.", "Cubito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SubAbrirDG(Form pObjFormularioDG)
        {
            using (pObjFormularioDG) pObjFormularioDG.ShowDialog(this);
            SubCargarIndicadoresDG();
        }

        private void SubBtnClientesClickDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubMostrarPendienteDG("Clientes"); }
        private void SubBtnInventarioClickDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubAbrirDG(new frmInventarioDG()); }
        private void SubBtnPedidosClickDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubAbrirDG(new frmPedidosDG()); }
        private void SubBtnPagosClickDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubAbrirDG(new frmCuentasPorCobrarDG()); }
        private void SubBtnGastosClickDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubMostrarPendienteDG("Gastos"); }
        private void SubBtnReportesClickDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubMostrarPendienteDG("Reportes"); }

        private void SubBtnSalirClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            Close();
        }
    }
}
