namespace WinCubitoDG
{
    partial class frmLoginDG
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
            this.pnlMarcaDG = new System.Windows.Forms.Panel();
            this.marMarcaDG = new WinCubitoDG.MarcaDG();
            this.lblLemaDG = new System.Windows.Forms.Label();
            this.lblTecnicasDG = new System.Windows.Forms.Label();
            this.lblTituloDG = new System.Windows.Forms.Label();
            this.lblSubtituloDG = new System.Windows.Forms.Label();
            this.lblUsuarioDG = new System.Windows.Forms.Label();
            this.txtUsuarioDG = new System.Windows.Forms.TextBox();
            this.lblClaveDG = new System.Windows.Forms.Label();
            this.txtClaveDG = new System.Windows.Forms.TextBox();
            this.lblMensajeDG = new System.Windows.Forms.Label();
            this.btnIngresarDG = new System.Windows.Forms.Button();
            this.btnSalirDG = new System.Windows.Forms.Button();
            this.pnlMarcaDG.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlMarcaDG
            //
            this.pnlMarcaDG.BackColor = System.Drawing.Color.FromArgb(30, 33, 48);
            this.pnlMarcaDG.Controls.Add(this.marMarcaDG);
            this.pnlMarcaDG.Controls.Add(this.lblLemaDG);
            this.pnlMarcaDG.Controls.Add(this.lblTecnicasDG);
            this.pnlMarcaDG.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMarcaDG.Name = "pnlMarcaDG";
            this.pnlMarcaDG.Size = new System.Drawing.Size(300, 420);
            //
            // marMarcaDG
            //
            this.marMarcaDG.Location = new System.Drawing.Point(36, 40);
            this.marMarcaDG.Name = "marMarcaDG";
            this.marMarcaDG.Size = new System.Drawing.Size(200, 44);
            this.marMarcaDG.TabStop = false;
            //
            // lblLemaDG
            //
            this.lblLemaDG.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblLemaDG.ForeColor = System.Drawing.Color.White;
            this.lblLemaDG.Location = new System.Drawing.Point(34, 150);
            this.lblLemaDG.Name = "lblLemaDG";
            this.lblLemaDG.Size = new System.Drawing.Size(240, 120);
            this.lblLemaDG.Text = "Pedidos, inventario y pagos del taller en un solo lugar.";
            //
            // lblTecnicasDG
            //
            this.lblTecnicasDG.ForeColor = System.Drawing.Color.FromArgb(169, 174, 194);
            this.lblTecnicasDG.Location = new System.Drawing.Point(36, 370);
            this.lblTecnicasDG.Name = "lblTecnicasDG";
            this.lblTecnicasDG.Size = new System.Drawing.Size(240, 20);
            this.lblTecnicasDG.Text = "Serigrafía · Sublimación · DTF";
            //
            // lblTituloDG
            //
            this.lblTituloDG.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.lblTituloDG.Location = new System.Drawing.Point(340, 52);
            this.lblTituloDG.Name = "lblTituloDG";
            this.lblTituloDG.Size = new System.Drawing.Size(340, 40);
            this.lblTituloDG.Text = "Iniciar sesión";
            //
            // lblSubtituloDG
            //
            this.lblSubtituloDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblSubtituloDG.Location = new System.Drawing.Point(342, 92);
            this.lblSubtituloDG.Name = "lblSubtituloDG";
            this.lblSubtituloDG.Size = new System.Drawing.Size(340, 22);
            this.lblSubtituloDG.Text = "Ingrese con su usuario del taller.";
            //
            // lblUsuarioDG
            //
            this.lblUsuarioDG.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblUsuarioDG.Location = new System.Drawing.Point(342, 134);
            this.lblUsuarioDG.Name = "lblUsuarioDG";
            this.lblUsuarioDG.Size = new System.Drawing.Size(320, 20);
            this.lblUsuarioDG.Text = "Usuario";
            //
            // txtUsuarioDG
            //
            this.txtUsuarioDG.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsuarioDG.Location = new System.Drawing.Point(344, 156);
            this.txtUsuarioDG.MaxLength = 50;
            this.txtUsuarioDG.Name = "txtUsuarioDG";
            this.txtUsuarioDG.Size = new System.Drawing.Size(320, 27);
            this.txtUsuarioDG.TabIndex = 0;
            //
            // lblClaveDG
            //
            this.lblClaveDG.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblClaveDG.Location = new System.Drawing.Point(342, 198);
            this.lblClaveDG.Name = "lblClaveDG";
            this.lblClaveDG.Size = new System.Drawing.Size(320, 20);
            this.lblClaveDG.Text = "Contraseña";
            //
            // txtClaveDG
            //
            this.txtClaveDG.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtClaveDG.Location = new System.Drawing.Point(344, 220);
            this.txtClaveDG.MaxLength = 100;
            this.txtClaveDG.Name = "txtClaveDG";
            this.txtClaveDG.Size = new System.Drawing.Size(320, 27);
            this.txtClaveDG.TabIndex = 1;
            this.txtClaveDG.UseSystemPasswordChar = true;
            //
            // lblMensajeDG
            //
            this.lblMensajeDG.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMensajeDG.Location = new System.Drawing.Point(342, 256);
            this.lblMensajeDG.Name = "lblMensajeDG";
            this.lblMensajeDG.Size = new System.Drawing.Size(324, 40);
            //
            // btnIngresarDG
            //
            this.btnIngresarDG.Location = new System.Drawing.Point(344, 300);
            this.btnIngresarDG.Name = "btnIngresarDG";
            this.btnIngresarDG.Size = new System.Drawing.Size(320, 40);
            this.btnIngresarDG.TabIndex = 2;
            this.btnIngresarDG.Text = "Ingresar";
            this.btnIngresarDG.Click += new System.EventHandler(this.SubBtnIngresarClickDG);
            //
            // btnSalirDG
            //
            this.btnSalirDG.Location = new System.Drawing.Point(344, 350);
            this.btnSalirDG.Name = "btnSalirDG";
            this.btnSalirDG.Size = new System.Drawing.Size(320, 36);
            this.btnSalirDG.TabIndex = 3;
            this.btnSalirDG.Text = "Salir";
            this.btnSalirDG.Click += new System.EventHandler(this.SubBtnSalirClickDG);
            //
            // frmLoginDG
            //
            this.AcceptButton = this.btnIngresarDG;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalirDG;
            this.ClientSize = new System.Drawing.Size(704, 420);
            this.Controls.Add(this.lblTituloDG);
            this.Controls.Add(this.lblSubtituloDG);
            this.Controls.Add(this.lblUsuarioDG);
            this.Controls.Add(this.txtUsuarioDG);
            this.Controls.Add(this.lblClaveDG);
            this.Controls.Add(this.txtClaveDG);
            this.Controls.Add(this.lblMensajeDG);
            this.Controls.Add(this.btnIngresarDG);
            this.Controls.Add(this.btnSalirDG);
            this.Controls.Add(this.pnlMarcaDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoginDG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cubito - Iniciar sesión";
            this.pnlMarcaDG.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlMarcaDG;
        private WinCubitoDG.MarcaDG marMarcaDG;
        private System.Windows.Forms.Label lblLemaDG;
        private System.Windows.Forms.Label lblTecnicasDG;
        private System.Windows.Forms.Label lblTituloDG;
        private System.Windows.Forms.Label lblSubtituloDG;
        private System.Windows.Forms.Label lblUsuarioDG;
        private System.Windows.Forms.TextBox txtUsuarioDG;
        private System.Windows.Forms.Label lblClaveDG;
        private System.Windows.Forms.TextBox txtClaveDG;
        private System.Windows.Forms.Label lblMensajeDG;
        private System.Windows.Forms.Button btnIngresarDG;
        private System.Windows.Forms.Button btnSalirDG;
    }
}
