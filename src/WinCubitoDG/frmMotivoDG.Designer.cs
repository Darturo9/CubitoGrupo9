namespace WinCubitoDG
{
    partial class frmMotivoDG
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
            this.lblPreguntaDG = new System.Windows.Forms.Label();
            this.txtMotivoDG = new System.Windows.Forms.TextBox();
            this.lblMensajeDG = new System.Windows.Forms.Label();
            this.btnAceptarDG = new System.Windows.Forms.Button();
            this.btnCancelarDG = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblPreguntaDG
            //
            this.lblPreguntaDG.Location = new System.Drawing.Point(15, 12);
            this.lblPreguntaDG.Name = "lblPreguntaDG";
            this.lblPreguntaDG.Size = new System.Drawing.Size(390, 40);
            this.lblPreguntaDG.Text = "Motivo:";
            //
            // txtMotivoDG
            //
            this.txtMotivoDG.Location = new System.Drawing.Point(15, 55);
            this.txtMotivoDG.MaxLength = 200;
            this.txtMotivoDG.Multiline = true;
            this.txtMotivoDG.Name = "txtMotivoDG";
            this.txtMotivoDG.Size = new System.Drawing.Size(390, 70);
            this.txtMotivoDG.TabIndex = 0;
            //
            // lblMensajeDG
            //
            this.lblMensajeDG.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMensajeDG.Location = new System.Drawing.Point(15, 130);
            this.lblMensajeDG.Name = "lblMensajeDG";
            this.lblMensajeDG.Size = new System.Drawing.Size(390, 20);
            //
            // btnAceptarDG
            //
            this.btnAceptarDG.Location = new System.Drawing.Point(195, 155);
            this.btnAceptarDG.Name = "btnAceptarDG";
            this.btnAceptarDG.Size = new System.Drawing.Size(100, 32);
            this.btnAceptarDG.TabIndex = 1;
            this.btnAceptarDG.Text = "Aceptar";
            this.btnAceptarDG.Click += new System.EventHandler(this.SubBtnAceptarClickDG);
            //
            // btnCancelarDG
            //
            this.btnCancelarDG.Location = new System.Drawing.Point(305, 155);
            this.btnCancelarDG.Name = "btnCancelarDG";
            this.btnCancelarDG.Size = new System.Drawing.Size(100, 32);
            this.btnCancelarDG.TabIndex = 2;
            this.btnCancelarDG.Text = "Volver";
            this.btnCancelarDG.Click += new System.EventHandler(this.SubBtnCancelarClickDG);
            //
            // frmMotivoDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelarDG;
            this.ClientSize = new System.Drawing.Size(420, 200);
            this.Controls.Add(this.lblPreguntaDG);
            this.Controls.Add(this.txtMotivoDG);
            this.Controls.Add(this.lblMensajeDG);
            this.Controls.Add(this.btnAceptarDG);
            this.Controls.Add(this.btnCancelarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMotivoDG";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Motivo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPreguntaDG;
        private System.Windows.Forms.TextBox txtMotivoDG;
        private System.Windows.Forms.Label lblMensajeDG;
        private System.Windows.Forms.Button btnAceptarDG;
        private System.Windows.Forms.Button btnCancelarDG;
    }
}
