using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Lista de clientes con búsqueda y el historial de pedidos del cliente seleccionado
    public partial class frmClientesDG : Form
    {
        private readonly LogicaClienteDG gObjLogicaClienteDG = new LogicaClienteDG();

        public frmClientesDG()
        {
            InitializeComponent();
            TemaDG.SubAplicarTemaDG(this);
            TemaDG.SubBotonDG(btnNuevoDG, EstiloBotonDG.Primario, IconoDG.AgregarDG);
            TemaDG.SubBotonDG(btnEditarDG, EstiloBotonDG.Secundario, IconoDG.EditarDG);
            TemaDG.SubBotonDG(btnDesactivarDG, EstiloBotonDG.Peligro, IconoDG.EliminarDG);
            dgvClientesDG.AutoGenerateColumns = false;
            dgvHistorialDG.AutoGenerateColumns = false;
        }

        private void SubFrmClientesLoadDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubCargarClientesDG(0);
        }

        // Recarga la lista y vuelve a seleccionar el cliente indicado (0 = el primero)
        private void SubCargarClientesDG(int pIntIdSeleccionarDG)
        {
            try
            {
                List<ClienteDG> lLstClientesDG = gObjLogicaClienteDG.FncBuscarClientesDG(txtBuscarDG.Text);
                dgvClientesDG.DataSource = null;
                dgvClientesDG.DataSource = lLstClientesDG;
                lblResumenDG.Text = lLstClientesDG.Count == 1 ? "1 cliente" : lLstClientesDG.Count + " clientes";

                foreach (DataGridViewRow lObjFilaDG in dgvClientesDG.Rows)
                {
                    if (((ClienteDG)lObjFilaDG.DataBoundItem).gIntIdClienteDG == pIntIdSeleccionarDG)
                    {
                        dgvClientesDG.CurrentCell = lObjFilaDG.Cells[0];
                        break;
                    }
                }
                bool lBlnHayDG = lLstClientesDG.Count > 0;
                btnEditarDG.Enabled = lBlnHayDG;
                btnDesactivarDG.Enabled = lBlnHayDG;
                SubCargarHistorialDG();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudieron cargar los clientes. Revise la conexión a la base de datos.", "Cubito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ClienteDG FncClienteSeleccionadoDG()
        {
            return dgvClientesDG.CurrentRow?.DataBoundItem as ClienteDG;
        }

        // Pedidos del cliente seleccionado con lo que ha comprado y lo que debe
        private void SubCargarHistorialDG()
        {
            ClienteDG lObjClienteDG = FncClienteSeleccionadoDG();
            if (lObjClienteDG == null)
            {
                lblHistorialDG.Text = "Historial";
                lblHistorialResumenDG.Text = string.Empty;
                dgvHistorialDG.DataSource = null;
                return;
            }

            try
            {
                List<PedidoDG> lLstPedidosDG = gObjLogicaClienteDG.FncHistorialClienteDG(lObjClienteDG.gIntIdClienteDG);
                dgvHistorialDG.DataSource = lLstPedidosDG;
                lblHistorialDG.Text = "Historial de " + lObjClienteDG.gStrNombreDG;

                // Comprado = pedidos que no se cancelaron ni se quedaron en cotización
                decimal lDcmCompradoDG = lLstPedidosDG
                    .Where(lObjPedidoDG => LogicaPagoDG.FncAceptaPagosDG(lObjPedidoDG.gStrEstadoDG) || lObjPedidoDG.gStrEstadoDG == PedidoDG.EstadoEntregadoDG)
                    .Sum(lObjPedidoDG => lObjPedidoDG.gDcmTotalDG);
                decimal lDcmSaldoDG = lLstPedidosDG
                    .Where(lObjPedidoDG => LogicaPagoDG.FncAceptaPagosDG(lObjPedidoDG.gStrEstadoDG))
                    .Sum(lObjPedidoDG => lObjPedidoDG.gDcmSaldoDG);
                lblHistorialResumenDG.Text = (lLstPedidosDG.Count == 1 ? "1 pedido" : lLstPedidosDG.Count + " pedidos") +
                    " · Comprado: Q" + lDcmCompradoDG.ToString("N2") + " · Debe: Q" + lDcmSaldoDG.ToString("N2");
                lblHistorialResumenDG.ForeColor = lDcmSaldoDG > 0 ? Color.Firebrick : TemaDG.gObjTextoSuaveDG;
            }
            catch (Exception)
            {
                lblHistorialResumenDG.Text = "No se pudo cargar el historial.";
            }
        }

        private void SubDgvClientesSelectionChangedDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubCargarHistorialDG();
        }

        private void SubTxtBuscarTextChangedDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubCargarClientesDG(0);
        }

        private void SubAbrirClienteDG(ClienteDG pObjClienteDG)
        {
            using (frmClienteDG lObjFormularioDG = new frmClienteDG(pObjClienteDG))
            {
                if (lObjFormularioDG.ShowDialog(this) == DialogResult.OK)
                    SubCargarClientesDG(lObjFormularioDG.gIntIdClienteDG);
            }
        }

        private void SubBtnNuevoClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubAbrirClienteDG(null);
        }

        private void SubBtnEditarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            ClienteDG lObjClienteDG = FncClienteSeleccionadoDG();
            if (lObjClienteDG != null) SubAbrirClienteDG(lObjClienteDG);
        }

        private void SubDgvClientesCellDoubleClickDG(object pObjSenderDG, DataGridViewCellEventArgs pObjEventoDG)
        {
            if (pObjEventoDG.RowIndex >= 0) SubBtnEditarClickDG(pObjSenderDG, pObjEventoDG);
        }

        private void SubBtnDesactivarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            ClienteDG lObjClienteDG = FncClienteSeleccionadoDG();
            if (lObjClienteDG == null) return;
            if (MessageBox.Show(this, "¿Desactivar a " + lObjClienteDG.gStrNombreDG + "?\n\nYa no aparecerá en las listas, pero sus pedidos y pagos se conservan.",
                    "Cubito", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            string lStrMensajeDG;
            try
            {
                bool lBlnOkDG = gObjLogicaClienteDG.FncDesactivarClienteDG(lObjClienteDG, out lStrMensajeDG);
                MessageBox.Show(this, lStrMensajeDG, "Cubito", MessageBoxButtons.OK, lBlnOkDG ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (lBlnOkDG) SubCargarClientesDG(0);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudo desactivar el cliente. Revise la conexión a la base de datos.", "Cubito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Estado del pedido con el mismo color que en la lista de pedidos
        private void SubDgvHistorialCellFormattingDG(object pObjSenderDG, DataGridViewCellFormattingEventArgs pObjEventoDG)
        {
            if (pObjEventoDG.RowIndex < 0 || dgvHistorialDG.Columns[pObjEventoDG.ColumnIndex] != colHisEstadoDG) return;
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

        private void SubBtnCerrarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            Close();
        }
    }
}
