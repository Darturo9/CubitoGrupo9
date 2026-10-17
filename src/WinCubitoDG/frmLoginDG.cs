using System;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Inicio de sesión del dueño del taller
    public partial class frmLoginDG : Form
    {
        private readonly LogicaUsuarioDG gObjLogicaUsuarioDG = new LogicaUsuarioDG();

        public UsuarioDG gObjUsuarioDG { get; private set; }

        public frmLoginDG()
        {
            InitializeComponent();
            TemaDG.SubAplicarTemaDG(this);
            BackColor = Color.White;
            pnlMarcaDG.BackColor = TemaDG.gObjTintaDG;
            TemaDG.SubBotonDG(btnIngresarDG, EstiloBotonDG.Primario, IconoDG.CandadoDG);
        }

        private void SubBtnIngresarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            lblMensajeDG.Text = string.Empty;
            string lStrMensajeDG;
            try
            {
                UsuarioDG lObjUsuarioDG = gObjLogicaUsuarioDG.FncIniciarSesionDG(txtUsuarioDG.Text, txtClaveDG.Text, out lStrMensajeDG);
                if (lObjUsuarioDG == null)
                {
                    lblMensajeDG.Text = lStrMensajeDG;
                    txtClaveDG.SelectAll();
                    txtClaveDG.Focus();
                    return;
                }
                gObjUsuarioDG = lObjUsuarioDG;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                // No se muestran detalles técnicos al usuario
                lblMensajeDG.Text = "No se pudo conectar a la base de datos. Revise que SQL Server Express esté encendido.";
            }
        }

        private void SubBtnSalirClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
