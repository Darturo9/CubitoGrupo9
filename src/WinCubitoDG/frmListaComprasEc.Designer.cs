namespace WinCubitoDG
{
    partial class frmListaComprasEc
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvComprasEC = new System.Windows.Forms.DataGridView();
            this.pnlFiltroEC = new System.Windows.Forms.Panel();
            this.lblFiltroEC = new System.Windows.Forms.Label();
            this.cmbTipoEC = new System.Windows.Forms.ComboBox();
            this.pnlInferiorEC = new System.Windows.Forms.Panel();
            this.lblTotalEC = new System.Windows.Forms.Label();
            this.btnActualizarEC = new System.Windows.Forms.Button();
            this.btnExportarEC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasEC)).BeginInit();
            this.pnlFiltroEC.SuspendLayout();
            this.pnlInferiorEC.SuspendLayout();
            this.SuspendLayout();
            //
            // dgvComprasEC
            //
            this.dgvComprasEC.AllowUserToAddRows = false;
            this.dgvComprasEC.AllowUserToDeleteRows = false;
            this.dgvComprasEC.AutoGenerateColumns = false;
            this.dgvComprasEC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprasEC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComprasEC.Name = "dgvComprasEC";
            this.dgvComprasEC.ReadOnly = true;
            this.dgvComprasEC.RowHeadersVisible = false;
            this.dgvComprasEC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprasEC.TabIndex = 0;
            //
            // pnlFiltroEC
            //
            this.pnlFiltroEC.Controls.Add(this.lblFiltroEC);
            this.pnlFiltroEC.Controls.Add(this.cmbTipoEC);
            this.pnlFiltroEC.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltroEC.Name = "pnlFiltroEC";
            this.pnlFiltroEC.Size = new System.Drawing.Size(934, 44);
            this.pnlFiltroEC.TabIndex = 1;
            //
            // lblFiltroEC
            //
            this.lblFiltroEC.AutoSize = true;
            this.lblFiltroEC.Location = new System.Drawing.Point(12, 15);
            this.lblFiltroEC.Name = "lblFiltroEC";
            this.lblFiltroEC.TabIndex = 0;
            this.lblFiltroEC.Text = "Mostrar";
            //
            // cmbTipoEC
            //
            this.cmbTipoEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEC.Location = new System.Drawing.Point(70, 11);
            this.cmbTipoEC.Name = "cmbTipoEC";
            this.cmbTipoEC.Size = new System.Drawing.Size(140, 21);
            this.cmbTipoEC.TabIndex = 1;
            //
            // pnlInferiorEC
            //
            this.pnlInferiorEC.Controls.Add(this.btnActualizarEC);
            this.pnlInferiorEC.Controls.Add(this.btnExportarEC);
            this.pnlInferiorEC.Controls.Add(this.lblTotalEC);
            this.pnlInferiorEC.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferiorEC.Name = "pnlInferiorEC";
            this.pnlInferiorEC.Size = new System.Drawing.Size(934, 56);
            this.pnlInferiorEC.TabIndex = 2;
            //
            // lblTotalEC
            //
            this.lblTotalEC.AutoSize = false;
            this.lblTotalEC.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotalEC.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalEC.Name = "lblTotalEC";
            this.lblTotalEC.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblTotalEC.Size = new System.Drawing.Size(520, 56);
            this.lblTotalEC.TabIndex = 0;
            this.lblTotalEC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnActualizarEC
            //
            this.btnActualizarEC.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnActualizarEC.Name = "btnActualizarEC";
            this.btnActualizarEC.Size = new System.Drawing.Size(120, 56);
            this.btnActualizarEC.TabIndex = 1;
            this.btnActualizarEC.Text = "Actualizar";
            this.btnActualizarEC.UseVisualStyleBackColor = true;
            //
            // btnExportarEC
            //
            this.btnExportarEC.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportarEC.Name = "btnExportarEC";
            this.btnExportarEC.Size = new System.Drawing.Size(160, 56);
            this.btnExportarEC.TabIndex = 2;
            this.btnExportarEC.Text = "Exportar a Excel";
            this.btnExportarEC.UseVisualStyleBackColor = true;
            //
            // frmListaComprasEC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 481);
            this.Controls.Add(this.dgvComprasEC);
            this.Controls.Add(this.pnlFiltroEC);
            this.Controls.Add(this.pnlInferiorEC);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "frmListaComprasEC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista de compras";
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasEC)).EndInit();
            this.pnlFiltroEC.ResumeLayout(false);
            this.pnlFiltroEC.PerformLayout();
            this.pnlInferiorEC.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvComprasEC;
        private System.Windows.Forms.Panel pnlFiltroEC;
        private System.Windows.Forms.Label lblFiltroEC;
        private System.Windows.Forms.ComboBox cmbTipoEC;
        private System.Windows.Forms.Panel pnlInferiorEC;
        private System.Windows.Forms.Label lblTotalEC;
        private System.Windows.Forms.Button btnActualizarEC;
        private System.Windows.Forms.Button btnExportarEC;
    }
}
