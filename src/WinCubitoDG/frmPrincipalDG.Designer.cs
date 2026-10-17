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
            this.lblTituloDG = new System.Windows.Forms.Label();
            this.lblBienvenidaDG = new System.Windows.Forms.Label();
            this.gpbModulosDG = new System.Windows.Forms.GroupBox();
            this.btnClientesDG = new System.Windows.Forms.Button();
            this.btnInventarioDG = new System.Windows.Forms.Button();
            this.btnPedidosDG = new System.Windows.Forms.Button();
            this.btnPagosDG = new System.Windows.Forms.Button();
            this.btnGastosDG = new System.Windows.Forms.Button();
            this.btnReportesDG = new System.Windows.Forms.Button();
            this.btnSalirDG = new System.Windows.Forms.Button();
            this.gpbModulosDG.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTituloDG
            //
            this.lblTituloDG.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTituloDG.Location = new System.Drawing.Point(20, 15);
            this.lblTituloDG.Name = "lblTituloDG";
            this.lblTituloDG.Size = new System.Drawing.Size(560, 45);
            this.lblTituloDG.Text = "Cubito - Gestión del taller";
            //
            // lblBienvenidaDG
            //
            this.lblBienvenidaDG.Location = new System.Drawing.Point(22, 62);
            this.lblBienvenidaDG.Name = "lblBienvenidaDG";
            this.lblBienvenidaDG.Size = new System.Drawing.Size(560, 23);
            this.lblBienvenidaDG.Text = "Bienvenido";
            //
            // gpbModulosDG
            //
            this.gpbModulosDG.Controls.Add(this.btnClientesDG);
            this.gpbModulosDG.Controls.Add(this.btnInventarioDG);
            this.gpbModulosDG.Controls.Add(this.btnPedidosDG);
            this.gpbModulosDG.Controls.Add(this.btnPagosDG);
            this.gpbModulosDG.Controls.Add(this.btnGastosDG);
            this.gpbModulosDG.Controls.Add(this.btnReportesDG);
            this.gpbModulosDG.Location = new System.Drawing.Point(20, 95);
            this.gpbModulosDG.Name = "gpbModulosDG";
            this.gpbModulosDG.Size = new System.Drawing.Size(560, 200);
            this.gpbModulosDG.Text = "Módulos";
            //
            // btnClientesDG
            //
            this.btnClientesDG.Location = new System.Drawing.Point(20, 30);
            this.btnClientesDG.Name = "btnClientesDG";
            this.btnClientesDG.Size = new System.Drawing.Size(160, 70);
            this.btnClientesDG.TabIndex = 0;
            this.btnClientesDG.Text = "Clientes";
            this.btnClientesDG.Click += new System.EventHandler(this.SubBtnClientesClickDG);
            //
            // btnInventarioDG
            //
            this.btnInventarioDG.Location = new System.Drawing.Point(200, 30);
            this.btnInventarioDG.Name = "btnInventarioDG";
            this.btnInventarioDG.Size = new System.Drawing.Size(160, 70);
            this.btnInventarioDG.TabIndex = 1;
            this.btnInventarioDG.Text = "Inventario";
            this.btnInventarioDG.Click += new System.EventHandler(this.SubBtnInventarioClickDG);
            //
            // btnPedidosDG
            //
            this.btnPedidosDG.Location = new System.Drawing.Point(380, 30);
            this.btnPedidosDG.Name = "btnPedidosDG";
            this.btnPedidosDG.Size = new System.Drawing.Size(160, 70);
            this.btnPedidosDG.TabIndex = 2;
            this.btnPedidosDG.Text = "Pedidos";
            this.btnPedidosDG.Click += new System.EventHandler(this.SubBtnPedidosClickDG);
            //
            // btnPagosDG
            //
            this.btnPagosDG.Location = new System.Drawing.Point(20, 115);
            this.btnPagosDG.Name = "btnPagosDG";
            this.btnPagosDG.Size = new System.Drawing.Size(160, 70);
            this.btnPagosDG.TabIndex = 3;
            this.btnPagosDG.Text = "Pagos";
            this.btnPagosDG.Click += new System.EventHandler(this.SubBtnPagosClickDG);
            //
            // btnGastosDG
            //
            this.btnGastosDG.Location = new System.Drawing.Point(200, 115);
            this.btnGastosDG.Name = "btnGastosDG";
            this.btnGastosDG.Size = new System.Drawing.Size(160, 70);
            this.btnGastosDG.TabIndex = 4;
            this.btnGastosDG.Text = "Gastos";
            this.btnGastosDG.Click += new System.EventHandler(this.SubBtnGastosClickDG);
            //
            // btnReportesDG
            //
            this.btnReportesDG.Location = new System.Drawing.Point(380, 115);
            this.btnReportesDG.Name = "btnReportesDG";
            this.btnReportesDG.Size = new System.Drawing.Size(160, 70);
            this.btnReportesDG.TabIndex = 5;
            this.btnReportesDG.Text = "Reportes";
            this.btnReportesDG.Click += new System.EventHandler(this.SubBtnReportesClickDG);
            //
            // btnSalirDG
            //
            this.btnSalirDG.Location = new System.Drawing.Point(480, 310);
            this.btnSalirDG.Name = "btnSalirDG";
            this.btnSalirDG.Size = new System.Drawing.Size(100, 32);
            this.btnSalirDG.TabIndex = 6;
            this.btnSalirDG.Text = "Salir";
            this.btnSalirDG.Click += new System.EventHandler(this.SubBtnSalirClickDG);
            //
            // frmPrincipalDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.lblTituloDG);
            this.Controls.Add(this.lblBienvenidaDG);
            this.Controls.Add(this.gpbModulosDG);
            this.Controls.Add(this.btnSalirDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrincipalDG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cubito";
            this.gpbModulosDG.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTituloDG;
        private System.Windows.Forms.Label lblBienvenidaDG;
        private System.Windows.Forms.GroupBox gpbModulosDG;
        private System.Windows.Forms.Button btnClientesDG;
        private System.Windows.Forms.Button btnInventarioDG;
        private System.Windows.Forms.Button btnPedidosDG;
        private System.Windows.Forms.Button btnPagosDG;
        private System.Windows.Forms.Button btnGastosDG;
        private System.Windows.Forms.Button btnReportesDG;
        private System.Windows.Forms.Button btnSalirDG;
    }
}
