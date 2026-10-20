namespace WinCubitoDG
{
    partial class frmGastosDG
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
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloMontoDG = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTituloDG = new System.Windows.Forms.Label();
            this.gpbFiltrosDG = new System.Windows.Forms.GroupBox();
            this.lblMesDG = new System.Windows.Forms.Label();
            this.dtpMesDG = new System.Windows.Forms.DateTimePicker();
            this.lblCategoriaDG = new System.Windows.Forms.Label();
            this.cmbCategoriaDG = new System.Windows.Forms.ComboBox();
            this.lblResumenDG = new System.Windows.Forms.Label();
            this.dgvGastosDG = new System.Windows.Forms.DataGridView();
            this.colFechaDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoriaDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcionDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevoDG = new System.Windows.Forms.Button();
            this.btnEditarDG = new System.Windows.Forms.Button();
            this.btnEliminarDG = new System.Windows.Forms.Button();
            this.btnCerrarDG = new System.Windows.Forms.Button();
            this.gpbFiltrosDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastosDG)).BeginInit();
            this.SuspendLayout();
            //
            // lblTituloDG
            //
            this.lblTituloDG.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloDG.Location = new System.Drawing.Point(20, 12);
            this.lblTituloDG.Name = "lblTituloDG";
            this.lblTituloDG.Size = new System.Drawing.Size(400, 40);
            this.lblTituloDG.Text = "Gastos";
            //
            // gpbFiltrosDG
            //
            this.gpbFiltrosDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbFiltrosDG.Controls.Add(this.lblMesDG);
            this.gpbFiltrosDG.Controls.Add(this.dtpMesDG);
            this.gpbFiltrosDG.Controls.Add(this.lblCategoriaDG);
            this.gpbFiltrosDG.Controls.Add(this.cmbCategoriaDG);
            this.gpbFiltrosDG.Controls.Add(this.lblResumenDG);
            this.gpbFiltrosDG.Location = new System.Drawing.Point(20, 58);
            this.gpbFiltrosDG.Name = "gpbFiltrosDG";
            this.gpbFiltrosDG.Size = new System.Drawing.Size(940, 62);
            this.gpbFiltrosDG.Text = "Filtros";
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
            this.dtpMesDG.ValueChanged += new System.EventHandler(this.SubFiltroCambioDG);
            //
            // lblCategoriaDG
            //
            this.lblCategoriaDG.Location = new System.Drawing.Point(235, 25);
            this.lblCategoriaDG.Name = "lblCategoriaDG";
            this.lblCategoriaDG.Size = new System.Drawing.Size(65, 23);
            this.lblCategoriaDG.Text = "Categoría:";
            this.lblCategoriaDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbCategoriaDG
            //
            this.cmbCategoriaDG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaDG.Location = new System.Drawing.Point(303, 25);
            this.cmbCategoriaDG.Name = "cmbCategoriaDG";
            this.cmbCategoriaDG.Size = new System.Drawing.Size(165, 23);
            this.cmbCategoriaDG.TabIndex = 1;
            this.cmbCategoriaDG.SelectedIndexChanged += new System.EventHandler(this.SubFiltroCambioDG);
            //
            // lblResumenDG
            //
            this.lblResumenDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumenDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResumenDG.Location = new System.Drawing.Point(480, 25);
            this.lblResumenDG.Name = "lblResumenDG";
            this.lblResumenDG.Size = new System.Drawing.Size(445, 23);
            this.lblResumenDG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // dgvGastosDG
            //
            this.dgvGastosDG.AllowUserToAddRows = false;
            this.dgvGastosDG.AllowUserToDeleteRows = false;
            this.dgvGastosDG.AllowUserToResizeRows = false;
            this.dgvGastosDG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGastosDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFechaDG,
            this.colCategoriaDG,
            this.colDescripcionDG,
            this.colMontoDG});
            this.dgvGastosDG.Location = new System.Drawing.Point(20, 130);
            this.dgvGastosDG.MultiSelect = false;
            this.dgvGastosDG.Name = "dgvGastosDG";
            this.dgvGastosDG.ReadOnly = true;
            this.dgvGastosDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGastosDG.Size = new System.Drawing.Size(790, 430);
            this.dgvGastosDG.TabIndex = 2;
            this.dgvGastosDG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SubDgvGastosCellDoubleClickDG);
            //
            // Columnas
            //
            lObjEstiloFechaDG.Format = "dd/MM/yyyy";
            lObjEstiloMontoDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloMontoDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lObjEstiloMontoDG.Format = "N2";
            this.colFechaDG.DataPropertyName = "gDtmFechaDG";
            this.colFechaDG.DefaultCellStyle = lObjEstiloFechaDG;
            this.colFechaDG.HeaderText = "Fecha";
            this.colFechaDG.Name = "colFechaDG";
            this.colFechaDG.Width = 95;
            this.colCategoriaDG.DataPropertyName = "gStrCategoriaDG";
            this.colCategoriaDG.HeaderText = "Categoría";
            this.colCategoriaDG.Name = "colCategoriaDG";
            this.colCategoriaDG.Width = 170;
            this.colDescripcionDG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescripcionDG.DataPropertyName = "gStrDescripcionDG";
            this.colDescripcionDG.HeaderText = "Descripción";
            this.colDescripcionDG.Name = "colDescripcionDG";
            this.colMontoDG.DataPropertyName = "gDcmMontoDG";
            this.colMontoDG.DefaultCellStyle = lObjEstiloMontoDG;
            this.colMontoDG.HeaderText = "Monto (Q)";
            this.colMontoDG.Name = "colMontoDG";
            this.colMontoDG.Width = 115;
            //
            // btnNuevoDG
            //
            this.btnNuevoDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoDG.Location = new System.Drawing.Point(825, 130);
            this.btnNuevoDG.Name = "btnNuevoDG";
            this.btnNuevoDG.Size = new System.Drawing.Size(135, 36);
            this.btnNuevoDG.TabIndex = 3;
            this.btnNuevoDG.Text = "Nuevo gasto";
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
            // btnEliminarDG
            //
            this.btnEliminarDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarDG.Location = new System.Drawing.Point(825, 218);
            this.btnEliminarDG.Name = "btnEliminarDG";
            this.btnEliminarDG.Size = new System.Drawing.Size(135, 36);
            this.btnEliminarDG.TabIndex = 5;
            this.btnEliminarDG.Text = "Eliminar";
            this.btnEliminarDG.Click += new System.EventHandler(this.SubBtnEliminarClickDG);
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
            // frmGastosDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrarDG;
            this.ClientSize = new System.Drawing.Size(980, 580);
            this.Controls.Add(this.lblTituloDG);
            this.Controls.Add(this.gpbFiltrosDG);
            this.Controls.Add(this.dgvGastosDG);
            this.Controls.Add(this.btnNuevoDG);
            this.Controls.Add(this.btnEditarDG);
            this.Controls.Add(this.btnEliminarDG);
            this.Controls.Add(this.btnCerrarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(820, 450);
            this.Name = "frmGastosDG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cubito - Gastos";
            this.Load += new System.EventHandler(this.SubFrmGastosLoadDG);
            this.gpbFiltrosDG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastosDG)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTituloDG;
        private System.Windows.Forms.GroupBox gpbFiltrosDG;
        private System.Windows.Forms.Label lblMesDG;
        private System.Windows.Forms.DateTimePicker dtpMesDG;
        private System.Windows.Forms.Label lblCategoriaDG;
        private System.Windows.Forms.ComboBox cmbCategoriaDG;
        private System.Windows.Forms.Label lblResumenDG;
        private System.Windows.Forms.DataGridView dgvGastosDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoDG;
        private System.Windows.Forms.Button btnNuevoDG;
        private System.Windows.Forms.Button btnEditarDG;
        private System.Windows.Forms.Button btnEliminarDG;
        private System.Windows.Forms.Button btnCerrarDG;
    }
}
