using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Kardex: historial de movimientos de un artículo con el saldo después de cada uno
    public partial class frmKardexDG : Form
    {
        private readonly LogicaInventarioDG gObjLogicaInventarioDG = new LogicaInventarioDG();
        private readonly ArticuloDG gObjArticuloDG;

        public frmKardexDG(ArticuloDG pObjArticuloDG)
        {
            InitializeComponent();
            TemaDG.SubAplicarTemaDG(this);
            gObjArticuloDG = pObjArticuloDG;
            dgvKardexDG.AutoGenerateColumns = false;
            lblArticuloDG.Text = "Kardex de " + pObjArticuloDG.gStrCodigoDG + " - " + pObjArticuloDG.gStrNombreDG +
                (pObjArticuloDG.gStrTallaDG.Length > 0 ? " · Talla " + pObjArticuloDG.gStrTallaDG : string.Empty);
        }

        private void SubFrmKardexLoadDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            try
            {
                List<MovimientoInventarioDG> lLstMovimientosDG = gObjLogicaInventarioDG.FncObtenerKardexDG(gObjArticuloDG.gIntIdArticuloDG);
                dgvKardexDG.DataSource = lLstMovimientosDG;
                lblResumenDG.Text = lLstMovimientosDG.Count + " movimientos · Stock actual: " +
                    gObjArticuloDG.gDcmStockDG.ToString("0.##") + " " + gObjArticuloDG.gStrUnidadDG;
                if (dgvKardexDG.Rows.Count > 0)
                    dgvKardexDG.FirstDisplayedScrollingRowIndex = dgvKardexDG.Rows.Count - 1;
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudo cargar el kardex.", "Cubito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubBtnCerrarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            Close();
        }
    }
}
