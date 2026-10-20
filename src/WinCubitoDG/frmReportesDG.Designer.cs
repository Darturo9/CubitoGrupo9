namespace WinCubitoDG
{
    partial class frmReportesDG
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
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloMontoDG = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloCantidadDG = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTituloDG = new System.Windows.Forms.Label();
            this.gpbFiltrosDG = new System.Windows.Forms.GroupBox();
            this.lblMesDG = new System.Windows.Forms.Label();
            this.dtpMesDG = new System.Windows.Forms.DateTimePicker();
            this.lblMesDescripcionDG = new System.Windows.Forms.Label();
            this.btnExportarDG = new System.Windows.Forms.Button();
            this.tarVentasDG = new WinCubitoDG.TarjetaIndicadorDG();
            this.tarCobradoDG = new WinCubitoDG.TarjetaIndicadorDG();
            this.tarGastosDG = new WinCubitoDG.TarjetaIndicadorDG();
            this.tarGananciaDG = new WinCubitoDG.TarjetaIndicadorDG();
            this.lblTecnicasDG = new System.Windows.Forms.Label();
            this.dgvTecnicasDG = new System.Windows.Forms.DataGridView();
            this.colTecnicasConceptoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTecnicasCantidadDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTecnicasMontoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblClientesDG = new System.Windows.Forms.Label();
            this.dgvClientesDG = new System.Windows.Forms.DataGridView();
            this.colClientesConceptoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientesCantidadDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientesMontoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCategoriasDG = new System.Windows.Forms.Label();
            this.dgvCategoriasDG = new System.Windows.Forms.DataGridView();
            this.colCategoriasConceptoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoriasCantidadDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoriasMontoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNotaDG = new System.Windows.Forms.Label();
            this.btnCerrarDG = new System.Windows.Forms.Button();
            this.gpbFiltrosDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTecnicasDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoriasDG)).BeginInit();
            this.SuspendLayout();
            //
            // lblTituloDG
            //
            this.lblTituloDG.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloDG.Location = new System.Drawing.Point(20, 12);
            this.lblTituloDG.Name = "lblTituloDG";
            this.lblTituloDG.Size = new System.Drawing.Size(400, 40);
            this.lblTituloDG.Text = "Reportes";
            //
            // gpbFiltrosDG
            //
            this.gpbFiltrosDG.Controls.Add(this.lblMesDG);
            this.gpbFiltrosDG.Controls.Add(this.dtpMesDG);
            this.gpbFiltrosDG.Controls.Add(this.lblMesDescripcionDG);
            this.gpbFiltrosDG.Controls.Add(this.btnExportarDG);
            this.gpbFiltrosDG.Location = new System.Drawing.Point(20, 58);
            this.gpbFiltrosDG.Name = "gpbFiltrosDG";
            this.gpbFiltrosDG.Size = new System.Drawing.Size(940, 62);
            this.gpbFiltrosDG.Text = "Período";
            //
            // lblMesDG
            //
            this.lblMesDG.Location = new System.Drawing.Point(15, 25);
            this.lblMesDG.Name = "lblMesDG";
            this.lblMesDG.Size = new System.Drawing.Size(40, 23);
            this.lblMesDG.Text = "Mes:";
            this.lblMesDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dtpMesDG
            //
            this.dtpMesDG.CustomFormat = "MMMM yyyy";
            this.dtpMesDG.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMesDG.Location = new System.Drawing.Point(58, 25);
            this.dtpMesDG.Name = "dtpMesDG";
            this.dtpMesDG.ShowUpDown = true;
            this.dtpMesDG.Size = new System.Drawing.Size(160, 23);
            this.dtpMesDG.TabIndex = 0;
            this.dtpMesDG.ValueChanged += new System.EventHandler(this.SubDtpMesValueChangedDG);
            //
            // lblMesDescripcionDG
            //
            this.lblMesDescripcionDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblMesDescripcionDG.Location = new System.Drawing.Point(235, 25);
            this.lblMesDescripcionDG.Name = "lblMesDescripcionDG";
            this.lblMesDescripcionDG.Size = new System.Drawing.Size(400, 23);
            this.lblMesDescripcionDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnExportarDG
            //
            this.btnExportarDG.Location = new System.Drawing.Point(785, 19);
            this.btnExportarDG.Name = "btnExportarDG";
            this.btnExportarDG.Size = new System.Drawing.Size(140, 34);
            this.btnExportarDG.TabIndex = 1;
            this.btnExportarDG.Text = "Exportar CSV";
            this.btnExportarDG.Click += new System.EventHandler(this.SubBtnExportarClickDG);
            //
            // tarVentasDG
            //
            this.tarVentasDG.Location = new System.Drawing.Point(20, 134);
            this.tarVentasDG.Name = "tarVentasDG";
            this.tarVentasDG.Size = new System.Drawing.Size(229, 100);
            this.tarVentasDG.gStrTituloDG = "Ventas del mes";
            //
            // tarCobradoDG
            //
            this.tarCobradoDG.Location = new System.Drawing.Point(257, 134);
            this.tarCobradoDG.Name = "tarCobradoDG";
            this.tarCobradoDG.Size = new System.Drawing.Size(229, 100);
            this.tarCobradoDG.gStrTituloDG = "Cobrado";
            //
            // tarGastosDG
            //
            this.tarGastosDG.Location = new System.Drawing.Point(494, 134);
            this.tarGastosDG.Name = "tarGastosDG";
            this.tarGastosDG.Size = new System.Drawing.Size(229, 100);
            this.tarGastosDG.gStrTituloDG = "Gastos";
            //
            // tarGananciaDG
            //
            this.tarGananciaDG.Location = new System.Drawing.Point(731, 134);
            this.tarGananciaDG.Name = "tarGananciaDG";
            this.tarGananciaDG.Size = new System.Drawing.Size(229, 100);
            this.tarGananciaDG.gStrTituloDG = "Ganancia";
            //
            // Estilos de las columnas numéricas
            //
            lObjEstiloMontoDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloMontoDG.Format = "N2";
            lObjEstiloCantidadDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            //
            // lblTecnicasDG
            //
            this.lblTecnicasDG.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblTecnicasDG.Location = new System.Drawing.Point(20, 248);
            this.lblTecnicasDG.Name = "lblTecnicasDG";
            this.lblTecnicasDG.Size = new System.Drawing.Size(304, 24);
            this.lblTecnicasDG.Text = "Ventas por técnica";
            //
            // dgvTecnicasDG
            //
            this.dgvTecnicasDG.AllowUserToAddRows = false;
            this.dgvTecnicasDG.AllowUserToDeleteRows = false;
            this.dgvTecnicasDG.AllowUserToResizeRows = false;
            this.dgvTecnicasDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTecnicasConceptoDG,
            this.colTecnicasCantidadDG,
            this.colTecnicasMontoDG});
            this.dgvTecnicasDG.Location = new System.Drawing.Point(20, 274);
            this.dgvTecnicasDG.MultiSelect = false;
            this.dgvTecnicasDG.Name = "dgvTecnicasDG";
            this.dgvTecnicasDG.ReadOnly = true;
            this.dgvTecnicasDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTecnicasDG.Size = new System.Drawing.Size(304, 270);
            this.dgvTecnicasDG.TabIndex = 2;
            this.dgvTecnicasDG.TabStop = false;
            this.colTecnicasConceptoDG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTecnicasConceptoDG.DataPropertyName = "gStrConceptoDG";
            this.colTecnicasConceptoDG.HeaderText = "Técnica";
            this.colTecnicasConceptoDG.Name = "colTecnicasConceptoDG";
            this.colTecnicasCantidadDG.DataPropertyName = "gIntCantidadDG";
            this.colTecnicasCantidadDG.DefaultCellStyle = lObjEstiloCantidadDG;
            this.colTecnicasCantidadDG.HeaderText = "Prendas";
            this.colTecnicasCantidadDG.Name = "colTecnicasCantidadDG";
            this.colTecnicasCantidadDG.Width = 62;
            this.colTecnicasMontoDG.DataPropertyName = "gDcmMontoDG";
            this.colTecnicasMontoDG.DefaultCellStyle = lObjEstiloMontoDG;
            this.colTecnicasMontoDG.HeaderText = "Monto (Q)";
            this.colTecnicasMontoDG.Name = "colTecnicasMontoDG";
            this.colTecnicasMontoDG.Width = 92;
            //
            // lblClientesDG
            //
            this.lblClientesDG.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblClientesDG.Location = new System.Drawing.Point(338, 248);
            this.lblClientesDG.Name = "lblClientesDG";
            this.lblClientesDG.Size = new System.Drawing.Size(304, 24);
            this.lblClientesDG.Text = "Mejores clientes";
            //
            // dgvClientesDG
            //
            this.dgvClientesDG.AllowUserToAddRows = false;
            this.dgvClientesDG.AllowUserToDeleteRows = false;
            this.dgvClientesDG.AllowUserToResizeRows = false;
            this.dgvClientesDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClientesConceptoDG,
            this.colClientesCantidadDG,
            this.colClientesMontoDG});
            this.dgvClientesDG.Location = new System.Drawing.Point(338, 274);
            this.dgvClientesDG.MultiSelect = false;
            this.dgvClientesDG.Name = "dgvClientesDG";
            this.dgvClientesDG.ReadOnly = true;
            this.dgvClientesDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientesDG.Size = new System.Drawing.Size(304, 270);
            this.dgvClientesDG.TabIndex = 3;
            this.dgvClientesDG.TabStop = false;
            this.colClientesConceptoDG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClientesConceptoDG.DataPropertyName = "gStrConceptoDG";
            this.colClientesConceptoDG.HeaderText = "Cliente";
            this.colClientesConceptoDG.Name = "colClientesConceptoDG";
            this.colClientesCantidadDG.DataPropertyName = "gIntCantidadDG";
            this.colClientesCantidadDG.DefaultCellStyle = lObjEstiloCantidadDG;
            this.colClientesCantidadDG.HeaderText = "Pedidos";
            this.colClientesCantidadDG.Name = "colClientesCantidadDG";
            this.colClientesCantidadDG.Width = 62;
            this.colClientesMontoDG.DataPropertyName = "gDcmMontoDG";
            this.colClientesMontoDG.DefaultCellStyle = lObjEstiloMontoDG;
            this.colClientesMontoDG.HeaderText = "Monto (Q)";
            this.colClientesMontoDG.Name = "colClientesMontoDG";
            this.colClientesMontoDG.Width = 92;
            //
            // lblCategoriasDG
            //
            this.lblCategoriasDG.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblCategoriasDG.Location = new System.Drawing.Point(656, 248);
            this.lblCategoriasDG.Name = "lblCategoriasDG";
            this.lblCategoriasDG.Size = new System.Drawing.Size(304, 24);
            this.lblCategoriasDG.Text = "Gastos por categoría";
            //
            // dgvCategoriasDG
            //
            this.dgvCategoriasDG.AllowUserToAddRows = false;
            this.dgvCategoriasDG.AllowUserToDeleteRows = false;
            this.dgvCategoriasDG.AllowUserToResizeRows = false;
            this.dgvCategoriasDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategoriasConceptoDG,
            this.colCategoriasCantidadDG,
            this.colCategoriasMontoDG});
            this.dgvCategoriasDG.Location = new System.Drawing.Point(656, 274);
            this.dgvCategoriasDG.MultiSelect = false;
            this.dgvCategoriasDG.Name = "dgvCategoriasDG";
            this.dgvCategoriasDG.ReadOnly = true;
            this.dgvCategoriasDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategoriasDG.Size = new System.Drawing.Size(304, 270);
            this.dgvCategoriasDG.TabIndex = 4;
            this.dgvCategoriasDG.TabStop = false;
            this.colCategoriasConceptoDG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCategoriasConceptoDG.DataPropertyName = "gStrConceptoDG";
            this.colCategoriasConceptoDG.HeaderText = "Categoría";
            this.colCategoriasConceptoDG.Name = "colCategoriasConceptoDG";
            this.colCategoriasCantidadDG.DataPropertyName = "gIntCantidadDG";
            this.colCategoriasCantidadDG.DefaultCellStyle = lObjEstiloCantidadDG;
            this.colCategoriasCantidadDG.HeaderText = "Gastos";
            this.colCategoriasCantidadDG.Name = "colCategoriasCantidadDG";
            this.colCategoriasCantidadDG.Width = 62;
            this.colCategoriasMontoDG.DataPropertyName = "gDcmMontoDG";
            this.colCategoriasMontoDG.DefaultCellStyle = lObjEstiloMontoDG;
            this.colCategoriasMontoDG.HeaderText = "Monto (Q)";
            this.colCategoriasMontoDG.Name = "colCategoriasMontoDG";
            this.colCategoriasMontoDG.Width = 92;
            //
            // lblNotaDG
            //
            this.lblNotaDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblNotaDG.Location = new System.Drawing.Point(20, 554);
            this.lblNotaDG.Name = "lblNotaDG";
            this.lblNotaDG.Size = new System.Drawing.Size(780, 40);
            this.lblNotaDG.Text = "Ventas: pedidos aprobados en el mes (sin cotizaciones ni cancelados). Cobrado: pagos recibidos en el mes.\r\nGanancia = cobrado − gastos.";
            //
            // btnCerrarDG
            //
            this.btnCerrarDG.Location = new System.Drawing.Point(825, 556);
            this.btnCerrarDG.Name = "btnCerrarDG";
            this.btnCerrarDG.Size = new System.Drawing.Size(135, 36);
            this.btnCerrarDG.TabIndex = 9;
            this.btnCerrarDG.Text = "Cerrar";
            this.btnCerrarDG.Click += new System.EventHandler(this.SubBtnCerrarClickDG);
            //
            // frmReportesDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrarDG;
            this.ClientSize = new System.Drawing.Size(980, 608);
            this.Controls.Add(this.lblTituloDG);
            this.Controls.Add(this.gpbFiltrosDG);
            this.Controls.Add(this.tarVentasDG);
            this.Controls.Add(this.tarCobradoDG);
            this.Controls.Add(this.tarGastosDG);
            this.Controls.Add(this.tarGananciaDG);
            this.Controls.Add(this.lblTecnicasDG);
            this.Controls.Add(this.dgvTecnicasDG);
            this.Controls.Add(this.lblClientesDG);
            this.Controls.Add(this.dgvClientesDG);
            this.Controls.Add(this.lblCategoriasDG);
            this.Controls.Add(this.dgvCategoriasDG);
            this.Controls.Add(this.lblNotaDG);
            this.Controls.Add(this.btnCerrarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReportesDG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cubito - Reportes";
            this.Load += new System.EventHandler(this.SubFrmReportesLoadDG);
            this.gpbFiltrosDG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTecnicasDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoriasDG)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTituloDG;
        private System.Windows.Forms.GroupBox gpbFiltrosDG;
        private System.Windows.Forms.Label lblMesDG;
        private System.Windows.Forms.DateTimePicker dtpMesDG;
        private System.Windows.Forms.Label lblMesDescripcionDG;
        private System.Windows.Forms.Button btnExportarDG;
        private WinCubitoDG.TarjetaIndicadorDG tarVentasDG;
        private WinCubitoDG.TarjetaIndicadorDG tarCobradoDG;
        private WinCubitoDG.TarjetaIndicadorDG tarGastosDG;
        private WinCubitoDG.TarjetaIndicadorDG tarGananciaDG;
        private System.Windows.Forms.Label lblTecnicasDG;
        private System.Windows.Forms.DataGridView dgvTecnicasDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTecnicasConceptoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTecnicasCantidadDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTecnicasMontoDG;
        private System.Windows.Forms.Label lblClientesDG;
        private System.Windows.Forms.DataGridView dgvClientesDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientesConceptoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientesCantidadDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientesMontoDG;
        private System.Windows.Forms.Label lblCategoriasDG;
        private System.Windows.Forms.DataGridView dgvCategoriasDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriasConceptoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriasCantidadDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriasMontoDG;
        private System.Windows.Forms.Label lblNotaDG;
        private System.Windows.Forms.Button btnCerrarDG;
    }
}
