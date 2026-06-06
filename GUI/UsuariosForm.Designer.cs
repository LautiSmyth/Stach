namespace GUI
{
    partial class UsuariosForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitPrincipal = new System.Windows.Forms.SplitContainer();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.tblEncabezado = new System.Windows.Forms.TableLayoutPanel();
            this.lblTituloGrilla = new System.Windows.Forms.Label();
            this.lblBuscarUsuario = new System.Windows.Forms.Label();
            this.txtBuscarUsuario = new System.Windows.Forms.TextBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.grpGestion = new System.Windows.Forms.GroupBox();
            this.tblGestion = new System.Windows.Forms.TableLayoutPanel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmarPassword = new System.Windows.Forms.Label();
            this.txtConfirmarPassword = new System.Windows.Forms.TextBox();
            this.lblRequisitos = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.tblBotones = new System.Windows.Forms.TableLayoutPanel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).BeginInit();
            this.splitPrincipal.Panel1.SuspendLayout();
            this.splitPrincipal.Panel2.SuspendLayout();
            this.splitPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.pnlEncabezado.SuspendLayout();
            this.tblEncabezado.SuspendLayout();
            this.grpGestion.SuspendLayout();
            this.tblGestion.SuspendLayout();
            this.tblBotones.SuspendLayout();
            this.SuspendLayout();
            
            
            
            this.splitPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPrincipal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitPrincipal.Location = new System.Drawing.Point(0, 0);
            this.splitPrincipal.Name = "splitPrincipal";
            
            
            
            this.splitPrincipal.Panel1.Controls.Add(this.dgvUsuarios);
            this.splitPrincipal.Panel1.Controls.Add(this.pnlEncabezado);
            
            
            
            this.splitPrincipal.Panel2.Controls.Add(this.grpGestion);
            this.splitPrincipal.Panel2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitPrincipal.Size = new System.Drawing.Size(814, 433);
            this.splitPrincipal.SplitterDistance = 475;
            this.splitPrincipal.SplitterWidth = 3;
            this.splitPrincipal.TabIndex = 0;
            
            
            
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            this.dgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUsuarios.ColumnHeadersHeight = 38;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(215)))), ((int)(((byte)(240)))));
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 37);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.RowTemplate.Height = 34;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(475, 396);
            this.dgvUsuarios.TabIndex = 1;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUsuarios_CellClick);
            this.dgvUsuarios.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvUsuarios_CellMouseDown);
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.DgvUsuarios_SelectionChanged);
            
            
            
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlEncabezado.Controls.Add(this.tblEncabezado);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(475, 37);
            this.pnlEncabezado.TabIndex = 0;
            
            
            
            this.tblEncabezado.ColumnCount = 4;
            this.tblEncabezado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblEncabezado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblEncabezado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEncabezado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblEncabezado.Controls.Add(this.lblTituloGrilla, 0, 0);
            this.tblEncabezado.Controls.Add(this.lblBuscarUsuario, 1, 0);
            this.tblEncabezado.Controls.Add(this.txtBuscarUsuario, 2, 0);
            this.tblEncabezado.Controls.Add(this.btnRefrescar, 3, 0);
            this.tblEncabezado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEncabezado.Location = new System.Drawing.Point(0, 0);
            this.tblEncabezado.Name = "tblEncabezado";
            this.tblEncabezado.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.tblEncabezado.RowCount = 1;
            this.tblEncabezado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEncabezado.Size = new System.Drawing.Size(475, 37);
            this.tblEncabezado.TabIndex = 0;
            
            
            
            this.lblTituloGrilla.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloGrilla.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloGrilla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.lblTituloGrilla.Location = new System.Drawing.Point(9, 0);
            this.lblTituloGrilla.Name = "lblTituloGrilla";
            this.lblTituloGrilla.Size = new System.Drawing.Size(90, 37);
            this.lblTituloGrilla.TabIndex = 0;
            this.lblTituloGrilla.Text = "Usuarios";
            this.lblTituloGrilla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            
            
            this.lblBuscarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscarUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBuscarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblBuscarUsuario.Location = new System.Drawing.Point(105, 0);
            this.lblBuscarUsuario.Name = "lblBuscarUsuario";
            this.lblBuscarUsuario.Size = new System.Drawing.Size(75, 37);
            this.lblBuscarUsuario.TabIndex = 1;
            this.lblBuscarUsuario.Text = "🔍 Buscar:";
            this.lblBuscarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            
            
            this.txtBuscarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarUsuario.BackColor = System.Drawing.Color.White;
            this.txtBuscarUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtBuscarUsuario.Location = new System.Drawing.Point(186, 6);
            this.txtBuscarUsuario.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.txtBuscarUsuario.Name = "txtBuscarUsuario";
            this.txtBuscarUsuario.Size = new System.Drawing.Size(184, 24);
            this.txtBuscarUsuario.TabIndex = 0;
            this.txtBuscarUsuario.TextChanged += new System.EventHandler(this.TxtBuscarUsuario_TextChanged);
            
            
            
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(249)))));
            this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefrescar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(182)))), ((int)(((byte)(228)))));
            this.btnRefrescar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnRefrescar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnRefrescar.Location = new System.Drawing.Point(381, 4);
            this.btnRefrescar.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(88, 29);
            this.btnRefrescar.TabIndex = 1;
            this.btnRefrescar.Text = "↻ Actualizar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.BtnRefrescar_Click);
            
            
            
            this.grpGestion.BackColor = System.Drawing.Color.Transparent;
            this.grpGestion.Controls.Add(this.tblGestion);
            this.grpGestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGestion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpGestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.grpGestion.Location = new System.Drawing.Point(6, 6);
            this.grpGestion.Name = "grpGestion";
            this.grpGestion.Padding = new System.Windows.Forms.Padding(9, 14, 9, 9);
            this.grpGestion.Size = new System.Drawing.Size(324, 421);
            this.grpGestion.TabIndex = 0;
            this.grpGestion.TabStop = false;
            this.grpGestion.Text = "Gestión de Usuario";
            
            
            
            this.tblGestion.ColumnCount = 1;
            this.tblGestion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblGestion.Controls.Add(this.lblUsername, 0, 0);
            this.tblGestion.Controls.Add(this.txtUsername, 0, 1);
            this.tblGestion.Controls.Add(this.lblPassword, 0, 2);
            this.tblGestion.Controls.Add(this.txtPassword, 0, 3);
            this.tblGestion.Controls.Add(this.lblConfirmarPassword, 0, 4);
            this.tblGestion.Controls.Add(this.txtConfirmarPassword, 0, 5);
            this.tblGestion.Controls.Add(this.lblRequisitos, 0, 6);
            this.tblGestion.Controls.Add(this.lblEstado, 0, 7);
            this.tblGestion.Controls.Add(this.cboEstado, 0, 8);
            this.tblGestion.Controls.Add(this.tblBotones, 0, 9);
            this.tblGestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGestion.Location = new System.Drawing.Point(9, 31);
            this.tblGestion.Name = "tblGestion";
            this.tblGestion.RowCount = 11;
            this.tblGestion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGestion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGestion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGestion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGestion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGestion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGestion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGestion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGestion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGestion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGestion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblGestion.Size = new System.Drawing.Size(306, 381);
            this.tblGestion.TabIndex = 0;
            
            
            
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblUsername.Location = new System.Drawing.Point(0, 3);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(127, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Nombre de usuario";
            
            
            
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtUsername.Location = new System.Drawing.Point(3, 25);
            this.txtUsername.MaxLength = 100;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(300, 24);
            this.txtUsername.TabIndex = 0;
            
            
            
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblPassword.Location = new System.Drawing.Point(0, 55);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(77, 17);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Contraseña";
            
            
            
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtPassword.Location = new System.Drawing.Point(3, 77);
            this.txtPassword.MaxLength = 200;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(300, 24);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            
            
            
            this.lblConfirmarPassword.AutoSize = true;
            this.lblConfirmarPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblConfirmarPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblConfirmarPassword.Location = new System.Drawing.Point(0, 107);
            this.lblConfirmarPassword.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new System.Drawing.Size(141, 17);
            this.lblConfirmarPassword.TabIndex = 2;
            this.lblConfirmarPassword.Text = "Confirmar contraseña";
            
            
            
            this.txtConfirmarPassword.BackColor = System.Drawing.Color.White;
            this.txtConfirmarPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmarPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmarPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtConfirmarPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtConfirmarPassword.Location = new System.Drawing.Point(3, 129);
            this.txtConfirmarPassword.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txtConfirmarPassword.MaxLength = 200;
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.Size = new System.Drawing.Size(300, 24);
            this.txtConfirmarPassword.TabIndex = 2;
            this.txtConfirmarPassword.UseSystemPasswordChar = true;
            
            
            
            this.lblRequisitos.AutoSize = true;
            this.lblRequisitos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRequisitos.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRequisitos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.lblRequisitos.Location = new System.Drawing.Point(0, 159);
            this.lblRequisitos.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblRequisitos.Name = "lblRequisitos";
            this.lblRequisitos.Size = new System.Drawing.Size(306, 39);
            this.lblRequisitos.TabIndex = 3;
            this.lblRequisitos.Text = "Para modificar, deje vacío para mantener la contraseña.\nDebe tener al menos 6 car" +
    "acteres, 1 mayúscula y 1 número.";
            
            
            
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblEstado.Location = new System.Drawing.Point(0, 207);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(49, 17);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado";
            
            
            
            this.cboEstado.BackColor = System.Drawing.Color.White;
            this.cboEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.cboEstado.Location = new System.Drawing.Point(3, 229);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(300, 25);
            this.cboEstado.TabIndex = 3;
            
            
            
            this.tblBotones.ColumnCount = 2;
            this.tblBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBotones.Controls.Add(this.btnGuardar, 0, 0);
            this.tblBotones.Controls.Add(this.btnLimpiar, 1, 0);
            this.tblBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBotones.Location = new System.Drawing.Point(3, 269);
            this.tblBotones.Name = "tblBotones";
            this.tblBotones.RowCount = 1;
            this.tblBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBotones.Size = new System.Drawing.Size(300, 29);
            this.tblBotones.TabIndex = 5;
            
            
            
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(58)))), ((int)(((byte)(160)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(0, 0);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(146, 29);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Crear usuario";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            
            
            
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(249)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(182)))), ((int)(((byte)(228)))));
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnLimpiar.Location = new System.Drawing.Point(154, 0);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(146, 29);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);

            
            
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnLimpiar;
            this.ClientSize = new System.Drawing.Size(814, 433);
            this.Controls.Add(this.splitPrincipal);
            this.MinimumSize = new System.Drawing.Size(830, 472);
            this.Name = "UsuariosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de usuarios";
            this.Load += new System.EventHandler(this.UsuariosForm_Load);
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUsername_KeyPress);
            this.Shown += new System.EventHandler(this.UsuariosForm_Shown);
            this.splitPrincipal.Panel1.ResumeLayout(false);
            this.splitPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).EndInit();
            this.splitPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.pnlEncabezado.ResumeLayout(false);
            this.tblEncabezado.ResumeLayout(false);
            this.tblEncabezado.PerformLayout();
            this.grpGestion.ResumeLayout(false);
            this.tblGestion.ResumeLayout(false);
            this.tblGestion.PerformLayout();
            this.tblBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer splitPrincipal;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.TableLayoutPanel tblEncabezado;
        private System.Windows.Forms.Label lblTituloGrilla;
        private System.Windows.Forms.Label lblBuscarUsuario;
        private System.Windows.Forms.TextBox txtBuscarUsuario;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.GroupBox grpGestion;
        private System.Windows.Forms.TableLayoutPanel tblGestion;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmarPassword;
        private System.Windows.Forms.TextBox txtConfirmarPassword;
        private System.Windows.Forms.Label lblRequisitos;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.TableLayoutPanel tblBotones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}
