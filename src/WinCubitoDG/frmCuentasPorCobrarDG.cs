using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Pedidos aprobados que todavía tienen saldo pendiente
    public partial class frmCuentasPorCobrarDG : Form
    {
        private readonly LogicaPagoDG gObjLogicaPagoDG = new LogicaPagoDG();

        public frmCuentasPorCobrarDG()
        {
            InitializeComponent();
            dgvCuentasDG.AutoGenerateColumns = false;
        }

        private void SubFrmCuentasPorCobrarLoadDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubCargarCuentasDG();
        }

        private void SubCargarCuentasDG()
        {
            try
            {
                List<PedidoDG> lLstCuentasDG = gObjLogicaPagoDG.FncListarCuentasPorCobrarDG(txtBuscarDG.Text);
                dgvCuentasDG.DataSource = null;
                dgvCuentasDG.DataSource = lLstCuentasDG;

                decimal lDcmPorCobrarDG = lLstCuentasDG.Sum(lObjPedidoDG => lObjPedidoDG.gDcmSaldoDG);
                lblResumenDG.Text = lLstCuentasDG.Count + " pedidos · Por cobrar: Q" + lDcmPorCobrarDG.ToString("N2") +
                    " · Cobrado hoy: Q" + gObjLogicaPagoDG.FncCobradoHoyDG().ToString("N2");
                btnRegistrarPagoDG.Enabled = lLstCuentasDG.Count > 0;
                btnAbrirDG.Enabled = lLstCuentasDG.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudieron cargar las cuentas por cobrar. Revise la conexión a la base de datos.", "Cubito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private PedidoDG FncPedidoSeleccionadoDG()
        {
            return dgvCuentasDG.CurrentRow?.DataBoundItem as PedidoDG;
        }

        // Listo = se puede cobrar y entregar ya; entrega vencida en rojo
        private void SubDgvCuentasCellFormattingDG(object pObjSenderDG, DataGridViewCellFormattingEventArgs pObjEventoDG)
        {
            if (pObjEventoDG.RowIndex < 0) return;
            PedidoDG lObjPedidoDG = dgvCuentasDG.Rows[pObjEventoDG.RowIndex].DataBoundItem as PedidoDG;
            if (lObjPedidoDG == null) return;

            if (dgvCuentasDG.Columns[pObjEventoDG.ColumnIndex] == colEstadoDG && lObjPedidoDG.gStrEstadoDG == PedidoDG.EstadoListoDG)
                pObjEventoDG.CellStyle.BackColor = Color.FromArgb(255, 236, 179);
            if (dgvCuentasDG.Columns[pObjEventoDG.ColumnIndex] == colEntregaDG &&
                lObjPedidoDG.gDtmFechaEntregaDG.HasValue && lObjPedidoDG.gDtmFechaEntregaDG.Value.Date < DateTime.Today)
                pObjEventoDG.CellStyle.ForeColor = Color.Firebrick;
        }

        private void SubBtnRegistrarPagoClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            PedidoDG lObjPedidoDG = FncPedidoSeleccionadoDG();
            if (lObjPedidoDG == null) return;
            using (frmPagoDG lObjFormularioDG = new frmPagoDG(lObjPedidoDG.gIntIdPedidoDG))
            {
                lObjFormularioDG.ShowDialog(this);
                if (lObjFormularioDG.gBlnSeGuardoAlgoDG) SubCargarCuentasDG();
            }
        }

        private void SubBtnAbrirClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            PedidoDG lObjPedidoDG = FncPedidoSeleccionadoDG();
            if (lObjPedidoDG == null) return;
            using (frmPedidoDG lObjFormularioDG = new frmPedidoDG(lObjPedidoDG.gIntIdPedidoDG))
            {
                lObjFormularioDG.ShowDialog(this);
                if (lObjFormularioDG.gBlnSeGuardoAlgoDG) SubCargarCuentasDG();
            }
        }

        // Doble clic va directo a cobrar, que es lo que más se hace en esta pantalla
        private void SubDgvCuentasCellDoubleClickDG(object pObjSenderDG, DataGridViewCellEventArgs pObjEventoDG)
        {
            if (pObjEventoDG.RowIndex >= 0) SubBtnRegistrarPagoClickDG(pObjSenderDG, pObjEventoDG);
        }

        private void SubTxtBuscarTextChangedDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubCargarCuentasDG(); }

        private void SubBtnCerrarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            Close();
        }
    }
}
