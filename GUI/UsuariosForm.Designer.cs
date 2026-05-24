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
            this.splitPrincipal = new System.Windows.Forms.SplitContainer();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTituloGrilla = new System.Windows.Forms.Label();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.tblInferior = new System.Windows.Forms.TableLayoutPanel();
            this.grpAlta = new System.Windows.Forms.GroupBox();
            this.tblAlta = new System.Windows.Forms.TableLayoutPanel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRequisitos = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.grpEstado = new System.Windows.Forms.GroupBox();
            this.tblEstado = new System.Windows.Forms.TableLayoutPanel();
            this.lblSeleccionado = new System.Windows.Forms.Label();
            this.lblNombreSeleccionado = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).BeginInit();
            this.splitPrincipal.Panel1.SuspendLayout();
            this.splitPrincipal.Panel2.SuspendLayout();
            this.splitPrincipal.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tblInferior.SuspendLayout();
            this.grpAlta.SuspendLayout();
            this.tblAlta.SuspendLayout();
            this.grpEstado.SuspendLayout();
            this.tblEstado.SuspendLayout();
            this.SuspendLayout();

            this.splitPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitPrincipal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitPrincipal.Name = "splitPrincipal";
            this.splitPrincipal.SplitterWidth = 5;
            this.splitPrincipal.Panel1.Controls.Add(this.dgvUsuarios);
            this.splitPrincipal.Panel1.Controls.Add(this.pnlEncabezado);
            this.splitPrincipal.Panel2.Controls.Add(this.tblInferior);

            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Height = 50;
            this.pnlEncabezado.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.pnlEncabezado.Controls.Add(this.lblTituloGrilla);
            this.pnlEncabezado.Controls.Add(this.btnRefrescar);
            this.pnlEncabezado.Name = "pnlEncabezado";

            this.lblTituloGrilla.AutoSize = false;
            this.lblTituloGrilla.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTituloGrilla.Name = "lblTituloGrilla";
            this.lblTituloGrilla.Text = "Usuarios registrados";
            this.lblTituloGrilla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloGrilla.Width = 280;

            this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            this.btnRefrescar.Location = new System.Drawing.Point(0, 6);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(130, 38);
            this.btnRefrescar.TabIndex = 0;
            this.btnRefrescar.Text = "↻ Actualizar";
            this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnRefrescar.Click += new System.EventHandler(this.BtnRefrescar_Click);

            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.DgvUsuarios_SelectionChanged);

            this.tblInferior.ColumnCount = 2;
            this.tblInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tblInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tblInferior.Controls.Add(this.grpAlta, 0, 0);
            this.tblInferior.Controls.Add(this.grpEstado, 1, 0);
            this.tblInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblInferior.Name = "tblInferior";
            this.tblInferior.Padding = new System.Windows.Forms.Padding(8);
            this.tblInferior.RowCount = 1;
            this.tblInferior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.grpAlta.Controls.Add(this.tblAlta);
            this.grpAlta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAlta.Margin = new System.Windows.Forms.Padding(4);
            this.grpAlta.Name = "grpAlta";
            this.grpAlta.Padding = new System.Windows.Forms.Padding(12, 18, 12, 12);
            this.grpAlta.Text = "Alta de usuario";

            this.tblAlta.ColumnCount = 1;
            this.tblAlta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAlta.Controls.Add(this.lblUsername, 0, 0);
            this.tblAlta.Controls.Add(this.txtUsername, 0, 1);
            this.tblAlta.Controls.Add(this.lblPassword, 0, 2);
            this.tblAlta.Controls.Add(this.txtPassword, 0, 3);
            this.tblAlta.Controls.Add(this.lblRequisitos, 0, 4);
            this.tblAlta.Controls.Add(this.btnCrear, 0, 5);
            this.tblAlta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblAlta.Name = "tblAlta";
            this.tblAlta.RowCount = 6;
            this.tblAlta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tblAlta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tblAlta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tblAlta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tblAlta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tblAlta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.lblUsername.AutoSize = true;
            this.lblUsername.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Text = "Nombre de usuario";

            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.txtUsername.MaxLength = 100;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.TabIndex = 0;

            this.lblPassword.AutoSize = true;
            this.lblPassword.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Contraseña";

            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.txtPassword.MaxLength = 200;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;

            this.lblRequisitos.AutoSize = true;
            this.lblRequisitos.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblRequisitos.Name = "lblRequisitos";
            this.lblRequisitos.Text = "Todos los campos son obligatorios";

            this.btnCrear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnCrear.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(160, 38);
            this.btnCrear.TabIndex = 2;
            this.btnCrear.Text = "Crear usuario";
            this.btnCrear.Click += new System.EventHandler(this.BtnCrear_Click);

            this.grpEstado.Controls.Add(this.tblEstado);
            this.grpEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEstado.Margin = new System.Windows.Forms.Padding(4);
            this.grpEstado.Name = "grpEstado";
            this.grpEstado.Padding = new System.Windows.Forms.Padding(12, 18, 12, 12);
            this.grpEstado.Text = "Estado del usuario seleccionado";

            this.tblEstado.ColumnCount = 1;
            this.tblEstado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEstado.Controls.Add(this.lblSeleccionado, 0, 0);
            this.tblEstado.Controls.Add(this.lblNombreSeleccionado, 0, 1);
            this.tblEstado.Controls.Add(this.lblEstado, 0, 2);
            this.tblEstado.Controls.Add(this.cboEstado, 0, 3);
            this.tblEstado.Controls.Add(this.btnCambiarEstado, 0, 4);
            this.tblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEstado.Name = "tblEstado";
            this.tblEstado.RowCount = 5;
            this.tblEstado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tblEstado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tblEstado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tblEstado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tblEstado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.lblSeleccionado.AutoSize = true;
            this.lblSeleccionado.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.lblSeleccionado.Name = "lblSeleccionado";
            this.lblSeleccionado.Text = "Usuario seleccionado";

            this.lblNombreSeleccionado.AutoSize = false;
            this.lblNombreSeleccionado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombreSeleccionado.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.lblNombreSeleccionado.Name = "lblNombreSeleccionado";
            this.lblNombreSeleccionado.Text = "(ninguno)";
            this.lblNombreSeleccionado.Height = 24;

            this.lblEstado.AutoSize = true;
            this.lblEstado.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Nuevo estado";

            this.cboEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(220, 24);
            this.cboEstado.TabIndex = 0;

            this.btnCambiarEstado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnCambiarEstado.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(170, 38);
            this.btnCambiarEstado.TabIndex = 1;
            this.btnCambiarEstado.Text = "Cambiar estado";
            this.btnCambiarEstado.Click += new System.EventHandler(this.BtnCambiarEstado_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.splitPrincipal);
            this.Name = "UsuariosForm";
            this.Text = "Gestión de usuarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UsuariosForm_Load);
            this.Shown += new System.EventHandler(this.UsuariosForm_Shown);
            this.splitPrincipal.Panel1.ResumeLayout(false);
            this.splitPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).EndInit();
            this.splitPrincipal.ResumeLayout(false);
            this.pnlEncabezado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tblInferior.ResumeLayout(false);
            this.grpAlta.ResumeLayout(false);
            this.tblAlta.ResumeLayout(false);
            this.tblAlta.PerformLayout();
            this.grpEstado.ResumeLayout(false);
            this.tblEstado.ResumeLayout(false);
            this.tblEstado.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.SplitContainer splitPrincipal;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTituloGrilla;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TableLayoutPanel tblInferior;
        private System.Windows.Forms.GroupBox grpAlta;
        private System.Windows.Forms.TableLayoutPanel tblAlta;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRequisitos;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.GroupBox grpEstado;
        private System.Windows.Forms.TableLayoutPanel tblEstado;
        private System.Windows.Forms.Label lblSeleccionado;
        private System.Windows.Forms.Label lblNombreSeleccionado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Button btnCambiarEstado;
    }
}
