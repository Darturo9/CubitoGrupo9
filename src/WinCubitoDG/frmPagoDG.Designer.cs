namespace WinCubitoDG
{
    partial class frmPagoDG
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
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloFechaDG = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloMonedaDG = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloEncabezadoDG = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCodigoDG = new System.Windows.Forms.Label();
            this.lblClienteDG = new System.Windows.Forms.Label();
            this.lblTotalDG = new System.Windows.Forms.Label();
            this.lblPagadoDG = new System.Windows.Forms.Label();
            this.lblSaldoDG = new System.Windows.Forms.Label();
            this.dgvPagosDG = new System.Windows.Forms.DataGridView();
            this.colFechaDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarPagoDG = new System.Windows.Forms.Button();
            this.gpbNuevoPagoDG = new System.Windows.Forms.GroupBox();
            this.lblMontoDG = new System.Windows.Forms.Label();
            this.nudMontoDG = new System.Windows.Forms.NumericUpDown();
            this.lblMetodoDG = new System.Windows.Forms.Label();
            this.cmbMetodoDG = new System.Windows.Forms.ComboBox();
            this.btnRegistrarDG = new System.Windows.Forms.Button();
            this.lblMensajeDG = new System.Windows.Forms.Label();
            this.btnCerrarDG = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosDG)).BeginInit();
            this.gpbNuevoPagoDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDG)).BeginInit();
            this.SuspendLayout();
            //
            // lblCodigoDG
            //
            this.lblCodigoDG.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCodigoDG.Location = new System.Drawing.Point(20, 12);
            this.lblCodigoDG.Name = "lblCodigoDG";
            this.lblCodigoDG.Size = new System.Drawing.Size(300, 34);
            //
            // lblClienteDG
            //
            this.lblClienteDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblClienteDG.Location = new System.Drawing.Point(22, 46);
            this.lblClienteDG.Name = "lblClienteDG";
            this.lblClienteDG.Size = new System.Drawing.Size(500, 20);
            //
            // lblTotalDG
            //
            this.lblTotalDG.BackColor = System.Drawing.Color.FromArgb(236, 237, 242);
            this.lblTotalDG.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalDG.Location = new System.Drawing.Point(20, 75);
            this.lblTotalDG.Name = "lblTotalDG";
            this.lblTotalDG.Size = new System.Drawing.Size(168, 48);
            this.lblTotalDG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblPagadoDG
            //
            this.lblPagadoDG.BackColor = System.Drawing.Color.FromArgb(236, 237, 242);
            this.lblPagadoDG.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPagadoDG.Location = new System.Drawing.Point(196, 75);
            this.lblPagadoDG.Name = "lblPagadoDG";
            this.lblPagadoDG.Size = new System.Drawing.Size(168, 48);
            this.lblPagadoDG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSaldoDG
            //
            this.lblSaldoDG.BackColor = System.Drawing.Color.FromArgb(236, 237, 242);
            this.lblSaldoDG.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSaldoDG.Location = new System.Drawing.Point(372, 75);
            this.lblSaldoDG.Name = "lblSaldoDG";
            this.lblSaldoDG.Size = new System.Drawing.Size(168, 48);
            this.lblSaldoDG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // dgvPagosDG
            //
            this.dgvPagosDG.AllowUserToAddRows = false;
            this.dgvPagosDG.AllowUserToDeleteRows = false;
            this.dgvPagosDG.AllowUserToResizeRows = false;
            this.dgvPagosDG.BackgroundColor = System.Drawing.SystemColors.Window;
            lObjEstiloEncabezadoDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvPagosDG.ColumnHeadersDefaultCellStyle = lObjEstiloEncabezadoDG;
            this.dgvPagosDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagosDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFechaDG,
            this.colMetodoDG,
            this.colMontoDG});
            this.dgvPagosDG.Location = new System.Drawing.Point(20, 135);
            this.dgvPagosDG.MultiSelect = false;
            this.dgvPagosDG.Name = "dgvPagosDG";
            this.dgvPagosDG.ReadOnly = true;
            this.dgvPagosDG.RowHeadersVisible = false;
            this.dgvPagosDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagosDG.Size = new System.Drawing.Size(520, 170);
            this.dgvPagosDG.TabIndex = 4;
            //
            // Columnas
            //
            lObjEstiloFechaDG.Format = "dd/MM/yyyy HH:mm";
            lObjEstiloMonedaDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloMonedaDG.Format = "N2";
            this.colFechaDG.DataPropertyName = "gDtmFechaDG";
            this.colFechaDG.DefaultCellStyle = lObjEstiloFechaDG;
            this.colFechaDG.HeaderText = "Fecha";
            this.colFechaDG.Name = "colFechaDG";
            this.colFechaDG.Width = 140;
            this.colMetodoDG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMetodoDG.DataPropertyName = "gStrMetodoDG";
            this.colMetodoDG.HeaderText = "Método";
            this.colMetodoDG.Name = "colMetodoDG";
            this.colMontoDG.DataPropertyName = "gDcmMontoDG";
            this.colMontoDG.DefaultCellStyle = lObjEstiloMonedaDG;
            this.colMontoDG.HeaderText = "Monto (Q)";
            this.colMontoDG.Name = "colMontoDG";
            this.colMontoDG.Width = 110;
            //
            // btnEliminarPagoDG
            //
            this.btnEliminarPagoDG.ForeColor = System.Drawing.Color.Firebrick;
            this.btnEliminarPagoDG.Location = new System.Drawing.Point(20, 311);
            this.btnEliminarPagoDG.Name = "btnEliminarPagoDG";
            this.btnEliminarPagoDG.Size = new System.Drawing.Size(130, 30);
            this.btnEliminarPagoDG.TabIndex = 5;
            this.btnEliminarPagoDG.Text = "Eliminar pago";
            this.btnEliminarPagoDG.Click += new System.EventHandler(this.SubBtnEliminarPagoClickDG);
            //
            // gpbNuevoPagoDG
            //
            this.gpbNuevoPagoDG.Controls.Add(this.lblMontoDG);
            this.gpbNuevoPagoDG.Controls.Add(this.nudMontoDG);
            this.gpbNuevoPagoDG.Controls.Add(this.lblMetodoDG);
            this.gpbNuevoPagoDG.Controls.Add(this.cmbMetodoDG);
            this.gpbNuevoPagoDG.Controls.Add(this.btnRegistrarDG);
            this.gpbNuevoPagoDG.Location = new System.Drawing.Point(20, 352);
            this.gpbNuevoPagoDG.Name = "gpbNuevoPagoDG";
            this.gpbNuevoPagoDG.Size = new System.Drawing.Size(520, 68);
            this.gpbNuevoPagoDG.TabIndex = 0;
            this.gpbNuevoPagoDG.Text = "Nuevo pago o anticipo";
            //
            // lblMontoDG
            //
            this.lblMontoDG.Location = new System.Drawing.Point(12, 27);
            this.lblMontoDG.Name = "lblMontoDG";
            this.lblMontoDG.Size = new System.Drawing.Size(70, 23);
            this.lblMontoDG.Text = "Monto (Q):";
            this.lblMontoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // nudMontoDG
            //
            this.nudMontoDG.DecimalPlaces = 2;
            this.nudMontoDG.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudMontoDG.Location = new System.Drawing.Point(85, 27);
            this.nudMontoDG.Name = "nudMontoDG";
            this.nudMontoDG.Size = new System.Drawing.Size(110, 23);
            this.nudMontoDG.TabIndex = 1;
            this.nudMontoDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMontoDG.ThousandsSeparator = true;
            this.nudMontoDG.Enter += new System.EventHandler(this.SubNudMontoEnterDG);
            //
            // lblMetodoDG
            //
            this.lblMetodoDG.Location = new System.Drawing.Point(210, 27);
            this.lblMetodoDG.Name = "lblMetodoDG";
            this.lblMetodoDG.Size = new System.Drawing.Size(55, 23);
            this.lblMetodoDG.Text = "Método:";
            this.lblMetodoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbMetodoDG
            //
            this.cmbMetodoDG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoDG.Location = new System.Drawing.Point(268, 27);
            this.cmbMetodoDG.Name = "cmbMetodoDG";
            this.cmbMetodoDG.Size = new System.Drawing.Size(115, 23);
            this.cmbMetodoDG.TabIndex = 2;
            //
            // btnRegistrarDG
            //
            this.btnRegistrarDG.Location = new System.Drawing.Point(395, 22);
            this.btnRegistrarDG.Name = "btnRegistrarDG";
            this.btnRegistrarDG.Size = new System.Drawing.Size(115, 32);
            this.btnRegistrarDG.TabIndex = 3;
            this.btnRegistrarDG.Text = "Registrar pago";
            this.btnRegistrarDG.Click += new System.EventHandler(this.SubBtnRegistrarClickDG);
            //
            // lblMensajeDG
            //
            this.lblMensajeDG.Location = new System.Drawing.Point(20, 428);
            this.lblMensajeDG.Name = "lblMensajeDG";
            this.lblMensajeDG.Size = new System.Drawing.Size(400, 40);
            //
            // btnCerrarDG
            //
            this.btnCerrarDG.Location = new System.Drawing.Point(440, 432);
            this.btnCerrarDG.Name = "btnCerrarDG";
            this.btnCerrarDG.Size = new System.Drawing.Size(100, 34);
            this.btnCerrarDG.TabIndex = 6;
            this.btnCerrarDG.Text = "Cerrar";
            this.btnCerrarDG.Click += new System.EventHandler(this.SubBtnCerrarClickDG);
            //
            // frmPagoDG
            //
            this.AcceptButton = this.btnRegistrarDG;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrarDG;
            this.ClientSize = new System.Drawing.Size(560, 480);
            this.Controls.Add(this.lblCodigoDG);
            this.Controls.Add(this.lblClienteDG);
            this.Controls.Add(this.lblTotalDG);
            this.Controls.Add(this.lblPagadoDG);
            this.Controls.Add(this.lblSaldoDG);
            this.Controls.Add(this.dgvPagosDG);
            this.Controls.Add(this.btnEliminarPagoDG);
            this.Controls.Add(this.gpbNuevoPagoDG);
            this.Controls.Add(this.lblMensajeDG);
            this.Controls.Add(this.btnCerrarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPagoDG";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pagos del pedido";
            this.Load += new System.EventHandler(this.SubFrmPagoLoadDG);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosDG)).EndInit();
            this.gpbNuevoPagoDG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDG)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblCodigoDG;
        private System.Windows.Forms.Label lblClienteDG;
        private System.Windows.Forms.Label lblTotalDG;
        private System.Windows.Forms.Label lblPagadoDG;
        private System.Windows.Forms.Label lblSaldoDG;
        private System.Windows.Forms.DataGridView dgvPagosDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetodoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoDG;
        private System.Windows.Forms.Button btnEliminarPagoDG;
        private System.Windows.Forms.GroupBox gpbNuevoPagoDG;
        private System.Windows.Forms.Label lblMontoDG;
        private System.Windows.Forms.NumericUpDown nudMontoDG;
        private System.Windows.Forms.Label lblMetodoDG;
        private System.Windows.Forms.ComboBox cmbMetodoDG;
        private System.Windows.Forms.Button btnRegistrarDG;
        private System.Windows.Forms.Label lblMensajeDG;
        private System.Windows.Forms.Button btnCerrarDG;
    }
}
