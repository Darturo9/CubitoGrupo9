using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Gastos del taller por mes, con total y categoría principal
    public partial class frmGastosDG : Form
    {
        private const string gStrTodasDG = "Todas";
        private readonly LogicaGastoDG gObjLogicaGastoDG = new LogicaGastoDG();
        private bool gBlnCargandoDG;

        public frmGastosDG()
        {
            InitializeComponent();
            TemaDG.SubAplicarTemaDG(this);
            TemaDG.SubBotonDG(btnNuevoDG, EstiloBotonDG.Primario, IconoDG.AgregarDG);
            TemaDG.SubBotonDG(btnEditarDG, EstiloBotonDG.Secundario, IconoDG.EditarDG);
            TemaDG.SubBotonDG(btnEliminarDG, EstiloBotonDG.Peligro, IconoDG.EliminarDG);
            dgvGastosDG.AutoGenerateColumns = false;

            gBlnCargandoDG = true;
            // Siempre el día 1: así cambiar de mes nunca cae en un día que no existe (31 de febrero)
            dtpMesDG.MaxDate = DateTime.Today;
            dtpMesDG.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            cmbCategoriaDG.Items.Add(gStrTodasDG);
            cmbCategoriaDG.Items.AddRange(LogicaGastoDG.gArrCategoriasDG);
            cmbCategoriaDG.SelectedIndex = 0;
            gBlnCargandoDG = false;
        }

        private void SubFrmGastosLoadDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubCargarGastosDG();
        }

        private void SubCargarGastosDG()
        {
            if (gBlnCargandoDG) return;
            try
            {
                string lStrCategoriaDG = cmbCategoriaDG.SelectedItem as string == gStrTodasDG ? string.Empty : cmbCategoriaDG.SelectedItem as string;
                List<GastoDG> lLstGastosDG = gObjLogicaGastoDG.FncListarGastosMesDG(dtpMesDG.Value.Year, dtpMesDG.Value.Month, lStrCategoriaDG);
                dgvGastosDG.DataSource = null;
                dgvGastosDG.DataSource = lLstGastosDG;

                decimal lDcmTotalDG = lLstGastosDG.Sum(lObjGastoDG => lObjGastoDG.gDcmMontoDG);
                string lStrMesDG = dtpMesDG.Value.ToString("MMMM yyyy", new CultureInfo("es-GT"));
                lblResumenDG.Text = (lLstGastosDG.Count == 1 ? "1 gasto" : lLstGastosDG.Count + " gastos") + " en " + lStrMesDG +
                    " · Total: Q" + lDcmTotalDG.ToString("N2");
                string lStrPrincipalDG = gObjLogicaGastoDG.FncCategoriaPrincipalDG(lLstGastosDG);
                if (lStrCategoriaDG.Length == 0 && lStrPrincipalDG.Length > 0) lblResumenDG.Text += " · Mayor gasto: " + lStrPrincipalDG;

                btnEditarDG.Enabled = lLstGastosDG.Count > 0;
                btnEliminarDG.Enabled = lLstGastosDG.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudieron cargar los gastos. Revise la conexión a la base de datos.", "Cubito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private GastoDG FncGastoSeleccionadoDG()
        {
            return dgvGastosDG.CurrentRow?.DataBoundItem as GastoDG;
        }

        private void SubAbrirGastoDG(GastoDG pObjGastoDG)
        {
            using (frmGastoDG lObjFormularioDG = new frmGastoDG(pObjGastoDG))
            {
                if (lObjFormularioDG.ShowDialog(this) != DialogResult.OK) return;
                // Se muestra el mes del gasto guardado para que el usuario lo vea en la lista
                gBlnCargandoDG = true;
                dtpMesDG.Value = new DateTime(lObjFormularioDG.gDtmFechaGuardadaDG.Year, lObjFormularioDG.gDtmFechaGuardadaDG.Month, 1);
                gBlnCargandoDG = false;
                SubCargarGastosDG();
            }
        }

        private void SubBtnNuevoClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubAbrirGastoDG(null);
        }

        private void SubBtnEditarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            GastoDG lObjGastoDG = FncGastoSeleccionadoDG();
            if (lObjGastoDG != null) SubAbrirGastoDG(lObjGastoDG);
        }

        private void SubDgvGastosCellDoubleClickDG(object pObjSenderDG, DataGridViewCellEventArgs pObjEventoDG)
        {
            if (pObjEventoDG.RowIndex >= 0) SubBtnEditarClickDG(pObjSenderDG, pObjEventoDG);
        }

        private void SubBtnEliminarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            GastoDG lObjGastoDG = FncGastoSeleccionadoDG();
            if (lObjGastoDG == null) return;
            if (MessageBox.Show(this, "¿Eliminar el gasto de Q" + lObjGastoDG.gDcmMontoDG.ToString("N2") + " del " +
                    lObjGastoDG.gDtmFechaDG.ToString("dd/MM/yyyy") + " (" + lObjGastoDG.gStrCategoriaDG + ")?", "Cubito",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            string lStrMensajeDG;
            try
            {
                if (!gObjLogicaGastoDG.FncEliminarGastoDG(lObjGastoDG, out lStrMensajeDG))
                    MessageBox.Show(this, lStrMensajeDG, "Cubito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SubCargarGastosDG();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudo eliminar el gasto. Revise la conexión a la base de datos.", "Cubito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubFiltroCambioDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubCargarGastosDG();
        }

        private void SubBtnCerrarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            Close();
        }
    }
}
