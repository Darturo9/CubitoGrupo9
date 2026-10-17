namespace WinCubitoDG
{
    partial class frmMovimientoDG
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
            this.lblArticuloDG = new System.Windows.Forms.Label();
            this.lblStockActualDG = new System.Windows.Forms.Label();
            this.gpbMovimientoDG = new System.Windows.Forms.GroupBox();
            this.lblTipoDG = new System.Windows.Forms.Label();
            this.cmbTipoDG = new System.Windows.Forms.ComboBox();
            this.lblCantidadDG = new System.Windows.Forms.Label();
            this.nudCantidadDG = new System.Windows.Forms.NumericUpDown();
            this.lblUnidadDG = new System.Windows.Forms.Label();
            this.lblMotivoDG = new System.Windows.Forms.Label();
            this.txtMotivoDG = new System.Windows.Forms.TextBox();
            this.lblMensajeDG = new System.Windows.Forms.Label();
            this.btnGuardarDG = new System.Windows.Forms.Button();
            this.btnCancelarDG = new System.Windows.Forms.Button();
            this.gpbMovimientoDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadDG)).BeginInit();
            this.SuspendLayout();
            //
            // lblArticuloDG
            //
            this.lblArticuloDG.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblArticuloDG.Location = new System.Drawing.Point(15, 12);
            this.lblArticuloDG.Name = "lblArticuloDG";
            this.lblArticuloDG.Size = new System.Drawing.Size(420, 25);
            this.lblArticuloDG.Text = "Artículo";
            //
            // lblStockActualDG
            //
            this.lblStockActualDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblStockActualDG.Location = new System.Drawing.Point(15, 38);
            this.lblStockActualDG.Name = "lblStockActualDG";
            this.lblStockActualDG.Size = new System.Drawing.Size(420, 20);
            this.lblStockActualDG.Text = "Stock actual:";
            //
            // gpbMovimientoDG
            //
            this.gpbMovimientoDG.Controls.Add(this.lblTipoDG);
            this.gpbMovimientoDG.Controls.Add(this.cmbTipoDG);
            this.gpbMovimientoDG.Controls.Add(this.lblCantidadDG);
            this.gpbMovimientoDG.Controls.Add(this.nudCantidadDG);
            this.gpbMovimientoDG.Controls.Add(this.lblUnidadDG);
            this.gpbMovimientoDG.Controls.Add(this.lblMotivoDG);
            this.gpbMovimientoDG.Controls.Add(this.txtMotivoDG);
            this.gpbMovimientoDG.Location = new System.Drawing.Point(15, 66);
            this.gpbMovimientoDG.Name = "gpbMovimientoDG";
            this.gpbMovimientoDG.Size = new System.Drawing.Size(420, 175);
            this.gpbMovimientoDG.Text = "Movimiento";
            //
            // lblTipoDG
            //
            this.lblTipoDG.Location = new System.Drawing.Point(15, 28);
            this.lblTipoDG.Name = "lblTipoDG";
            this.lblTipoDG.Size = new System.Drawing.Size(80, 23);
            this.lblTipoDG.Text = "Tipo:";
            this.lblTipoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbTipoDG
            //
            this.cmbTipoDG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDG.Location = new System.Drawing.Point(100, 28);
            this.cmbTipoDG.Name = "cmbTipoDG";
            this.cmbTipoDG.Size = new System.Drawing.Size(300, 23);
            this.cmbTipoDG.TabIndex = 0;
            //
            // lblCantidadDG
            //
            this.lblCantidadDG.Location = new System.Drawing.Point(15, 62);
            this.lblCantidadDG.Name = "lblCantidadDG";
            this.lblCantidadDG.Size = new System.Drawing.Size(80, 23);
            this.lblCantidadDG.Text = "Cantidad:";
            this.lblCantidadDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // nudCantidadDG
            //
            this.nudCantidadDG.Location = new System.Drawing.Point(100, 62);
            this.nudCantidadDG.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudCantidadDG.Name = "nudCantidadDG";
            this.nudCantidadDG.Size = new System.Drawing.Size(110, 23);
            this.nudCantidadDG.TabIndex = 1;
            this.nudCantidadDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblUnidadDG
            //
            this.lblUnidadDG.Location = new System.Drawing.Point(215, 62);
            this.lblUnidadDG.Name = "lblUnidadDG";
            this.lblUnidadDG.Size = new System.Drawing.Size(100, 23);
            this.lblUnidadDG.Text = "Unidad";
            this.lblUnidadDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblMotivoDG
            //
            this.lblMotivoDG.Location = new System.Drawing.Point(15, 96);
            this.lblMotivoDG.Name = "lblMotivoDG";
            this.lblMotivoDG.Size = new System.Drawing.Size(80, 23);
            this.lblMotivoDG.Text = "Motivo:";
            this.lblMotivoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtMotivoDG
            //
            this.txtMotivoDG.Location = new System.Drawing.Point(100, 96);
            this.txtMotivoDG.MaxLength = 200;
            this.txtMotivoDG.Multiline = true;
            this.txtMotivoDG.Name = "txtMotivoDG";
            this.txtMotivoDG.Size = new System.Drawing.Size(300, 60);
            this.txtMotivoDG.TabIndex = 2;
            //
            // lblMensajeDG
            //
            this.lblMensajeDG.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMensajeDG.Location = new System.Drawing.Point(15, 247);
            this.lblMensajeDG.Name = "lblMensajeDG";
            this.lblMensajeDG.Size = new System.Drawing.Size(420, 38);
            //
            // btnGuardarDG
            //
            this.btnGuardarDG.Location = new System.Drawing.Point(225, 290);
            this.btnGuardarDG.Name = "btnGuardarDG";
            this.btnGuardarDG.Size = new System.Drawing.Size(100, 32);
            this.btnGuardarDG.TabIndex = 3;
            this.btnGuardarDG.Text = "Registrar";
            this.btnGuardarDG.Click += new System.EventHandler(this.SubBtnGuardarClickDG);
            //
            // btnCancelarDG
            //
            this.btnCancelarDG.Location = new System.Drawing.Point(335, 290);
            this.btnCancelarDG.Name = "btnCancelarDG";
            this.btnCancelarDG.Size = new System.Drawing.Size(100, 32);
            this.btnCancelarDG.TabIndex = 4;
            this.btnCancelarDG.Text = "Cancelar";
            this.btnCancelarDG.Click += new System.EventHandler(this.SubBtnCancelarClickDG);
            //
            // frmMovimientoDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelarDG;
            this.ClientSize = new System.Drawing.Size(450, 336);
            this.Controls.Add(this.lblArticuloDG);
            this.Controls.Add(this.lblStockActualDG);
            this.Controls.Add(this.gpbMovimientoDG);
            this.Controls.Add(this.lblMensajeDG);
            this.Controls.Add(this.btnGuardarDG);
            this.Controls.Add(this.btnCancelarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMovimientoDG";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entrada / salida de inventario";
            this.gpbMovimientoDG.ResumeLayout(false);
            this.gpbMovimientoDG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadDG)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblArticuloDG;
        private System.Windows.Forms.Label lblStockActualDG;
        private System.Windows.Forms.GroupBox gpbMovimientoDG;
        private System.Windows.Forms.Label lblTipoDG;
        private System.Windows.Forms.ComboBox cmbTipoDG;
        private System.Windows.Forms.Label lblCantidadDG;
        private System.Windows.Forms.NumericUpDown nudCantidadDG;
        private System.Windows.Forms.Label lblUnidadDG;
        private System.Windows.Forms.Label lblMotivoDG;
        private System.Windows.Forms.TextBox txtMotivoDG;
        private System.Windows.Forms.Label lblMensajeDG;
        private System.Windows.Forms.Button btnGuardarDG;
        private System.Windows.Forms.Button btnCancelarDG;
    }
}
