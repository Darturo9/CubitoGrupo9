namespace WinCubitoDG
{
    partial class frmKardexDG
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
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloVariacionDG = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloSaldoDG = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloFechaDG = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloEncabezadoDG = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblArticuloDG = new System.Windows.Forms.Label();
            this.lblResumenDG = new System.Windows.Forms.Label();
            this.dgvKardexDG = new System.Windows.Forms.DataGridView();
            this.colFechaDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVariacionDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPedidoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldoDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCerrarDG = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardexDG)).BeginInit();
            this.SuspendLayout();
            //
            // lblArticuloDG
            //
            this.lblArticuloDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArticuloDG.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblArticuloDG.Location = new System.Drawing.Point(15, 12);
            this.lblArticuloDG.Name = "lblArticuloDG";
            this.lblArticuloDG.Size = new System.Drawing.Size(730, 28);
            this.lblArticuloDG.Text = "Kardex";
            //
            // lblResumenDG
            //
            this.lblResumenDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumenDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblResumenDG.Location = new System.Drawing.Point(15, 40);
            this.lblResumenDG.Name = "lblResumenDG";
            this.lblResumenDG.Size = new System.Drawing.Size(730, 20);
            //
            // dgvKardexDG
            //
            this.dgvKardexDG.AllowUserToAddRows = false;
            this.dgvKardexDG.AllowUserToDeleteRows = false;
            this.dgvKardexDG.AllowUserToResizeRows = false;
            this.dgvKardexDG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKardexDG.BackgroundColor = System.Drawing.SystemColors.Window;
            lObjEstiloEncabezadoDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvKardexDG.ColumnHeadersDefaultCellStyle = lObjEstiloEncabezadoDG;
            this.dgvKardexDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKardexDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFechaDG,
            this.colTipoDG,
            this.colVariacionDG,
            this.colMotivoDG,
            this.colPedidoDG,
            this.colSaldoDG});
            this.dgvKardexDG.Location = new System.Drawing.Point(15, 66);
            this.dgvKardexDG.MultiSelect = false;
            this.dgvKardexDG.Name = "dgvKardexDG";
            this.dgvKardexDG.ReadOnly = true;
            this.dgvKardexDG.RowHeadersVisible = false;
            this.dgvKardexDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKardexDG.Size = new System.Drawing.Size(730, 330);
            this.dgvKardexDG.TabIndex = 0;
            //
            // Columnas
            //
            lObjEstiloFechaDG.Format = "dd/MM/yyyy HH:mm";
            this.colFechaDG.DataPropertyName = "gDtmFechaDG";
            this.colFechaDG.DefaultCellStyle = lObjEstiloFechaDG;
            this.colFechaDG.HeaderText = "Fecha";
            this.colFechaDG.Name = "colFechaDG";
            this.colFechaDG.Width = 120;
            this.colTipoDG.DataPropertyName = "gStrTipoDG";
            this.colTipoDG.HeaderText = "Tipo";
            this.colTipoDG.Name = "colTipoDG";
            this.colTipoDG.Width = 70;
            lObjEstiloVariacionDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloVariacionDG.Format = "+0.##;-0.##;0";
            this.colVariacionDG.DataPropertyName = "gDcmVariacionStockDG";
            this.colVariacionDG.DefaultCellStyle = lObjEstiloVariacionDG;
            this.colVariacionDG.HeaderText = "Cantidad";
            this.colVariacionDG.Name = "colVariacionDG";
            this.colVariacionDG.Width = 75;
            this.colMotivoDG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMotivoDG.DataPropertyName = "gStrMotivoDG";
            this.colMotivoDG.HeaderText = "Motivo";
            this.colMotivoDG.MinimumWidth = 120;
            this.colMotivoDG.Name = "colMotivoDG";
            this.colPedidoDG.DataPropertyName = "gStrCodigoPedidoDG";
            this.colPedidoDG.HeaderText = "Pedido";
            this.colPedidoDG.Name = "colPedidoDG";
            this.colPedidoDG.Width = 75;
            lObjEstiloSaldoDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloSaldoDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lObjEstiloSaldoDG.Format = "0.##";
            this.colSaldoDG.DataPropertyName = "gDcmSaldoDG";
            this.colSaldoDG.DefaultCellStyle = lObjEstiloSaldoDG;
            this.colSaldoDG.HeaderText = "Saldo";
            this.colSaldoDG.Name = "colSaldoDG";
            this.colSaldoDG.Width = 75;
            //
            // btnCerrarDG
            //
            this.btnCerrarDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarDG.Location = new System.Drawing.Point(645, 406);
            this.btnCerrarDG.Name = "btnCerrarDG";
            this.btnCerrarDG.Size = new System.Drawing.Size(100, 32);
            this.btnCerrarDG.TabIndex = 1;
            this.btnCerrarDG.Text = "Cerrar";
            this.btnCerrarDG.Click += new System.EventHandler(this.SubBtnCerrarClickDG);
            //
            // frmKardexDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrarDG;
            this.ClientSize = new System.Drawing.Size(760, 450);
            this.Controls.Add(this.lblArticuloDG);
            this.Controls.Add(this.lblResumenDG);
            this.Controls.Add(this.dgvKardexDG);
            this.Controls.Add(this.btnCerrarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "frmKardexDG";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cubito - Kardex";
            this.Load += new System.EventHandler(this.SubFrmKardexLoadDG);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardexDG)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblArticuloDG;
        private System.Windows.Forms.Label lblResumenDG;
        private System.Windows.Forms.DataGridView dgvKardexDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariacionDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPedidoDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoDG;
        private System.Windows.Forms.Button btnCerrarDG;
    }
}
