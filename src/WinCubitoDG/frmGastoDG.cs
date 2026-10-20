using System;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Registrar o corregir un gasto
    public partial class frmGastoDG : Form
    {
        private readonly LogicaGastoDG gObjLogicaGastoDG = new LogicaGastoDG();
        private readonly GastoDG gObjGastoDG;

        // Fecha del gasto guardado, para que la lista muestre su mes
        public DateTime gDtmFechaGuardadaDG { get { return gObjGastoDG.gDtmFechaDG; } }

        public frmGastoDG(GastoDG pObjGastoDG)
        {
            InitializeComponent();
            TemaDG.SubAplicarTemaDG(this);
            TemaDG.SubBotonDG(btnGuardarDG, EstiloBotonDG.Primario, IconoDG.GuardarDG);

            // Se edita una copia: si se cancela, la lista no cambia
            gObjGastoDG = pObjGastoDG == null ? new GastoDG() : new GastoDG
            {
                gIntIdGastoDG = pObjGastoDG.gIntIdGastoDG,
                gStrCategoriaDG = pObjGastoDG.gStrCategoriaDG,
                gStrDescripcionDG = pObjGastoDG.gStrDescripcionDG,
                gDcmMontoDG = pObjGastoDG.gDcmMontoDG,
                gDtmFechaDG = pObjGastoDG.gDtmFechaDG
            };

            Text = pObjGastoDG == null ? "Nuevo gasto" : "Editar gasto";
            cmbCategoriaDG.Items.AddRange(LogicaGastoDG.gArrCategoriasDG);
            cmbCategoriaDG.SelectedItem = gObjGastoDG.gStrCategoriaDG;
            dtpFechaDG.MaxDate = DateTime.Today;
            dtpFechaDG.Value = gObjGastoDG.gDtmFechaDG > DateTime.Today ? DateTime.Today : gObjGastoDG.gDtmFechaDG;
            nudMontoDG.Value = gObjGastoDG.gDcmMontoDG;
            txtDescripcionDG.Text = gObjGastoDG.gStrDescripcionDG;
        }

        private void SubBtnGuardarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            lblMensajeDG.Text = string.Empty;
            gObjGastoDG.gStrCategoriaDG = cmbCategoriaDG.SelectedItem as string ?? string.Empty;
            gObjGastoDG.gDtmFechaDG = dtpFechaDG.Value.Date;
            gObjGastoDG.gDcmMontoDG = nudMontoDG.Value;
            gObjGastoDG.gStrDescripcionDG = txtDescripcionDG.Text.Trim();

            string lStrMensajeDG;
            try
            {
                if (!gObjLogicaGastoDG.FncGuardarGastoDG(gObjGastoDG, out lStrMensajeDG))
                {
                    lblMensajeDG.Text = lStrMensajeDG;
                    return;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                lblMensajeDG.Text = "No se pudo guardar el gasto. Revise la conexión a la base de datos.";
            }
        }

        // Al entrar al monto se selecciona todo para escribir encima
        private void SubNudMontoEnterDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            nudMontoDG.Select(0, nudMontoDG.Text.Length);
        }

        private void SubBtnCancelarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
