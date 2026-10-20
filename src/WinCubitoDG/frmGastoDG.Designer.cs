namespace WinCubitoDG
{
    partial class frmGastoDG
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
            this.lblFechaDG = new System.Windows.Forms.Label();
            this.dtpFechaDG = new System.Windows.Forms.DateTimePicker();
            this.lblCategoriaDG = new System.Windows.Forms.Label();
            this.cmbCategoriaDG = new System.Windows.Forms.ComboBox();
            this.lblMontoDG = new System.Windows.Forms.Label();
            this.nudMontoDG = new System.Windows.Forms.NumericUpDown();
            this.lblDescripcionDG = new System.Windows.Forms.Label();
            this.txtDescripcionDG = new System.Windows.Forms.TextBox();
            this.lblMensajeDG = new System.Windows.Forms.Label();
            this.btnGuardarDG = new System.Windows.Forms.Button();
            this.btnCancelarDG = new System.Windows.Forms.Button();
            this.gpbDatosDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDG)).BeginInit();
            this.SuspendLayout();
            //
            // gpbDatosDG
            //
            this.gpbDatosDG.Controls.Add(this.lblFechaDG);
            this.gpbDatosDG.Controls.Add(this.dtpFechaDG);
            this.gpbDatosDG.Controls.Add(this.lblCategoriaDG);
            this.gpbDatosDG.Controls.Add(this.cmbCategoriaDG);
            this.gpbDatosDG.Controls.Add(this.lblMontoDG);
            this.gpbDatosDG.Controls.Add(this.nudMontoDG);
            this.gpbDatosDG.Controls.Add(this.lblDescripcionDG);
            this.gpbDatosDG.Controls.Add(this.txtDescripcionDG);
            this.gpbDatosDG.Location = new System.Drawing.Point(20, 15);
            this.gpbDatosDG.Name = "gpbDatosDG";
            this.gpbDatosDG.Size = new System.Drawing.Size(420, 215);
            this.gpbDatosDG.TabIndex = 0;
            this.gpbDatosDG.Text = "Datos del gasto";
            //
            // lblFechaDG
            //
            this.lblFechaDG.Location = new System.Drawing.Point(15, 30);
            this.lblFechaDG.Name = "lblFechaDG";
            this.lblFechaDG.Size = new System.Drawing.Size(85, 23);
            this.lblFechaDG.Text = "Fecha:";
            this.lblFechaDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dtpFechaDG
            //
            this.dtpFechaDG.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDG.Location = new System.Drawing.Point(105, 30);
            this.dtpFechaDG.Name = "dtpFechaDG";
            this.dtpFechaDG.Size = new System.Drawing.Size(130, 23);
            this.dtpFechaDG.TabIndex = 0;
            //
            // lblCategoriaDG
            //
            this.lblCategoriaDG.Location = new System.Drawing.Point(15, 70);
            this.lblCategoriaDG.Name = "lblCategoriaDG";
            this.lblCategoriaDG.Size = new System.Drawing.Size(85, 23);
            this.lblCategoriaDG.Text = "Categoría:";
            this.lblCategoriaDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbCategoriaDG
            //
            this.cmbCategoriaDG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaDG.Location = new System.Drawing.Point(105, 70);
            this.cmbCategoriaDG.Name = "cmbCategoriaDG";
            this.cmbCategoriaDG.Size = new System.Drawing.Size(200, 23);
            this.cmbCategoriaDG.TabIndex = 1;
            //
            // lblMontoDG
            //
            this.lblMontoDG.Location = new System.Drawing.Point(15, 110);
            this.lblMontoDG.Name = "lblMontoDG";
            this.lblMontoDG.Size = new System.Drawing.Size(85, 23);
            this.lblMontoDG.Text = "Monto (Q):";
            this.lblMontoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // nudMontoDG
            //
            this.nudMontoDG.DecimalPlaces = 2;
            this.nudMontoDG.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudMontoDG.Location = new System.Drawing.Point(105, 110);
            this.nudMontoDG.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudMontoDG.Name = "nudMontoDG";
            this.nudMontoDG.Size = new System.Drawing.Size(130, 23);
            this.nudMontoDG.TabIndex = 2;
            this.nudMontoDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMontoDG.ThousandsSeparator = true;
            this.nudMontoDG.Enter += new System.EventHandler(this.SubNudMontoEnterDG);
            //
            // lblDescripcionDG
            //
            this.lblDescripcionDG.Location = new System.Drawing.Point(15, 150);
            this.lblDescripcionDG.Name = "lblDescripcionDG";
            this.lblDescripcionDG.Size = new System.Drawing.Size(85, 23);
            this.lblDescripcionDG.Text = "Descripción:";
            this.lblDescripcionDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtDescripcionDG
            //
            this.txtDescripcionDG.Location = new System.Drawing.Point(105, 150);
            this.txtDescripcionDG.MaxLength = 200;
            this.txtDescripcionDG.Multiline = true;
            this.txtDescripcionDG.Name = "txtDescripcionDG";
            this.txtDescripcionDG.Size = new System.Drawing.Size(295, 48);
            this.txtDescripcionDG.TabIndex = 3;
            //
            // lblMensajeDG
            //
            this.lblMensajeDG.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMensajeDG.Location = new System.Drawing.Point(20, 236);
            this.lblMensajeDG.Name = "lblMensajeDG";
            this.lblMensajeDG.Size = new System.Drawing.Size(420, 36);
            //
            // btnGuardarDG
            //
            this.btnGuardarDG.Location = new System.Drawing.Point(220, 278);
            this.btnGuardarDG.Name = "btnGuardarDG";
            this.btnGuardarDG.Size = new System.Drawing.Size(105, 34);
            this.btnGuardarDG.TabIndex = 1;
            this.btnGuardarDG.Text = "Guardar";
            this.btnGuardarDG.Click += new System.EventHandler(this.SubBtnGuardarClickDG);
            //
            // btnCancelarDG
            //
            this.btnCancelarDG.Location = new System.Drawing.Point(335, 278);
            this.btnCancelarDG.Name = "btnCancelarDG";
            this.btnCancelarDG.Size = new System.Drawing.Size(105, 34);
            this.btnCancelarDG.TabIndex = 2;
            this.btnCancelarDG.Text = "Cancelar";
            this.btnCancelarDG.Click += new System.EventHandler(this.SubBtnCancelarClickDG);
            //
            // frmGastoDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelarDG;
            this.ClientSize = new System.Drawing.Size(460, 330);
            this.Controls.Add(this.gpbDatosDG);
            this.Controls.Add(this.lblMensajeDG);
            this.Controls.Add(this.btnGuardarDG);
            this.Controls.Add(this.btnCancelarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGastoDG";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gasto";
            this.gpbDatosDG.ResumeLayout(false);
            this.gpbDatosDG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDG)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gpbDatosDG;
        private System.Windows.Forms.Label lblFechaDG;
        private System.Windows.Forms.DateTimePicker dtpFechaDG;
        private System.Windows.Forms.Label lblCategoriaDG;
        private System.Windows.Forms.ComboBox cmbCategoriaDG;
        private System.Windows.Forms.Label lblMontoDG;
        private System.Windows.Forms.NumericUpDown nudMontoDG;
        private System.Windows.Forms.Label lblDescripcionDG;
        private System.Windows.Forms.TextBox txtDescripcionDG;
        private System.Windows.Forms.Label lblMensajeDG;
        private System.Windows.Forms.Button btnGuardarDG;
        private System.Windows.Forms.Button btnCancelarDG;
    }
}
