using System;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Crear o editar un artículo. El stock solo se pide al crear; después cambia con movimientos.
    public partial class frmArticuloDG : Form
    {
        private readonly LogicaInventarioDG gObjLogicaInventarioDG = new LogicaInventarioDG();
        private readonly ArticuloDG gObjArticuloDG;
        private readonly bool gBlnEsNuevoDG;

        public frmArticuloDG(ArticuloDG pObjArticuloDG)
        {
            InitializeComponent();
            TemaDG.SubAplicarTemaDG(this);
            TemaDG.SubBotonDG(btnGuardarDG, EstiloBotonDG.Primario, IconoDG.GuardarDG);
            gBlnEsNuevoDG = pObjArticuloDG == null;
            gObjArticuloDG = pObjArticuloDG ?? new ArticuloDG();

            cmbTipoDG.Items.AddRange(new object[] { ArticuloDG.TipoPrendaDG, ArticuloDG.TipoInsumoDG });
            cmbUnidadDG.Items.AddRange(LogicaInventarioDG.gArrUnidadesDG);
            SubMostrarArticuloDG();
        }

        private void SubMostrarArticuloDG()
        {
            Text = gBlnEsNuevoDG ? "Nuevo artículo" : "Editar artículo " + gObjArticuloDG.gStrCodigoDG;
            txtCodigoDG.Text = gObjArticuloDG.gStrCodigoDG;
            txtNombreDG.Text = gObjArticuloDG.gStrNombreDG;
            cmbTipoDG.SelectedItem = gObjArticuloDG.gStrTipoDG;
            txtTallaDG.Text = gObjArticuloDG.gStrTallaDG;
            txtColorDG.Text = gObjArticuloDG.gStrColorDG;
            cmbUnidadDG.SelectedItem = gObjArticuloDG.gStrUnidadDG;
            nudMinimoDG.Value = gObjArticuloDG.gDcmStockMinimoDG;
            nudMaximoDG.Value = gObjArticuloDG.gDcmStockMaximoDG;
            nudCostoDG.Value = gObjArticuloDG.gDcmCostoUnitarioDG;

            // Al editar, el stock se muestra pero no se modifica aquí
            lblStockDG.Text = gBlnEsNuevoDG ? "Stock inicial:" : "Stock actual:";
            nudStockInicialDG.Value = gBlnEsNuevoDG ? 0 : gObjArticuloDG.gDcmStockDG;
            nudStockInicialDG.Enabled = gBlnEsNuevoDG;
            lblAyudaStockDG.Visible = !gBlnEsNuevoDG;
            SubAplicarReglasTipoDG();
        }

        // Las prendas llevan talla y siempre se cuentan por unidad
        private void SubAplicarReglasTipoDG()
        {
            bool lBlnEsPrendaDG = (cmbTipoDG.SelectedItem as string) == ArticuloDG.TipoPrendaDG;
            txtTallaDG.Enabled = lBlnEsPrendaDG;
            if (!lBlnEsPrendaDG) txtTallaDG.Text = string.Empty;
            if (lBlnEsPrendaDG) cmbUnidadDG.SelectedItem = "Unidad";
            cmbUnidadDG.Enabled = !lBlnEsPrendaDG;
        }

        private void SubCmbTipoSelectedIndexChangedDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubAplicarReglasTipoDG();
        }

        private void SubBtnGuardarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            lblMensajeDG.Text = string.Empty;
            gObjArticuloDG.gStrCodigoDG = txtCodigoDG.Text;
            gObjArticuloDG.gStrNombreDG = txtNombreDG.Text;
            gObjArticuloDG.gStrTipoDG = cmbTipoDG.SelectedItem as string ?? string.Empty;
            gObjArticuloDG.gStrTallaDG = txtTallaDG.Text;
            gObjArticuloDG.gStrColorDG = txtColorDG.Text;
            gObjArticuloDG.gStrUnidadDG = cmbUnidadDG.SelectedItem as string ?? string.Empty;
            gObjArticuloDG.gDcmStockMinimoDG = nudMinimoDG.Value;
            gObjArticuloDG.gDcmStockMaximoDG = nudMaximoDG.Value;
            gObjArticuloDG.gDcmCostoUnitarioDG = nudCostoDG.Value;

            string lStrMensajeDG;
            try
            {
                decimal lDcmStockInicialDG = gBlnEsNuevoDG ? nudStockInicialDG.Value : 0;
                if (!gObjLogicaInventarioDG.FncGuardarArticuloDG(gObjArticuloDG, lDcmStockInicialDG, out lStrMensajeDG))
                {
                    lblMensajeDG.Text = lStrMensajeDG;
                    return;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                lblMensajeDG.Text = "No se pudo guardar el artículo. Revise la conexión a la base de datos.";
            }
        }

        private void SubBtnCancelarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
