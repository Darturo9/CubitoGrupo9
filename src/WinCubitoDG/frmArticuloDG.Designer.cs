namespace WinCubitoDG
{
    partial class frmArticuloDG
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
            this.lblCodigoDG = new System.Windows.Forms.Label();
            this.txtCodigoDG = new System.Windows.Forms.TextBox();
            this.lblNombreDG = new System.Windows.Forms.Label();
            this.txtNombreDG = new System.Windows.Forms.TextBox();
            this.lblTipoDG = new System.Windows.Forms.Label();
            this.cmbTipoDG = new System.Windows.Forms.ComboBox();
            this.lblTallaDG = new System.Windows.Forms.Label();
            this.txtTallaDG = new System.Windows.Forms.TextBox();
            this.lblColorDG = new System.Windows.Forms.Label();
            this.txtColorDG = new System.Windows.Forms.TextBox();
            this.lblUnidadDG = new System.Windows.Forms.Label();
            this.cmbUnidadDG = new System.Windows.Forms.ComboBox();
            this.lblStockDG = new System.Windows.Forms.Label();
            this.nudStockInicialDG = new System.Windows.Forms.NumericUpDown();
            this.lblAyudaStockDG = new System.Windows.Forms.Label();
            this.lblMinimoDG = new System.Windows.Forms.Label();
            this.nudMinimoDG = new System.Windows.Forms.NumericUpDown();
            this.lblMaximoDG = new System.Windows.Forms.Label();
            this.nudMaximoDG = new System.Windows.Forms.NumericUpDown();
            this.lblCostoDG = new System.Windows.Forms.Label();
            this.nudCostoDG = new System.Windows.Forms.NumericUpDown();
            this.lblMensajeDG = new System.Windows.Forms.Label();
            this.btnGuardarDG = new System.Windows.Forms.Button();
            this.btnCancelarDG = new System.Windows.Forms.Button();
            this.gpbDatosDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockInicialDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimoDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximoDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCostoDG)).BeginInit();
            this.SuspendLayout();
            //
            // gpbDatosDG
            //
            this.gpbDatosDG.Controls.Add(this.lblCodigoDG);
            this.gpbDatosDG.Controls.Add(this.txtCodigoDG);
            this.gpbDatosDG.Controls.Add(this.lblNombreDG);
            this.gpbDatosDG.Controls.Add(this.txtNombreDG);
            this.gpbDatosDG.Controls.Add(this.lblTipoDG);
            this.gpbDatosDG.Controls.Add(this.cmbTipoDG);
            this.gpbDatosDG.Controls.Add(this.lblTallaDG);
            this.gpbDatosDG.Controls.Add(this.txtTallaDG);
            this.gpbDatosDG.Controls.Add(this.lblColorDG);
            this.gpbDatosDG.Controls.Add(this.txtColorDG);
            this.gpbDatosDG.Controls.Add(this.lblUnidadDG);
            this.gpbDatosDG.Controls.Add(this.cmbUnidadDG);
            this.gpbDatosDG.Controls.Add(this.lblStockDG);
            this.gpbDatosDG.Controls.Add(this.nudStockInicialDG);
            this.gpbDatosDG.Controls.Add(this.lblAyudaStockDG);
            this.gpbDatosDG.Controls.Add(this.lblMinimoDG);
            this.gpbDatosDG.Controls.Add(this.nudMinimoDG);
            this.gpbDatosDG.Controls.Add(this.lblMaximoDG);
            this.gpbDatosDG.Controls.Add(this.nudMaximoDG);
            this.gpbDatosDG.Controls.Add(this.lblCostoDG);
            this.gpbDatosDG.Controls.Add(this.nudCostoDG);
            this.gpbDatosDG.Location = new System.Drawing.Point(15, 12);
            this.gpbDatosDG.Name = "gpbDatosDG";
            this.gpbDatosDG.Size = new System.Drawing.Size(400, 360);
            this.gpbDatosDG.Text = "Datos del artículo";
            //
            // lblCodigoDG
            //
            this.lblCodigoDG.Location = new System.Drawing.Point(15, 28);
            this.lblCodigoDG.Name = "lblCodigoDG";
            this.lblCodigoDG.Size = new System.Drawing.Size(115, 23);
            this.lblCodigoDG.Text = "Código:";
            this.lblCodigoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtCodigoDG
            //
            this.txtCodigoDG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoDG.Location = new System.Drawing.Point(135, 28);
            this.txtCodigoDG.MaxLength = 20;
            this.txtCodigoDG.Name = "txtCodigoDG";
            this.txtCodigoDG.Size = new System.Drawing.Size(150, 23);
            this.txtCodigoDG.TabIndex = 0;
            //
            // lblNombreDG
            //
            this.lblNombreDG.Location = new System.Drawing.Point(15, 62);
            this.lblNombreDG.Name = "lblNombreDG";
            this.lblNombreDG.Size = new System.Drawing.Size(115, 23);
            this.lblNombreDG.Text = "Nombre:";
            this.lblNombreDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtNombreDG
            //
            this.txtNombreDG.Location = new System.Drawing.Point(135, 62);
            this.txtNombreDG.MaxLength = 100;
            this.txtNombreDG.Name = "txtNombreDG";
            this.txtNombreDG.Size = new System.Drawing.Size(245, 23);
            this.txtNombreDG.TabIndex = 1;
            //
            // lblTipoDG
            //
            this.lblTipoDG.Location = new System.Drawing.Point(15, 96);
            this.lblTipoDG.Name = "lblTipoDG";
            this.lblTipoDG.Size = new System.Drawing.Size(115, 23);
            this.lblTipoDG.Text = "Tipo:";
            this.lblTipoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbTipoDG
            //
            this.cmbTipoDG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDG.Location = new System.Drawing.Point(135, 96);
            this.cmbTipoDG.Name = "cmbTipoDG";
            this.cmbTipoDG.Size = new System.Drawing.Size(150, 23);
            this.cmbTipoDG.TabIndex = 2;
            this.cmbTipoDG.SelectedIndexChanged += new System.EventHandler(this.SubCmbTipoSelectedIndexChangedDG);
            //
            // lblTallaDG
            //
            this.lblTallaDG.Location = new System.Drawing.Point(15, 130);
            this.lblTallaDG.Name = "lblTallaDG";
            this.lblTallaDG.Size = new System.Drawing.Size(115, 23);
            this.lblTallaDG.Text = "Talla:";
            this.lblTallaDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtTallaDG
            //
            this.txtTallaDG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTallaDG.Location = new System.Drawing.Point(135, 130);
            this.txtTallaDG.MaxLength = 10;
            this.txtTallaDG.Name = "txtTallaDG";
            this.txtTallaDG.Size = new System.Drawing.Size(80, 23);
            this.txtTallaDG.TabIndex = 3;
            //
            // lblColorDG
            //
            this.lblColorDG.Location = new System.Drawing.Point(15, 164);
            this.lblColorDG.Name = "lblColorDG";
            this.lblColorDG.Size = new System.Drawing.Size(115, 23);
            this.lblColorDG.Text = "Color:";
            this.lblColorDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtColorDG
            //
            this.txtColorDG.Location = new System.Drawing.Point(135, 164);
            this.txtColorDG.MaxLength = 30;
            this.txtColorDG.Name = "txtColorDG";
            this.txtColorDG.Size = new System.Drawing.Size(150, 23);
            this.txtColorDG.TabIndex = 4;
            //
            // lblUnidadDG
            //
            this.lblUnidadDG.Location = new System.Drawing.Point(15, 198);
            this.lblUnidadDG.Name = "lblUnidadDG";
            this.lblUnidadDG.Size = new System.Drawing.Size(115, 23);
            this.lblUnidadDG.Text = "Unidad:";
            this.lblUnidadDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbUnidadDG
            //
            this.cmbUnidadDG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadDG.Location = new System.Drawing.Point(135, 198);
            this.cmbUnidadDG.Name = "cmbUnidadDG";
            this.cmbUnidadDG.Size = new System.Drawing.Size(150, 23);
            this.cmbUnidadDG.TabIndex = 5;
            //
            // lblStockDG
            //
            this.lblStockDG.Location = new System.Drawing.Point(15, 232);
            this.lblStockDG.Name = "lblStockDG";
            this.lblStockDG.Size = new System.Drawing.Size(115, 23);
            this.lblStockDG.Text = "Stock inicial:";
            this.lblStockDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // nudStockInicialDG
            //
            this.nudStockInicialDG.DecimalPlaces = 2;
            this.nudStockInicialDG.Location = new System.Drawing.Point(135, 232);
            this.nudStockInicialDG.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudStockInicialDG.Name = "nudStockInicialDG";
            this.nudStockInicialDG.Size = new System.Drawing.Size(100, 23);
            this.nudStockInicialDG.TabIndex = 6;
            this.nudStockInicialDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblAyudaStockDG
            //
            this.lblAyudaStockDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblAyudaStockDG.Location = new System.Drawing.Point(240, 226);
            this.lblAyudaStockDG.Name = "lblAyudaStockDG";
            this.lblAyudaStockDG.Size = new System.Drawing.Size(150, 34);
            this.lblAyudaStockDG.Text = "Se cambia con Entrada / salida";
            this.lblAyudaStockDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblMinimoDG
            //
            this.lblMinimoDG.Location = new System.Drawing.Point(15, 266);
            this.lblMinimoDG.Name = "lblMinimoDG";
            this.lblMinimoDG.Size = new System.Drawing.Size(115, 23);
            this.lblMinimoDG.Text = "Stock mínimo:";
            this.lblMinimoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // nudMinimoDG
            //
            this.nudMinimoDG.DecimalPlaces = 2;
            this.nudMinimoDG.Location = new System.Drawing.Point(135, 266);
            this.nudMinimoDG.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudMinimoDG.Name = "nudMinimoDG";
            this.nudMinimoDG.Size = new System.Drawing.Size(100, 23);
            this.nudMinimoDG.TabIndex = 7;
            this.nudMinimoDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblMaximoDG
            //
            this.lblMaximoDG.Location = new System.Drawing.Point(15, 300);
            this.lblMaximoDG.Name = "lblMaximoDG";
            this.lblMaximoDG.Size = new System.Drawing.Size(115, 23);
            this.lblMaximoDG.Text = "Stock máximo:";
            this.lblMaximoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // nudMaximoDG
            //
            this.nudMaximoDG.DecimalPlaces = 2;
            this.nudMaximoDG.Location = new System.Drawing.Point(135, 300);
            this.nudMaximoDG.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudMaximoDG.Name = "nudMaximoDG";
            this.nudMaximoDG.Size = new System.Drawing.Size(100, 23);
            this.nudMaximoDG.TabIndex = 8;
            this.nudMaximoDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblCostoDG
            //
            this.lblCostoDG.Location = new System.Drawing.Point(240, 266);
            this.lblCostoDG.Name = "lblCostoDG";
            this.lblCostoDG.Size = new System.Drawing.Size(140, 23);
            this.lblCostoDG.Text = "Costo unitario (Q):";
            this.lblCostoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // nudCostoDG
            //
            this.nudCostoDG.DecimalPlaces = 2;
            this.nudCostoDG.Location = new System.Drawing.Point(255, 300);
            this.nudCostoDG.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudCostoDG.Name = "nudCostoDG";
            this.nudCostoDG.Size = new System.Drawing.Size(100, 23);
            this.nudCostoDG.TabIndex = 9;
            this.nudCostoDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblMensajeDG
            //
            this.lblMensajeDG.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMensajeDG.Location = new System.Drawing.Point(15, 378);
            this.lblMensajeDG.Name = "lblMensajeDG";
            this.lblMensajeDG.Size = new System.Drawing.Size(400, 38);
            //
            // btnGuardarDG
            //
            this.btnGuardarDG.Location = new System.Drawing.Point(205, 422);
            this.btnGuardarDG.Name = "btnGuardarDG";
            this.btnGuardarDG.Size = new System.Drawing.Size(100, 32);
            this.btnGuardarDG.TabIndex = 10;
            this.btnGuardarDG.Text = "Guardar";
            this.btnGuardarDG.Click += new System.EventHandler(this.SubBtnGuardarClickDG);
            //
            // btnCancelarDG
            //
            this.btnCancelarDG.Location = new System.Drawing.Point(315, 422);
            this.btnCancelarDG.Name = "btnCancelarDG";
            this.btnCancelarDG.Size = new System.Drawing.Size(100, 32);
            this.btnCancelarDG.TabIndex = 11;
            this.btnCancelarDG.Text = "Cancelar";
            this.btnCancelarDG.Click += new System.EventHandler(this.SubBtnCancelarClickDG);
            //
            // frmArticuloDG
            //
            this.AcceptButton = this.btnGuardarDG;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelarDG;
            this.ClientSize = new System.Drawing.Size(430, 468);
            this.Controls.Add(this.gpbDatosDG);
            this.Controls.Add(this.lblMensajeDG);
            this.Controls.Add(this.btnGuardarDG);
            this.Controls.Add(this.btnCancelarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArticuloDG";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Artículo";
            this.gpbDatosDG.ResumeLayout(false);
            this.gpbDatosDG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockInicialDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimoDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximoDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCostoDG)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gpbDatosDG;
        private System.Windows.Forms.Label lblCodigoDG;
        private System.Windows.Forms.TextBox txtCodigoDG;
        private System.Windows.Forms.Label lblNombreDG;
        private System.Windows.Forms.TextBox txtNombreDG;
        private System.Windows.Forms.Label lblTipoDG;
        private System.Windows.Forms.ComboBox cmbTipoDG;
        private System.Windows.Forms.Label lblTallaDG;
        private System.Windows.Forms.TextBox txtTallaDG;
        private System.Windows.Forms.Label lblColorDG;
        private System.Windows.Forms.TextBox txtColorDG;
        private System.Windows.Forms.Label lblUnidadDG;
        private System.Windows.Forms.ComboBox cmbUnidadDG;
        private System.Windows.Forms.Label lblStockDG;
        private System.Windows.Forms.NumericUpDown nudStockInicialDG;
        private System.Windows.Forms.Label lblAyudaStockDG;
        private System.Windows.Forms.Label lblMinimoDG;
        private System.Windows.Forms.NumericUpDown nudMinimoDG;
        private System.Windows.Forms.Label lblMaximoDG;
        private System.Windows.Forms.NumericUpDown nudMaximoDG;
        private System.Windows.Forms.Label lblCostoDG;
        private System.Windows.Forms.NumericUpDown nudCostoDG;
        private System.Windows.Forms.Label lblMensajeDG;
        private System.Windows.Forms.Button btnGuardarDG;
        private System.Windows.Forms.Button btnCancelarDG;
    }
}
