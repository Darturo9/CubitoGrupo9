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
            this.lblTituloDG = new System.Windows.Forms.Label();
            this.gpbCredencialesDG = new System.Windows.Forms.GroupBox();
            this.lblUsuarioDG = new System.Windows.Forms.Label();
            this.txtUsuarioDG = new System.Windows.Forms.TextBox();
            this.lblClaveDG = new System.Windows.Forms.Label();
            this.txtClaveDG = new System.Windows.Forms.TextBox();
            this.lblMensajeDG = new System.Windows.Forms.Label();
            this.btnIngresarDG = new System.Windows.Forms.Button();
            this.btnSalirDG = new System.Windows.Forms.Button();
            this.gpbCredencialesDG.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTituloDG
            //
            this.lblTituloDG.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloDG.Location = new System.Drawing.Point(20, 15);
            this.lblTituloDG.Name = "lblTituloDG";
            this.lblTituloDG.Size = new System.Drawing.Size(340, 40);
            this.lblTituloDG.Text = "Cubito";
            this.lblTituloDG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // gpbCredencialesDG
            //
            this.gpbCredencialesDG.Controls.Add(this.lblUsuarioDG);
            this.gpbCredencialesDG.Controls.Add(this.txtUsuarioDG);
            this.gpbCredencialesDG.Controls.Add(this.lblClaveDG);
            this.gpbCredencialesDG.Controls.Add(this.txtClaveDG);
            this.gpbCredencialesDG.Location = new System.Drawing.Point(20, 65);
            this.gpbCredencialesDG.Name = "gpbCredencialesDG";
            this.gpbCredencialesDG.Size = new System.Drawing.Size(340, 130);
            this.gpbCredencialesDG.Text = "Iniciar sesión";
            //
            // lblUsuarioDG
            //
            this.lblUsuarioDG.Location = new System.Drawing.Point(15, 30);
            this.lblUsuarioDG.Name = "lblUsuarioDG";
            this.lblUsuarioDG.Size = new System.Drawing.Size(90, 23);
            this.lblUsuarioDG.Text = "Usuario:";
            this.lblUsuarioDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtUsuarioDG
            //
            this.txtUsuarioDG.Location = new System.Drawing.Point(110, 30);
            this.txtUsuarioDG.MaxLength = 50;
            this.txtUsuarioDG.Name = "txtUsuarioDG";
            this.txtUsuarioDG.Size = new System.Drawing.Size(210, 23);
            this.txtUsuarioDG.TabIndex = 0;
            //
            // lblClaveDG
            //
            this.lblClaveDG.Location = new System.Drawing.Point(15, 75);
            this.lblClaveDG.Name = "lblClaveDG";
            this.lblClaveDG.Size = new System.Drawing.Size(90, 23);
            this.lblClaveDG.Text = "Contraseña:";
            this.lblClaveDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtClaveDG
            //
            this.txtClaveDG.Location = new System.Drawing.Point(110, 75);
            this.txtClaveDG.MaxLength = 100;
            this.txtClaveDG.Name = "txtClaveDG";
            this.txtClaveDG.Size = new System.Drawing.Size(210, 23);
            this.txtClaveDG.TabIndex = 1;
            this.txtClaveDG.UseSystemPasswordChar = true;
            //
            // lblMensajeDG
            //
            this.lblMensajeDG.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMensajeDG.Location = new System.Drawing.Point(20, 200);
            this.lblMensajeDG.Name = "lblMensajeDG";
            this.lblMensajeDG.Size = new System.Drawing.Size(340, 40);
            //
            // btnIngresarDG
            //
            this.btnIngresarDG.Location = new System.Drawing.Point(150, 245);
            this.btnIngresarDG.Name = "btnIngresarDG";
            this.btnIngresarDG.Size = new System.Drawing.Size(100, 32);
            this.btnIngresarDG.TabIndex = 2;
            this.btnIngresarDG.Text = "Ingresar";
            this.btnIngresarDG.Click += new System.EventHandler(this.SubBtnIngresarClickDG);
            //
            // btnSalirDG
            //
            this.btnSalirDG.Location = new System.Drawing.Point(260, 245);
            this.btnSalirDG.Name = "btnSalirDG";
            this.btnSalirDG.Size = new System.Drawing.Size(100, 32);
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
            this.ClientSize = new System.Drawing.Size(380, 295);
            this.Controls.Add(this.lblTituloDG);
            this.Controls.Add(this.gpbCredencialesDG);
            this.Controls.Add(this.lblMensajeDG);
            this.Controls.Add(this.btnIngresarDG);
            this.Controls.Add(this.btnSalirDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoginDG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cubito - Iniciar sesión";
            this.gpbCredencialesDG.ResumeLayout(false);
            this.gpbCredencialesDG.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTituloDG;
        private System.Windows.Forms.GroupBox gpbCredencialesDG;
        private System.Windows.Forms.Label lblUsuarioDG;
        private System.Windows.Forms.TextBox txtUsuarioDG;
        private System.Windows.Forms.Label lblClaveDG;
        private System.Windows.Forms.TextBox txtClaveDG;
        private System.Windows.Forms.Label lblMensajeDG;
        private System.Windows.Forms.Button btnIngresarDG;
        private System.Windows.Forms.Button btnSalirDG;
    }
}
