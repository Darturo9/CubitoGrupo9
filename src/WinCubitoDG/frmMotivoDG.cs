using System;
using System.Windows.Forms;

namespace WinCubitoDG
{
    // Diálogo genérico para pedir un motivo (por ejemplo, al cancelar un pedido)
    public partial class frmMotivoDG : Form
    {
        public string gStrMotivoDG
        {
            get { return txtMotivoDG.Text.Trim(); }
        }

        public frmMotivoDG(string pStrTituloDG, string pStrPreguntaDG)
        {
            InitializeComponent();
            Text = pStrTituloDG;
            lblPreguntaDG.Text = pStrPreguntaDG;
        }

        private void SubBtnAceptarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            if (gStrMotivoDG.Length == 0)
            {
                lblMensajeDG.Text = "Escriba el motivo.";
                txtMotivoDG.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SubBtnCancelarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
