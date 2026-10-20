namespace WinCubitoDG
{
    partial class frmClientesDG
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
            this.lblTituloDG = new System.Windows.Forms.Label();
            this.gpbFiltrosDG = new System.Windows.Forms.GroupBox();
            this.lblBuscarDG = new System.Windows.Forms.Label();
            this.txtBuscarDG = new System.Windows.Forms.TextBox();
            this.lblResumenDG = new System.Windows.Forms.Label();
            this.dgvClientesDG = new System.Windows.Forms.DataGridView();
            this.colNombreDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefonoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorreoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegistroDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHistorialDG = new System.Windows.Forms.Label();
            this.lblHistorialResumenDG = new System.Windows.Forms.Label();
            this.dgvHistorialDG = new System.Windows.Forms.DataGridView();
            this.colHisCodigoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHisFechaDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHisEstadoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHisTotalDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHisSaldoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevoDG = new System.Windows.Forms.Button();
            this.btnEditarDG = new System.Windows.Forms.Button();
            this.btnDesactivarDG = new System.Windows.Forms.Button();
            this.btnCerrarDG = new System.Windows.Forms.Button();
            this.gpbFiltrosDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialDG)).BeginInit();
            this.SuspendLayout();
            //
            // lblTituloDG
            //
            this.lblTituloDG.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloDG.Location = new System.Drawing.Point(20, 12);
            this.lblTituloDG.Name = "lblTituloDG";
            this.lblTituloDG.Size = new System.Drawing.Size(400, 40);
            this.lblTituloDG.Text = "Clientes";
            //
            // gpbFiltrosDG
            //
            this.gpbFiltrosDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbFiltrosDG.Controls.Add(this.lblBuscarDG);
            this.gpbFiltrosDG.Controls.Add(this.txtBuscarDG);
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
            // lblResumenDG
            //
            this.lblResumenDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumenDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResumenDG.Location = new System.Drawing.Point(620, 25);
            this.lblResumenDG.Name = "lblResumenDG";
            this.lblResumenDG.Size = new System.Drawing.Size(305, 23);
            this.lblResumenDG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // dgvClientesDG
            //
            this.dgvClientesDG.AllowUserToAddRows = false;
            this.dgvClientesDG.AllowUserToDeleteRows = false;
            this.dgvClientesDG.AllowUserToResizeRows = false;
            this.dgvClientesDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientesDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombreDG,
            this.colTelefonoDG,
            this.colCorreoDG,
            this.colRegistroDG});
            this.dgvClientesDG.Location = new System.Drawing.Point(20, 130);
            this.dgvClientesDG.MultiSelect = false;
            this.dgvClientesDG.Name = "dgvClientesDG";
            this.dgvClientesDG.ReadOnly = true;
            this.dgvClientesDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientesDG.Size = new System.Drawing.Size(790, 240);
            this.dgvClientesDG.TabIndex = 1;
            this.dgvClientesDG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SubDgvClientesCellDoubleClickDG);
            this.dgvClientesDG.SelectionChanged += new System.EventHandler(this.SubDgvClientesSelectionChangedDG);
            //
            // Columnas de clientes
            //
            lObjEstiloFechaDG.Format = "dd/MM/yyyy";
            this.colNombreDG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombreDG.DataPropertyName = "gStrNombreDG";
            this.colNombreDG.HeaderText = "Nombre";
            this.colNombreDG.MinimumWidth = 160;
            this.colNombreDG.Name = "colNombreDG";
            this.colTelefonoDG.DataPropertyName = "gStrTelefonoDG";
            this.colTelefonoDG.HeaderText = "Teléfono";
            this.colTelefonoDG.Name = "colTelefonoDG";
            this.colTelefonoDG.Width = 100;
            this.colCorreoDG.DataPropertyName = "gStrCorreoDG";
            this.colCorreoDG.HeaderText = "Correo";
            this.colCorreoDG.Name = "colCorreoDG";
            this.colCorreoDG.Width = 220;
            this.colRegistroDG.DataPropertyName = "gDtmFechaRegistroDG";
            this.colRegistroDG.DefaultCellStyle = lObjEstiloFechaDG;
            this.colRegistroDG.HeaderText = "Cliente desde";
            this.colRegistroDG.Name = "colRegistroDG";
            this.colRegistroDG.Width = 105;
            //
            // lblHistorialDG
            //
            this.lblHistorialDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHistorialDG.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblHistorialDG.Location = new System.Drawing.Point(18, 380);
            this.lblHistorialDG.Name = "lblHistorialDG";
            this.lblHistorialDG.Size = new System.Drawing.Size(400, 26);
            this.lblHistorialDG.Text = "Historial";
            //
            // lblHistorialResumenDG
            //
            this.lblHistorialResumenDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHistorialResumenDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHistorialResumenDG.Location = new System.Drawing.Point(420, 382);
            this.lblHistorialResumenDG.Name = "lblHistorialResumenDG";
            this.lblHistorialResumenDG.Size = new System.Drawing.Size(390, 24);
            this.lblHistorialResumenDG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // dgvHistorialDG
            //
            this.dgvHistorialDG.AllowUserToAddRows = false;
            this.dgvHistorialDG.AllowUserToDeleteRows = false;
            this.dgvHistorialDG.AllowUserToResizeRows = false;
            this.dgvHistorialDG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHisCodigoDG,
            this.colHisFechaDG,
            this.colHisEstadoDG,
            this.colHisTotalDG,
            this.colHisSaldoDG});
            this.dgvHistorialDG.Location = new System.Drawing.Point(20, 410);
            this.dgvHistorialDG.MultiSelect = false;
            this.dgvHistorialDG.Name = "dgvHistorialDG";
            this.dgvHistorialDG.ReadOnly = true;
            this.dgvHistorialDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialDG.Size = new System.Drawing.Size(790, 150);
            this.dgvHistorialDG.TabIndex = 2;
            this.dgvHistorialDG.TabStop = false;
            this.dgvHistorialDG.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.SubDgvHistorialCellFormattingDG);
            //
            // Columnas del historial
            //
            lObjEstiloMonedaDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloMonedaDG.Format = "N2";
            this.colHisCodigoDG.DataPropertyName = "gStrCodigoDG";
            this.colHisCodigoDG.HeaderText = "Pedido";
            this.colHisCodigoDG.Name = "colHisCodigoDG";
            this.colHisCodigoDG.Width = 90;
            this.colHisFechaDG.DataPropertyName = "gDtmFechaPedidoDG";
            this.colHisFechaDG.DefaultCellStyle = lObjEstiloFechaDG;
            this.colHisFechaDG.HeaderText = "Fecha";
            this.colHisFechaDG.Name = "colHisFechaDG";
            this.colHisFechaDG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHisEstadoDG.Width = 120;
            this.colHisEstadoDG.DataPropertyName = "gStrEstadoDG";
            this.colHisEstadoDG.HeaderText = "Estado";
            this.colHisEstadoDG.Name = "colHisEstadoDG";
            this.colHisTotalDG.DataPropertyName = "gDcmTotalDG";
            this.colHisTotalDG.DefaultCellStyle = lObjEstiloMonedaDG;
            this.colHisTotalDG.HeaderText = "Total (Q)";
            this.colHisTotalDG.Name = "colHisTotalDG";
            this.colHisTotalDG.Width = 110;
            this.colHisSaldoDG.DataPropertyName = "gDcmSaldoDG";
            this.colHisSaldoDG.DefaultCellStyle = lObjEstiloMonedaDG;
            this.colHisSaldoDG.HeaderText = "Saldo (Q)";
            this.colHisSaldoDG.Name = "colHisSaldoDG";
            this.colHisSaldoDG.Width = 110;
            //
            // btnNuevoDG
            //
            this.btnNuevoDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoDG.Location = new System.Drawing.Point(825, 130);
            this.btnNuevoDG.Name = "btnNuevoDG";
            this.btnNuevoDG.Size = new System.Drawing.Size(135, 36);
            this.btnNuevoDG.TabIndex = 3;
            this.btnNuevoDG.Text = "Nuevo cliente";
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
            // btnDesactivarDG
            //
            this.btnDesactivarDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesactivarDG.Location = new System.Drawing.Point(825, 218);
            this.btnDesactivarDG.Name = "btnDesactivarDG";
            this.btnDesactivarDG.Size = new System.Drawing.Size(135, 36);
            this.btnDesactivarDG.TabIndex = 5;
            this.btnDesactivarDG.Text = "Desactivar";
            this.btnDesactivarDG.Click += new System.EventHandler(this.SubBtnDesactivarClickDG);
            //
            // btnCerrarDG
            //
            this.btnCerrarDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarDG.Location = new System.Drawing.Point(825, 524);
            this.btnCerrarDG.Name = "btnCerrarDG";
            this.btnCerrarDG.Size = new System.Drawing.Size(135, 36);
            this.btnCerrarDG.TabIndex = 6;
            this.btnCerrarDG.Text = "Cerrar";
            this.btnCerrarDG.Click += new System.EventHandler(this.SubBtnCerrarClickDG);
            //
            // frmClientesDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrarDG;
            this.ClientSize = new System.Drawing.Size(980, 580);
            this.Controls.Add(this.lblTituloDG);
            this.Controls.Add(this.gpbFiltrosDG);
            this.Controls.Add(this.dgvClientesDG);
            this.Controls.Add(this.lblHistorialDG);
            this.Controls.Add(this.lblHistorialResumenDG);
            this.Controls.Add(this.dgvHistorialDG);
            this.Controls.Add(this.btnNuevoDG);
            this.Controls.Add(this.btnEditarDG);
            this.Controls.Add(this.btnDesactivarDG);
            this.Controls.Add(this.btnCerrarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(820, 520);
            this.Name = "frmClientesDG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cubito - Clientes";
            this.Load += new System.EventHandler(this.SubFrmClientesLoadDG);
            this.gpbFiltrosDG.ResumeLayout(false);
            this.gpbFiltrosDG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialDG)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTituloDG;
        private System.Windows.Forms.GroupBox gpbFiltrosDG;
        private System.Windows.Forms.Label lblBuscarDG;
        private System.Windows.Forms.TextBox txtBuscarDG;
        private System.Windows.Forms.Label lblResumenDG;
        private System.Windows.Forms.DataGridView dgvClientesDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefonoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistroDG;
        private System.Windows.Forms.Label lblHistorialDG;
        private System.Windows.Forms.Label lblHistorialResumenDG;
        private System.Windows.Forms.DataGridView dgvHistorialDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHisCodigoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHisFechaDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHisEstadoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHisTotalDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHisSaldoDG;
        private System.Windows.Forms.Button btnNuevoDG;
        private System.Windows.Forms.Button btnEditarDG;
        private System.Windows.Forms.Button btnDesactivarDG;
        private System.Windows.Forms.Button btnCerrarDG;
    }
}
