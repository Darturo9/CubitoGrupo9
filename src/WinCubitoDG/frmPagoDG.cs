using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Pagos de un pedido: historial, saldo y registro de anticipos o del pago final
    public partial class frmPagoDG : Form
    {
        private readonly LogicaPagoDG gObjLogicaPagoDG = new LogicaPagoDG();
        private readonly LogicaPedidoDG gObjLogicaPedidoDG = new LogicaPedidoDG();
        private readonly int gIntIdPedidoDG;
        private PedidoDG gObjPedidoDG;

        // Indica a quien abrió el formulario si debe refrescarse al cerrar
        public bool gBlnSeGuardoAlgoDG { get; private set; }

        public frmPagoDG(int pIntIdPedidoDG)
        {
            InitializeComponent();
            TemaDG.SubAplicarTemaDG(this);
            TemaDG.SubBotonDG(btnRegistrarDG, EstiloBotonDG.Primario, IconoDG.PagosDG);
            TemaDG.SubBotonDG(btnEliminarPagoDG, EstiloBotonDG.Peligro, IconoDG.EliminarDG);
            dgvPagosDG.AutoGenerateColumns = false;
            gIntIdPedidoDG = pIntIdPedidoDG;
        }

        private void SubFrmPagoLoadDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            cmbMetodoDG.Items.AddRange(LogicaPagoDG.gArrMetodosDG);
            cmbMetodoDG.SelectedIndex = 0;
            try
            {
                SubCargarDG();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudieron cargar los pagos. Revise la conexión a la base de datos.", "Cubito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        // Lee el pedido y sus pagos de la base y los muestra
        private void SubCargarDG()
        {
            gObjPedidoDG = gObjLogicaPedidoDG.FncBuscarPedidoDG(gIntIdPedidoDG);
            if (gObjPedidoDG == null) throw new InvalidOperationException("El pedido no existe.");
            List<PagoDG> lLstPagosDG = gObjLogicaPagoDG.FncListarPagosDG(gIntIdPedidoDG);

            Text = "Pagos del pedido " + gObjPedidoDG.gStrCodigoDG;
            lblCodigoDG.Text = gObjPedidoDG.gStrCodigoDG;
            lblClienteDG.Text = gObjPedidoDG.gStrNombreClienteDG + " · " + gObjPedidoDG.gStrEstadoDG;
            lblTotalDG.Text = "Total\nQ" + gObjPedidoDG.gDcmTotalDG.ToString("N2");
            lblPagadoDG.Text = "Pagado\nQ" + gObjPedidoDG.gDcmTotalPagadoDG.ToString("N2");
            lblSaldoDG.Text = "Saldo\nQ" + gObjPedidoDG.gDcmSaldoDG.ToString("N2");
            lblSaldoDG.ForeColor = gObjPedidoDG.gDcmSaldoDG > 0 ? Color.Firebrick : Color.SeaGreen;

            dgvPagosDG.DataSource = null;
            dgvPagosDG.DataSource = lLstPagosDG;

            bool lBlnAceptaPagosDG = LogicaPagoDG.FncAceptaPagosDG(gObjPedidoDG.gStrEstadoDG);
            bool lBlnHaySaldoDG = gObjPedidoDG.gDcmSaldoDG > 0;
            gpbNuevoPagoDG.Enabled = lBlnAceptaPagosDG && lBlnHaySaldoDG;
            btnEliminarPagoDG.Enabled = lBlnAceptaPagosDG && lLstPagosDG.Count > 0;

            // El monto sugerido es todo el saldo; para un anticipo basta con escribir otro valor
            nudMontoDG.Maximum = lBlnHaySaldoDG ? gObjPedidoDG.gDcmSaldoDG : 0;
            nudMontoDG.Value = nudMontoDG.Maximum;

            lblMensajeDG.ForeColor = SystemColors.GrayText;
            if (gObjPedidoDG.gStrEstadoDG == PedidoDG.EstadoCotizacionDG)
                lblMensajeDG.Text = "Primero apruebe la cotización; después se pueden registrar anticipos.";
            else if (!lBlnAceptaPagosDG)
                lblMensajeDG.Text = "Un pedido " + gObjPedidoDG.gStrEstadoDG.ToLower() + " ya no recibe pagos.";
            else if (!lBlnHaySaldoDG)
                lblMensajeDG.Text = "Pedido pagado por completo.";
            else
                lblMensajeDG.Text = string.Empty;
        }

        private void SubBtnRegistrarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            PagoDG lObjPagoDG = new PagoDG
            {
                gIntIdPedidoDG = gIntIdPedidoDG,
                gDcmMontoDG = nudMontoDG.Value,
                gStrMetodoDG = cmbMetodoDG.SelectedItem as string
            };

            string lStrMensajeDG;
            try
            {
                if (!gObjLogicaPagoDG.FncRegistrarPagoDG(lObjPagoDG, out lStrMensajeDG))
                {
                    lblMensajeDG.ForeColor = Color.Firebrick;
                    lblMensajeDG.Text = lStrMensajeDG;
                    nudMontoDG.Focus();
                    return;
                }
                gBlnSeGuardoAlgoDG = true;
                SubCargarDG();
            }
            catch (Exception)
            {
                lblMensajeDG.ForeColor = Color.Firebrick;
                lblMensajeDG.Text = "No se pudo registrar el pago. Revise la conexión a la base de datos.";
                return;
            }

            lblMensajeDG.ForeColor = Color.SeaGreen;
            lblMensajeDG.Text = lStrMensajeDG;
        }

        private void SubBtnEliminarPagoClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            PagoDG lObjPagoDG = dgvPagosDG.CurrentRow?.DataBoundItem as PagoDG;
            if (lObjPagoDG == null) return;
            if (MessageBox.Show(this, "¿Eliminar el pago de Q" + lObjPagoDG.gDcmMontoDG.ToString("N2") + " del " +
                    lObjPagoDG.gDtmFechaDG.ToString("dd/MM/yyyy") + "?\n\nÚselo solo si el pago se registró por error.", "Cubito",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            string lStrMensajeDG;
            try
            {
                if (!gObjLogicaPagoDG.FncEliminarPagoDG(lObjPagoDG, out lStrMensajeDG))
                {
                    lblMensajeDG.ForeColor = Color.Firebrick;
                    lblMensajeDG.Text = lStrMensajeDG;
                    return;
                }
                gBlnSeGuardoAlgoDG = true;
                SubCargarDG();
            }
            catch (Exception)
            {
                lblMensajeDG.ForeColor = Color.Firebrick;
                lblMensajeDG.Text = "No se pudo eliminar el pago. Revise la conexión a la base de datos.";
                return;
            }

            lblMensajeDG.ForeColor = Color.SeaGreen;
            lblMensajeDG.Text = lStrMensajeDG;
        }

        // Al entrar al monto se selecciona todo para poder escribir encima
        private void SubNudMontoEnterDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            nudMontoDG.Select(0, nudMontoDG.Text.Length);
        }

        private void SubBtnCerrarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            Close();
        }
    }
}
