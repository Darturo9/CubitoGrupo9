using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Inventario: lista de artículos con alertas de reorden y acceso a movimientos y kardex
    public partial class frmInventarioDG : Form
    {
        private readonly LogicaInventarioDG gObjLogicaInventarioDG = new LogicaInventarioDG();
        private List<ArticuloDG> gLstArticulosDG = new List<ArticuloDG>();

        public frmInventarioDG()
        {
            InitializeComponent();
            dgvArticulosDG.AutoGenerateColumns = false;
        }

        private void SubFrmInventarioLoadDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubCargarArticulosDG();
        }

        // Vuelve a consultar la base y refresca la grilla y el resumen
        private void SubCargarArticulosDG()
        {
            try
            {
                int lIntIdSeleccionadoDG = FncObtenerSeleccionadoDG()?.gIntIdArticuloDG ?? 0;
                gLstArticulosDG = gObjLogicaInventarioDG.FncListarArticulosDG(txtBuscarDG.Text, chkSoloAlertasDG.Checked);
                dgvArticulosDG.DataSource = null;
                dgvArticulosDG.DataSource = gLstArticulosDG;

                int lIntAlertasDG = gObjLogicaInventarioDG.FncContarAlertasDG(gLstArticulosDG);
                lblResumenDG.Text = gLstArticulosDG.Count + " artículos · " + lIntAlertasDG + " en alerta de reorden";
                lblResumenDG.ForeColor = lIntAlertasDG > 0 ? Color.Firebrick : SystemColors.ControlText;

                // Mantener seleccionado el mismo artículo después de refrescar
                foreach (DataGridViewRow lObjFilaDG in dgvArticulosDG.Rows)
                {
                    if (((ArticuloDG)lObjFilaDG.DataBoundItem).gIntIdArticuloDG != lIntIdSeleccionadoDG) continue;
                    lObjFilaDG.Selected = true;
                    dgvArticulosDG.CurrentCell = lObjFilaDG.Cells[0];
                    break;
                }
                SubActualizarBotonesDG();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudo cargar el inventario. Revise la conexión a la base de datos.", "Cubito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ArticuloDG FncObtenerSeleccionadoDG()
        {
            return dgvArticulosDG.CurrentRow?.DataBoundItem as ArticuloDG;
        }

        private void SubActualizarBotonesDG()
        {
            bool lBlnHaySeleccionDG = FncObtenerSeleccionadoDG() != null;
            btnEditarDG.Enabled = lBlnHaySeleccionDG;
            btnMovimientoDG.Enabled = lBlnHaySeleccionDG;
            btnKardexDG.Enabled = lBlnHaySeleccionDG;
            btnDesactivarDG.Enabled = lBlnHaySeleccionDG;
        }

        // Colores de alerta: rojo suave para reordenar, amarillo suave para sobre stock
        private void SubDgvArticulosRowPrePaintDG(object pObjSenderDG, DataGridViewRowPrePaintEventArgs pObjEventoDG)
        {
            ArticuloDG lObjArticuloDG = dgvArticulosDG.Rows[pObjEventoDG.RowIndex].DataBoundItem as ArticuloDG;
            if (lObjArticuloDG == null) return;

            DataGridViewCellStyle lObjEstiloDG = dgvArticulosDG.Rows[pObjEventoDG.RowIndex].DefaultCellStyle;
            if (lObjArticuloDG.gBlnRequiereReordenDG)
                lObjEstiloDG.BackColor = Color.FromArgb(253, 226, 226);
            else if (lObjArticuloDG.gStrEstadoStockDG == "Sobre stock")
                lObjEstiloDG.BackColor = Color.FromArgb(255, 244, 204);
            else
                lObjEstiloDG.BackColor = Color.Empty;
        }

        private void SubTxtBuscarTextChangedDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubCargarArticulosDG(); }

        private void SubChkSoloAlertasCheckedChangedDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubCargarArticulosDG(); }

        private void SubDgvArticulosSelectionChangedDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubActualizarBotonesDG(); }

        private void SubDgvArticulosCellDoubleClickDG(object pObjSenderDG, DataGridViewCellEventArgs pObjEventoDG)
        {
            if (pObjEventoDG.RowIndex >= 0) SubBtnEditarClickDG(pObjSenderDG, pObjEventoDG);
        }

        private void SubBtnNuevoClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            using (frmArticuloDG lObjFormularioDG = new frmArticuloDG(null))
            {
                if (lObjFormularioDG.ShowDialog(this) == DialogResult.OK) SubCargarArticulosDG();
            }
        }

        private void SubBtnEditarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            ArticuloDG lObjArticuloDG = FncObtenerSeleccionadoDG();
            if (lObjArticuloDG == null) return;
            using (frmArticuloDG lObjFormularioDG = new frmArticuloDG(lObjArticuloDG))
            {
                if (lObjFormularioDG.ShowDialog(this) == DialogResult.OK) SubCargarArticulosDG();
            }
        }

        private void SubBtnMovimientoClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            ArticuloDG lObjArticuloDG = FncObtenerSeleccionadoDG();
            if (lObjArticuloDG == null) return;
            using (frmMovimientoDG lObjFormularioDG = new frmMovimientoDG(lObjArticuloDG))
            {
                if (lObjFormularioDG.ShowDialog(this) == DialogResult.OK) SubCargarArticulosDG();
            }
        }

        private void SubBtnKardexClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            ArticuloDG lObjArticuloDG = FncObtenerSeleccionadoDG();
            if (lObjArticuloDG == null) return;
            using (frmKardexDG lObjFormularioDG = new frmKardexDG(lObjArticuloDG))
                lObjFormularioDG.ShowDialog(this);
        }

        private void SubBtnDesactivarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            ArticuloDG lObjArticuloDG = FncObtenerSeleccionadoDG();
            if (lObjArticuloDG == null) return;

            string lStrPreguntaDG = "¿Desactivar el artículo " + lObjArticuloDG.gStrCodigoDG + " - " + lObjArticuloDG.gStrNombreDG + "?\n\n" +
                "Dejará de aparecer en el inventario, pero su kardex se conserva.";
            if (MessageBox.Show(this, lStrPreguntaDG, "Cubito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                gObjLogicaInventarioDG.SubDesactivarArticuloDG(lObjArticuloDG.gIntIdArticuloDG);
                SubCargarArticulosDG();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudo desactivar el artículo.", "Cubito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubBtnCerrarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            Close();
        }
    }
}
