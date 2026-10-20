using System;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Crear o editar un cliente
    public partial class frmClienteDG : Form
    {
        private readonly LogicaClienteDG gObjLogicaClienteDG = new LogicaClienteDG();
        private readonly ClienteDG gObjClienteDG;

        // Id del cliente guardado, para que la lista lo deje seleccionado
        public int gIntIdClienteDG { get { return gObjClienteDG.gIntIdClienteDG; } }

        public frmClienteDG(ClienteDG pObjClienteDG)
        {
            InitializeComponent();
            TemaDG.SubAplicarTemaDG(this);
            TemaDG.SubBotonDG(btnGuardarDG, EstiloBotonDG.Primario, IconoDG.GuardarDG);

            // Se edita una copia: si el usuario cancela, la lista no queda con datos a medias
            gObjClienteDG = pObjClienteDG == null ? new ClienteDG() : new ClienteDG
            {
                gIntIdClienteDG = pObjClienteDG.gIntIdClienteDG,
                gStrNombreDG = pObjClienteDG.gStrNombreDG,
                gStrTelefonoDG = pObjClienteDG.gStrTelefonoDG,
                gStrCorreoDG = pObjClienteDG.gStrCorreoDG,
                gDtmFechaRegistroDG = pObjClienteDG.gDtmFechaRegistroDG,
                gBlnActivoDG = pObjClienteDG.gBlnActivoDG
            };

            Text = pObjClienteDG == null ? "Nuevo cliente" : "Editar cliente";
            txtNombreDG.Text = gObjClienteDG.gStrNombreDG;
            txtTelefonoDG.Text = gObjClienteDG.gStrTelefonoDG;
            txtCorreoDG.Text = gObjClienteDG.gStrCorreoDG;
        }

        // El teléfono solo acepta dígitos
        private void SubTxtTelefonoKeyPressDG(object pObjSenderDG, KeyPressEventArgs pObjEventoDG)
        {
            if (!char.IsDigit(pObjEventoDG.KeyChar) && !char.IsControl(pObjEventoDG.KeyChar)) pObjEventoDG.Handled = true;
        }

        private void SubBtnGuardarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            lblMensajeDG.Text = string.Empty;
            gObjClienteDG.gStrNombreDG = txtNombreDG.Text;
            gObjClienteDG.gStrTelefonoDG = txtTelefonoDG.Text;
            gObjClienteDG.gStrCorreoDG = txtCorreoDG.Text;

            string lStrMensajeDG;
            try
            {
                if (!gObjLogicaClienteDG.FncGuardarClienteDG(gObjClienteDG, out lStrMensajeDG))
                {
                    lblMensajeDG.Text = lStrMensajeDG;
                    return;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                lblMensajeDG.Text = "No se pudo guardar el cliente. Revise la conexión a la base de datos.";
            }
        }

        private void SubBtnCancelarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
