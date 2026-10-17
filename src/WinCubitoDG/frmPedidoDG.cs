using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Crear, editar y avanzar un pedido por sus estados
    public partial class frmPedidoDG : Form
    {
        private readonly LogicaPedidoDG gObjLogicaPedidoDG = new LogicaPedidoDG();
        private readonly LogicaClienteDG gObjLogicaClienteDG = new LogicaClienteDG();
        private readonly BindingList<DetallePedidoDG> gLstLineasDG = new BindingList<DetallePedidoDG>();
        private PedidoDG gObjPedidoDG;
        private bool gBlnHayCambiosDG;
        private bool gBlnCargandoDG;

        // Indica a la lista de pedidos si debe refrescarse al cerrar
        public bool gBlnSeGuardoAlgoDG { get; private set; }

        public frmPedidoDG(int pIntIdPedidoDG)
        {
            InitializeComponent();
            TemaDG.SubAplicarTemaDG(this);
            TemaDG.SubBotonDG(btnAgregarLineaDG, EstiloBotonDG.Secundario, null);
            TemaDG.SubBotonDG(btnQuitarLineaDG, EstiloBotonDG.Secundario, IconoDG.EliminarDG);
            TemaDG.SubBotonDG(btnGuardarDG, EstiloBotonDG.Primario, IconoDG.GuardarDG);
            TemaDG.SubBotonDG(btnPagosDG, EstiloBotonDG.Secundario, IconoDG.PagosDG);
            TemaDG.SubBotonDG(btnAprobarDG, EstiloBotonDG.Secundario, IconoDG.AprobarDG);
            TemaDG.SubBotonDG(btnProduccionDG, EstiloBotonDG.Secundario, IconoDG.ProduccionDG);
            TemaDG.SubBotonDG(btnListoDG, EstiloBotonDG.Secundario, IconoDG.ListoDG);
            TemaDG.SubBotonDG(btnEntregarDG, EstiloBotonDG.Secundario, IconoDG.EntregarDG);
            TemaDG.SubBotonDG(btnCancelarPedidoDG, EstiloBotonDG.Peligro, IconoDG.CerrarDG);
            dgvDetalleDG.AutoGenerateColumns = false;
            dgvDetalleDG.DataSource = gLstLineasDG;
            gObjPedidoDG = new PedidoDG { gIntIdPedidoDG = pIntIdPedidoDG };
        }

        private void SubFrmPedidoLoadDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            try
            {
                cmbTecnicaDG.Items.AddRange(LogicaPedidoDG.gArrTecnicasDG);
                cmbTecnicaDG.SelectedIndex = 0;

                cmbClienteDG.DisplayMember = "gStrDescripcionDG";
                cmbClienteDG.ValueMember = "gIntIdClienteDG";
                cmbClienteDG.DataSource = gObjLogicaClienteDG.FncBuscarClientesDG(string.Empty);

                SubCargarPrendasDG();
                if (gObjPedidoDG.gIntIdPedidoDG > 0)
                    gObjPedidoDG = gObjLogicaPedidoDG.FncBuscarPedidoDG(gObjPedidoDG.gIntIdPedidoDG) ?? new PedidoDG();
                SubMostrarPedidoDG();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudo cargar el pedido. Revise la conexión a la base de datos.", "Cubito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        // La primera opción es "Prenda del cliente": el cliente trae la prenda y no se descuenta inventario
        private void SubCargarPrendasDG()
        {
            List<ArticuloDG> lLstPrendasDG = new List<ArticuloDG> { new ArticuloDG { gIntIdArticuloDG = 0, gStrNombreDG = "Prenda del cliente" } };
            lLstPrendasDG.AddRange(gObjLogicaPedidoDG.FncListarPrendasDG());
            cmbPrendaDG.DisplayMember = "gStrDescripcionDG";
            cmbPrendaDG.ValueMember = "gIntIdArticuloDG";
            cmbPrendaDG.DataSource = lLstPrendasDG;
        }

        // Pasa los datos del pedido a los controles
        private void SubMostrarPedidoDG()
        {
            gBlnCargandoDG = true;
            bool lBlnEsNuevoDG = gObjPedidoDG.gIntIdPedidoDG == 0;

            Text = lBlnEsNuevoDG ? "Nuevo pedido" : "Pedido " + gObjPedidoDG.gStrCodigoDG;
            lblCodigoDG.Text = lBlnEsNuevoDG ? "Nuevo pedido" : gObjPedidoDG.gStrCodigoDG;
            lblFechaDG.Text = lBlnEsNuevoDG ? string.Empty :
                "Creado el " + gObjPedidoDG.gDtmFechaPedidoDG.ToString("dd/MM/yyyy") + " · Origen: " + gObjPedidoDG.gStrOrigenDG;
            lblEstadoDG.Text = gObjPedidoDG.gStrEstadoDG;
            lblEstadoDG.BackColor = FncColorEstadoDG(gObjPedidoDG.gStrEstadoDG);

            if (lBlnEsNuevoDG) cmbClienteDG.SelectedIndex = -1;
            else cmbClienteDG.SelectedValue = gObjPedidoDG.gIntIdClienteDG;

            dtpEntregaDG.Value = gObjPedidoDG.gDtmFechaEntregaDG ?? DateTime.Today.AddDays(3);
            dtpEntregaDG.Checked = gObjPedidoDG.gDtmFechaEntregaDG.HasValue;
            txtObservacionesDG.Text = gObjPedidoDG.gStrObservacionesDG;

            gLstLineasDG.Clear();
            foreach (DetallePedidoDG lObjDetalleDG in gObjPedidoDG.gLstDetallesDG) gLstLineasDG.Add(lObjDetalleDG);

            lblMotivoCancelacionDG.Visible = gObjPedidoDG.gStrEstadoDG == PedidoDG.EstadoCanceladoDG;
            lblMotivoCancelacionDG.Text = "Motivo de cancelación: " + gObjPedidoDG.gStrMotivoCancelacionDG;

            SubAplicarEstadoDG();
            SubActualizarTotalesDG();
            gBlnHayCambiosDG = false;
            gBlnCargandoDG = false;
        }

        // Habilita la edición y los botones según el estado del pedido
        private void SubAplicarEstadoDG()
        {
            bool lBlnEditableDG = gObjPedidoDG.gIntIdPedidoDG == 0 || gObjPedidoDG.gBlnEsEditableDG;
            gpbDatosDG.Enabled = lBlnEditableDG;
            gpbLineaDG.Enabled = lBlnEditableDG;
            btnQuitarLineaDG.Enabled = lBlnEditableDG;
            btnGuardarDG.Enabled = lBlnEditableDG;
            dgvDetalleDG.ReadOnly = !lBlnEditableDG;
            colCantidadDG.ReadOnly = !lBlnEditableDG;
            colPrecioDG.ReadOnly = !lBlnEditableDG;

            List<string> lLstSiguientesDG = gObjPedidoDG.gIntIdPedidoDG == 0
                ? new List<string>()
                : gObjLogicaPedidoDG.FncEstadosSiguientesDG(gObjPedidoDG.gStrEstadoDG);
            btnAprobarDG.Visible = lLstSiguientesDG.Contains(PedidoDG.EstadoAprobadoDG);
            btnProduccionDG.Visible = lLstSiguientesDG.Contains(PedidoDG.EstadoEnProduccionDG);
            btnListoDG.Visible = lLstSiguientesDG.Contains(PedidoDG.EstadoListoDG);
            btnEntregarDG.Visible = lLstSiguientesDG.Contains(PedidoDG.EstadoEntregadoDG);
            btnCancelarPedidoDG.Visible = lLstSiguientesDG.Contains(PedidoDG.EstadoCanceladoDG);

            // Los pagos se ven desde que el pedido se aprueba (también el historial de los entregados o cancelados)
            btnPagosDG.Visible = gObjPedidoDG.gIntIdPedidoDG != 0 && gObjPedidoDG.gStrEstadoDG != PedidoDG.EstadoCotizacionDG;
        }

        private void SubActualizarTotalesDG()
        {
            decimal lDcmTotalDG = gObjLogicaPedidoDG.FncCalcularTotalDG(gLstLineasDG);
            lblTotalDG.Text = "Total: Q" + lDcmTotalDG.ToString("N2");
            lblPagosDG.Text = "Pagado: Q" + gObjPedidoDG.gDcmTotalPagadoDG.ToString("N2") +
                "   ·   Saldo: Q" + (lDcmTotalDG - gObjPedidoDG.gDcmTotalPagadoDG).ToString("N2");
            dgvDetalleDG.Invalidate();
        }

        private static Color FncColorEstadoDG(string pStrEstadoDG)
        {
            switch (pStrEstadoDG)
            {
                case PedidoDG.EstadoAprobadoDG: return Color.FromArgb(204, 231, 245);
                case PedidoDG.EstadoEnProduccionDG: return Color.FromArgb(248, 209, 228);
                case PedidoDG.EstadoListoDG: return Color.FromArgb(255, 236, 179);
                case PedidoDG.EstadoEntregadoDG: return Color.FromArgb(205, 238, 221);
                case PedidoDG.EstadoCanceladoDG: return Color.FromArgb(225, 225, 225);
                default: return Color.FromArgb(236, 237, 242);
            }
        }

        // ---------------- Líneas ----------------

        private void SubBtnAgregarLineaClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            lblMensajeDG.ForeColor = Color.Firebrick;
            lblMensajeDG.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(txtDescripcionDG.Text))
            {
                lblMensajeDG.Text = "Describa el diseño de la línea (por ejemplo: logo al frente).";
                txtDescripcionDG.Focus();
                return;
            }

            ArticuloDG lObjPrendaDG = cmbPrendaDG.SelectedItem as ArticuloDG;
            gLstLineasDG.Add(new DetallePedidoDG
            {
                gStrTecnicaDG = cmbTecnicaDG.SelectedItem as string,
                gIntIdArticuloDG = lObjPrendaDG == null || lObjPrendaDG.gIntIdArticuloDG == 0 ? (int?)null : lObjPrendaDG.gIntIdArticuloDG,
                gStrPrendaDG = lObjPrendaDG == null || lObjPrendaDG.gIntIdArticuloDG == 0 ? "Prenda del cliente" : lObjPrendaDG.gStrNombreCompletoDG,
                gStrDescripcionDG = txtDescripcionDG.Text.Trim(),
                gIntCantidadDG = (int)nudCantidadDG.Value,
                gDcmPrecioUnitarioDG = nudPrecioDG.Value
            });

            txtDescripcionDG.Clear();
            nudCantidadDG.Value = 1;
            gBlnHayCambiosDG = true;
            SubActualizarTotalesDG();
            txtDescripcionDG.Focus();
        }

        private void SubBtnQuitarLineaClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            DetallePedidoDG lObjDetalleDG = dgvDetalleDG.CurrentRow?.DataBoundItem as DetallePedidoDG;
            if (lObjDetalleDG == null) return;
            gLstLineasDG.Remove(lObjDetalleDG);
            gBlnHayCambiosDG = true;
            SubActualizarTotalesDG();
        }

        // Al editar cantidad o precio en la grilla se recalcula el total
        private void SubDgvDetalleCellEndEditDG(object pObjSenderDG, DataGridViewCellEventArgs pObjEventoDG)
        {
            gBlnHayCambiosDG = true;
            SubActualizarTotalesDG();
        }

        private void SubDgvDetalleDataErrorDG(object pObjSenderDG, DataGridViewDataErrorEventArgs pObjEventoDG)
        {
            lblMensajeDG.Text = "Valor no válido: la cantidad debe ser un número entero y el precio un número.";
            pObjEventoDG.Cancel = true;
        }

        private void SubDatoCambioDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            if (!gBlnCargandoDG) gBlnHayCambiosDG = true;
        }

        // ---------------- Guardar ----------------

        private bool FncGuardarDG()
        {
            lblMensajeDG.Text = string.Empty;
            dgvDetalleDG.EndEdit();

            PedidoDG lObjPedidoDG = new PedidoDG
            {
                gIntIdPedidoDG = gObjPedidoDG.gIntIdPedidoDG,
                gStrCodigoDG = gObjPedidoDG.gStrCodigoDG,
                gStrEstadoDG = gObjPedidoDG.gStrEstadoDG,
                gStrOrigenDG = gObjPedidoDG.gStrOrigenDG,
                gDtmFechaPedidoDG = gObjPedidoDG.gDtmFechaPedidoDG,
                gIntIdClienteDG = cmbClienteDG.SelectedValue is int lIntIdClienteDG ? lIntIdClienteDG : 0,
                gDtmFechaEntregaDG = dtpEntregaDG.Checked ? dtpEntregaDG.Value.Date : (DateTime?)null,
                gStrObservacionesDG = txtObservacionesDG.Text,
                gLstDetallesDG = gLstLineasDG.ToList()
            };

            string lStrMensajeDG;
            try
            {
                if (!gObjLogicaPedidoDG.FncGuardarPedidoDG(lObjPedidoDG, out lStrMensajeDG))
                {
                    lblMensajeDG.Text = lStrMensajeDG;
                    return false;
                }
            }
            catch (Exception)
            {
                lblMensajeDG.Text = "No se pudo guardar el pedido. Revise la conexión a la base de datos.";
                return false;
            }

            // Si era nuevo, la capa de datos dejó el Id y el código generados en el objeto guardado
            gObjPedidoDG.gIntIdPedidoDG = lObjPedidoDG.gIntIdPedidoDG;
            gBlnSeGuardoAlgoDG = true;
            SubRecargarDG(lStrMensajeDG);
            return true;
        }

        // Vuelve a leer el pedido de la base para mostrar el estado y los totales reales
        private void SubRecargarDG(string pStrMensajeDG)
        {
            gObjPedidoDG = gObjLogicaPedidoDG.FncBuscarPedidoDG(gObjPedidoDG.gIntIdPedidoDG) ?? gObjPedidoDG;
            SubCargarPrendasDG();
            SubMostrarPedidoDG();
            lblMensajeDG.ForeColor = Color.SeaGreen;
            lblMensajeDG.Text = pStrMensajeDG;
        }

        private void SubBtnGuardarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            lblMensajeDG.ForeColor = Color.Firebrick;
            FncGuardarDG();
        }

        // ---------------- Estados ----------------

        private void SubCambiarEstadoDG(string pStrEstadoNuevoDG, string pStrMotivoDG)
        {
            lblMensajeDG.ForeColor = Color.Firebrick;
            // Si hay cambios sin guardar en un pedido editable, primero se guardan
            if (gBlnHayCambiosDG && gObjPedidoDG.gBlnEsEditableDG && !FncGuardarDG()) return;

            string lStrMensajeDG;
            try
            {
                if (!gObjLogicaPedidoDG.FncCambiarEstadoDG(gObjPedidoDG.gIntIdPedidoDG, pStrEstadoNuevoDG, pStrMotivoDG, out lStrMensajeDG))
                {
                    MessageBox.Show(this, lStrMensajeDG, "Cubito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudo cambiar el estado. Revise la conexión a la base de datos.", "Cubito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            gBlnSeGuardoAlgoDG = true;
            SubRecargarDG(lStrMensajeDG);
        }

        private void SubBtnAprobarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubCambiarEstadoDG(PedidoDG.EstadoAprobadoDG, null);
        }

        private void SubBtnProduccionClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            int lIntPrendasDG = gLstLineasDG.Where(lObjDetalleDG => lObjDetalleDG.gIntIdArticuloDG.HasValue).Sum(lObjDetalleDG => lObjDetalleDG.gIntCantidadDG);
            string lStrPreguntaDG = lIntPrendasDG > 0
                ? "Se descontarán " + lIntPrendasDG + " prendas del inventario y el pedido ya no se podrá editar.\n\n¿Enviar a producción?"
                : "El pedido ya no se podrá editar.\n\n¿Enviar a producción?";
            if (MessageBox.Show(this, lStrPreguntaDG, "Cubito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                SubCambiarEstadoDG(PedidoDG.EstadoEnProduccionDG, null);
        }

        private void SubBtnListoClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubCambiarEstadoDG(PedidoDG.EstadoListoDG, null);
        }

        // Si todavía hay saldo, se ofrece cobrarlo antes de entregar
        private void SubBtnEntregarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            if (gObjPedidoDG.gDcmSaldoDG > 0)
            {
                if (MessageBox.Show(this, "El cliente todavía debe Q" + gObjPedidoDG.gDcmSaldoDG.ToString("N2") +
                        ". El pedido solo se entrega pagado por completo.\n\n¿Registrar el pago ahora?", "Cubito",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                SubAbrirPagosDG();
                if (gObjPedidoDG.gDcmSaldoDG > 0) return;
            }
            SubCambiarEstadoDG(PedidoDG.EstadoEntregadoDG, null);
        }

        // ---------------- Pagos ----------------

        private void SubBtnPagosClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            lblMensajeDG.ForeColor = Color.Firebrick;
            // Los pagos se validan contra el total guardado, así que primero se guardan los cambios
            if (gBlnHayCambiosDG && gObjPedidoDG.gBlnEsEditableDG && !FncGuardarDG()) return;
            SubAbrirPagosDG();
        }

        private void SubAbrirPagosDG()
        {
            using (frmPagoDG lObjFormularioDG = new frmPagoDG(gObjPedidoDG.gIntIdPedidoDG))
            {
                lObjFormularioDG.ShowDialog(this);
                if (!lObjFormularioDG.gBlnSeGuardoAlgoDG) return;
            }
            gBlnSeGuardoAlgoDG = true;
            SubRecargarDG(string.Empty);
        }

        private void SubBtnCancelarPedidoClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            using (frmMotivoDG lObjMotivoDG = new frmMotivoDG("Cancelar pedido " + gObjPedidoDG.gStrCodigoDG,
                "¿Por qué se cancela el pedido? El motivo queda guardado."))
            {
                if (lObjMotivoDG.ShowDialog(this) == DialogResult.OK)
                    SubCambiarEstadoDG(PedidoDG.EstadoCanceladoDG, lObjMotivoDG.gStrMotivoDG);
            }
        }

        // ---------------- Cerrar ----------------

        private void SubBtnCerrarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            Close();
        }

        private void SubFrmPedidoFormClosingDG(object pObjSenderDG, FormClosingEventArgs pObjEventoDG)
        {
            if (!gBlnHayCambiosDG) return;
            DialogResult lObjRespuestaDG = MessageBox.Show(this, "Hay cambios sin guardar. ¿Desea guardarlos antes de cerrar?", "Cubito",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (lObjRespuestaDG == DialogResult.Cancel) pObjEventoDG.Cancel = true;
            else if (lObjRespuestaDG == DialogResult.Yes && !FncGuardarDG()) pObjEventoDG.Cancel = true;
        }
    }
}
