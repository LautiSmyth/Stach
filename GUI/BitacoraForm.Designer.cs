namespace GUI
{
    partial class BitacoraForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblFiltrarUsuario = new System.Windows.Forms.Label();
            this.cboFiltrarUsuario = new System.Windows.Forms.ComboBox();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.tlpFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.flpCheckboxes = new System.Windows.Forms.FlowLayoutPanel();
            this.chkUsername = new System.Windows.Forms.CheckBox();
            this.chkDetalle = new System.Windows.Forms.CheckBox();
            this.chkError = new System.Windows.Forms.CheckBox();
            this.lblCriticidad = new System.Windows.Forms.Label();
            this.cboCriticidad = new System.Windows.Forms.ComboBox();
            this.lblActividad = new System.Windows.Forms.Label();
            this.cboActividad = new System.Windows.Forms.ComboBox();
            this.flpExitoso = new System.Windows.Forms.FlowLayoutPanel();
            this.chkExitoso = new System.Windows.Forms.CheckBox();
            this.flpFechas = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblLimite = new System.Windows.Forms.Label();
            this.cboLimite = new System.Windows.Forms.ComboBox();
            this.flpBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.splitCuerpo = new System.Windows.Forms.SplitContainer();
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.tblDetalle = new System.Windows.Forms.TableLayoutPanel();
            this.lblDetFecha = new System.Windows.Forms.Label();
            this.lblDetUsuario = new System.Windows.Forms.Label();
            this.txtDetFecha = new System.Windows.Forms.TextBox();
            this.txtDetUsuario = new System.Windows.Forms.TextBox();
            this.lblDetModulo = new System.Windows.Forms.Label();
            this.lblDetActividad = new System.Windows.Forms.Label();
            this.txtDetModulo = new System.Windows.Forms.TextBox();
            this.txtDetActividad = new System.Windows.Forms.TextBox();
            this.lblDetCriticidad = new System.Windows.Forms.Label();
            this.lblDetResultado = new System.Windows.Forms.Label();
            this.txtDetCriticidad = new System.Windows.Forms.TextBox();
            this.txtDetResultado = new System.Windows.Forms.TextBox();
            this.lblDetDetalle = new System.Windows.Forms.Label();
            this.txtDetDetalle = new System.Windows.Forms.TextBox();
            this.lblDetError = new System.Windows.Forms.Label();
            this.txtDetError = new System.Windows.Forms.TextBox();
            this.pnlEstado = new System.Windows.Forms.Panel();
            this.lblContador = new System.Windows.Forms.Label();
            this.pnlFiltros.SuspendLayout();
            this.tlpFiltros.SuspendLayout();
            this.flpCheckboxes.SuspendLayout();
            this.flpExitoso.SuspendLayout();
            this.flpFechas.SuspendLayout();
            this.flpBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCuerpo)).BeginInit();
            this.splitCuerpo.Panel1.SuspendLayout();
            this.splitCuerpo.Panel2.SuspendLayout();
            this.splitCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.grpDetalle.SuspendLayout();
            this.tblDetalle.SuspendLayout();
            this.pnlEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFiltrarUsuario
            // 
            this.lblFiltrarUsuario.AutoSize = true;
            this.lblFiltrarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltrarUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFiltrarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblFiltrarUsuario.Location = new System.Drawing.Point(36, 8);
            this.lblFiltrarUsuario.Margin = new System.Windows.Forms.Padding(15, 8, 3, 0);
            this.lblFiltrarUsuario.Name = "lblFiltrarUsuario";
            this.lblFiltrarUsuario.Size = new System.Drawing.Size(56, 17);
            this.lblFiltrarUsuario.TabIndex = 1;
            this.lblFiltrarUsuario.Text = "Usuario:";
            this.lblFiltrarUsuario.Visible = false;
            // 
            // cboFiltrarUsuario
            // 
            this.cboFiltrarUsuario.BackColor = System.Drawing.Color.White;
            this.cboFiltrarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFiltrarUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFiltrarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.cboFiltrarUsuario.Location = new System.Drawing.Point(98, 4);
            this.cboFiltrarUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.cboFiltrarUsuario.Name = "cboFiltrarUsuario";
            this.cboFiltrarUsuario.Size = new System.Drawing.Size(120, 25);
            this.cboFiltrarUsuario.TabIndex = 1;
            this.cboFiltrarUsuario.Visible = false;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(249)))));
            this.pnlFiltros.Controls.Add(this.tlpFiltros);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1068, 78);
            this.pnlFiltros.TabIndex = 2;
            // 
            // tlpFiltros
            // 
            this.tlpFiltros.ColumnCount = 7;
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFiltros.Controls.Add(this.lblBuscar, 0, 0);
            this.tlpFiltros.Controls.Add(this.txtBuscar, 1, 0);
            this.tlpFiltros.Controls.Add(this.flpCheckboxes, 2, 0);
            this.tlpFiltros.Controls.Add(this.lblCriticidad, 3, 0);
            this.tlpFiltros.Controls.Add(this.cboCriticidad, 4, 0);
            this.tlpFiltros.Controls.Add(this.lblActividad, 5, 0);
            this.tlpFiltros.Controls.Add(this.cboActividad, 6, 0);
            this.tlpFiltros.Controls.Add(this.flpExitoso, 1, 1);
            this.tlpFiltros.Controls.Add(this.flpFechas, 2, 1);
            this.tlpFiltros.Controls.Add(this.lblLimite, 3, 1);
            this.tlpFiltros.Controls.Add(this.cboLimite, 4, 1);
            this.tlpFiltros.Controls.Add(this.flpBotones, 5, 1);
            this.tlpFiltros.Controls.Add(this.label1, 0, 1);
            this.tlpFiltros.Location = new System.Drawing.Point(0, 0);
            this.tlpFiltros.Name = "tlpFiltros";
            this.tlpFiltros.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.tlpFiltros.RowCount = 2;
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFiltros.Size = new System.Drawing.Size(1068, 78);
            this.tlpFiltros.TabIndex = 0;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuscar.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblBuscar.Location = new System.Drawing.Point(13, 5);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(67, 34);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtBuscar.Location = new System.Drawing.Point(83, 8);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(0, 3, 9, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(287, 24);
            this.txtBuscar.TabIndex = 1;
            // 
            // flpCheckboxes
            // 
            this.flpCheckboxes.Controls.Add(this.chkUsername);
            this.flpCheckboxes.Controls.Add(this.chkDetalle);
            this.flpCheckboxes.Controls.Add(this.chkError);
            this.flpCheckboxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCheckboxes.Location = new System.Drawing.Point(379, 5);
            this.flpCheckboxes.Margin = new System.Windows.Forms.Padding(0);
            this.flpCheckboxes.Name = "flpCheckboxes";
            this.flpCheckboxes.Size = new System.Drawing.Size(303, 34);
            this.flpCheckboxes.TabIndex = 2;
            this.flpCheckboxes.WrapContents = false;
            // 
            // chkUsername
            // 
            this.chkUsername.AutoSize = true;
            this.chkUsername.BackColor = System.Drawing.Color.Transparent;
            this.chkUsername.Checked = true;
            this.chkUsername.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.chkUsername.Location = new System.Drawing.Point(3, 5);
            this.chkUsername.Margin = new System.Windows.Forms.Padding(3, 5, 7, 3);
            this.chkUsername.Name = "chkUsername";
            this.chkUsername.Size = new System.Drawing.Size(86, 21);
            this.chkUsername.TabIndex = 0;
            this.chkUsername.Text = "Username";
            this.chkUsername.UseVisualStyleBackColor = false;
            // 
            // chkDetalle
            // 
            this.chkDetalle.AutoSize = true;
            this.chkDetalle.BackColor = System.Drawing.Color.Transparent;
            this.chkDetalle.Checked = true;
            this.chkDetalle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.chkDetalle.Location = new System.Drawing.Point(99, 5);
            this.chkDetalle.Margin = new System.Windows.Forms.Padding(3, 5, 7, 3);
            this.chkDetalle.Name = "chkDetalle";
            this.chkDetalle.Size = new System.Drawing.Size(67, 21);
            this.chkDetalle.TabIndex = 1;
            this.chkDetalle.Text = "Detalle";
            this.chkDetalle.UseVisualStyleBackColor = false;
            // 
            // chkError
            // 
            this.chkError.AutoSize = true;
            this.chkError.BackColor = System.Drawing.Color.Transparent;
            this.chkError.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.chkError.Location = new System.Drawing.Point(176, 5);
            this.chkError.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.chkError.Name = "chkError";
            this.chkError.Size = new System.Drawing.Size(57, 21);
            this.chkError.TabIndex = 2;
            this.chkError.Text = "Error";
            this.chkError.UseVisualStyleBackColor = false;
            // 
            // lblCriticidad
            // 
            this.lblCriticidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCriticidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCriticidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCriticidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblCriticidad.Location = new System.Drawing.Point(682, 5);
            this.lblCriticidad.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.lblCriticidad.Name = "lblCriticidad";
            this.lblCriticidad.Size = new System.Drawing.Size(66, 34);
            this.lblCriticidad.TabIndex = 3;
            this.lblCriticidad.Text = "Criticidad:";
            this.lblCriticidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCriticidad
            // 
            this.cboCriticidad.BackColor = System.Drawing.Color.White;
            this.cboCriticidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriticidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCriticidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCriticidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.cboCriticidad.Location = new System.Drawing.Point(755, 8);
            this.cboCriticidad.Margin = new System.Windows.Forms.Padding(0, 3, 9, 3);
            this.cboCriticidad.Name = "cboCriticidad";
            this.cboCriticidad.Size = new System.Drawing.Size(106, 25);
            this.cboCriticidad.TabIndex = 1;
            // 
            // lblActividad
            // 
            this.lblActividad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActividad.BackColor = System.Drawing.Color.Transparent;
            this.lblActividad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblActividad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblActividad.Location = new System.Drawing.Point(870, 5);
            this.lblActividad.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.lblActividad.Name = "lblActividad";
            this.lblActividad.Size = new System.Drawing.Size(66, 34);
            this.lblActividad.TabIndex = 4;
            this.lblActividad.Text = "Actividad:";
            this.lblActividad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboActividad
            // 
            this.cboActividad.BackColor = System.Drawing.Color.White;
            this.cboActividad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboActividad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboActividad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.cboActividad.Location = new System.Drawing.Point(943, 8);
            this.cboActividad.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cboActividad.Name = "cboActividad";
            this.cboActividad.Size = new System.Drawing.Size(115, 25);
            this.cboActividad.TabIndex = 1;
            // 
            // flpExitoso
            // 
            this.flpExitoso.Controls.Add(this.chkExitoso);
            this.flpExitoso.Controls.Add(this.lblFiltrarUsuario);
            this.flpExitoso.Controls.Add(this.cboFiltrarUsuario);
            this.flpExitoso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpExitoso.Location = new System.Drawing.Point(83, 39);
            this.flpExitoso.Margin = new System.Windows.Forms.Padding(0);
            this.flpExitoso.Name = "flpExitoso";
            this.flpExitoso.Size = new System.Drawing.Size(296, 34);
            this.flpExitoso.TabIndex = 5;
            // 
            // chkExitoso
            // 
            this.chkExitoso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkExitoso.AutoSize = true;
            this.chkExitoso.BackColor = System.Drawing.Color.Transparent;
            this.chkExitoso.Checked = true;
            this.chkExitoso.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkExitoso.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkExitoso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.chkExitoso.Location = new System.Drawing.Point(3, 10);
            this.chkExitoso.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.chkExitoso.Name = "chkExitoso";
            this.chkExitoso.Size = new System.Drawing.Size(15, 14);
            this.chkExitoso.TabIndex = 0;
            this.chkExitoso.ThreeState = true;
            this.chkExitoso.UseVisualStyleBackColor = false;
            // 
            // flpFechas
            // 
            this.flpFechas.Controls.Add(this.lblDesde);
            this.flpFechas.Controls.Add(this.dtpDesde);
            this.flpFechas.Controls.Add(this.lblHasta);
            this.flpFechas.Controls.Add(this.dtpHasta);
            this.flpFechas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFechas.Location = new System.Drawing.Point(379, 39);
            this.flpFechas.Margin = new System.Windows.Forms.Padding(0);
            this.flpFechas.Name = "flpFechas";
            this.flpFechas.Size = new System.Drawing.Size(303, 34);
            this.flpFechas.TabIndex = 6;
            this.flpFechas.WrapContents = false;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.BackColor = System.Drawing.Color.Transparent;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblDesde.Location = new System.Drawing.Point(3, 5);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(48, 17);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(57, 3);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(93, 24);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.BackColor = System.Drawing.Color.Transparent;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblHasta.Location = new System.Drawing.Point(156, 5);
            this.lblHasta.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(44, 17);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(206, 3);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(89, 24);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblLimite
            // 
            this.lblLimite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLimite.BackColor = System.Drawing.Color.Transparent;
            this.lblLimite.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLimite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblLimite.Location = new System.Drawing.Point(682, 39);
            this.lblLimite.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.lblLimite.Name = "lblLimite";
            this.lblLimite.Size = new System.Drawing.Size(66, 34);
            this.lblLimite.TabIndex = 7;
            this.lblLimite.Text = "Límite:";
            this.lblLimite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLimite
            // 
            this.cboLimite.BackColor = System.Drawing.Color.White;
            this.cboLimite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLimite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLimite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLimite.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLimite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.cboLimite.Location = new System.Drawing.Point(755, 42);
            this.cboLimite.Margin = new System.Windows.Forms.Padding(0, 3, 9, 3);
            this.cboLimite.Name = "cboLimite";
            this.cboLimite.Size = new System.Drawing.Size(106, 25);
            this.cboLimite.TabIndex = 1;
            // 
            // flpBotones
            // 
            this.tlpFiltros.SetColumnSpan(this.flpBotones, 2);
            this.flpBotones.Controls.Add(this.btnBuscar);
            this.flpBotones.Controls.Add(this.btnLimpiar);
            this.flpBotones.Controls.Add(this.btnExportar);
            this.flpBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpBotones.Location = new System.Drawing.Point(870, 39);
            this.flpBotones.Margin = new System.Windows.Forms.Padding(0);
            this.flpBotones.Name = "flpBotones";
            this.flpBotones.Size = new System.Drawing.Size(188, 34);
            this.flpBotones.TabIndex = 8;
            this.flpBotones.WrapContents = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(58)))), ((int)(((byte)(160)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(125, 3);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(63, 26);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(249)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(182)))), ((int)(((byte)(228)))));
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnLimpiar.Location = new System.Drawing.Point(60, 3);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(61, 26);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(249)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(182)))), ((int)(((byte)(228)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnExportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnExportar.Location = new System.Drawing.Point(-10, 3);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(66, 26);
            this.btnExportar.TabIndex = 2;
            this.btnExportar.Text = "📥 CSV";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 34);
            this.label1.TabIndex = 9;
            this.label1.Text = "Exitoso:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitCuerpo
            // 
            this.splitCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCuerpo.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitCuerpo.Location = new System.Drawing.Point(0, 78);
            this.splitCuerpo.Name = "splitCuerpo";
            // 
            // splitCuerpo.Panel1
            // 
            this.splitCuerpo.Panel1.Controls.Add(this.dgvBitacora);
            // 
            // splitCuerpo.Panel2
            // 
            this.splitCuerpo.Panel2.Controls.Add(this.grpDetalle);
            this.splitCuerpo.Panel2.Padding = new System.Windows.Forms.Padding(7);
            this.splitCuerpo.Size = new System.Drawing.Size(1068, 570);
            this.splitCuerpo.SplitterDistance = 722;
            this.splitCuerpo.SplitterWidth = 3;
            this.splitCuerpo.TabIndex = 0;
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.AllowUserToAddRows = false;
            this.dgvBitacora.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            this.dgvBitacora.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBitacora.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.dgvBitacora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBitacora.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBitacora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBitacora.ColumnHeadersHeight = 38;
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBitacora.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBitacora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBitacora.EnableHeadersVisualStyles = false;
            this.dgvBitacora.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(215)))), ((int)(((byte)(240)))));
            this.dgvBitacora.Location = new System.Drawing.Point(0, 0);
            this.dgvBitacora.MultiSelect = false;
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.ReadOnly = true;
            this.dgvBitacora.RowHeadersVisible = false;
            this.dgvBitacora.RowTemplate.Height = 34;
            this.dgvBitacora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBitacora.Size = new System.Drawing.Size(722, 570);
            this.dgvBitacora.TabIndex = 0;
            this.dgvBitacora.SelectionChanged += new System.EventHandler(this.DgvBitacora_SelectionChanged);
            // 
            // grpDetalle
            // 
            this.grpDetalle.Controls.Add(this.tblDetalle);
            this.grpDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.grpDetalle.Location = new System.Drawing.Point(7, 7);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Padding = new System.Windows.Forms.Padding(7, 10, 7, 7);
            this.grpDetalle.Size = new System.Drawing.Size(329, 556);
            this.grpDetalle.TabIndex = 0;
            this.grpDetalle.TabStop = false;
            this.grpDetalle.Text = "Detalle del Registro";
            // 
            // tblDetalle
            // 
            this.tblDetalle.ColumnCount = 2;
            this.tblDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDetalle.Controls.Add(this.lblDetFecha, 0, 0);
            this.tblDetalle.Controls.Add(this.lblDetUsuario, 1, 0);
            this.tblDetalle.Controls.Add(this.txtDetFecha, 0, 1);
            this.tblDetalle.Controls.Add(this.txtDetUsuario, 1, 1);
            this.tblDetalle.Controls.Add(this.lblDetModulo, 0, 2);
            this.tblDetalle.Controls.Add(this.lblDetActividad, 1, 2);
            this.tblDetalle.Controls.Add(this.txtDetModulo, 0, 3);
            this.tblDetalle.Controls.Add(this.txtDetActividad, 1, 3);
            this.tblDetalle.Controls.Add(this.lblDetCriticidad, 0, 4);
            this.tblDetalle.Controls.Add(this.lblDetResultado, 1, 4);
            this.tblDetalle.Controls.Add(this.txtDetCriticidad, 0, 5);
            this.tblDetalle.Controls.Add(this.txtDetResultado, 1, 5);
            this.tblDetalle.Controls.Add(this.lblDetDetalle, 0, 6);
            this.tblDetalle.Controls.Add(this.txtDetDetalle, 0, 7);
            this.tblDetalle.Controls.Add(this.lblDetError, 0, 8);
            this.tblDetalle.Controls.Add(this.txtDetError, 0, 9);
            this.tblDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDetalle.Location = new System.Drawing.Point(7, 27);
            this.tblDetalle.Name = "tblDetalle";
            this.tblDetalle.RowCount = 10;
            this.tblDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tblDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tblDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tblDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tblDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tblDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tblDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tblDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tblDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tblDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tblDetalle.Size = new System.Drawing.Size(315, 522);
            this.tblDetalle.TabIndex = 0;
            // 
            // lblDetFecha
            // 
            this.lblDetFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDetFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblDetFecha.Location = new System.Drawing.Point(0, 2);
            this.lblDetFecha.Margin = new System.Windows.Forms.Padding(0, 2, 0, 1);
            this.lblDetFecha.Name = "lblDetFecha";
            this.lblDetFecha.Size = new System.Drawing.Size(157, 14);
            this.lblDetFecha.TabIndex = 0;
            this.lblDetFecha.Text = "Fecha y Hora";
            // 
            // lblDetUsuario
            // 
            this.lblDetUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetUsuario.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDetUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblDetUsuario.Location = new System.Drawing.Point(162, 2);
            this.lblDetUsuario.Margin = new System.Windows.Forms.Padding(5, 2, 0, 1);
            this.lblDetUsuario.Name = "lblDetUsuario";
            this.lblDetUsuario.Size = new System.Drawing.Size(153, 14);
            this.lblDetUsuario.TabIndex = 1;
            this.lblDetUsuario.Text = "Usuario";
            // 
            // txtDetFecha
            // 
            this.txtDetFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtDetFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtDetFecha.Location = new System.Drawing.Point(0, 17);
            this.txtDetFecha.Margin = new System.Windows.Forms.Padding(0, 0, 5, 3);
            this.txtDetFecha.Name = "txtDetFecha";
            this.txtDetFecha.ReadOnly = true;
            this.txtDetFecha.Size = new System.Drawing.Size(152, 23);
            this.txtDetFecha.TabIndex = 2;
            // 
            // txtDetUsuario
            // 
            this.txtDetUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtDetUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtDetUsuario.Location = new System.Drawing.Point(162, 17);
            this.txtDetUsuario.Margin = new System.Windows.Forms.Padding(5, 0, 0, 3);
            this.txtDetUsuario.Name = "txtDetUsuario";
            this.txtDetUsuario.ReadOnly = true;
            this.txtDetUsuario.Size = new System.Drawing.Size(153, 23);
            this.txtDetUsuario.TabIndex = 3;
            // 
            // lblDetModulo
            // 
            this.lblDetModulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetModulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDetModulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblDetModulo.Location = new System.Drawing.Point(0, 43);
            this.lblDetModulo.Margin = new System.Windows.Forms.Padding(0, 2, 0, 1);
            this.lblDetModulo.Name = "lblDetModulo";
            this.lblDetModulo.Size = new System.Drawing.Size(157, 14);
            this.lblDetModulo.TabIndex = 4;
            this.lblDetModulo.Text = "Módulo";
            // 
            // lblDetActividad
            // 
            this.lblDetActividad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetActividad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDetActividad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblDetActividad.Location = new System.Drawing.Point(162, 43);
            this.lblDetActividad.Margin = new System.Windows.Forms.Padding(5, 2, 0, 1);
            this.lblDetActividad.Name = "lblDetActividad";
            this.lblDetActividad.Size = new System.Drawing.Size(153, 14);
            this.lblDetActividad.TabIndex = 5;
            this.lblDetActividad.Text = "Actividad";
            // 
            // txtDetModulo
            // 
            this.txtDetModulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtDetModulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetModulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetModulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetModulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtDetModulo.Location = new System.Drawing.Point(0, 58);
            this.txtDetModulo.Margin = new System.Windows.Forms.Padding(0, 0, 5, 3);
            this.txtDetModulo.Name = "txtDetModulo";
            this.txtDetModulo.ReadOnly = true;
            this.txtDetModulo.Size = new System.Drawing.Size(152, 23);
            this.txtDetModulo.TabIndex = 6;
            // 
            // txtDetActividad
            // 
            this.txtDetActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtDetActividad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetActividad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetActividad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetActividad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtDetActividad.Location = new System.Drawing.Point(162, 58);
            this.txtDetActividad.Margin = new System.Windows.Forms.Padding(5, 0, 0, 3);
            this.txtDetActividad.Name = "txtDetActividad";
            this.txtDetActividad.ReadOnly = true;
            this.txtDetActividad.Size = new System.Drawing.Size(153, 23);
            this.txtDetActividad.TabIndex = 7;
            // 
            // lblDetCriticidad
            // 
            this.lblDetCriticidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetCriticidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDetCriticidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblDetCriticidad.Location = new System.Drawing.Point(0, 84);
            this.lblDetCriticidad.Margin = new System.Windows.Forms.Padding(0, 2, 0, 1);
            this.lblDetCriticidad.Name = "lblDetCriticidad";
            this.lblDetCriticidad.Size = new System.Drawing.Size(157, 14);
            this.lblDetCriticidad.TabIndex = 8;
            this.lblDetCriticidad.Text = "Criticidad";
            // 
            // lblDetResultado
            // 
            this.lblDetResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetResultado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDetResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblDetResultado.Location = new System.Drawing.Point(162, 84);
            this.lblDetResultado.Margin = new System.Windows.Forms.Padding(5, 2, 0, 1);
            this.lblDetResultado.Name = "lblDetResultado";
            this.lblDetResultado.Size = new System.Drawing.Size(153, 14);
            this.lblDetResultado.TabIndex = 9;
            this.lblDetResultado.Text = "Resultado";
            // 
            // txtDetCriticidad
            // 
            this.txtDetCriticidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtDetCriticidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetCriticidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetCriticidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetCriticidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtDetCriticidad.Location = new System.Drawing.Point(0, 99);
            this.txtDetCriticidad.Margin = new System.Windows.Forms.Padding(0, 0, 5, 3);
            this.txtDetCriticidad.Name = "txtDetCriticidad";
            this.txtDetCriticidad.ReadOnly = true;
            this.txtDetCriticidad.Size = new System.Drawing.Size(152, 23);
            this.txtDetCriticidad.TabIndex = 10;
            // 
            // txtDetResultado
            // 
            this.txtDetResultado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtDetResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetResultado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtDetResultado.Location = new System.Drawing.Point(162, 99);
            this.txtDetResultado.Margin = new System.Windows.Forms.Padding(5, 0, 0, 3);
            this.txtDetResultado.Name = "txtDetResultado";
            this.txtDetResultado.ReadOnly = true;
            this.txtDetResultado.Size = new System.Drawing.Size(153, 23);
            this.txtDetResultado.TabIndex = 11;
            // 
            // lblDetDetalle
            // 
            this.tblDetalle.SetColumnSpan(this.lblDetDetalle, 2);
            this.lblDetDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetDetalle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDetDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblDetDetalle.Location = new System.Drawing.Point(0, 126);
            this.lblDetDetalle.Margin = new System.Windows.Forms.Padding(0, 3, 0, 1);
            this.lblDetDetalle.Name = "lblDetDetalle";
            this.lblDetDetalle.Size = new System.Drawing.Size(315, 13);
            this.lblDetDetalle.TabIndex = 12;
            this.lblDetDetalle.Text = "Detalle";
            // 
            // txtDetDetalle
            // 
            this.txtDetDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtDetDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblDetalle.SetColumnSpan(this.txtDetDetalle, 2);
            this.txtDetDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtDetDetalle.Location = new System.Drawing.Point(3, 143);
            this.txtDetDetalle.Multiline = true;
            this.txtDetDetalle.Name = "txtDetDetalle";
            this.txtDetDetalle.ReadOnly = true;
            this.txtDetDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetDetalle.Size = new System.Drawing.Size(309, 158);
            this.txtDetDetalle.TabIndex = 13;
            // 
            // lblDetError
            // 
            this.tblDetalle.SetColumnSpan(this.lblDetError, 2);
            this.lblDetError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetError.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDetError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblDetError.Location = new System.Drawing.Point(0, 307);
            this.lblDetError.Margin = new System.Windows.Forms.Padding(0, 3, 0, 1);
            this.lblDetError.Name = "lblDetError";
            this.lblDetError.Size = new System.Drawing.Size(315, 13);
            this.lblDetError.TabIndex = 14;
            this.lblDetError.Text = "Detalle del Error";
            // 
            // txtDetError
            // 
            this.txtDetError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtDetError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblDetalle.SetColumnSpan(this.txtDetError, 2);
            this.txtDetError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtDetError.Location = new System.Drawing.Point(3, 324);
            this.txtDetError.Multiline = true;
            this.txtDetError.Name = "txtDetError";
            this.txtDetError.ReadOnly = true;
            this.txtDetError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetError.Size = new System.Drawing.Size(309, 195);
            this.txtDetError.TabIndex = 15;
            // 
            // pnlEstado
            // 
            this.pnlEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(249)))));
            this.pnlEstado.Controls.Add(this.lblContador);
            this.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEstado.Location = new System.Drawing.Point(0, 648);
            this.pnlEstado.Name = "pnlEstado";
            this.pnlEstado.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pnlEstado.Size = new System.Drawing.Size(1068, 21);
            this.pnlEstado.TabIndex = 1;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.BackColor = System.Drawing.Color.Transparent;
            this.lblContador.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblContador.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblContador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblContador.Location = new System.Drawing.Point(10, 3);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(140, 17);
            this.lblContador.TabIndex = 0;
            this.lblContador.Text = "Mostrando 0 registros";
            // 
            // BitacoraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1068, 669);
            this.Controls.Add(this.splitCuerpo);
            this.Controls.Add(this.pnlEstado);
            this.Controls.Add(this.pnlFiltros);
            this.MinimumSize = new System.Drawing.Size(1084, 708);
            this.Name = "BitacoraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitácora";
            this.Load += new System.EventHandler(this.BitacoraForm_Load);
            this.Shown += new System.EventHandler(this.BitacoraForm_Shown);
            this.pnlFiltros.ResumeLayout(false);
            this.tlpFiltros.ResumeLayout(false);
            this.tlpFiltros.PerformLayout();
            this.flpCheckboxes.ResumeLayout(false);
            this.flpCheckboxes.PerformLayout();
            this.flpExitoso.ResumeLayout(false);
            this.flpExitoso.PerformLayout();
            this.flpFechas.ResumeLayout(false);
            this.flpFechas.PerformLayout();
            this.flpBotones.ResumeLayout(false);
            this.splitCuerpo.Panel1.ResumeLayout(false);
            this.splitCuerpo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCuerpo)).EndInit();
            this.splitCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.grpDetalle.ResumeLayout(false);
            this.tblDetalle.ResumeLayout(false);
            this.tblDetalle.PerformLayout();
            this.pnlEstado.ResumeLayout(false);
            this.pnlEstado.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.TableLayoutPanel tlpFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.FlowLayoutPanel flpCheckboxes;
        private System.Windows.Forms.CheckBox chkUsername;
        private System.Windows.Forms.CheckBox chkDetalle;
        private System.Windows.Forms.CheckBox chkError;
        private System.Windows.Forms.Label lblCriticidad;
        private System.Windows.Forms.ComboBox cboCriticidad;
        private System.Windows.Forms.Label lblActividad;
        private System.Windows.Forms.ComboBox cboActividad;
        private System.Windows.Forms.FlowLayoutPanel flpExitoso;
        private System.Windows.Forms.CheckBox chkExitoso;
        private System.Windows.Forms.FlowLayoutPanel flpFechas;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblLimite;
        private System.Windows.Forms.ComboBox cboLimite;
        private System.Windows.Forms.FlowLayoutPanel flpBotones;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.SplitContainer splitCuerpo;
        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.TableLayoutPanel tblDetalle;
        private System.Windows.Forms.Label lblDetFecha;
        private System.Windows.Forms.TextBox txtDetFecha;
        private System.Windows.Forms.Label lblDetUsuario;
        private System.Windows.Forms.TextBox txtDetUsuario;
        private System.Windows.Forms.Label lblDetModulo;
        private System.Windows.Forms.TextBox txtDetModulo;
        private System.Windows.Forms.Label lblDetActividad;
        private System.Windows.Forms.TextBox txtDetActividad;
        private System.Windows.Forms.Label lblDetCriticidad;
        private System.Windows.Forms.TextBox txtDetCriticidad;
        private System.Windows.Forms.Label lblDetResultado;
        private System.Windows.Forms.TextBox txtDetResultado;
        private System.Windows.Forms.Label lblDetDetalle;
        private System.Windows.Forms.TextBox txtDetDetalle;
        private System.Windows.Forms.Label lblDetError;
        private System.Windows.Forms.TextBox txtDetError;
        private System.Windows.Forms.Panel pnlEstado;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFiltrarUsuario;
        private System.Windows.Forms.ComboBox cboFiltrarUsuario;
    }
}
