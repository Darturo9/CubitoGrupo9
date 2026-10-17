namespace WinCubitoDG
{
    partial class frmInventarioDG
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
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloNumeroDG = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloEncabezadoDG = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTituloDG = new System.Windows.Forms.Label();
            this.gpbFiltrosDG = new System.Windows.Forms.GroupBox();
            this.lblBuscarDG = new System.Windows.Forms.Label();
            this.txtBuscarDG = new System.Windows.Forms.TextBox();
            this.chkSoloAlertasDG = new System.Windows.Forms.CheckBox();
            this.lblResumenDG = new System.Windows.Forms.Label();
            this.dgvArticulosDG = new System.Windows.Forms.DataGridView();
            this.colCodigoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTallaDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidadDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinimoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaximoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSugeridoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevoDG = new System.Windows.Forms.Button();
            this.btnEditarDG = new System.Windows.Forms.Button();
            this.btnMovimientoDG = new System.Windows.Forms.Button();
            this.btnKardexDG = new System.Windows.Forms.Button();
            this.btnDesactivarDG = new System.Windows.Forms.Button();
            this.btnCerrarDG = new System.Windows.Forms.Button();
            this.gpbFiltrosDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosDG)).BeginInit();
            this.SuspendLayout();
            //
            // lblTituloDG
            //
            this.lblTituloDG.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloDG.Location = new System.Drawing.Point(20, 12);
            this.lblTituloDG.Name = "lblTituloDG";
            this.lblTituloDG.Size = new System.Drawing.Size(400, 40);
            this.lblTituloDG.Text = "Inventario";
            //
            // gpbFiltrosDG
            //
            this.gpbFiltrosDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbFiltrosDG.Controls.Add(this.lblBuscarDG);
            this.gpbFiltrosDG.Controls.Add(this.txtBuscarDG);
            this.gpbFiltrosDG.Controls.Add(this.chkSoloAlertasDG);
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
            this.txtBuscarDG.Size = new System.Drawing.Size(260, 23);
            this.txtBuscarDG.TabIndex = 0;
            this.txtBuscarDG.TextChanged += new System.EventHandler(this.SubTxtBuscarTextChangedDG);
            //
            // chkSoloAlertasDG
            //
            this.chkSoloAlertasDG.Location = new System.Drawing.Point(355, 25);
            this.chkSoloAlertasDG.Name = "chkSoloAlertasDG";
            this.chkSoloAlertasDG.Size = new System.Drawing.Size(250, 23);
            this.chkSoloAlertasDG.TabIndex = 1;
            this.chkSoloAlertasDG.Text = "Solo artículos en alerta de reorden";
            this.chkSoloAlertasDG.CheckedChanged += new System.EventHandler(this.SubChkSoloAlertasCheckedChangedDG);
            //
            // lblResumenDG
            //
            this.lblResumenDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumenDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResumenDG.Location = new System.Drawing.Point(620, 25);
            this.lblResumenDG.Name = "lblResumenDG";
            this.lblResumenDG.Size = new System.Drawing.Size(305, 23);
            this.lblResumenDG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // dgvArticulosDG
            //
            this.dgvArticulosDG.AllowUserToAddRows = false;
            this.dgvArticulosDG.AllowUserToDeleteRows = false;
            this.dgvArticulosDG.AllowUserToResizeRows = false;
            this.dgvArticulosDG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulosDG.BackgroundColor = System.Drawing.SystemColors.Window;
            lObjEstiloEncabezadoDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvArticulosDG.ColumnHeadersDefaultCellStyle = lObjEstiloEncabezadoDG;
            this.dgvArticulosDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulosDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoDG,
            this.colNombreDG,
            this.colTipoDG,
            this.colTallaDG,
            this.colColorDG,
            this.colUnidadDG,
            this.colStockDG,
            this.colMinimoDG,
            this.colMaximoDG,
            this.colEstadoDG,
            this.colSugeridoDG});
            this.dgvArticulosDG.Location = new System.Drawing.Point(20, 130);
            this.dgvArticulosDG.MultiSelect = false;
            this.dgvArticulosDG.Name = "dgvArticulosDG";
            this.dgvArticulosDG.ReadOnly = true;
            this.dgvArticulosDG.RowHeadersVisible = false;
            this.dgvArticulosDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulosDG.Size = new System.Drawing.Size(790, 430);
            this.dgvArticulosDG.TabIndex = 2;
            this.dgvArticulosDG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SubDgvArticulosCellDoubleClickDG);
            this.dgvArticulosDG.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.SubDgvArticulosRowPrePaintDG);
            this.dgvArticulosDG.SelectionChanged += new System.EventHandler(this.SubDgvArticulosSelectionChangedDG);
            //
            // Columnas
            //
            lObjEstiloNumeroDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloNumeroDG.Format = "0.##";
            this.colCodigoDG.DataPropertyName = "gStrCodigoDG";
            this.colCodigoDG.HeaderText = "Código";
            this.colCodigoDG.Name = "colCodigoDG";
            this.colCodigoDG.Width = 85;
            this.colNombreDG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombreDG.DataPropertyName = "gStrNombreDG";
            this.colNombreDG.HeaderText = "Nombre";
            this.colNombreDG.MinimumWidth = 120;
            this.colNombreDG.Name = "colNombreDG";
            this.colTipoDG.DataPropertyName = "gStrTipoDG";
            this.colTipoDG.HeaderText = "Tipo";
            this.colTipoDG.Name = "colTipoDG";
            this.colTipoDG.Width = 60;
            this.colTallaDG.DataPropertyName = "gStrTallaDG";
            this.colTallaDG.HeaderText = "Talla";
            this.colTallaDG.Name = "colTallaDG";
            this.colTallaDG.Width = 45;
            this.colColorDG.DataPropertyName = "gStrColorDG";
            this.colColorDG.HeaderText = "Color";
            this.colColorDG.Name = "colColorDG";
            this.colColorDG.Width = 65;
            this.colUnidadDG.DataPropertyName = "gStrUnidadDG";
            this.colUnidadDG.HeaderText = "Unidad";
            this.colUnidadDG.Name = "colUnidadDG";
            this.colUnidadDG.Width = 62;
            this.colStockDG.DataPropertyName = "gDcmStockDG";
            this.colStockDG.DefaultCellStyle = lObjEstiloNumeroDG;
            this.colStockDG.HeaderText = "Stock";
            this.colStockDG.Name = "colStockDG";
            this.colStockDG.Width = 62;
            this.colMinimoDG.DataPropertyName = "gDcmStockMinimoDG";
            this.colMinimoDG.DefaultCellStyle = lObjEstiloNumeroDG;
            this.colMinimoDG.HeaderText = "Mínimo";
            this.colMinimoDG.Name = "colMinimoDG";
            this.colMinimoDG.Width = 62;
            this.colMaximoDG.DataPropertyName = "gDcmStockMaximoDG";
            this.colMaximoDG.DefaultCellStyle = lObjEstiloNumeroDG;
            this.colMaximoDG.HeaderText = "Máximo";
            this.colMaximoDG.Name = "colMaximoDG";
            this.colMaximoDG.Width = 62;
            this.colEstadoDG.DataPropertyName = "gStrEstadoStockDG";
            this.colEstadoDG.HeaderText = "Estado";
            this.colEstadoDG.Name = "colEstadoDG";
            this.colEstadoDG.Width = 82;
            this.colSugeridoDG.DataPropertyName = "gDcmCantidadSugeridaDG";
            this.colSugeridoDG.DefaultCellStyle = lObjEstiloNumeroDG;
            this.colSugeridoDG.HeaderText = "Comprar";
            this.colSugeridoDG.Name = "colSugeridoDG";
            this.colSugeridoDG.ToolTipText = "Cantidad sugerida = Máximo - Stock";
            this.colSugeridoDG.Width = 72;
            //
            // btnNuevoDG
            //
            this.btnNuevoDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoDG.Location = new System.Drawing.Point(825, 130);
            this.btnNuevoDG.Name = "btnNuevoDG";
            this.btnNuevoDG.Size = new System.Drawing.Size(135, 36);
            this.btnNuevoDG.TabIndex = 3;
            this.btnNuevoDG.Text = "Nuevo artículo";
            this.btnNuevoDG.Click += new System.EventHandler(this.SubBtnNuevoClickDG);
            //
            // btnEditarDG
            //
            this.btnEditarDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarDG.Location = new System.Drawing.Point(825, 174);
            this.btnEditarDG.Name = "btnEditarDG";
            this.btnEditarDG.Size = new System.Drawing.Size(135, 36);
            this.btnEditarDG.TabIndex = 4;
            this.btnEditarDG.Text = "Editar";
            this.btnEditarDG.Click += new System.EventHandler(this.SubBtnEditarClickDG);
            //
            // btnMovimientoDG
            //
            this.btnMovimientoDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMovimientoDG.Location = new System.Drawing.Point(825, 218);
            this.btnMovimientoDG.Name = "btnMovimientoDG";
            this.btnMovimientoDG.Size = new System.Drawing.Size(135, 36);
            this.btnMovimientoDG.TabIndex = 5;
            this.btnMovimientoDG.Text = "Entrada / salida";
            this.btnMovimientoDG.Click += new System.EventHandler(this.SubBtnMovimientoClickDG);
            //
            // btnKardexDG
            //
            this.btnKardexDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKardexDG.Location = new System.Drawing.Point(825, 262);
            this.btnKardexDG.Name = "btnKardexDG";
            this.btnKardexDG.Size = new System.Drawing.Size(135, 36);
            this.btnKardexDG.TabIndex = 6;
            this.btnKardexDG.Text = "Ver kardex";
            this.btnKardexDG.Click += new System.EventHandler(this.SubBtnKardexClickDG);
            //
            // btnDesactivarDG
            //
            this.btnDesactivarDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesactivarDG.Location = new System.Drawing.Point(825, 306);
            this.btnDesactivarDG.Name = "btnDesactivarDG";
            this.btnDesactivarDG.Size = new System.Drawing.Size(135, 36);
            this.btnDesactivarDG.TabIndex = 7;
            this.btnDesactivarDG.Text = "Desactivar";
            this.btnDesactivarDG.Click += new System.EventHandler(this.SubBtnDesactivarClickDG);
            //
            // btnCerrarDG
            //
            this.btnCerrarDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarDG.Location = new System.Drawing.Point(825, 524);
            this.btnCerrarDG.Name = "btnCerrarDG";
            this.btnCerrarDG.Size = new System.Drawing.Size(135, 36);
            this.btnCerrarDG.TabIndex = 8;
            this.btnCerrarDG.Text = "Cerrar";
            this.btnCerrarDG.Click += new System.EventHandler(this.SubBtnCerrarClickDG);
            //
            // frmInventarioDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrarDG;
            this.ClientSize = new System.Drawing.Size(980, 580);
            this.Controls.Add(this.lblTituloDG);
            this.Controls.Add(this.gpbFiltrosDG);
            this.Controls.Add(this.dgvArticulosDG);
            this.Controls.Add(this.btnNuevoDG);
            this.Controls.Add(this.btnEditarDG);
            this.Controls.Add(this.btnMovimientoDG);
            this.Controls.Add(this.btnKardexDG);
            this.Controls.Add(this.btnDesactivarDG);
            this.Controls.Add(this.btnCerrarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(820, 450);
            this.Name = "frmInventarioDG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cubito - Inventario";
            this.Load += new System.EventHandler(this.SubFrmInventarioLoadDG);
            this.gpbFiltrosDG.ResumeLayout(false);
            this.gpbFiltrosDG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosDG)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTituloDG;
        private System.Windows.Forms.GroupBox gpbFiltrosDG;
        private System.Windows.Forms.Label lblBuscarDG;
        private System.Windows.Forms.TextBox txtBuscarDG;
        private System.Windows.Forms.CheckBox chkSoloAlertasDG;
        private System.Windows.Forms.Label lblResumenDG;
        private System.Windows.Forms.DataGridView dgvArticulosDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTallaDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidadDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinimoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaximoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSugeridoDG;
        private System.Windows.Forms.Button btnNuevoDG;
        private System.Windows.Forms.Button btnEditarDG;
        private System.Windows.Forms.Button btnMovimientoDG;
        private System.Windows.Forms.Button btnKardexDG;
        private System.Windows.Forms.Button btnDesactivarDG;
        private System.Windows.Forms.Button btnCerrarDG;
    }
}
