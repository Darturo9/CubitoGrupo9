using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Resumen del mes: ventas, cobros, gastos, ganancia y de dónde vienen
    public partial class frmReportesDG : Form
    {
        private static readonly CultureInfo gObjCulturaDG = new CultureInfo("es-GT");
        private readonly LogicaReporteDG gObjLogicaReporteDG = new LogicaReporteDG();
        private ResumenMesDG gObjResumenDG;
        private bool gBlnCargandoDG;

        public frmReportesDG()
        {
            InitializeComponent();
            TemaDG.SubAplicarTemaDG(this);
            TemaDG.SubBotonDG(btnExportarDG, EstiloBotonDG.Secundario, IconoDG.GuardarDG);
            dgvTecnicasDG.AutoGenerateColumns = false;
            dgvClientesDG.AutoGenerateColumns = false;
            dgvCategoriasDG.AutoGenerateColumns = false;

            SubConfigurarTarjetaDG(tarVentasDG, IconoDG.PedidosDG, TemaDG.gObjCianDG);
            SubConfigurarTarjetaDG(tarCobradoDG, IconoDG.PagosDG, TemaDG.gObjMagentaDG);
            SubConfigurarTarjetaDG(tarGastosDG, IconoDG.GastosDG, Color.FromArgb(0xC7, 0x8A, 0x00));
            SubConfigurarTarjetaDG(tarGananciaDG, IconoDG.ReportesDG, TemaDG.gObjVerdeDG);

            // Siempre el día 1, para que cambiar de mes nunca caiga en un día que no existe
            gBlnCargandoDG = true;
            dtpMesDG.MaxDate = DateTime.Today;
            dtpMesDG.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            gBlnCargandoDG = false;
        }

        // En este formulario las tarjetas solo informan: no se pueden pulsar
        private static void SubConfigurarTarjetaDG(TarjetaIndicadorDG pObjTarjetaDG, string pStrIconoDG, Color pObjColorDG)
        {
            pObjTarjetaDG.gStrIconoDG = pStrIconoDG;
            pObjTarjetaDG.gObjColorAcentoDG = pObjColorDG;
            pObjTarjetaDG.Cursor = Cursors.Default;
            pObjTarjetaDG.TabStop = false;
        }

        private void SubFrmReportesLoadDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubCargarResumenDG();
        }

        private void SubDtpMesValueChangedDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            if (!gBlnCargandoDG) SubCargarResumenDG();
        }

        private void SubCargarResumenDG()
        {
            try
            {
                DateTime lDtmMesDG = dtpMesDG.Value;
                DateTime lDtmAnteriorDG = lDtmMesDG.AddMonths(-1);
                gObjResumenDG = gObjLogicaReporteDG.FncResumenMesDG(lDtmMesDG.Year, lDtmMesDG.Month);
                ResumenMesDG lObjAnteriorDG = gObjLogicaReporteDG.FncResumenMesDG(lDtmAnteriorDG.Year, lDtmAnteriorDG.Month);

                tarVentasDG.gStrValorIndicadorDG = "Q" + gObjResumenDG.gDcmVentasDG.ToString("N2");
                tarVentasDG.gStrDetalleIndicadorDG = (gObjResumenDG.gIntPedidosDG == 1 ? "1 pedido · " : gObjResumenDG.gIntPedidosDG + " pedidos · ") +
                    gObjLogicaReporteDG.FncComparacionDG(gObjResumenDG.gDcmVentasDG, lObjAnteriorDG.gDcmVentasDG, lDtmAnteriorDG);
                tarCobradoDG.gStrValorIndicadorDG = "Q" + gObjResumenDG.gDcmCobradoDG.ToString("N2");
                tarCobradoDG.gStrDetalleIndicadorDG = gObjLogicaReporteDG.FncComparacionDG(gObjResumenDG.gDcmCobradoDG, lObjAnteriorDG.gDcmCobradoDG, lDtmAnteriorDG);
                tarGastosDG.gStrValorIndicadorDG = "Q" + gObjResumenDG.gDcmGastosDG.ToString("N2");
                tarGastosDG.gStrDetalleIndicadorDG = gObjLogicaReporteDG.FncComparacionDG(gObjResumenDG.gDcmGastosDG, lObjAnteriorDG.gDcmGastosDG, lDtmAnteriorDG);

                decimal lDcmGananciaDG = gObjResumenDG.gDcmGananciaDG;
                tarGananciaDG.gStrValorIndicadorDG = (lDcmGananciaDG < 0 ? "-Q" : "Q") + Math.Abs(lDcmGananciaDG).ToString("N2");
                tarGananciaDG.gStrDetalleIndicadorDG = lDcmGananciaDG < 0 ? "Se gastó más de lo cobrado" : "Cobrado menos gastos";
                tarGananciaDG.gObjColorAcentoDG = lDcmGananciaDG < 0 ? TemaDG.gObjRojoDG : TemaDG.gObjVerdeDG;
                tarGananciaDG.Invalidate();

                dgvTecnicasDG.DataSource = gObjResumenDG.gLstTecnicasDG;
                dgvClientesDG.DataSource = gObjResumenDG.gLstClientesDG;
                dgvCategoriasDG.DataSource = gObjResumenDG.gLstCategoriasDG;
                lblMesDescripcionDG.Text = "Resumen de " + lDtmMesDG.ToString("MMMM 'de' yyyy", gObjCulturaDG);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudo generar el reporte. Revise la conexión a la base de datos.", "Cubito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Guarda el resumen en un archivo CSV que se abre con Excel
        private void SubBtnExportarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            if (gObjResumenDG == null) return;
            using (SaveFileDialog lObjDialogoDG = new SaveFileDialog())
            {
                lObjDialogoDG.Title = "Exportar resumen";
                lObjDialogoDG.Filter = "Archivo CSV (*.csv)|*.csv";
                lObjDialogoDG.FileName = "Cubito-resumen-" + gObjResumenDG.gDtmMesDG.ToString("yyyy-MM") + ".csv";
                if (lObjDialogoDG.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    // UTF-8 con BOM para que Excel muestre bien las tildes
                    File.WriteAllText(lObjDialogoDG.FileName, gObjLogicaReporteDG.FncGenerarCsvDG(gObjResumenDG), new UTF8Encoding(true));
                    MessageBox.Show(this, "Resumen exportado.", "Cubito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException)
                {
                    MessageBox.Show(this, "No se pudo guardar el archivo. Si está abierto en Excel, ciérrelo e intente de nuevo.", "Cubito",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(this, "No hay permiso para guardar en esa carpeta. Elija otra.", "Cubito",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void SubBtnCerrarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            Close();
        }
    }
}
