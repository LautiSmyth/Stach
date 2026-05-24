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
            this.btnCrearFamilia = new System.Windows.Forms.Button();
            this.btnCrearPatente = new System.Windows.Forms.Button();
            this.txtClavePermiso = new System.Windows.Forms.TextBox();
            this.lblClavePermiso = new System.Windows.Forms.Label();
            this.txtNombrePermiso = new System.Windows.Forms.TextBox();
            this.lblNombrePermiso = new System.Windows.Forms.Label();
            this.tvEstructura = new System.Windows.Forms.TreeView();
            this.lblCol1Titulo = new System.Windows.Forms.Label();
            this.pnlCol2 = new System.Windows.Forms.Panel();
            this.btnGuardarRelaciones = new System.Windows.Forms.Button();
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
            this.lstPatentesPlanas = new System.Windows.Forms.ListBox();
            this.lblPatentesPlanas = new System.Windows.Forms.Label();
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
            this.pnlCol1.Controls.Add(this.btnCrearFamilia);
            this.pnlCol1.Controls.Add(this.btnCrearPatente);
            this.pnlCol1.Controls.Add(this.txtClavePermiso);
            this.pnlCol1.Controls.Add(this.lblClavePermiso);
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
            this.btnEliminarPermiso.TabIndex = 8;
            this.btnEliminarPermiso.Text = "Eliminar Seleccionado";
            this.btnEliminarPermiso.UseVisualStyleBackColor = false;

            this.btnCrearFamilia.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnCrearFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearFamilia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCrearFamilia.ForeColor = System.Drawing.Color.White;
            this.btnCrearFamilia.Location = new System.Drawing.Point(198, 505);
            this.btnCrearFamilia.Name = "btnCrearFamilia";
            this.btnCrearFamilia.Size = new System.Drawing.Size(174, 28);
            this.btnCrearFamilia.TabIndex = 7;
            this.btnCrearFamilia.Text = "Nueva Familia";
            this.btnCrearFamilia.UseVisualStyleBackColor = false;

            this.btnCrearPatente.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnCrearPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearPatente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCrearPatente.ForeColor = System.Drawing.Color.White;
            this.btnCrearPatente.Location = new System.Drawing.Point(18, 505);
            this.btnCrearPatente.Name = "btnCrearPatente";
            this.btnCrearPatente.Size = new System.Drawing.Size(174, 28);
            this.btnCrearPatente.TabIndex = 6;
            this.btnCrearPatente.Text = "Nueva Patente";
            this.btnCrearPatente.UseVisualStyleBackColor = false;

            this.txtClavePermiso.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtClavePermiso.Location = new System.Drawing.Point(18, 470);
            this.txtClavePermiso.Name = "txtClavePermiso";
            this.txtClavePermiso.Size = new System.Drawing.Size(354, 24);
            this.txtClavePermiso.TabIndex = 5;

            this.lblClavePermiso.AutoSize = true;
            this.lblClavePermiso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClavePermiso.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblClavePermiso.Location = new System.Drawing.Point(18, 450);
            this.lblClavePermiso.Name = "lblClavePermiso";
            this.lblClavePermiso.Size = new System.Drawing.Size(37, 15);
            this.lblClavePermiso.TabIndex = 4;
            this.lblClavePermiso.Text = "Clave";

            this.txtNombrePermiso.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombrePermiso.Location = new System.Drawing.Point(18, 415);
            this.txtNombrePermiso.Name = "txtNombrePermiso";
            this.txtNombrePermiso.Size = new System.Drawing.Size(354, 24);
            this.txtNombrePermiso.TabIndex = 3;

            this.lblNombrePermiso.AutoSize = true;
            this.lblNombrePermiso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombrePermiso.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblNombrePermiso.Location = new System.Drawing.Point(18, 395);
            this.lblNombrePermiso.Name = "lblNombrePermiso";
            this.lblNombrePermiso.Size = new System.Drawing.Size(53, 15);
            this.lblNombrePermiso.TabIndex = 2;
            this.lblNombrePermiso.Text = "Nombre";

            this.tvEstructura.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tvEstructura.Location = new System.Drawing.Point(18, 45);
            this.tvEstructura.Name = "tvEstructura";
            this.tvEstructura.Size = new System.Drawing.Size(354, 335);
            this.tvEstructura.TabIndex = 1;

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
            this.pnlCol2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol2.Location = new System.Drawing.Point(399, 3);
            this.pnlCol2.Name = "pnlCol2";
            this.pnlCol2.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCol2.Size = new System.Drawing.Size(402, 594);
            this.pnlCol2.TabIndex = 1;

            this.btnGuardarRelaciones.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnGuardarRelaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarRelaciones.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
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
            this.tblCol2Transfer.Location = new System.Drawing.Point(18, 80);
            this.tblCol2Transfer.Name = "tblCol2Transfer";
            this.tblCol2Transfer.RowCount = 1;
            this.tblCol2Transfer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCol2Transfer.Size = new System.Drawing.Size(366, 445);
            this.tblCol2Transfer.TabIndex = 4;

            this.lstDisponibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDisponibles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstDisponibles.FormattingEnabled = true;
            this.lstDisponibles.ItemHeight = 15;
            this.lstDisponibles.Location = new System.Drawing.Point(3, 3);
            this.lstDisponibles.Name = "lstDisponibles";
            this.lstDisponibles.Size = new System.Drawing.Size(151, 439);
            this.lstDisponibles.TabIndex = 0;

            this.pnlCol2Buttons.Controls.Add(this.btnQuitarRelacion);
            this.pnlCol2Buttons.Controls.Add(this.btnAgregarRelacion);
            this.pnlCol2Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol2Buttons.Location = new System.Drawing.Point(160, 3);
            this.pnlCol2Buttons.Name = "pnlCol2Buttons";
            this.pnlCol2Buttons.Size = new System.Drawing.Size(45, 439);
            this.pnlCol2Buttons.TabIndex = 1;

            this.btnQuitarRelacion.Location = new System.Drawing.Point(2, 230);
            this.btnQuitarRelacion.Name = "btnQuitarRelacion";
            this.btnQuitarRelacion.Size = new System.Drawing.Size(41, 30);
            this.btnQuitarRelacion.TabIndex = 1;
            this.btnQuitarRelacion.Text = "<<";
            this.btnQuitarRelacion.UseVisualStyleBackColor = true;

            this.btnAgregarRelacion.Location = new System.Drawing.Point(2, 185);
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
            this.lstMiembros.Size = new System.Drawing.Size(152, 439);
            this.lstMiembros.TabIndex = 2;

            this.lblMiembros.AutoSize = true;
            this.lblMiembros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMiembros.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblMiembros.Location = new System.Drawing.Point(226, 55);
            this.lblMiembros.Name = "lblMiembros";
            this.lblMiembros.Size = new System.Drawing.Size(102, 15);
            this.lblMiembros.TabIndex = 3;
            this.lblMiembros.Text = "Miembros del Rol";

            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDisponibles.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblDisponibles.Location = new System.Drawing.Point(18, 55);
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

            this.pnlCol3.BackColor = System.Drawing.Color.FromArgb(248, 244, 255);
            this.pnlCol3.Controls.Add(this.btnQuitarUsuario);
            this.pnlCol3.Controls.Add(this.lstPatentesPlanas);
            this.pnlCol3.Controls.Add(this.lblPatentesPlanas);
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
            this.btnQuitarUsuario.TabIndex = 7;
            this.btnQuitarUsuario.Text = "<< Quitar de Usuario";
            this.btnQuitarUsuario.UseVisualStyleBackColor = false;

            this.lstPatentesPlanas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstPatentesPlanas.FormattingEnabled = true;
            this.lstPatentesPlanas.ItemHeight = 15;
            this.lstPatentesPlanas.Location = new System.Drawing.Point(18, 445);
            this.lstPatentesPlanas.Name = "lstPatentesPlanas";
            this.lstPatentesPlanas.Size = new System.Drawing.Size(354, 124);
            this.lstPatentesPlanas.TabIndex = 6;

            this.lblPatentesPlanas.AutoSize = true;
            this.lblPatentesPlanas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPatentesPlanas.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblPatentesPlanas.Location = new System.Drawing.Point(18, 425);
            this.lblPatentesPlanas.Name = "lblPatentesPlanas";
            this.lblPatentesPlanas.Size = new System.Drawing.Size(117, 15);
            this.lblPatentesPlanas.TabIndex = 5;
            this.lblPatentesPlanas.Text = "Patentes Resultantes";

            this.btnAsignarUsuario.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnAsignarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsignarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnAsignarUsuario.Location = new System.Drawing.Point(18, 385);
            this.btnAsignarUsuario.Name = "btnAsignarUsuario";
            this.btnAsignarUsuario.Size = new System.Drawing.Size(174, 28);
            this.btnAsignarUsuario.TabIndex = 4;
            this.btnAsignarUsuario.Text = "Asignar a Usuario >>";
            this.btnAsignarUsuario.UseVisualStyleBackColor = false;

            this.tvUsuarioPermisos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tvUsuarioPermisos.Location = new System.Drawing.Point(18, 120);
            this.tvUsuarioPermisos.Name = "tvUsuarioPermisos";
            this.tvUsuarioPermisos.Size = new System.Drawing.Size(354, 255);
            this.tvUsuarioPermisos.TabIndex = 3;

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
            this.cboUsuarios.TabIndex = 1;

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
        private System.Windows.Forms.Label lblClavePermiso;
        private System.Windows.Forms.TextBox txtClavePermiso;
        private System.Windows.Forms.Button btnCrearPatente;
        private System.Windows.Forms.Button btnCrearFamilia;
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
        private System.Windows.Forms.Panel pnlCol3;
        private System.Windows.Forms.Label lblCol3Titulo;
        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.Label lblUserPerms;
        private System.Windows.Forms.TreeView tvUsuarioPermisos;
        private System.Windows.Forms.Button btnAsignarUsuario;
        private System.Windows.Forms.Label lblPatentesPlanas;
        private System.Windows.Forms.ListBox lstPatentesPlanas;
        private System.Windows.Forms.Button btnQuitarUsuario;
    }
}
