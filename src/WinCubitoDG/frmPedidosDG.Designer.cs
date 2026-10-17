namespace WinCubitoDG
{
    partial class frmPedidosDG
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
            this.lblEstadoDG = new System.Windows.Forms.Label();
            this.cmbEstadoDG = new System.Windows.Forms.ComboBox();
            this.lblResumenDG = new System.Windows.Forms.Label();
            this.dgvPedidosDG = new System.Windows.Forms.DataGridView();
            this.colCodigoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClienteDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntregaDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrigenDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPagadoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevoDG = new System.Windows.Forms.Button();
            this.btnAbrirDG = new System.Windows.Forms.Button();
            this.btnCerrarDG = new System.Windows.Forms.Button();
            this.gpbFiltrosDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosDG)).BeginInit();
            this.SuspendLayout();
            //
            // lblTituloDG
            //
            this.lblTituloDG.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloDG.Location = new System.Drawing.Point(20, 12);
            this.lblTituloDG.Name = "lblTituloDG";
            this.lblTituloDG.Size = new System.Drawing.Size(400, 40);
            this.lblTituloDG.Text = "Pedidos";
            //
            // gpbFiltrosDG
            //
            this.gpbFiltrosDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbFiltrosDG.Controls.Add(this.lblBuscarDG);
            this.gpbFiltrosDG.Controls.Add(this.txtBuscarDG);
            this.gpbFiltrosDG.Controls.Add(this.lblEstadoDG);
            this.gpbFiltrosDG.Controls.Add(this.cmbEstadoDG);
            this.gpbFiltrosDG.Controls.Add(this.lblResumenDG);
            this.gpbFiltrosDG.Location = new System.Drawing.Point(20, 58);
            this.gpbFiltrosDG.Name = "gpbFiltrosDG";
            this.gpbFiltrosDG.Size = new System.Drawing.Size(940, 62);
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
            // lblEstadoDG
            //
            this.lblEstadoDG.Location = new System.Drawing.Point(310, 25);
            this.lblEstadoDG.Name = "lblEstadoDG";
            this.lblEstadoDG.Size = new System.Drawing.Size(50, 23);
            this.lblEstadoDG.Text = "Estado:";
            this.lblEstadoDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbEstadoDG
            //
            this.cmbEstadoDG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoDG.Location = new System.Drawing.Point(365, 25);
            this.cmbEstadoDG.Name = "cmbEstadoDG";
            this.cmbEstadoDG.Size = new System.Drawing.Size(140, 23);
            this.cmbEstadoDG.TabIndex = 1;
            this.cmbEstadoDG.SelectedIndexChanged += new System.EventHandler(this.SubCmbEstadoSelectedIndexChangedDG);
            //
            // lblResumenDG
            //
            this.lblResumenDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumenDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResumenDG.Location = new System.Drawing.Point(520, 25);
            this.lblResumenDG.Name = "lblResumenDG";
            this.lblResumenDG.Size = new System.Drawing.Size(405, 23);
            this.lblResumenDG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // dgvPedidosDG
            //
            this.dgvPedidosDG.AllowUserToAddRows = false;
            this.dgvPedidosDG.AllowUserToDeleteRows = false;
            this.dgvPedidosDG.AllowUserToResizeRows = false;
            this.dgvPedidosDG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedidosDG.BackgroundColor = System.Drawing.SystemColors.Window;
            lObjEstiloEncabezadoDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvPedidosDG.ColumnHeadersDefaultCellStyle = lObjEstiloEncabezadoDG;
            this.dgvPedidosDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidosDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoDG,
            this.colClienteDG,
            this.colFechaDG,
            this.colEntregaDG,
            this.colEstadoDG,
            this.colOrigenDG,
            this.colTotalDG,
            this.colPagadoDG,
            this.colSaldoDG});
            this.dgvPedidosDG.Location = new System.Drawing.Point(20, 130);
            this.dgvPedidosDG.MultiSelect = false;
            this.dgvPedidosDG.Name = "dgvPedidosDG";
            this.dgvPedidosDG.ReadOnly = true;
            this.dgvPedidosDG.RowHeadersVisible = false;
            this.dgvPedidosDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidosDG.Size = new System.Drawing.Size(790, 430);
            this.dgvPedidosDG.TabIndex = 2;
            this.dgvPedidosDG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SubDgvPedidosCellDoubleClickDG);
            this.dgvPedidosDG.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.SubDgvPedidosCellFormattingDG);
            //
            // Columnas
            //
            lObjEstiloFechaDG.Format = "dd/MM/yyyy";
            lObjEstiloMonedaDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloMonedaDG.Format = "N2";
            lObjEstiloSaldoDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloSaldoDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
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
            this.colFechaDG.DataPropertyName = "gDtmFechaPedidoDG";
            this.colFechaDG.DefaultCellStyle = lObjEstiloFechaDG;
            this.colFechaDG.HeaderText = "Fecha";
            this.colFechaDG.Name = "colFechaDG";
            this.colFechaDG.Width = 80;
            this.colEntregaDG.DataPropertyName = "gDtmFechaEntregaDG";
            this.colEntregaDG.DefaultCellStyle = lObjEstiloFechaDG;
            this.colEntregaDG.HeaderText = "Entrega";
            this.colEntregaDG.Name = "colEntregaDG";
            this.colEntregaDG.Width = 80;
            this.colEstadoDG.DataPropertyName = "gStrEstadoDG";
            this.colEstadoDG.HeaderText = "Estado";
            this.colEstadoDG.Name = "colEstadoDG";
            this.colEstadoDG.Width = 105;
            this.colOrigenDG.DataPropertyName = "gStrOrigenDG";
            this.colOrigenDG.HeaderText = "Origen";
            this.colOrigenDG.Name = "colOrigenDG";
            this.colOrigenDG.Width = 70;
            this.colTotalDG.DataPropertyName = "gDcmTotalDG";
            this.colTotalDG.DefaultCellStyle = lObjEstiloMonedaDG;
            this.colTotalDG.HeaderText = "Total (Q)";
            this.colTotalDG.Name = "colTotalDG";
            this.colTotalDG.Width = 80;
            this.colPagadoDG.DataPropertyName = "gDcmTotalPagadoDG";
            this.colPagadoDG.DefaultCellStyle = lObjEstiloMonedaDG;
            this.colPagadoDG.HeaderText = "Pagado (Q)";
            this.colPagadoDG.Name = "colPagadoDG";
            this.colPagadoDG.Width = 88;
            this.colSaldoDG.DataPropertyName = "gDcmSaldoDG";
            this.colSaldoDG.DefaultCellStyle = lObjEstiloSaldoDG;
            this.colSaldoDG.HeaderText = "Saldo (Q)";
            this.colSaldoDG.Name = "colSaldoDG";
            this.colSaldoDG.Width = 80;
            //
            // btnNuevoDG
            //
            this.btnNuevoDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoDG.Location = new System.Drawing.Point(825, 130);
            this.btnNuevoDG.Name = "btnNuevoDG";
            this.btnNuevoDG.Size = new System.Drawing.Size(135, 36);
            this.btnNuevoDG.TabIndex = 3;
            this.btnNuevoDG.Text = "Nuevo pedido";
            this.btnNuevoDG.Click += new System.EventHandler(this.SubBtnNuevoClickDG);
            //
            // btnAbrirDG
            //
            this.btnAbrirDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirDG.Location = new System.Drawing.Point(825, 174);
            this.btnAbrirDG.Name = "btnAbrirDG";
            this.btnAbrirDG.Size = new System.Drawing.Size(135, 36);
            this.btnAbrirDG.TabIndex = 4;
            this.btnAbrirDG.Text = "Abrir pedido";
            this.btnAbrirDG.Click += new System.EventHandler(this.SubBtnAbrirClickDG);
            //
            // btnCerrarDG
            //
            this.btnCerrarDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarDG.Location = new System.Drawing.Point(825, 524);
            this.btnCerrarDG.Name = "btnCerrarDG";
            this.btnCerrarDG.Size = new System.Drawing.Size(135, 36);
            this.btnCerrarDG.TabIndex = 5;
            this.btnCerrarDG.Text = "Cerrar";
            this.btnCerrarDG.Click += new System.EventHandler(this.SubBtnCerrarClickDG);
            //
            // frmPedidosDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrarDG;
            this.ClientSize = new System.Drawing.Size(980, 580);
            this.Controls.Add(this.lblTituloDG);
            this.Controls.Add(this.gpbFiltrosDG);
            this.Controls.Add(this.dgvPedidosDG);
            this.Controls.Add(this.btnNuevoDG);
            this.Controls.Add(this.btnAbrirDG);
            this.Controls.Add(this.btnCerrarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(820, 450);
            this.Name = "frmPedidosDG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cubito - Pedidos";
            this.Load += new System.EventHandler(this.SubFrmPedidosLoadDG);
            this.gpbFiltrosDG.ResumeLayout(false);
            this.gpbFiltrosDG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosDG)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTituloDG;
        private System.Windows.Forms.GroupBox gpbFiltrosDG;
        private System.Windows.Forms.Label lblBuscarDG;
        private System.Windows.Forms.TextBox txtBuscarDG;
        private System.Windows.Forms.Label lblEstadoDG;
        private System.Windows.Forms.ComboBox cmbEstadoDG;
        private System.Windows.Forms.Label lblResumenDG;
        private System.Windows.Forms.DataGridView dgvPedidosDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClienteDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntregaDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigenDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPagadoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoDG;
        private System.Windows.Forms.Button btnNuevoDG;
        private System.Windows.Forms.Button btnAbrirDG;
        private System.Windows.Forms.Button btnCerrarDG;
    }
}
