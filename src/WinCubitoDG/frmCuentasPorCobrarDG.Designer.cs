namespace WinCubitoDG
{
    partial class frmCuentasPorCobrarDG
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
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloSaldoDG = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloEncabezadoDG = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTituloDG = new System.Windows.Forms.Label();
            this.gpbFiltrosDG = new System.Windows.Forms.GroupBox();
            this.lblBuscarDG = new System.Windows.Forms.Label();
            this.txtBuscarDG = new System.Windows.Forms.TextBox();
            this.lblResumenDG = new System.Windows.Forms.Label();
            this.dgvCuentasDG = new System.Windows.Forms.DataGridView();
            this.colCodigoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClienteDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntregaDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPagadoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRegistrarPagoDG = new System.Windows.Forms.Button();
            this.btnAbrirDG = new System.Windows.Forms.Button();
            this.btnCerrarDG = new System.Windows.Forms.Button();
            this.gpbFiltrosDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasDG)).BeginInit();
            this.SuspendLayout();
            //
            // lblTituloDG
            //
            this.lblTituloDG.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloDG.Location = new System.Drawing.Point(20, 12);
            this.lblTituloDG.Name = "lblTituloDG";
            this.lblTituloDG.Size = new System.Drawing.Size(400, 40);
            this.lblTituloDG.Text = "Cuentas por cobrar";
            //
            // gpbFiltrosDG
            //
            this.gpbFiltrosDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbFiltrosDG.Controls.Add(this.lblBuscarDG);
            this.gpbFiltrosDG.Controls.Add(this.txtBuscarDG);
            this.gpbFiltrosDG.Controls.Add(this.lblResumenDG);
            this.gpbFiltrosDG.Location = new System.Drawing.Point(20, 58);
            this.gpbFiltrosDG.Name = "gpbFiltrosDG";
            this.gpbFiltrosDG.Size = new System.Drawing.Size(860, 62);
            this.gpbFiltrosDG.Text = "Filtros";
            //
            // lblBuscarDG
            //
            this.lblBuscarDG.Location = new System.Drawing.Point(15, 25);
            this.lblBuscarDG.Name = "lblBuscarDG";
            this.lblBuscarDG.Size = new System.Drawing.Size(55, 23);
            this.lblBuscarDG.Text = "Buscar:";
            this.lblBuscarDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtBuscarDG
            //
            this.txtBuscarDG.Location = new System.Drawing.Point(75, 25);
            this.txtBuscarDG.Name = "txtBuscarDG";
            this.txtBuscarDG.Size = new System.Drawing.Size(220, 23);
            this.txtBuscarDG.TabIndex = 0;
            this.txtBuscarDG.TextChanged += new System.EventHandler(this.SubTxtBuscarTextChangedDG);
            //
            // lblResumenDG
            //
            this.lblResumenDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumenDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResumenDG.Location = new System.Drawing.Point(310, 25);
            this.lblResumenDG.Name = "lblResumenDG";
            this.lblResumenDG.Size = new System.Drawing.Size(535, 23);
            this.lblResumenDG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // dgvCuentasDG
            //
            this.dgvCuentasDG.AllowUserToAddRows = false;
            this.dgvCuentasDG.AllowUserToDeleteRows = false;
            this.dgvCuentasDG.AllowUserToResizeRows = false;
            this.dgvCuentasDG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCuentasDG.BackgroundColor = System.Drawing.SystemColors.Window;
            lObjEstiloEncabezadoDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvCuentasDG.ColumnHeadersDefaultCellStyle = lObjEstiloEncabezadoDG;
            this.dgvCuentasDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentasDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoDG,
            this.colClienteDG,
            this.colEstadoDG,
            this.colEntregaDG,
            this.colTotalDG,
            this.colPagadoDG,
            this.colSaldoDG});
            this.dgvCuentasDG.Location = new System.Drawing.Point(20, 130);
            this.dgvCuentasDG.MultiSelect = false;
            this.dgvCuentasDG.Name = "dgvCuentasDG";
            this.dgvCuentasDG.ReadOnly = true;
            this.dgvCuentasDG.RowHeadersVisible = false;
            this.dgvCuentasDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentasDG.Size = new System.Drawing.Size(710, 390);
            this.dgvCuentasDG.TabIndex = 1;
            this.dgvCuentasDG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SubDgvCuentasCellDoubleClickDG);
            this.dgvCuentasDG.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.SubDgvCuentasCellFormattingDG);
            //
            // Columnas
            //
            lObjEstiloFechaDG.Format = "dd/MM/yyyy";
            lObjEstiloMonedaDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloMonedaDG.Format = "N2";
            lObjEstiloSaldoDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloSaldoDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lObjEstiloSaldoDG.ForeColor = System.Drawing.Color.Firebrick;
            lObjEstiloSaldoDG.Format = "N2";
            this.colCodigoDG.DataPropertyName = "gStrCodigoDG";
            this.colCodigoDG.HeaderText = "Código";
            this.colCodigoDG.Name = "colCodigoDG";
            this.colCodigoDG.Width = 75;
            this.colClienteDG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClienteDG.DataPropertyName = "gStrNombreClienteDG";
            this.colClienteDG.HeaderText = "Cliente";
            this.colClienteDG.MinimumWidth = 120;
            this.colClienteDG.Name = "colClienteDG";
            this.colEstadoDG.DataPropertyName = "gStrEstadoDG";
            this.colEstadoDG.HeaderText = "Estado";
            this.colEstadoDG.Name = "colEstadoDG";
            this.colEstadoDG.Width = 95;
            this.colEntregaDG.DataPropertyName = "gDtmFechaEntregaDG";
            this.colEntregaDG.DefaultCellStyle = lObjEstiloFechaDG;
            this.colEntregaDG.HeaderText = "Entrega";
            this.colEntregaDG.Name = "colEntregaDG";
            this.colEntregaDG.Width = 80;
            this.colTotalDG.DataPropertyName = "gDcmTotalDG";
            this.colTotalDG.DefaultCellStyle = lObjEstiloMonedaDG;
            this.colTotalDG.HeaderText = "Total (Q)";
            this.colTotalDG.Name = "colTotalDG";
            this.colTotalDG.Width = 85;
            this.colPagadoDG.DataPropertyName = "gDcmTotalPagadoDG";
            this.colPagadoDG.DefaultCellStyle = lObjEstiloMonedaDG;
            this.colPagadoDG.HeaderText = "Pagado (Q)";
            this.colPagadoDG.Name = "colPagadoDG";
            this.colPagadoDG.Width = 85;
            this.colSaldoDG.DataPropertyName = "gDcmSaldoDG";
            this.colSaldoDG.DefaultCellStyle = lObjEstiloSaldoDG;
            this.colSaldoDG.HeaderText = "Saldo (Q)";
            this.colSaldoDG.Name = "colSaldoDG";
            this.colSaldoDG.Width = 85;
            //
            // btnRegistrarPagoDG
            //
            this.btnRegistrarPagoDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrarPagoDG.Location = new System.Drawing.Point(745, 130);
            this.btnRegistrarPagoDG.Name = "btnRegistrarPagoDG";
            this.btnRegistrarPagoDG.Size = new System.Drawing.Size(135, 36);
            this.btnRegistrarPagoDG.TabIndex = 2;
            this.btnRegistrarPagoDG.Text = "Registrar pago";
            this.btnRegistrarPagoDG.Click += new System.EventHandler(this.SubBtnRegistrarPagoClickDG);
            //
            // btnAbrirDG
            //
            this.btnAbrirDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirDG.Location = new System.Drawing.Point(745, 174);
            this.btnAbrirDG.Name = "btnAbrirDG";
            this.btnAbrirDG.Size = new System.Drawing.Size(135, 36);
            this.btnAbrirDG.TabIndex = 3;
            this.btnAbrirDG.Text = "Abrir pedido";
            this.btnAbrirDG.Click += new System.EventHandler(this.SubBtnAbrirClickDG);
            //
            // btnCerrarDG
            //
            this.btnCerrarDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarDG.Location = new System.Drawing.Point(745, 484);
            this.btnCerrarDG.Name = "btnCerrarDG";
            this.btnCerrarDG.Size = new System.Drawing.Size(135, 36);
            this.btnCerrarDG.TabIndex = 4;
            this.btnCerrarDG.Text = "Cerrar";
            this.btnCerrarDG.Click += new System.EventHandler(this.SubBtnCerrarClickDG);
            //
            // frmCuentasPorCobrarDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrarDG;
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.lblTituloDG);
            this.Controls.Add(this.gpbFiltrosDG);
            this.Controls.Add(this.dgvCuentasDG);
            this.Controls.Add(this.btnRegistrarPagoDG);
            this.Controls.Add(this.btnAbrirDG);
            this.Controls.Add(this.btnCerrarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(760, 420);
            this.Name = "frmCuentasPorCobrarDG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cubito - Cuentas por cobrar";
            this.Load += new System.EventHandler(this.SubFrmCuentasPorCobrarLoadDG);
            this.gpbFiltrosDG.ResumeLayout(false);
            this.gpbFiltrosDG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasDG)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTituloDG;
        private System.Windows.Forms.GroupBox gpbFiltrosDG;
        private System.Windows.Forms.Label lblBuscarDG;
        private System.Windows.Forms.TextBox txtBuscarDG;
        private System.Windows.Forms.Label lblResumenDG;
        private System.Windows.Forms.DataGridView dgvCuentasDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClienteDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntregaDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPagadoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoDG;
        private System.Windows.Forms.Button btnRegistrarPagoDG;
        private System.Windows.Forms.Button btnAbrirDG;
        private System.Windows.Forms.Button btnCerrarDG;
    }
}
