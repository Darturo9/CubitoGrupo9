using System;
using System.Windows.Forms;
using CapaEntidadesDG;

namespace WinCubitoDG
{
    // Menú principal: desde aquí se abre cada módulo
    public partial class frmPrincipalDG : Form
    {
        public frmPrincipalDG(UsuarioDG pObjUsuarioDG)
        {
            InitializeComponent();
            lblBienvenidaDG.Text = "Bienvenido, " + pObjUsuarioDG.gStrUsuarioDG;
        }

        // Cada integrante reemplaza este mensaje por la apertura de su formulario,
        // por ejemplo: using (frmClientesXX lObjFormularioXX = new frmClientesXX()) lObjFormularioXX.ShowDialog(this);
        private void SubMostrarPendienteDG(string pStrModuloDG)
        {
            MessageBox.Show(this, "El módulo " + pStrModuloDG + " está en construcción.", "Cubito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SubBtnClientesClickDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubMostrarPendienteDG("Clientes"); }
        private void SubBtnInventarioClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            using (frmInventarioDG lObjFormularioDG = new frmInventarioDG()) lObjFormularioDG.ShowDialog(this);
        }
        private void SubBtnPedidosClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            using (frmPedidosDG lObjFormularioDG = new frmPedidosDG()) lObjFormularioDG.ShowDialog(this);
        }
        private void SubBtnPagosClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            using (frmCuentasPorCobrarDG lObjFormularioDG = new frmCuentasPorCobrarDG()) lObjFormularioDG.ShowDialog(this);
        }
        private void SubBtnGastosClickDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubMostrarPendienteDG("Gastos"); }
        private void SubBtnReportesClickDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubMostrarPendienteDG("Reportes"); }

        private void SubBtnSalirClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            Close();
        }
    }
}
