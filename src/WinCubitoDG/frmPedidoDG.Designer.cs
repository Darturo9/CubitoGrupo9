namespace WinCubitoDG
{
    partial class frmPedidoDG
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
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloEnteroDG = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloMonedaDG = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloSubtotalDG = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle lObjEstiloEncabezadoDG = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCodigoDG = new System.Windows.Forms.Label();
            this.lblEstadoDG = new System.Windows.Forms.Label();
            this.lblFechaDG = new System.Windows.Forms.Label();
            this.gpbDatosDG = new System.Windows.Forms.GroupBox();
            this.lblClienteDG = new System.Windows.Forms.Label();
            this.cmbClienteDG = new System.Windows.Forms.ComboBox();
            this.lblEntregaDG = new System.Windows.Forms.Label();
            this.dtpEntregaDG = new System.Windows.Forms.DateTimePicker();
            this.lblObservacionesDG = new System.Windows.Forms.Label();
            this.txtObservacionesDG = new System.Windows.Forms.TextBox();
            this.gpbLineaDG = new System.Windows.Forms.GroupBox();
            this.lblTecnicaDG = new System.Windows.Forms.Label();
            this.cmbTecnicaDG = new System.Windows.Forms.ComboBox();
            this.lblPrendaDG = new System.Windows.Forms.Label();
            this.cmbPrendaDG = new System.Windows.Forms.ComboBox();
            this.lblDescripcionDG = new System.Windows.Forms.Label();
            this.txtDescripcionDG = new System.Windows.Forms.TextBox();
            this.lblCantidadDG = new System.Windows.Forms.Label();
            this.nudCantidadDG = new System.Windows.Forms.NumericUpDown();
            this.lblPrecioDG = new System.Windows.Forms.Label();
            this.nudPrecioDG = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarLineaDG = new System.Windows.Forms.Button();
            this.dgvDetalleDG = new System.Windows.Forms.DataGridView();
            this.colTecnicaDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrendaDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcionDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotalDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuitarLineaDG = new System.Windows.Forms.Button();
            this.lblMotivoCancelacionDG = new System.Windows.Forms.Label();
            this.lblTotalDG = new System.Windows.Forms.Label();
            this.lblPagosDG = new System.Windows.Forms.Label();
            this.lblMensajeDG = new System.Windows.Forms.Label();
            this.btnGuardarDG = new System.Windows.Forms.Button();
            this.flpAccionesDG = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAprobarDG = new System.Windows.Forms.Button();
            this.btnProduccionDG = new System.Windows.Forms.Button();
            this.btnListoDG = new System.Windows.Forms.Button();
            this.btnEntregarDG = new System.Windows.Forms.Button();
            this.btnCancelarPedidoDG = new System.Windows.Forms.Button();
            this.btnCerrarDG = new System.Windows.Forms.Button();
            this.gpbDatosDG.SuspendLayout();
            this.gpbLineaDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleDG)).BeginInit();
            this.flpAccionesDG.SuspendLayout();
            this.SuspendLayout();
            //
            // lblCodigoDG
            //
            this.lblCodigoDG.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCodigoDG.Location = new System.Drawing.Point(15, 8);
            this.lblCodigoDG.Name = "lblCodigoDG";
            this.lblCodigoDG.Size = new System.Drawing.Size(250, 38);
            this.lblCodigoDG.Text = "Nuevo pedido";
            //
            // lblEstadoDG
            //
            this.lblEstadoDG.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstadoDG.Location = new System.Drawing.Point(270, 15);
            this.lblEstadoDG.Name = "lblEstadoDG";
            this.lblEstadoDG.Size = new System.Drawing.Size(140, 26);
            this.lblEstadoDG.Text = "Cotización";
            this.lblEstadoDG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblFechaDG
            //
            this.lblFechaDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblFechaDG.Location = new System.Drawing.Point(17, 46);
            this.lblFechaDG.Name = "lblFechaDG";
            this.lblFechaDG.Size = new System.Drawing.Size(600, 20);
            //
            // gpbDatosDG
            //
            this.gpbDatosDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbDatosDG.Controls.Add(this.lblClienteDG);
            this.gpbDatosDG.Controls.Add(this.cmbClienteDG);
            this.gpbDatosDG.Controls.Add(this.lblEntregaDG);
            this.gpbDatosDG.Controls.Add(this.dtpEntregaDG);
            this.gpbDatosDG.Controls.Add(this.lblObservacionesDG);
            this.gpbDatosDG.Controls.Add(this.txtObservacionesDG);
            this.gpbDatosDG.Location = new System.Drawing.Point(15, 70);
            this.gpbDatosDG.Name = "gpbDatosDG";
            this.gpbDatosDG.Size = new System.Drawing.Size(870, 100);
            this.gpbDatosDG.Text = "Datos del pedido";
            //
            // lblClienteDG
            //
            this.lblClienteDG.Location = new System.Drawing.Point(15, 28);
            this.lblClienteDG.Name = "lblClienteDG";
            this.lblClienteDG.Size = new System.Drawing.Size(90, 23);
            this.lblClienteDG.Text = "Cliente:";
            this.lblClienteDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbClienteDG
            //
            this.cmbClienteDG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClienteDG.Location = new System.Drawing.Point(110, 28);
            this.cmbClienteDG.Name = "cmbClienteDG";
            this.cmbClienteDG.Size = new System.Drawing.Size(320, 23);
            this.cmbClienteDG.TabIndex = 0;
            this.cmbClienteDG.SelectedIndexChanged += new System.EventHandler(this.SubDatoCambioDG);
            //
            // lblEntregaDG
            //
            this.lblEntregaDG.Location = new System.Drawing.Point(450, 28);
            this.lblEntregaDG.Name = "lblEntregaDG";
            this.lblEntregaDG.Size = new System.Drawing.Size(115, 23);
            this.lblEntregaDG.Text = "Entrega estimada:";
            this.lblEntregaDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dtpEntregaDG
            //
            this.dtpEntregaDG.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntregaDG.Location = new System.Drawing.Point(570, 28);
            this.dtpEntregaDG.Name = "dtpEntregaDG";
            this.dtpEntregaDG.ShowCheckBox = true;
            this.dtpEntregaDG.Size = new System.Drawing.Size(140, 23);
            this.dtpEntregaDG.TabIndex = 1;
            this.dtpEntregaDG.ValueChanged += new System.EventHandler(this.SubDatoCambioDG);
            //
            // lblObservacionesDG
            //
            this.lblObservacionesDG.Location = new System.Drawing.Point(15, 62);
            this.lblObservacionesDG.Name = "lblObservacionesDG";
            this.lblObservacionesDG.Size = new System.Drawing.Size(90, 23);
            this.lblObservacionesDG.Text = "Observaciones:";
            this.lblObservacionesDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtObservacionesDG
            //
            this.txtObservacionesDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacionesDG.Location = new System.Drawing.Point(110, 62);
            this.txtObservacionesDG.MaxLength = 300;
            this.txtObservacionesDG.Name = "txtObservacionesDG";
            this.txtObservacionesDG.Size = new System.Drawing.Size(740, 23);
            this.txtObservacionesDG.TabIndex = 2;
            this.txtObservacionesDG.TextChanged += new System.EventHandler(this.SubDatoCambioDG);
            //
            // gpbLineaDG
            //
            this.gpbLineaDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbLineaDG.Controls.Add(this.lblTecnicaDG);
            this.gpbLineaDG.Controls.Add(this.cmbTecnicaDG);
            this.gpbLineaDG.Controls.Add(this.lblPrendaDG);
            this.gpbLineaDG.Controls.Add(this.cmbPrendaDG);
            this.gpbLineaDG.Controls.Add(this.lblDescripcionDG);
            this.gpbLineaDG.Controls.Add(this.txtDescripcionDG);
            this.gpbLineaDG.Controls.Add(this.lblCantidadDG);
            this.gpbLineaDG.Controls.Add(this.nudCantidadDG);
            this.gpbLineaDG.Controls.Add(this.lblPrecioDG);
            this.gpbLineaDG.Controls.Add(this.nudPrecioDG);
            this.gpbLineaDG.Controls.Add(this.btnAgregarLineaDG);
            this.gpbLineaDG.Location = new System.Drawing.Point(15, 178);
            this.gpbLineaDG.Name = "gpbLineaDG";
            this.gpbLineaDG.Size = new System.Drawing.Size(870, 85);
            this.gpbLineaDG.Text = "Agregar línea";
            //
            // lblTecnicaDG
            //
            this.lblTecnicaDG.Location = new System.Drawing.Point(15, 22);
            this.lblTecnicaDG.Name = "lblTecnicaDG";
            this.lblTecnicaDG.Size = new System.Drawing.Size(110, 20);
            this.lblTecnicaDG.Text = "Técnica";
            //
            // cmbTecnicaDG
            //
            this.cmbTecnicaDG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTecnicaDG.Location = new System.Drawing.Point(15, 44);
            this.cmbTecnicaDG.Name = "cmbTecnicaDG";
            this.cmbTecnicaDG.Size = new System.Drawing.Size(110, 23);
            this.cmbTecnicaDG.TabIndex = 3;
            //
            // lblPrendaDG
            //
            this.lblPrendaDG.Location = new System.Drawing.Point(135, 22);
            this.lblPrendaDG.Name = "lblPrendaDG";
            this.lblPrendaDG.Size = new System.Drawing.Size(250, 20);
            this.lblPrendaDG.Text = "Prenda";
            //
            // cmbPrendaDG
            //
            this.cmbPrendaDG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrendaDG.Location = new System.Drawing.Point(135, 44);
            this.cmbPrendaDG.Name = "cmbPrendaDG";
            this.cmbPrendaDG.Size = new System.Drawing.Size(250, 23);
            this.cmbPrendaDG.TabIndex = 4;
            //
            // lblDescripcionDG
            //
            this.lblDescripcionDG.Location = new System.Drawing.Point(395, 22);
            this.lblDescripcionDG.Name = "lblDescripcionDG";
            this.lblDescripcionDG.Size = new System.Drawing.Size(220, 20);
            this.lblDescripcionDG.Text = "Diseño / descripción";
            //
            // txtDescripcionDG
            //
            this.txtDescripcionDG.Location = new System.Drawing.Point(395, 44);
            this.txtDescripcionDG.MaxLength = 200;
            this.txtDescripcionDG.Name = "txtDescripcionDG";
            this.txtDescripcionDG.Size = new System.Drawing.Size(220, 23);
            this.txtDescripcionDG.TabIndex = 5;
            //
            // lblCantidadDG
            //
            this.lblCantidadDG.Location = new System.Drawing.Point(625, 22);
            this.lblCantidadDG.Name = "lblCantidadDG";
            this.lblCantidadDG.Size = new System.Drawing.Size(65, 20);
            this.lblCantidadDG.Text = "Cantidad";
            //
            // nudCantidadDG
            //
            this.nudCantidadDG.Location = new System.Drawing.Point(625, 44);
            this.nudCantidadDG.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.nudCantidadDG.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCantidadDG.Name = "nudCantidadDG";
            this.nudCantidadDG.Size = new System.Drawing.Size(65, 23);
            this.nudCantidadDG.TabIndex = 6;
            this.nudCantidadDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCantidadDG.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // lblPrecioDG
            //
            this.lblPrecioDG.Location = new System.Drawing.Point(700, 22);
            this.lblPrecioDG.Name = "lblPrecioDG";
            this.lblPrecioDG.Size = new System.Drawing.Size(80, 20);
            this.lblPrecioDG.Text = "Precio (Q)";
            //
            // nudPrecioDG
            //
            this.nudPrecioDG.DecimalPlaces = 2;
            this.nudPrecioDG.Location = new System.Drawing.Point(700, 44);
            this.nudPrecioDG.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudPrecioDG.Name = "nudPrecioDG";
            this.nudPrecioDG.Size = new System.Drawing.Size(80, 23);
            this.nudPrecioDG.TabIndex = 7;
            this.nudPrecioDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // btnAgregarLineaDG
            //
            this.btnAgregarLineaDG.Location = new System.Drawing.Point(790, 40);
            this.btnAgregarLineaDG.Name = "btnAgregarLineaDG";
            this.btnAgregarLineaDG.Size = new System.Drawing.Size(70, 30);
            this.btnAgregarLineaDG.TabIndex = 8;
            this.btnAgregarLineaDG.Text = "Agregar";
            this.btnAgregarLineaDG.Click += new System.EventHandler(this.SubBtnAgregarLineaClickDG);
            //
            // dgvDetalleDG
            //
            this.dgvDetalleDG.AllowUserToAddRows = false;
            this.dgvDetalleDG.AllowUserToDeleteRows = false;
            this.dgvDetalleDG.AllowUserToResizeRows = false;
            this.dgvDetalleDG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalleDG.BackgroundColor = System.Drawing.SystemColors.Window;
            lObjEstiloEncabezadoDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvDetalleDG.ColumnHeadersDefaultCellStyle = lObjEstiloEncabezadoDG;
            this.dgvDetalleDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTecnicaDG,
            this.colPrendaDG,
            this.colDescripcionDG,
            this.colCantidadDG,
            this.colPrecioDG,
            this.colSubtotalDG});
            this.dgvDetalleDG.Location = new System.Drawing.Point(15, 272);
            this.dgvDetalleDG.MultiSelect = false;
            this.dgvDetalleDG.Name = "dgvDetalleDG";
            this.dgvDetalleDG.RowHeadersVisible = false;
            this.dgvDetalleDG.Size = new System.Drawing.Size(870, 250);
            this.dgvDetalleDG.TabIndex = 9;
            this.dgvDetalleDG.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.SubDgvDetalleCellEndEditDG);
            this.dgvDetalleDG.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.SubDgvDetalleDataErrorDG);
            //
            // Columnas
            //
            this.colTecnicaDG.DataPropertyName = "gStrTecnicaDG";
            this.colTecnicaDG.HeaderText = "Técnica";
            this.colTecnicaDG.Name = "colTecnicaDG";
            this.colTecnicaDG.ReadOnly = true;
            this.colTecnicaDG.Width = 90;
            this.colPrendaDG.DataPropertyName = "gStrPrendaDG";
            this.colPrendaDG.HeaderText = "Prenda";
            this.colPrendaDG.Name = "colPrendaDG";
            this.colPrendaDG.ReadOnly = true;
            this.colPrendaDG.Width = 190;
            this.colDescripcionDG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescripcionDG.DataPropertyName = "gStrDescripcionDG";
            this.colDescripcionDG.HeaderText = "Diseño / descripción";
            this.colDescripcionDG.MinimumWidth = 120;
            this.colDescripcionDG.Name = "colDescripcionDG";
            this.colDescripcionDG.ReadOnly = true;
            lObjEstiloEnteroDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCantidadDG.DataPropertyName = "gIntCantidadDG";
            this.colCantidadDG.DefaultCellStyle = lObjEstiloEnteroDG;
            this.colCantidadDG.HeaderText = "Cantidad";
            this.colCantidadDG.Name = "colCantidadDG";
            this.colCantidadDG.ToolTipText = "Doble clic para editar";
            this.colCantidadDG.Width = 75;
            lObjEstiloMonedaDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloMonedaDG.Format = "N2";
            this.colPrecioDG.DataPropertyName = "gDcmPrecioUnitarioDG";
            this.colPrecioDG.DefaultCellStyle = lObjEstiloMonedaDG;
            this.colPrecioDG.HeaderText = "Precio (Q)";
            this.colPrecioDG.Name = "colPrecioDG";
            this.colPrecioDG.ToolTipText = "Doble clic para editar";
            this.colPrecioDG.Width = 90;
            lObjEstiloSubtotalDG.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            lObjEstiloSubtotalDG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lObjEstiloSubtotalDG.Format = "N2";
            this.colSubtotalDG.DataPropertyName = "gDcmSubtotalDG";
            this.colSubtotalDG.DefaultCellStyle = lObjEstiloSubtotalDG;
            this.colSubtotalDG.HeaderText = "Subtotal (Q)";
            this.colSubtotalDG.Name = "colSubtotalDG";
            this.colSubtotalDG.ReadOnly = true;
            this.colSubtotalDG.Width = 100;
            //
            // btnQuitarLineaDG
            //
            this.btnQuitarLineaDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuitarLineaDG.Location = new System.Drawing.Point(15, 530);
            this.btnQuitarLineaDG.Name = "btnQuitarLineaDG";
            this.btnQuitarLineaDG.Size = new System.Drawing.Size(120, 30);
            this.btnQuitarLineaDG.TabIndex = 10;
            this.btnQuitarLineaDG.Text = "Quitar línea";
            this.btnQuitarLineaDG.Click += new System.EventHandler(this.SubBtnQuitarLineaClickDG);
            //
            // lblMotivoCancelacionDG
            //
            this.lblMotivoCancelacionDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMotivoCancelacionDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblMotivoCancelacionDG.Location = new System.Drawing.Point(145, 534);
            this.lblMotivoCancelacionDG.Name = "lblMotivoCancelacionDG";
            this.lblMotivoCancelacionDG.Size = new System.Drawing.Size(420, 22);
            //
            // lblTotalDG
            //
            this.lblTotalDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDG.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalDG.Location = new System.Drawing.Point(585, 527);
            this.lblTotalDG.Name = "lblTotalDG";
            this.lblTotalDG.Size = new System.Drawing.Size(300, 30);
            this.lblTotalDG.Text = "Total: Q0.00";
            this.lblTotalDG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblPagosDG
            //
            this.lblPagosDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPagosDG.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblPagosDG.Location = new System.Drawing.Point(485, 557);
            this.lblPagosDG.Name = "lblPagosDG";
            this.lblPagosDG.Size = new System.Drawing.Size(400, 20);
            this.lblPagosDG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblMensajeDG
            //
            this.lblMensajeDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMensajeDG.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMensajeDG.Location = new System.Drawing.Point(15, 565);
            this.lblMensajeDG.Name = "lblMensajeDG";
            this.lblMensajeDG.Size = new System.Drawing.Size(460, 36);
            //
            // btnGuardarDG
            //
            this.btnGuardarDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardarDG.Location = new System.Drawing.Point(15, 608);
            this.btnGuardarDG.Name = "btnGuardarDG";
            this.btnGuardarDG.Size = new System.Drawing.Size(110, 34);
            this.btnGuardarDG.TabIndex = 11;
            this.btnGuardarDG.Text = "Guardar";
            this.btnGuardarDG.Click += new System.EventHandler(this.SubBtnGuardarClickDG);
            //
            // flpAccionesDG
            //
            this.flpAccionesDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flpAccionesDG.Controls.Add(this.btnAprobarDG);
            this.flpAccionesDG.Controls.Add(this.btnProduccionDG);
            this.flpAccionesDG.Controls.Add(this.btnListoDG);
            this.flpAccionesDG.Controls.Add(this.btnEntregarDG);
            this.flpAccionesDG.Controls.Add(this.btnCancelarPedidoDG);
            this.flpAccionesDG.Location = new System.Drawing.Point(135, 605);
            this.flpAccionesDG.Name = "flpAccionesDG";
            this.flpAccionesDG.Size = new System.Drawing.Size(640, 40);
            this.flpAccionesDG.WrapContents = false;
            //
            // btnAprobarDG
            //
            this.btnAprobarDG.Name = "btnAprobarDG";
            this.btnAprobarDG.Size = new System.Drawing.Size(110, 34);
            this.btnAprobarDG.TabIndex = 12;
            this.btnAprobarDG.Text = "Aprobar";
            this.btnAprobarDG.Click += new System.EventHandler(this.SubBtnAprobarClickDG);
            //
            // btnProduccionDG
            //
            this.btnProduccionDG.Name = "btnProduccionDG";
            this.btnProduccionDG.Size = new System.Drawing.Size(140, 34);
            this.btnProduccionDG.TabIndex = 13;
            this.btnProduccionDG.Text = "Enviar a producción";
            this.btnProduccionDG.Click += new System.EventHandler(this.SubBtnProduccionClickDG);
            //
            // btnListoDG
            //
            this.btnListoDG.Name = "btnListoDG";
            this.btnListoDG.Size = new System.Drawing.Size(110, 34);
            this.btnListoDG.TabIndex = 14;
            this.btnListoDG.Text = "Marcar listo";
            this.btnListoDG.Click += new System.EventHandler(this.SubBtnListoClickDG);
            //
            // btnEntregarDG
            //
            this.btnEntregarDG.Name = "btnEntregarDG";
            this.btnEntregarDG.Size = new System.Drawing.Size(110, 34);
            this.btnEntregarDG.TabIndex = 15;
            this.btnEntregarDG.Text = "Entregar";
            this.btnEntregarDG.Click += new System.EventHandler(this.SubBtnEntregarClickDG);
            //
            // btnCancelarPedidoDG
            //
            this.btnCancelarPedidoDG.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCancelarPedidoDG.Name = "btnCancelarPedidoDG";
            this.btnCancelarPedidoDG.Size = new System.Drawing.Size(120, 34);
            this.btnCancelarPedidoDG.TabIndex = 16;
            this.btnCancelarPedidoDG.Text = "Cancelar pedido";
            this.btnCancelarPedidoDG.Click += new System.EventHandler(this.SubBtnCancelarPedidoClickDG);
            //
            // btnCerrarDG
            //
            this.btnCerrarDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarDG.Location = new System.Drawing.Point(785, 608);
            this.btnCerrarDG.Name = "btnCerrarDG";
            this.btnCerrarDG.Size = new System.Drawing.Size(100, 34);
            this.btnCerrarDG.TabIndex = 17;
            this.btnCerrarDG.Text = "Cerrar";
            this.btnCerrarDG.Click += new System.EventHandler(this.SubBtnCerrarClickDG);
            //
            // frmPedidoDG
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrarDG;
            this.ClientSize = new System.Drawing.Size(900, 655);
            this.Controls.Add(this.lblCodigoDG);
            this.Controls.Add(this.lblEstadoDG);
            this.Controls.Add(this.lblFechaDG);
            this.Controls.Add(this.gpbDatosDG);
            this.Controls.Add(this.gpbLineaDG);
            this.Controls.Add(this.dgvDetalleDG);
            this.Controls.Add(this.btnQuitarLineaDG);
            this.Controls.Add(this.lblMotivoCancelacionDG);
            this.Controls.Add(this.lblTotalDG);
            this.Controls.Add(this.lblPagosDG);
            this.Controls.Add(this.lblMensajeDG);
            this.Controls.Add(this.btnGuardarDG);
            this.Controls.Add(this.flpAccionesDG);
            this.Controls.Add(this.btnCerrarDG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(916, 600);
            this.Name = "frmPedidoDG";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pedido";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubFrmPedidoFormClosingDG);
            this.Load += new System.EventHandler(this.SubFrmPedidoLoadDG);
            this.gpbDatosDG.ResumeLayout(false);
            this.gpbDatosDG.PerformLayout();
            this.gpbLineaDG.ResumeLayout(false);
            this.gpbLineaDG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleDG)).EndInit();
            this.flpAccionesDG.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblCodigoDG;
        private System.Windows.Forms.Label lblEstadoDG;
        private System.Windows.Forms.Label lblFechaDG;
        private System.Windows.Forms.GroupBox gpbDatosDG;
        private System.Windows.Forms.Label lblClienteDG;
        private System.Windows.Forms.ComboBox cmbClienteDG;
        private System.Windows.Forms.Label lblEntregaDG;
        private System.Windows.Forms.DateTimePicker dtpEntregaDG;
        private System.Windows.Forms.Label lblObservacionesDG;
        private System.Windows.Forms.TextBox txtObservacionesDG;
        private System.Windows.Forms.GroupBox gpbLineaDG;
        private System.Windows.Forms.Label lblTecnicaDG;
        private System.Windows.Forms.ComboBox cmbTecnicaDG;
        private System.Windows.Forms.Label lblPrendaDG;
        private System.Windows.Forms.ComboBox cmbPrendaDG;
        private System.Windows.Forms.Label lblDescripcionDG;
        private System.Windows.Forms.TextBox txtDescripcionDG;
        private System.Windows.Forms.Label lblCantidadDG;
        private System.Windows.Forms.NumericUpDown nudCantidadDG;
        private System.Windows.Forms.Label lblPrecioDG;
        private System.Windows.Forms.NumericUpDown nudPrecioDG;
        private System.Windows.Forms.Button btnAgregarLineaDG;
        private System.Windows.Forms.DataGridView dgvDetalleDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTecnicaDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrendaDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotalDG;
        private System.Windows.Forms.Button btnQuitarLineaDG;
        private System.Windows.Forms.Label lblMotivoCancelacionDG;
        private System.Windows.Forms.Label lblTotalDG;
        private System.Windows.Forms.Label lblPagosDG;
        private System.Windows.Forms.Label lblMensajeDG;
        private System.Windows.Forms.Button btnGuardarDG;
        private System.Windows.Forms.FlowLayoutPanel flpAccionesDG;
        private System.Windows.Forms.Button btnAprobarDG;
        private System.Windows.Forms.Button btnProduccionDG;
        private System.Windows.Forms.Button btnListoDG;
        private System.Windows.Forms.Button btnEntregarDG;
        private System.Windows.Forms.Button btnCancelarPedidoDG;
        private System.Windows.Forms.Button btnCerrarDG;
    }
}
