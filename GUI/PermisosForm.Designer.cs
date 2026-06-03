namespace GUI
{
    partial class PermisosForm
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

        private void InitializeComponent()
        {
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCol1 = new System.Windows.Forms.Panel();
            this.btnEliminarPermiso = new System.Windows.Forms.Button();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.btnCrearPermiso = new System.Windows.Forms.Button();
            this.txtNombrePermiso = new System.Windows.Forms.TextBox();
            this.lblNombrePermiso = new System.Windows.Forms.Label();
            this.tvEstructura = new System.Windows.Forms.TreeView();
            this.lblCol1Titulo = new System.Windows.Forms.Label();
            this.pnlCol2 = new System.Windows.Forms.Panel();
            this.btnGuardarRelaciones = new System.Windows.Forms.Button();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.cboFormularios = new System.Windows.Forms.ComboBox();
            this.btnGuardarControles = new System.Windows.Forms.Button();
            this.tblCol2Transfer = new System.Windows.Forms.TableLayoutPanel();
            this.lstDisponibles = new System.Windows.Forms.ListBox();
            this.pnlCol2Buttons = new System.Windows.Forms.Panel();
            this.btnQuitarRelacion = new System.Windows.Forms.Button();
            this.btnAgregarRelacion = new System.Windows.Forms.Button();
            this.lstMiembros = new System.Windows.Forms.ListBox();
            this.lblMiembros = new System.Windows.Forms.Label();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.lblCol2Titulo = new System.Windows.Forms.Label();
            this.pnlCol3 = new System.Windows.Forms.Panel();
            this.btnQuitarUsuario = new System.Windows.Forms.Button();
            this.lstPermisosPlanas = new System.Windows.Forms.ListBox();
            this.lblPermisosPlanas = new System.Windows.Forms.Label();
            this.btnAsignarUsuario = new System.Windows.Forms.Button();
            this.tvUsuarioPermisos = new System.Windows.Forms.TreeView();
            this.lblUserPerms = new System.Windows.Forms.Label();
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            this.lblCol3Titulo = new System.Windows.Forms.Label();
            this.tblMain.SuspendLayout();
            this.pnlCol1.SuspendLayout();
            this.pnlCol2.SuspendLayout();
            this.tblCol2Transfer.SuspendLayout();
            this.pnlCol2Buttons.SuspendLayout();
            this.pnlCol3.SuspendLayout();
            this.SuspendLayout();

            this.tblMain.ColumnCount = 3;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblMain.Controls.Add(this.pnlCol1, 0, 0);
            this.tblMain.Controls.Add(this.pnlCol2, 1, 0);
            this.tblMain.Controls.Add(this.pnlCol3, 2, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 1;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(1200, 600);
            this.tblMain.TabIndex = 0;

            this.pnlCol1.BackColor = System.Drawing.Color.FromArgb(248, 244, 255);
            this.pnlCol1.Controls.Add(this.btnEliminarPermiso);
            this.pnlCol1.Controls.Add(this.btnCrearRol);
            this.pnlCol1.Controls.Add(this.btnCrearPermiso);
            this.pnlCol1.Controls.Add(this.txtNombrePermiso);
            this.pnlCol1.Controls.Add(this.lblNombrePermiso);
            this.pnlCol1.Controls.Add(this.tvEstructura);
            this.pnlCol1.Controls.Add(this.lblCol1Titulo);
            this.pnlCol1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol1.Location = new System.Drawing.Point(3, 3);
            this.pnlCol1.Name = "pnlCol1";
            this.pnlCol1.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCol1.Size = new System.Drawing.Size(390, 594);
            this.pnlCol1.TabIndex = 0;

            this.btnEliminarPermiso.BackColor = System.Drawing.Color.FromArgb(229, 115, 115);
            this.btnEliminarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarPermiso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarPermiso.ForeColor = System.Drawing.Color.White;
            this.btnEliminarPermiso.Location = new System.Drawing.Point(18, 545);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(354, 28);
            this.btnEliminarPermiso.TabIndex = 5;
            this.btnEliminarPermiso.Text = "Eliminar Seleccionado";
            this.btnEliminarPermiso.UseVisualStyleBackColor = false;

            this.btnCrearRol.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnCrearRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCrearRol.ForeColor = System.Drawing.Color.White;
            this.btnCrearRol.Location = new System.Drawing.Point(198, 505);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(174, 28);
            this.btnCrearRol.TabIndex = 4;
            this.btnCrearRol.Text = "Nueva Rol";
            this.btnCrearRol.UseVisualStyleBackColor = false;

            this.btnCrearPermiso.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnCrearPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearPermiso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCrearPermiso.ForeColor = System.Drawing.Color.White;
            this.btnCrearPermiso.Location = new System.Drawing.Point(18, 505);
            this.btnCrearPermiso.Name = "btnCrearPermiso";
            this.btnCrearPermiso.Size = new System.Drawing.Size(174, 28);
            this.btnCrearPermiso.TabIndex = 3;
            this.btnCrearPermiso.Text = "Nueva Permiso";
            this.btnCrearPermiso.UseVisualStyleBackColor = false;

            this.txtNombrePermiso.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombrePermiso.Location = new System.Drawing.Point(18, 465);
            this.txtNombrePermiso.Name = "txtNombrePermiso";
            this.txtNombrePermiso.Size = new System.Drawing.Size(354, 24);
            this.txtNombrePermiso.TabIndex = 1;

            this.lblNombrePermiso.AutoSize = true;
            this.lblNombrePermiso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombrePermiso.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblNombrePermiso.Location = new System.Drawing.Point(18, 445);
            this.lblNombrePermiso.Name = "lblNombrePermiso";
            this.lblNombrePermiso.Size = new System.Drawing.Size(53, 15);
            this.lblNombrePermiso.TabIndex = 2;
            this.lblNombrePermiso.Text = "Nombre";

            this.tvEstructura.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tvEstructura.Location = new System.Drawing.Point(18, 45);
            this.tvEstructura.Name = "tvEstructura";
            this.tvEstructura.Size = new System.Drawing.Size(354, 390);
            this.tvEstructura.TabIndex = 0;

            this.lblCol1Titulo.AutoSize = true;
            this.lblCol1Titulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCol1Titulo.ForeColor = System.Drawing.Color.FromArgb(94, 58, 160);
            this.lblCol1Titulo.Location = new System.Drawing.Point(15, 15);
            this.lblCol1Titulo.Name = "lblCol1Titulo";
            this.lblCol1Titulo.Size = new System.Drawing.Size(206, 21);
            this.lblCol1Titulo.TabIndex = 0;
            this.lblCol1Titulo.Text = "Estructura de Permisos";

            this.pnlCol2.BackColor = System.Drawing.Color.White;
            this.pnlCol2.Controls.Add(this.btnGuardarRelaciones);
            this.pnlCol2.Controls.Add(this.tblCol2Transfer);
            this.pnlCol2.Controls.Add(this.lblMiembros);
            this.pnlCol2.Controls.Add(this.lblDisponibles);
            this.pnlCol2.Controls.Add(this.lblCol2Titulo);
            this.pnlCol2.Controls.Add(this.lblFormulario);
            this.pnlCol2.Controls.Add(this.cboFormularios);
            this.pnlCol2.Controls.Add(this.btnGuardarControles);
            this.pnlCol2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol2.Location = new System.Drawing.Point(399, 3);
            this.pnlCol2.Name = "pnlCol2";
            this.pnlCol2.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCol2.Size = new System.Drawing.Size(402, 594);
            this.pnlCol2.TabIndex = 1;

            this.btnGuardarRelaciones.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnGuardarRelaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarRelaciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarRelaciones.ForeColor = System.Drawing.Color.White;
            this.btnGuardarRelaciones.Location = new System.Drawing.Point(18, 545);
            this.btnGuardarRelaciones.Name = "btnGuardarRelaciones";
            this.btnGuardarRelaciones.Size = new System.Drawing.Size(366, 30);
            this.btnGuardarRelaciones.TabIndex = 5;
            this.btnGuardarRelaciones.Text = "Guardar Relaciones del Rol";
            this.btnGuardarRelaciones.UseVisualStyleBackColor = false;

            this.tblCol2Transfer.ColumnCount = 3;
            this.tblCol2Transfer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tblCol2Transfer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tblCol2Transfer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tblCol2Transfer.Controls.Add(this.lstDisponibles, 0, 0);
            this.tblCol2Transfer.Controls.Add(this.pnlCol2Buttons, 1, 0);
            this.tblCol2Transfer.Controls.Add(this.lstMiembros, 2, 0);
            this.tblCol2Transfer.Location = new System.Drawing.Point(18, 110);
            this.tblCol2Transfer.Name = "tblCol2Transfer";
            this.tblCol2Transfer.RowCount = 1;
            this.tblCol2Transfer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCol2Transfer.Size = new System.Drawing.Size(366, 420);
            this.tblCol2Transfer.TabIndex = 4;

            this.lstDisponibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDisponibles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstDisponibles.FormattingEnabled = true;
            this.lstDisponibles.ItemHeight = 15;
            this.lstDisponibles.Location = new System.Drawing.Point(3, 3);
            this.lstDisponibles.Name = "lstDisponibles";
            this.lstDisponibles.Size = new System.Drawing.Size(151, 414);
            this.lstDisponibles.TabIndex = 0;

            this.pnlCol2Buttons.Controls.Add(this.btnQuitarRelacion);
            this.pnlCol2Buttons.Controls.Add(this.btnAgregarRelacion);
            this.pnlCol2Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol2Buttons.Location = new System.Drawing.Point(160, 3);
            this.pnlCol2Buttons.Name = "pnlCol2Buttons";
            this.pnlCol2Buttons.Size = new System.Drawing.Size(45, 414);
            this.pnlCol2Buttons.TabIndex = 1;

            this.btnQuitarRelacion.Location = new System.Drawing.Point(2, 215);
            this.btnQuitarRelacion.Name = "btnQuitarRelacion";
            this.btnQuitarRelacion.Size = new System.Drawing.Size(41, 30);
            this.btnQuitarRelacion.TabIndex = 1;
            this.btnQuitarRelacion.Text = "<<";
            this.btnQuitarRelacion.UseVisualStyleBackColor = true;

            this.btnAgregarRelacion.Location = new System.Drawing.Point(2, 175);
            this.btnAgregarRelacion.Name = "btnAgregarRelacion";
            this.btnAgregarRelacion.Size = new System.Drawing.Size(41, 30);
            this.btnAgregarRelacion.TabIndex = 0;
            this.btnAgregarRelacion.Text = ">>";
            this.btnAgregarRelacion.UseVisualStyleBackColor = true;

            this.lstMiembros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMiembros.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstMiembros.FormattingEnabled = true;
            this.lstMiembros.ItemHeight = 15;
            this.lstMiembros.Location = new System.Drawing.Point(211, 3);
            this.lstMiembros.Name = "lstMiembros";
            this.lstMiembros.Size = new System.Drawing.Size(152, 414);
            this.lstMiembros.TabIndex = 2;

            this.lblMiembros.AutoSize = true;
            this.lblMiembros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMiembros.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblMiembros.Location = new System.Drawing.Point(226, 90);
            this.lblMiembros.Name = "lblMiembros";
            this.lblMiembros.Size = new System.Drawing.Size(102, 15);
            this.lblMiembros.TabIndex = 3;
            this.lblMiembros.Text = "Miembros del Rol";

            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDisponibles.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblDisponibles.Location = new System.Drawing.Point(18, 90);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(130, 15);
            this.lblDisponibles.TabIndex = 2;
            this.lblDisponibles.Text = "Permisos Disponibles";

            this.lblCol2Titulo.AutoSize = true;
            this.lblCol2Titulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCol2Titulo.ForeColor = System.Drawing.Color.FromArgb(94, 58, 160);
            this.lblCol2Titulo.Location = new System.Drawing.Point(15, 15);
            this.lblCol2Titulo.Name = "lblCol2Titulo";
            this.lblCol2Titulo.Size = new System.Drawing.Size(224, 21);
            this.lblCol2Titulo.TabIndex = 0;
            this.lblCol2Titulo.Text = "Configurador de Relaciones";

            this.lblFormulario.AutoSize = true;
            this.lblFormulario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFormulario.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblFormulario.Location = new System.Drawing.Point(18, 55);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(70, 15);
            this.lblFormulario.TabIndex = 7;
            this.lblFormulario.Text = "Formulario:";

            this.cboFormularios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormularios.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFormularios.FormattingEnabled = true;
            this.cboFormularios.Location = new System.Drawing.Point(100, 52);
            this.cboFormularios.Name = "cboFormularios";
            this.cboFormularios.Size = new System.Drawing.Size(284, 23);
            this.cboFormularios.TabIndex = 8;

            this.btnGuardarControles.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnGuardarControles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarControles.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarControles.ForeColor = System.Drawing.Color.White;
            this.btnGuardarControles.Location = new System.Drawing.Point(18, 545);
            this.btnGuardarControles.Name = "btnGuardarControles";
            this.btnGuardarControles.Size = new System.Drawing.Size(366, 30);
            this.btnGuardarControles.TabIndex = 12;
            this.btnGuardarControles.Text = "Guardar Controles";
            this.btnGuardarControles.UseVisualStyleBackColor = false;

            this.pnlCol3.BackColor = System.Drawing.Color.FromArgb(248, 244, 255);
            this.pnlCol3.Controls.Add(this.btnQuitarUsuario);
            this.pnlCol3.Controls.Add(this.lstPermisosPlanas);
            this.pnlCol3.Controls.Add(this.lblPermisosPlanas);
            this.pnlCol3.Controls.Add(this.btnAsignarUsuario);
            this.pnlCol3.Controls.Add(this.tvUsuarioPermisos);
            this.pnlCol3.Controls.Add(this.lblUserPerms);
            this.pnlCol3.Controls.Add(this.cboUsuarios);
            this.pnlCol3.Controls.Add(this.lblCol3Titulo);
            this.pnlCol3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol3.Location = new System.Drawing.Point(807, 3);
            this.pnlCol3.Name = "pnlCol3";
            this.pnlCol3.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCol3.Size = new System.Drawing.Size(390, 594);
            this.pnlCol3.TabIndex = 2;

            this.btnQuitarUsuario.BackColor = System.Drawing.Color.FromArgb(229, 115, 115);
            this.btnQuitarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuitarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnQuitarUsuario.Location = new System.Drawing.Point(198, 385);
            this.btnQuitarUsuario.Name = "btnQuitarUsuario";
            this.btnQuitarUsuario.Size = new System.Drawing.Size(174, 28);
            this.btnQuitarUsuario.TabIndex = 3;
            this.btnQuitarUsuario.Text = "<< Quitar de Usuario";
            this.btnQuitarUsuario.UseVisualStyleBackColor = false;

            this.lstPermisosPlanas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstPermisosPlanas.FormattingEnabled = true;
            this.lstPermisosPlanas.ItemHeight = 15;
            this.lstPermisosPlanas.Location = new System.Drawing.Point(18, 445);
            this.lstPermisosPlanas.Name = "lstPermisosPlanas";
            this.lstPermisosPlanas.Size = new System.Drawing.Size(354, 124);
            this.lstPermisosPlanas.TabIndex = 4;
            this.lstPermisosPlanas.TabStop = false;

            this.lblPermisosPlanas.AutoSize = true;
            this.lblPermisosPlanas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPermisosPlanas.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblPermisosPlanas.Location = new System.Drawing.Point(18, 425);
            this.lblPermisosPlanas.Name = "lblPermisosPlanas";
            this.lblPermisosPlanas.Size = new System.Drawing.Size(117, 15);
            this.lblPermisosPlanas.TabIndex = 5;
            this.lblPermisosPlanas.Text = "Permisos Resultantes";

            this.btnAsignarUsuario.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnAsignarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsignarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnAsignarUsuario.Location = new System.Drawing.Point(18, 385);
            this.btnAsignarUsuario.Name = "btnAsignarUsuario";
            this.btnAsignarUsuario.Size = new System.Drawing.Size(174, 28);
            this.btnAsignarUsuario.TabIndex = 2;
            this.btnAsignarUsuario.Text = "Asignar a Usuario >>";
            this.btnAsignarUsuario.UseVisualStyleBackColor = false;

            this.tvUsuarioPermisos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tvUsuarioPermisos.Location = new System.Drawing.Point(18, 120);
            this.tvUsuarioPermisos.Name = "tvUsuarioPermisos";
            this.tvUsuarioPermisos.Size = new System.Drawing.Size(354, 255);
            this.tvUsuarioPermisos.TabIndex = 1;

            this.lblUserPerms.AutoSize = true;
            this.lblUserPerms.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserPerms.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblUserPerms.Location = new System.Drawing.Point(18, 100);
            this.lblUserPerms.Name = "lblUserPerms";
            this.lblUserPerms.Size = new System.Drawing.Size(126, 15);
            this.lblUserPerms.TabIndex = 2;
            this.lblUserPerms.Text = "Permisos del Usuario";

            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(18, 65);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(354, 25);
            this.cboUsuarios.TabIndex = 0;

            this.lblCol3Titulo.AutoSize = true;
            this.lblCol3Titulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCol3Titulo.ForeColor = System.Drawing.Color.FromArgb(94, 58, 160);
            this.lblCol3Titulo.Location = new System.Drawing.Point(15, 15);
            this.lblCol3Titulo.Name = "lblCol3Titulo";
            this.lblCol3Titulo.Size = new System.Drawing.Size(161, 21);
            this.lblCol3Titulo.TabIndex = 0;
            this.lblCol3Titulo.Text = "Gestión de Usuarios";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.tblMain);
            this.Name = "PermisosForm";
            this.Text = "Gestión de Perfiles y Permisos";
            this.Load += new System.EventHandler(this.PermisosForm_Load);
            this.tvEstructura.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvEstructura_AfterSelect);
            this.btnCrearPermiso.Click += new System.EventHandler(this.BtnCrearPermiso_Click);
            this.btnCrearRol.Click += new System.EventHandler(this.BtnCrearRol_Click);
            this.btnEliminarPermiso.Click += new System.EventHandler(this.BtnEliminarPermiso_Click);
            this.btnAgregarRelacion.Click += new System.EventHandler(this.BtnAgregarRelacion_Click);
            this.btnQuitarRelacion.Click += new System.EventHandler(this.BtnQuitarRelacion_Click);
            this.btnGuardarRelaciones.Click += new System.EventHandler(this.BtnGuardarRelaciones_Click);
            this.btnGuardarControles.Click += new System.EventHandler(this.BtnGuardarControles_Click);
            this.cboFormularios.SelectedIndexChanged += new System.EventHandler(this.CboFormularios_SelectedIndexChanged);
            this.cboUsuarios.SelectedIndexChanged += new System.EventHandler(this.CboUsuarios_SelectedIndexChanged);
            this.btnAsignarUsuario.Click += new System.EventHandler(this.BtnAsignarUsuario_Click);
            this.btnQuitarUsuario.Click += new System.EventHandler(this.BtnQuitarUsuario_Click);
            this.tblMain.ResumeLayout(false);
            this.pnlCol1.ResumeLayout(false);
            this.pnlCol1.PerformLayout();
            this.pnlCol2.ResumeLayout(false);
            this.pnlCol2.PerformLayout();
            this.tblCol2Transfer.ResumeLayout(false);
            this.pnlCol2Buttons.ResumeLayout(false);
            this.pnlCol3.ResumeLayout(false);
            this.pnlCol3.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Panel pnlCol1;
        private System.Windows.Forms.Label lblCol1Titulo;
        private System.Windows.Forms.TreeView tvEstructura;
        private System.Windows.Forms.Label lblNombrePermiso;
        private System.Windows.Forms.TextBox txtNombrePermiso;
        private System.Windows.Forms.Button btnCrearPermiso;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.Button btnEliminarPermiso;
        private System.Windows.Forms.Panel pnlCol2;
        private System.Windows.Forms.Label lblCol2Titulo;
        private System.Windows.Forms.Label lblDisponibles;
        private System.Windows.Forms.Label lblMiembros;
        private System.Windows.Forms.TableLayoutPanel tblCol2Transfer;
        private System.Windows.Forms.ListBox lstDisponibles;
        private System.Windows.Forms.Panel pnlCol2Buttons;
        private System.Windows.Forms.Button btnAgregarRelacion;
        private System.Windows.Forms.Button btnQuitarRelacion;
        private System.Windows.Forms.ListBox lstMiembros;
        private System.Windows.Forms.Button btnGuardarRelaciones;
        private System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.ComboBox cboFormularios;
        private System.Windows.Forms.Button btnGuardarControles;
        private System.Windows.Forms.Panel pnlCol3;
        private System.Windows.Forms.Label lblCol3Titulo;
        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.Label lblUserPerms;
        private System.Windows.Forms.TreeView tvUsuarioPermisos;
        private System.Windows.Forms.Button btnAsignarUsuario;
        private System.Windows.Forms.Label lblPermisosPlanas;
        private System.Windows.Forms.ListBox lstPermisosPlanas;
        private System.Windows.Forms.Button btnQuitarUsuario;
    }
}
