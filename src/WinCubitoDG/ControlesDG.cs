using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace WinCubitoDG
{
    // Logo de Cubito: tres puntos CMYK y el nombre
    public class MarcaDG : Control
    {
        public MarcaDG()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            Size = new Size(180, 40);
            Text = "Cubito";
        }

        protected override void OnPaint(PaintEventArgs pObjEventoDG)
        {
            Graphics lObjGraficoDG = pObjEventoDG.Graphics;
            lObjGraficoDG.SmoothingMode = SmoothingMode.AntiAlias;
            lObjGraficoDG.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            int lIntPuntoDG = Math.Max(8, Font.Height / 3);
            int lIntYDG = (Height - lIntPuntoDG) / 2;
            Color[] lArrColoresDG = { TemaDG.gObjCianDG, TemaDG.gObjMagentaDG, TemaDG.gObjAmarilloDG };
            for (int lIntIndiceDG = 0; lIntIndiceDG < lArrColoresDG.Length; lIntIndiceDG++)
            {
                using (SolidBrush lObjPincelDG = new SolidBrush(lArrColoresDG[lIntIndiceDG]))
                    lObjGraficoDG.FillEllipse(lObjPincelDG, lIntIndiceDG * (lIntPuntoDG + 4), lIntYDG, lIntPuntoDG, lIntPuntoDG);
            }

            int lIntTextoXDG = 3 * (lIntPuntoDG + 4) + 6;
            TextRenderer.DrawText(lObjGraficoDG, Text, Font, new Rectangle(lIntTextoXDG, 0, Width - lIntTextoXDG, Height), ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding);
        }
    }

    // Base de las tarjetas: fondo blanco redondeado, borde fino y resaltado al pasar el mouse
    public abstract class TarjetaBaseDG : Control
    {
        private bool gBlnSobreDG;

        [Category("Cubito")] public string gStrTituloDG { get; set; } = string.Empty;
        [Category("Cubito")] public string gStrIconoDG { get; set; } = IconoDG.PedidosDG;
        [Category("Cubito")] public Color gObjColorAcentoDG { get; set; } = TemaDG.gObjMagentaDG;

        protected TarjetaBaseDG()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw | ControlStyles.Selectable, true);
            BackColor = TemaDG.gObjPapelDG;
            Cursor = Cursors.Hand;
            TabStop = true;
        }

        protected override void OnMouseEnter(EventArgs pObjEventoDG) { gBlnSobreDG = true; Invalidate(); base.OnMouseEnter(pObjEventoDG); }
        protected override void OnMouseLeave(EventArgs pObjEventoDG) { gBlnSobreDG = false; Invalidate(); base.OnMouseLeave(pObjEventoDG); }
        protected override void OnGotFocus(EventArgs pObjEventoDG) { Invalidate(); base.OnGotFocus(pObjEventoDG); }
        protected override void OnLostFocus(EventArgs pObjEventoDG) { Invalidate(); base.OnLostFocus(pObjEventoDG); }

        // Con el teclado también se abre: Enter o espacio
        protected override void OnKeyDown(KeyEventArgs pObjEventoDG)
        {
            if (pObjEventoDG.KeyCode == Keys.Enter || pObjEventoDG.KeyCode == Keys.Space) { OnClick(EventArgs.Empty); pObjEventoDG.Handled = true; }
            base.OnKeyDown(pObjEventoDG);
        }

        protected override void OnPaint(PaintEventArgs pObjEventoDG)
        {
            Graphics lObjGraficoDG = pObjEventoDG.Graphics;
            lObjGraficoDG.SmoothingMode = SmoothingMode.AntiAlias;
            lObjGraficoDG.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Rectangle lObjAreaDG = new Rectangle(0, 0, Width - 1, Height - 1);
            bool lBlnResaltarDG = gBlnSobreDG || (Focused && ShowFocusCues);
            using (GraphicsPath lObjRutaDG = TemaDG.FncRectanguloRedondeadoDG(lObjAreaDG, 10))
            using (SolidBrush lObjFondoDG = new SolidBrush(Color.White))
            using (Pen lObjBordeDG = new Pen(lBlnResaltarDG ? gObjColorAcentoDG : TemaDG.gObjLineaDG, lBlnResaltarDG ? 2f : 1f))
            {
                lObjGraficoDG.FillPath(lObjFondoDG, lObjRutaDG);
                lObjGraficoDG.DrawPath(lObjBordeDG, lObjRutaDG);
            }
            SubDibujarContenidoDG(lObjGraficoDG);
        }

        // Círculo de color suave con el ícono en el color de acento
        protected void SubDibujarIconoDG(Graphics pObjGraficoDG, int pIntXDG, int pIntYDG, int pIntTamanoDG)
        {
            using (SolidBrush lObjCirculoDG = new SolidBrush(Color.FromArgb(28, gObjColorAcentoDG)))
                pObjGraficoDG.FillEllipse(lObjCirculoDG, pIntXDG, pIntYDG, pIntTamanoDG, pIntTamanoDG);
            int lIntIconoDG = pIntTamanoDG / 2;
            using (Bitmap lObjIconoDG = TemaDG.FncIconoDG(gStrIconoDG, lIntIconoDG, gObjColorAcentoDG))
                pObjGraficoDG.DrawImage(lObjIconoDG, pIntXDG + (pIntTamanoDG - lIntIconoDG) / 2, pIntYDG + (pIntTamanoDG - lIntIconoDG) / 2);
        }

        protected abstract void SubDibujarContenidoDG(Graphics pObjGraficoDG);
    }

    // Tarjeta del menú principal: ícono, nombre del módulo y una línea que explica para qué sirve
    public class TarjetaModuloDG : TarjetaBaseDG
    {
        [Category("Cubito")] public string gStrDescripcionDG { get; set; } = string.Empty;

        protected override void SubDibujarContenidoDG(Graphics pObjGraficoDG)
        {
            SubDibujarIconoDG(pObjGraficoDG, 20, 20, 44);
            using (Font lObjTituloDG = new Font("Segoe UI Semibold", 12F))
            using (Font lObjDescripcionDG = new Font("Segoe UI", 9F))
            {
                TextRenderer.DrawText(pObjGraficoDG, gStrTituloDG, lObjTituloDG, new Rectangle(20, 74, Width - 40, 24), TemaDG.gObjTintaDG,
                    TextFormatFlags.Left | TextFormatFlags.NoPadding);
                TextRenderer.DrawText(pObjGraficoDG, gStrDescripcionDG, lObjDescripcionDG, new Rectangle(20, 100, Width - 40, Height - 108), TemaDG.gObjTextoSuaveDG,
                    TextFormatFlags.Left | TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
            }
        }
    }

    // Indicador del inicio: un número grande con su explicación (pedidos activos, por cobrar, etc.)
    public class TarjetaIndicadorDG : TarjetaBaseDG
    {
        private string gStrValorDG = "—";
        private string gStrDetalleDG = string.Empty;

        [Category("Cubito")]
        public string gStrValorIndicadorDG
        {
            get { return gStrValorDG; }
            set { gStrValorDG = value; Invalidate(); }
        }

        [Category("Cubito")]
        public string gStrDetalleIndicadorDG
        {
            get { return gStrDetalleDG; }
            set { gStrDetalleDG = value; Invalidate(); }
        }

        protected override void SubDibujarContenidoDG(Graphics pObjGraficoDG)
        {
            SubDibujarIconoDG(pObjGraficoDG, Width - 52, 16, 36);
            using (Font lObjTituloDG = new Font("Segoe UI", 9F))
            using (Font lObjValorDG = new Font("Segoe UI Semibold", 18F))
            using (Font lObjDetalleDG = new Font("Segoe UI", 8.25F))
            {
                TextRenderer.DrawText(pObjGraficoDG, gStrTituloDG, lObjTituloDG, new Rectangle(16, 16, Width - 76, 20), TemaDG.gObjTextoSuaveDG,
                    TextFormatFlags.Left | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);
                TextRenderer.DrawText(pObjGraficoDG, gStrValorDG, lObjValorDG, new Rectangle(14, 38, Width - 28, 36), TemaDG.gObjTintaDG,
                    TextFormatFlags.Left | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);
                TextRenderer.DrawText(pObjGraficoDG, gStrDetalleDG, lObjDetalleDG, new Rectangle(16, Height - 26, Width - 32, 18), gObjColorAcentoDG,
                    TextFormatFlags.Left | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);
            }
        }
    }
}
