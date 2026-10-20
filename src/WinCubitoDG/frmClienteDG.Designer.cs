namespace WinCubitoDG
{
    partial class frmClienteDG
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
            this.gpbDatosDG = new System.Windows.Forms.GroupBox();
            this.lblNombreDG = new System.Windows.Forms.Label();
            this.txtNombreDG = new System.Windows.Forms.TextBox();
            this.lblTelefonoDG = new System.Windows.Forms.Label();
            this.txtTelefonoDG = new System.Windows.Forms.TextBox();
            this.lblAyudaTelefonoDG = new System.Windows.Forms.Label();
            this.lblCorreoDG = new System.Windows.Forms.Label();
            this.txtCorreoDG = new System.Windows.Forms.TextBox();
            this.lblAyudaCorreoDG = new System.Windows.Forms.Label();
            this.lblMensajeDG = new System.Windows.Forms.Label();
            this.btnGuardarDG = new System.Windows.Forms.Button();
            this.btnCancelarDG = new System.Windows.Forms.Button();
            this.gpbDatosDG.SuspendLayout();
            this.SuspendLayout();
            //
            // gpbDatosDG
            //
            this.gpbDatosDG.Controls.Add(this.lblNombreDG);
            this.gpbDatosDG.Controls.Add(this.txtNombreDG);
            this.gpbDatosDG.Controls.Add(this.lblTelefonoDG);
            this.gpbDatosDG.Controls.Add(this.txtTelefonoDG);
            this.gpbDatosDG.Controls.Add(this.lblAyudaTelefonoDG);
            this.gpbDatosDG.Controls.Add(this.lblCorreoDG);
            this.gpbDatosDG.Controls.Add(this.txtCorreoDG);
            this.gpbDatosDG.Controls.Add(this.lblAyudaCorreoDG);
            this.gpbDatosDG.Location = new System.Drawing.Point(20, 15);
            this.gpbDatosDG.Name = "gpbDatosDG";
            this.gpbDatosDG.Size = new System.Drawing.Size(420, 180);
            this.gpbDatosDG.TabIndex = 0;
            this.gpbDatosDG.Text = "Datos del cliente";
            //
            // lblNombreDG
            //
            this.lblNombreDG.Location = new System.Drawing.Point(15, 30);
            this.lblNombreDG.Name = "lblNombreDG";
            this.lblNombreDG.Size = new System.Drawing.Size(80, 23);
            this.lblNombreDG.Text = "Nombre:";
            this.lblNombreDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtNombreDG
            //
            this.txtNombreDG.Location = new System.Drawing.Point(100, 30);
            this.txtNombreDG.MaxLength = 120;
            this.txtNombreDG.Name = "txtNombreDG";
            this.txtNombreDG.Size = new System.Drawing.Size(300, 23);
            this.txtNombreDG.TabIndex = 0;
            //
            // lblTelefonoDG
            //
            this.lblTelefonoDG.Location = new System.Drawing.Point(15, 70);
            this.lblTelefonoDG.Name = "lblTelefonoDG";
            this.lblTelefonoDG.Size = new System.Drawing.Size(80, 23);
            this.lblTelefonoDG.Text = "Teléfono:";
            this.lblTelefonoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtTelefonoDG
            //
            this.txtTelefonoDG.Location = new System.Drawing.Point(100, 70);
            this.txtTelefonoDG.MaxLength = 15;
            this.txtTelefonoDG.Name = "txtTelefonoDG";
            this.txtTelefonoDG.Size = new System.Drawing.Size(140, 23);
            this.txtTelefonoDG.TabIndex = 1;
            this.txtTelefonoDG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SubTxtTelefonoKeyPressDG);
            //
            // lblAyudaTelefonoDG
            //
            this.lblAyudaTelefonoDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblAyudaTelefonoDG.Location = new System.Drawing.Point(248, 70);
            this.lblAyudaTelefonoDG.Name = "lblAyudaTelefonoDG";
            this.lblAyudaTelefonoDG.Size = new System.Drawing.Size(160, 23);
            this.lblAyudaTelefonoDG.Text = "8 a 15 dígitos, sin guiones";
            this.lblAyudaTelefonoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblCorreoDG
            //
            this.lblCorreoDG.Location = new System.Drawing.Point(15, 110);
            this.lblCorreoDG.Name = "lblCorreoDG";
            this.lblCorreoDG.Size = new System.Drawing.Size(80, 23);
            this.lblCorreoDG.Text = "Correo:";
            this.lblCorreoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtCorreoDG
            //
            this.txtCorreoDG.Location = new System.Drawing.Point(100, 110);
            this.txtCorreoDG.MaxLength = 120;
            this.txtCorreoDG.Name = "txtCorreoDG";
            this.txtCorreoDG.Size = new System.Drawing.Size(300, 23);
            this.txtCorreoDG.TabIndex = 2;
            //
            // lblAyudaCorreoDG
            //
            this.lblAyudaCorreoDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblAyudaCorreoDG.Location = new System.Drawing.Point(100, 138);
            this.lblAyudaCorreoDG.Name = "lblAyudaCorreoDG";
            this.lblAyudaCorreoDG.Size = new System.Drawing.Size(300, 20);
            this.lblAyudaCorreoDG.Text = "Opcional";
            //
            // lblMensajeDG
            //
            this.lblMensajeDG.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMensajeDG.Location = new System.Drawing.Point(20, 202);
            this.lblMensajeDG.Name = "lblMensajeDG";
            this.lblMensajeDG.Size = new System.Drawing.Size(420, 36);
            //
            // btnGuardarDG
            //
            this.btnGuardarDG.Location = new System.Drawing.Point(220, 244);
            this.btnGuardarDG.Name = "btnGuardarDG";
            this.btnGuardarDG.Size = new System.Drawing.Size(105, 34);
            this.btnGuardarDG.TabIndex = 1;
            this.btnGuardarDG.Text = "Guardar";
            this.btnGuardarDG.Click += new System.EventHandler(this.SubBtnGuardarClickDG);
            //
            // btnCancelarDG
            //
            this.btnCancelarDG.Location = new System.Drawing.Point(335, 244);
            this.btnCancelarDG.Name = "btnCancelarDG";
            this.btnCancelarDG.Size = new System.Drawing.Size(105, 34);
            this.btnCancelarDG.TabIndex = 2;
            this.btnCancelarDG.Text = "Cancelar";
            this.btnCancelarDG.Click += new System.EventHandler(this.SubBtnCancelarClickDG);
            //
            // frmClienteDG
            //
            this.AcceptButton = this.btnGuardarDG;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelarDG;
            this.ClientSize = new System.Drawing.Size(460, 295);
            this.Controls.Add(this.gpbDatosDG);
            this.Controls.Add(this.lblMensajeDG);
            this.Controls.Add(this.btnGuardarDG);
            this.Controls.Add(this.btnCancelarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClienteDG";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cliente";
            this.gpbDatosDG.ResumeLayout(false);
            this.gpbDatosDG.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gpbDatosDG;
        private System.Windows.Forms.Label lblNombreDG;
        private System.Windows.Forms.TextBox txtNombreDG;
        private System.Windows.Forms.Label lblTelefonoDG;
        private System.Windows.Forms.TextBox txtTelefonoDG;
        private System.Windows.Forms.Label lblAyudaTelefonoDG;
        private System.Windows.Forms.Label lblCorreoDG;
        private System.Windows.Forms.TextBox txtCorreoDG;
        private System.Windows.Forms.Label lblAyudaCorreoDG;
        private System.Windows.Forms.Label lblMensajeDG;
        private System.Windows.Forms.Button btnGuardarDG;
        private System.Windows.Forms.Button btnCancelarDG;
    }
}
