using System;
using System.Windows.Forms;
using CapaEntidadesDG;
using CapaLogicaNegocioDG;

namespace WinCubitoDG
{
    // Registrar una entrada, salida o ajuste de un artículo
    public partial class frmMovimientoDG : Form
    {
        // Opciones que ve el usuario; los ajustes se guardan con signo según la opción
        private const string gStrOpcionEntradaDG = "Entrada (compra o reposición)";
        private const string gStrOpcionSalidaDG = "Salida (uso o venta)";
        private const string gStrOpcionAumentarDG = "Ajuste: aumentar (conteo físico)";
        private const string gStrOpcionDisminuirDG = "Ajuste: disminuir (merma o daño)";

        private readonly LogicaInventarioDG gObjLogicaInventarioDG = new LogicaInventarioDG();
        private readonly ArticuloDG gObjArticuloDG;

        public frmMovimientoDG(ArticuloDG pObjArticuloDG)
        {
            InitializeComponent();
            TemaDG.SubAplicarTemaDG(this);
            TemaDG.SubBotonDG(btnGuardarDG, EstiloBotonDG.Primario, IconoDG.GuardarDG);
            gObjArticuloDG = pObjArticuloDG;

            string lStrDetalleDG = pObjArticuloDG.gStrTallaDG.Length > 0 ? " · Talla " + pObjArticuloDG.gStrTallaDG : string.Empty;
            if (pObjArticuloDG.gStrColorDG.Length > 0) lStrDetalleDG += " · " + pObjArticuloDG.gStrColorDG;
            lblArticuloDG.Text = pObjArticuloDG.gStrCodigoDG + " - " + pObjArticuloDG.gStrNombreDG + lStrDetalleDG;
            lblStockActualDG.Text = "Stock actual: " + pObjArticuloDG.gDcmStockDG.ToString("0.##") + " " + pObjArticuloDG.gStrUnidadDG +
                "   ·   Mínimo: " + pObjArticuloDG.gDcmStockMinimoDG.ToString("0.##");
            lblUnidadDG.Text = pObjArticuloDG.gStrUnidadDG;

            // Las prendas y artículos por unidad no llevan decimales
            nudCantidadDG.DecimalPlaces = pObjArticuloDG.gBlnUsaCantidadEnteraDG ? 0 : 2;
            nudCantidadDG.Increment = 1;

            cmbTipoDG.Items.AddRange(new object[] { gStrOpcionEntradaDG, gStrOpcionSalidaDG, gStrOpcionAumentarDG, gStrOpcionDisminuirDG });
            cmbTipoDG.SelectedIndex = 0;
        }

        private void SubBtnGuardarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            lblMensajeDG.Text = string.Empty;
            string lStrOpcionDG = cmbTipoDG.SelectedItem as string;
            MovimientoInventarioDG lObjMovimientoDG = new MovimientoInventarioDG
            {
                gIntIdArticuloDG = gObjArticuloDG.gIntIdArticuloDG,
                gStrMotivoDG = txtMotivoDG.Text,
                gDcmCantidadDG = nudCantidadDG.Value
            };

            if (lStrOpcionDG == gStrOpcionEntradaDG) lObjMovimientoDG.gStrTipoDG = MovimientoInventarioDG.TipoEntradaDG;
            else if (lStrOpcionDG == gStrOpcionSalidaDG) lObjMovimientoDG.gStrTipoDG = MovimientoInventarioDG.TipoSalidaDG;
            else
            {
                lObjMovimientoDG.gStrTipoDG = MovimientoInventarioDG.TipoAjusteDG;
                if (lStrOpcionDG == gStrOpcionDisminuirDG) lObjMovimientoDG.gDcmCantidadDG = -nudCantidadDG.Value;
            }

            string lStrMensajeDG;
            try
            {
                if (!gObjLogicaInventarioDG.FncRegistrarMovimientoDG(lObjMovimientoDG, out lStrMensajeDG))
                {
                    lblMensajeDG.Text = lStrMensajeDG;
                    return;
                }
                MessageBox.Show(this, lStrMensajeDG, "Cubito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                lblMensajeDG.Text = "No se pudo registrar el movimiento. Revise la conexión a la base de datos.";
            }
        }

        private void SubBtnCancelarClickDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
