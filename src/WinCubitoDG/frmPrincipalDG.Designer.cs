namespace WinCubitoDG
{
    partial class frmPrincipalDG
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.pnlLateralDG = new System.Windows.Forms.Panel();
            this.marMarcaDG = new WinCubitoDG.MarcaDG();
            this.lblLemaDG = new System.Windows.Forms.Label();
            this.lblUsuarioDG = new System.Windows.Forms.Label();
            this.lblRolDG = new System.Windows.Forms.Label();
            this.btnSalirDG = new System.Windows.Forms.Button();
            this.lblSaludoDG = new System.Windows.Forms.Label();
            this.lblFechaDG = new System.Windows.Forms.Label();
            this.tarActivosDG = new WinCubitoDG.TarjetaIndicadorDG();
            this.tarPorCobrarDG = new WinCubitoDG.TarjetaIndicadorDG();
            this.tarListosDG = new WinCubitoDG.TarjetaIndicadorDG();
            this.tarAlertasDG = new WinCubitoDG.TarjetaIndicadorDG();
            this.lblModulosDG = new System.Windows.Forms.Label();
            this.tarPedidosDG = new WinCubitoDG.TarjetaModuloDG();
            this.tarPagosDG = new WinCubitoDG.TarjetaModuloDG();
            this.tarInventarioDG = new WinCubitoDG.TarjetaModuloDG();
            this.tarClientesDG = new WinCubitoDG.TarjetaModuloDG();
            this.tarGastosDG = new WinCubitoDG.TarjetaModuloDG();
            this.tarReportesDG = new WinCubitoDG.TarjetaModuloDG();
            this.pnlLateralDG.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlLateralDG
            //
            this.pnlLateralDG.BackColor = System.Drawing.Color.FromArgb(30, 33, 48);
            this.pnlLateralDG.Controls.Add(this.marMarcaDG);
            this.pnlLateralDG.Controls.Add(this.lblLemaDG);
            this.pnlLateralDG.Controls.Add(this.lblUsuarioDG);
            this.pnlLateralDG.Controls.Add(this.lblRolDG);
            this.pnlLateralDG.Controls.Add(this.btnSalirDG);
            this.pnlLateralDG.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateralDG.Name = "pnlLateralDG";
            this.pnlLateralDG.Size = new System.Drawing.Size(220, 560);
            //
            // marMarcaDG
            //
            this.marMarcaDG.Location = new System.Drawing.Point(24, 28);
            this.marMarcaDG.Name = "marMarcaDG";
            this.marMarcaDG.Size = new System.Drawing.Size(180, 40);
            this.marMarcaDG.TabStop = false;
            //
            // lblLemaDG
            //
            this.lblLemaDG.ForeColor = System.Drawing.Color.FromArgb(169, 174, 194);
            this.lblLemaDG.Location = new System.Drawing.Point(26, 70);
            this.lblLemaDG.Name = "lblLemaDG";
            this.lblLemaDG.Size = new System.Drawing.Size(180, 40);
            this.lblLemaDG.Text = "Serigrafía · Sublimación · DTF\r\nGestión del taller";
            //
            // lblUsuarioDG
            //
            this.lblUsuarioDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUsuarioDG.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblUsuarioDG.ForeColor = System.Drawing.Color.White;
            this.lblUsuarioDG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUsuarioDG.Location = new System.Drawing.Point(24, 446);
            this.lblUsuarioDG.Name = "lblUsuarioDG";
            this.lblUsuarioDG.Size = new System.Drawing.Size(172, 24);
            this.lblUsuarioDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblRolDG
            //
            this.lblRolDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRolDG.ForeColor = System.Drawing.Color.FromArgb(169, 174, 194);
            this.lblRolDG.Location = new System.Drawing.Point(24, 470);
            this.lblRolDG.Name = "lblRolDG";
            this.lblRolDG.Size = new System.Drawing.Size(172, 20);
            this.lblRolDG.Text = "Dueño del taller";
            //
            // btnSalirDG
            //
            this.btnSalirDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalirDG.Location = new System.Drawing.Point(24, 502);
            this.btnSalirDG.Name = "btnSalirDG";
            this.btnSalirDG.Size = new System.Drawing.Size(172, 36);
            this.btnSalirDG.TabIndex = 10;
            this.btnSalirDG.Text = "Salir";
            this.btnSalirDG.Click += new System.EventHandler(this.SubBtnSalirClickDG);
            //
            // lblSaludoDG
            //
            this.lblSaludoDG.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.lblSaludoDG.Location = new System.Drawing.Point(250, 24);
            this.lblSaludoDG.Name = "lblSaludoDG";
            this.lblSaludoDG.Size = new System.Drawing.Size(560, 40);
            //
            // lblFechaDG
            //
            this.lblFechaDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblFechaDG.Location = new System.Drawing.Point(252, 64);
            this.lblFechaDG.Name = "lblFechaDG";
            this.lblFechaDG.Size = new System.Drawing.Size(560, 22);
            //
            // Indicadores
            //
            this.tarActivosDG.Location = new System.Drawing.Point(252, 102);
            this.tarActivosDG.Name = "tarActivosDG";
            this.tarActivosDG.Size = new System.Drawing.Size(178, 100);
            this.tarActivosDG.TabIndex = 0;
            this.tarActivosDG.gStrTituloDG = "Pedidos activos";
            this.tarActivosDG.Click += new System.EventHandler(this.SubBtnPedidosClickDG);
            this.tarPorCobrarDG.Location = new System.Drawing.Point(442, 102);
            this.tarPorCobrarDG.Name = "tarPorCobrarDG";
            this.tarPorCobrarDG.Size = new System.Drawing.Size(178, 100);
            this.tarPorCobrarDG.TabIndex = 1;
            this.tarPorCobrarDG.gStrTituloDG = "Por cobrar";
            this.tarPorCobrarDG.Click += new System.EventHandler(this.SubBtnPagosClickDG);
            this.tarListosDG.Location = new System.Drawing.Point(632, 102);
            this.tarListosDG.Name = "tarListosDG";
            this.tarListosDG.Size = new System.Drawing.Size(178, 100);
            this.tarListosDG.TabIndex = 2;
            this.tarListosDG.gStrTituloDG = "Para entregar";
            this.tarListosDG.Click += new System.EventHandler(this.SubBtnPedidosClickDG);
            this.tarAlertasDG.Location = new System.Drawing.Point(822, 102);
            this.tarAlertasDG.Name = "tarAlertasDG";
            this.tarAlertasDG.Size = new System.Drawing.Size(178, 100);
            this.tarAlertasDG.TabIndex = 3;
            this.tarAlertasDG.gStrTituloDG = "Alertas de stock";
            this.tarAlertasDG.Click += new System.EventHandler(this.SubBtnInventarioClickDG);
            //
            // lblModulosDG
            //
            this.lblModulosDG.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblModulosDG.Location = new System.Drawing.Point(250, 222);
            this.lblModulosDG.Name = "lblModulosDG";
            this.lblModulosDG.Size = new System.Drawing.Size(300, 26);
            this.lblModulosDG.Text = "Módulos";
            //
            // Módulos
            //
            this.tarPedidosDG.Location = new System.Drawing.Point(252, 254);
            this.tarPedidosDG.Name = "tarPedidosDG";
            this.tarPedidosDG.Size = new System.Drawing.Size(240, 136);
            this.tarPedidosDG.TabIndex = 4;
            this.tarPedidosDG.gStrTituloDG = "Pedidos";
            this.tarPedidosDG.gStrDescripcionDG = "Cotizaciones, producción y entregas";
            this.tarPedidosDG.Click += new System.EventHandler(this.SubBtnPedidosClickDG);
            this.tarPagosDG.Location = new System.Drawing.Point(506, 254);
            this.tarPagosDG.Name = "tarPagosDG";
            this.tarPagosDG.Size = new System.Drawing.Size(240, 136);
            this.tarPagosDG.TabIndex = 5;
            this.tarPagosDG.gStrTituloDG = "Pagos";
            this.tarPagosDG.gStrDescripcionDG = "Anticipos, saldos y cuentas por cobrar";
            this.tarPagosDG.Click += new System.EventHandler(this.SubBtnPagosClickDG);
            this.tarInventarioDG.Location = new System.Drawing.Point(760, 254);
            this.tarInventarioDG.Name = "tarInventarioDG";
            this.tarInventarioDG.Size = new System.Drawing.Size(240, 136);
            this.tarInventarioDG.TabIndex = 6;
            this.tarInventarioDG.gStrTituloDG = "Inventario";
            this.tarInventarioDG.gStrDescripcionDG = "Prendas, insumos, kardex y alertas";
            this.tarInventarioDG.Click += new System.EventHandler(this.SubBtnInventarioClickDG);
            this.tarClientesDG.Location = new System.Drawing.Point(252, 402);
            this.tarClientesDG.Name = "tarClientesDG";
            this.tarClientesDG.Size = new System.Drawing.Size(240, 136);
            this.tarClientesDG.TabIndex = 7;
            this.tarClientesDG.gStrTituloDG = "Clientes";
            this.tarClientesDG.gStrDescripcionDG = "Datos de contacto e historial";
            this.tarClientesDG.Click += new System.EventHandler(this.SubBtnClientesClickDG);
            this.tarGastosDG.Location = new System.Drawing.Point(506, 402);
            this.tarGastosDG.Name = "tarGastosDG";
            this.tarGastosDG.Size = new System.Drawing.Size(240, 136);
            this.tarGastosDG.TabIndex = 8;
            this.tarGastosDG.gStrTituloDG = "Gastos";
            this.tarGastosDG.gStrDescripcionDG = "Compras y gastos del taller";
            this.tarGastosDG.Click += new System.EventHandler(this.SubBtnGastosClickDG);
            this.tarReportesDG.Location = new System.Drawing.Point(760, 402);
            this.tarReportesDG.Name = "tarReportesDG";
            this.tarReportesDG.Size = new System.Drawing.Size(240, 136);
            this.tarReportesDG.TabIndex = 9;
            this.tarReportesDG.gStrTituloDG = "Reportes";
            this.tarReportesDG.gStrDescripcionDG = "Ventas, cobros y ganancias";
            this.tarReportesDG.Click += new System.EventHandler(this.SubBtnReportesClickDG);
            //
            // frmPrincipalDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 560);
            this.Controls.Add(this.lblSaludoDG);
            this.Controls.Add(this.lblFechaDG);
            this.Controls.Add(this.tarActivosDG);
            this.Controls.Add(this.tarPorCobrarDG);
            this.Controls.Add(this.tarListosDG);
            this.Controls.Add(this.tarAlertasDG);
            this.Controls.Add(this.lblModulosDG);
            this.Controls.Add(this.tarPedidosDG);
            this.Controls.Add(this.tarPagosDG);
            this.Controls.Add(this.tarInventarioDG);
            this.Controls.Add(this.tarClientesDG);
            this.Controls.Add(this.tarGastosDG);
            this.Controls.Add(this.tarReportesDG);
            this.Controls.Add(this.pnlLateralDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrincipalDG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cubito";
            this.Load += new System.EventHandler(this.SubFrmPrincipalLoadDG);
            this.pnlLateralDG.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlLateralDG;
        private WinCubitoDG.MarcaDG marMarcaDG;
        private System.Windows.Forms.Label lblLemaDG;
        private System.Windows.Forms.Label lblUsuarioDG;
        private System.Windows.Forms.Label lblRolDG;
        private System.Windows.Forms.Button btnSalirDG;
        private System.Windows.Forms.Label lblSaludoDG;
        private System.Windows.Forms.Label lblFechaDG;
        private WinCubitoDG.TarjetaIndicadorDG tarActivosDG;
        private WinCubitoDG.TarjetaIndicadorDG tarPorCobrarDG;
        private WinCubitoDG.TarjetaIndicadorDG tarListosDG;
        private WinCubitoDG.TarjetaIndicadorDG tarAlertasDG;
        private System.Windows.Forms.Label lblModulosDG;
        private WinCubitoDG.TarjetaModuloDG tarPedidosDG;
        private WinCubitoDG.TarjetaModuloDG tarPagosDG;
        private WinCubitoDG.TarjetaModuloDG tarInventarioDG;
        private WinCubitoDG.TarjetaModuloDG tarClientesDG;
        private WinCubitoDG.TarjetaModuloDG tarGastosDG;
        private WinCubitoDG.TarjetaModuloDG tarReportesDG;
    }
}
