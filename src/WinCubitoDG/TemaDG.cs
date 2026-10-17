using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace WinCubitoDG
{
    public enum EstiloBotonDG { Secundario, Primario, Peligro }

    // Íconos de la fuente de Windows (Segoe Fluent Icons en Windows 11, Segoe MDL2 Assets en Windows 10).
    // Son gratuitos, vienen con el sistema y no hay que distribuir imágenes.
    public static class IconoDG
    {
        public const string AgregarDG = "";
        public const string EditarDG = "";
        public const string GuardarDG = "";
        public const string EliminarDG = "";
        public const string CerrarDG = "";
        public const string BuscarDG = "";
        public const string ClientesDG = "";
        public const string UsuarioDG = "";
        public const string InventarioDG = "";
        public const string PedidosDG = "";
        public const string PagosDG = "";
        public const string GastosDG = "";
        public const string ReportesDG = "";
        public const string SalirDG = "";
        public const string CandadoDG = "";
        public const string KardexDG = "";
        public const string MovimientoDG = "";
        public const string AlertaDG = "";
        public const string AprobarDG = "";
        public const string ProduccionDG = "";
        public const string ListoDG = "";
        public const string EntregarDG = "";
        public const string AbrirDG = "";
        public const string CalendarioDG = "";
    }

    // Colores, fuentes y estilos comunes. Los colores son los mismos del portal web (sitioDG.css).
    public static class TemaDG
    {
        public static readonly Color gObjTintaDG = Color.FromArgb(0x1E, 0x21, 0x30);
        public static readonly Color gObjTinta2DG = Color.FromArgb(0x3A, 0x3F, 0x55);
        public static readonly Color gObjTextoSuaveDG = Color.FromArgb(0x6B, 0x70, 0x85);
        public static readonly Color gObjPapelDG = Color.FromArgb(0xF2, 0xF3, 0xF7);
        public static readonly Color gObjBordeDG = Color.FromArgb(0xD5, 0xD8, 0xE2);
        public static readonly Color gObjLineaDG = Color.FromArgb(0xE8, 0xEA, 0xF0);
        public static readonly Color gObjHoverDG = Color.FromArgb(0xF5, 0xF6, 0xFA);
        public static readonly Color gObjMagentaDG = Color.FromArgb(0xD6, 0x00, 0x6F);
        public static readonly Color gObjMagentaOscuroDG = Color.FromArgb(0xB0, 0x00, 0x5B);
        public static readonly Color gObjCianDG = Color.FromArgb(0x00, 0x89, 0xC7);
        public static readonly Color gObjCianSuaveDG = Color.FromArgb(0xE1, 0xF1, 0xFA);
        public static readonly Color gObjAmarilloDG = Color.FromArgb(0xF2, 0xB2, 0x00);
        public static readonly Color gObjVerdeDG = Color.FromArgb(0x1B, 0x9E, 0x6A);
        public static readonly Color gObjRojoDG = Color.FromArgb(0xC6, 0x28, 0x28);
        public static readonly Color gObjDeshabilitadoDG = Color.FromArgb(0xE6, 0xE8, 0xEF);

        public static readonly string gStrFuenteIconosDG = FncFuenteIconosDG();

        private static string FncFuenteIconosDG()
        {
            using (InstalledFontCollection lObjFuentesDG = new InstalledFontCollection())
            {
                foreach (FontFamily lObjFamiliaDG in lObjFuentesDG.Families)
                    if (lObjFamiliaDG.Name == "Segoe Fluent Icons") return lObjFamiliaDG.Name;
            }
            return "Segoe MDL2 Assets";
        }

        // Dibuja un ícono de la fuente como imagen del tamaño y color indicados
        public static Bitmap FncIconoDG(string pStrGlifoDG, int pIntTamanoDG, Color pObjColorDG)
        {
            Bitmap lObjImagenDG = new Bitmap(pIntTamanoDG, pIntTamanoDG);
            using (Graphics lObjGraficoDG = Graphics.FromImage(lObjImagenDG))
            using (Font lObjFuenteDG = new Font(gStrFuenteIconosDG, pIntTamanoDG * 0.75f, GraphicsUnit.Pixel))
            using (SolidBrush lObjPincelDG = new SolidBrush(pObjColorDG))
            using (StringFormat lObjFormatoDG = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                lObjGraficoDG.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                lObjGraficoDG.DrawString(pStrGlifoDG, lObjFuenteDG, lObjPincelDG, new RectangleF(0, 0, pIntTamanoDG, pIntTamanoDG), lObjFormatoDG);
            }
            return lObjImagenDG;
        }

        // Rectángulo con esquinas redondeadas para las tarjetas
        public static GraphicsPath FncRectanguloRedondeadoDG(Rectangle pObjRectanguloDG, int pIntRadioDG)
        {
            int lIntDiametroDG = pIntRadioDG * 2;
            GraphicsPath lObjRutaDG = new GraphicsPath();
            lObjRutaDG.AddArc(pObjRectanguloDG.X, pObjRectanguloDG.Y, lIntDiametroDG, lIntDiametroDG, 180, 90);
            lObjRutaDG.AddArc(pObjRectanguloDG.Right - lIntDiametroDG, pObjRectanguloDG.Y, lIntDiametroDG, lIntDiametroDG, 270, 90);
            lObjRutaDG.AddArc(pObjRectanguloDG.Right - lIntDiametroDG, pObjRectanguloDG.Bottom - lIntDiametroDG, lIntDiametroDG, lIntDiametroDG, 0, 90);
            lObjRutaDG.AddArc(pObjRectanguloDG.X, pObjRectanguloDG.Bottom - lIntDiametroDG, lIntDiametroDG, lIntDiametroDG, 90, 90);
            lObjRutaDG.CloseFigure();
            return lObjRutaDG;
        }

        // ---------------- Aplicar el tema ----------------

        // Se llama una vez en el constructor de cada formulario, después de InitializeComponent
        public static void SubAplicarTemaDG(Form pObjFormularioDG)
        {
            pObjFormularioDG.BackColor = gObjPapelDG;
            pObjFormularioDG.ForeColor = gObjTintaDG;
            SubEstilizarControlesDG(pObjFormularioDG.Controls);
        }

        private static void SubEstilizarControlesDG(Control.ControlCollection pLstControlesDG)
        {
            foreach (Control lObjControlDG in pLstControlesDG)
            {
                if (lObjControlDG is Button lObjBotonDG) SubBotonDG(lObjBotonDG, EstiloBotonDG.Secundario, null);
                else if (lObjControlDG is DataGridView lObjGrillaDG) SubGrillaDG(lObjGrillaDG);
                else if (lObjControlDG is TextBox lObjTextoDG) { lObjTextoDG.BorderStyle = BorderStyle.FixedSingle; lObjTextoDG.ForeColor = gObjTintaDG; }
                else if (lObjControlDG is NumericUpDown lObjNumeroDG) { lObjNumeroDG.BorderStyle = BorderStyle.FixedSingle; lObjNumeroDG.ForeColor = gObjTintaDG; }
                else if (lObjControlDG is GroupBox lObjGrupoDG) lObjGrupoDG.ForeColor = gObjTinta2DG;
                else if (lObjControlDG is Label lObjEtiquetaDG && lObjEtiquetaDG.ForeColor == SystemColors.GrayText)
                    lObjEtiquetaDG.ForeColor = gObjTextoSuaveDG;   // el resto hereda la tinta del formulario

                if (lObjControlDG.HasChildren && !(lObjControlDG is DataGridView) && !(lObjControlDG is NumericUpDown))
                    SubEstilizarControlesDG(lObjControlDG.Controls);
            }
        }

        // Botón plano con borde fino; el principal va en magenta (igual que el portal)
        public static void SubBotonDG(Button pObjBotonDG, EstiloBotonDG pObjEstiloDG, string pStrIconoDG)
        {
            pObjBotonDG.FlatStyle = FlatStyle.Flat;
            pObjBotonDG.FlatAppearance.BorderSize = 1;
            pObjBotonDG.Cursor = Cursors.Hand;
            pObjBotonDG.Font = new Font("Segoe UI Semibold", 9F);
            pObjBotonDG.UseVisualStyleBackColor = false;
            pObjBotonDG.Tag = pObjEstiloDG;

            Color lObjTextoDG;
            switch (pObjEstiloDG)
            {
                case EstiloBotonDG.Primario:
                    lObjTextoDG = Color.White;
                    pObjBotonDG.FlatAppearance.MouseOverBackColor = gObjMagentaOscuroDG;
                    pObjBotonDG.FlatAppearance.MouseDownBackColor = gObjMagentaOscuroDG;
                    break;
                case EstiloBotonDG.Peligro:
                    lObjTextoDG = gObjRojoDG;
                    pObjBotonDG.FlatAppearance.MouseOverBackColor = Color.FromArgb(0xFD, 0xEC, 0xEC);
                    pObjBotonDG.FlatAppearance.MouseDownBackColor = Color.FromArgb(0xFA, 0xDA, 0xDA);
                    break;
                default:
                    lObjTextoDG = gObjTintaDG;
                    pObjBotonDG.FlatAppearance.MouseOverBackColor = gObjHoverDG;
                    pObjBotonDG.FlatAppearance.MouseDownBackColor = gObjLineaDG;
                    break;
            }
            pObjBotonDG.ForeColor = lObjTextoDG;

            if (pStrIconoDG != null)
            {
                pObjBotonDG.Image = FncIconoDG(pStrIconoDG, 16, lObjTextoDG);
                pObjBotonDG.ImageAlign = ContentAlignment.MiddleCenter;
                pObjBotonDG.TextAlign = ContentAlignment.MiddleCenter;
                pObjBotonDG.TextImageRelation = TextImageRelation.ImageBeforeText;
            }

            pObjBotonDG.EnabledChanged -= SubBotonEnabledChangedDG;
            pObjBotonDG.EnabledChanged += SubBotonEnabledChangedDG;
            SubColorearBotonDG(pObjBotonDG);
        }

        private static void SubBotonEnabledChangedDG(object pObjSenderDG, EventArgs pObjEventoDG)
        {
            SubColorearBotonDG((Button)pObjSenderDG);
        }

        // Un botón deshabilitado se ve gris para que no parezca que se puede usar
        private static void SubColorearBotonDG(Button pObjBotonDG)
        {
            EstiloBotonDG lObjEstiloDG = pObjBotonDG.Tag is EstiloBotonDG ? (EstiloBotonDG)pObjBotonDG.Tag : EstiloBotonDG.Secundario;
            if (!pObjBotonDG.Enabled)
            {
                pObjBotonDG.BackColor = gObjDeshabilitadoDG;
                pObjBotonDG.FlatAppearance.BorderColor = gObjDeshabilitadoDG;
                return;
            }
            switch (lObjEstiloDG)
            {
                case EstiloBotonDG.Primario:
                    pObjBotonDG.BackColor = gObjMagentaDG;
                    pObjBotonDG.FlatAppearance.BorderColor = gObjMagentaDG;
                    break;
                case EstiloBotonDG.Peligro:
                    pObjBotonDG.BackColor = Color.White;
                    pObjBotonDG.FlatAppearance.BorderColor = Color.FromArgb(0xEB, 0xB4, 0xB4);
                    break;
                default:
                    pObjBotonDG.BackColor = Color.White;
                    pObjBotonDG.FlatAppearance.BorderColor = gObjBordeDG;
                    break;
            }
        }

        // Grilla limpia: sin líneas verticales, encabezado claro, filas más altas y selección suave
        public static void SubGrillaDG(DataGridView pObjGrillaDG)
        {
            pObjGrillaDG.BorderStyle = BorderStyle.None;
            pObjGrillaDG.BackgroundColor = Color.White;
            pObjGrillaDG.GridColor = gObjLineaDG;
            pObjGrillaDG.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            pObjGrillaDG.EnableHeadersVisualStyles = false;
            pObjGrillaDG.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            pObjGrillaDG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            pObjGrillaDG.ColumnHeadersHeight = 36;
            pObjGrillaDG.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0xF7, 0xF8, 0xFB);
            pObjGrillaDG.ColumnHeadersDefaultCellStyle.ForeColor = gObjTextoSuaveDG;
            pObjGrillaDG.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0xF7, 0xF8, 0xFB);
            pObjGrillaDG.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);
            pObjGrillaDG.ColumnHeadersDefaultCellStyle.Padding = new Padding(2, 0, 2, 0);
            pObjGrillaDG.RowTemplate.Height = 32;
            pObjGrillaDG.DefaultCellStyle.ForeColor = gObjTintaDG;
            pObjGrillaDG.DefaultCellStyle.SelectionBackColor = gObjCianSuaveDG;
            pObjGrillaDG.DefaultCellStyle.SelectionForeColor = gObjTintaDG;
            pObjGrillaDG.DefaultCellStyle.Padding = new Padding(2, 0, 2, 0);
            pObjGrillaDG.RowHeadersVisible = false;
        }
    }
}
