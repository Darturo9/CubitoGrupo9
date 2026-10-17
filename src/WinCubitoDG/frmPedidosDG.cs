using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Lista de pedidos con búsqueda y filtro por estado
    public partial class frmPedidosDG : Form
    {
        private const string gStrTodosDG = "Todos";
        private readonly LogicaPedidoDG gObjLogicaPedidoDG = new LogicaPedidoDG();

        public frmPedidosDG()
        {
            InitializeComponent();
            dgvPedidosDG.AutoGenerateColumns = false;
            cmbEstadoDG.Items.Add(gStrTodosDG);
            cmbEstadoDG.Items.AddRange(LogicaPedidoDG.gArrEstadosDG);
        }

        // Al elegir "Todos" se dispara el filtro y se cargan los pedidos
        private void SubFrmPedidosLoadDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            cmbEstadoDG.SelectedIndex = 0;
        }

        private void SubCargarPedidosDG()
        {
            try
            {
                string lStrEstadoDG = cmbEstadoDG.SelectedItem as string == gStrTodosDG ? string.Empty : cmbEstadoDG.SelectedItem as string;
                List<PedidoDG> lLstPedidosDG = gObjLogicaPedidoDG.FncListarPedidosDG(txtBuscarDG.Text, lStrEstadoDG);
                dgvPedidosDG.DataSource = null;
                dgvPedidosDG.DataSource = lLstPedidosDG;

                // Por cobrar: saldo de los pedidos que siguen activos
                decimal lDcmPorCobrarDG = lLstPedidosDG
                    .Where(lObjPedidoDG => lObjPedidoDG.gStrEstadoDG != PedidoDG.EstadoCanceladoDG && lObjPedidoDG.gStrEstadoDG != PedidoDG.EstadoCotizacionDG)
                    .Sum(lObjPedidoDG => lObjPedidoDG.gDcmSaldoDG);
                int lIntCotizacionesDG = lLstPedidosDG.Count(lObjPedidoDG => lObjPedidoDG.gStrEstadoDG == PedidoDG.EstadoCotizacionDG);
                lblResumenDG.Text = lLstPedidosDG.Count + " pedidos · " + lIntCotizacionesDG + " cotizaciones por responder · Por cobrar: Q" + lDcmPorCobrarDG.ToString("N2");
                btnAbrirDG.Enabled = lLstPedidosDG.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudieron cargar los pedidos. Revise la conexión a la base de datos.", "Cubito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubAbrirPedidoDG(int pIntIdPedidoDG)
        {
            using (frmPedidoDG lObjFormularioDG = new frmPedidoDG(pIntIdPedidoDG))
            {
                lObjFormularioDG.ShowDialog(this);
                if (lObjFormularioDG.gBlnSeGuardoAlgoDG) SubCargarPedidosDG();
            }
        }

        // El estado se pinta con el mismo color que en la pantalla del pedido
        private void SubDgvPedidosCellFormattingDG(object pObjSenderDG, DataGridViewCellFormattingEventArgs pObjEventoDG)
        {
            if (pObjEventoDG.RowIndex < 0 || dgvPedidosDG.Columns[pObjEventoDG.ColumnIndex] != colEstadoDG) return;
            switch (pObjEventoDG.Value as string)
            {
                case PedidoDG.EstadoAprobadoDG: pObjEventoDG.CellStyle.BackColor = Color.FromArgb(204, 231, 245); break;
                case PedidoDG.EstadoEnProduccionDG: pObjEventoDG.CellStyle.BackColor = Color.FromArgb(248, 209, 228); break;
                case PedidoDG.EstadoListoDG: pObjEventoDG.CellStyle.BackColor = Color.FromArgb(255, 236, 179); break;
                case PedidoDG.EstadoEntregadoDG: pObjEventoDG.CellStyle.BackColor = Color.FromArgb(205, 238, 221); break;
                case PedidoDG.EstadoCanceladoDG: pObjEventoDG.CellStyle.BackColor = Color.FromArgb(225, 225, 225); break;
                default: pObjEventoDG.CellStyle.BackColor = Color.FromArgb(236, 237, 242); break;
            }
        }

        private void SubTxtBuscarTextChangedDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubCargarPedidosDG(); }

        private void SubCmbEstadoSelectedIndexChangedDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubCargarPedidosDG(); }

        private void SubBtnNuevoClickDG(object pObjSenderDG, EventArgs pObjEventoDG) { SubAbrirPedidoDG(0); }

        private void SubBtnAbrirClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            PedidoDG lObjPedidoDG = dgvPedidosDG.CurrentRow?.DataBoundItem as PedidoDG;
            if (lObjPedidoDG != null) SubAbrirPedidoDG(lObjPedidoDG.gIntIdPedidoDG);
        }

        private void SubDgvPedidosCellDoubleClickDG(object pObjSenderDG, DataGridViewCellEventArgs pObjEventoDG)
        {
            if (pObjEventoDG.RowIndex >= 0) SubBtnAbrirClickDG(pObjSenderDG, pObjEventoDG);
        }

        private void SubBtnCerrarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            Close();
        }
    }
}
