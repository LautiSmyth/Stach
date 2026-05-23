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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.tblInferior = new System.Windows.Forms.TableLayoutPanel();
            this.grpAlta = new System.Windows.Forms.GroupBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.grpEstado = new System.Windows.Forms.GroupBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).BeginInit();
            this.splitPrincipal.Panel1.SuspendLayout();
            this.splitPrincipal.Panel2.SuspendLayout();
            this.splitPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tblInferior.SuspendLayout();
            this.grpAlta.SuspendLayout();
            this.grpEstado.SuspendLayout();
            this.SuspendLayout();
            //
            // splitPrincipal
            //
            this.splitPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitPrincipal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitPrincipal.Name = "splitPrincipal";
            this.splitPrincipal.SplitterWidth = 4;
            this.splitPrincipal.Panel1.Controls.Add(this.dgvUsuarios);
            this.splitPrincipal.Panel2.Controls.Add(this.tblInferior);
            //
            // dgvUsuarios
            //
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.DgvUsuarios_SelectionChanged);
            //
            // tblInferior — 2 columnas: Alta (55%) | Estado (45%)
            //
            this.tblInferior.ColumnCount = 2;
            this.tblInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tblInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tblInferior.Controls.Add(this.grpAlta, 0, 0);
            this.tblInferior.Controls.Add(this.grpEstado, 1, 0);
            this.tblInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblInferior.Name = "tblInferior";
            this.tblInferior.Padding = new System.Windows.Forms.Padding(6);
            this.tblInferior.RowCount = 1;
            this.tblInferior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // grpAlta
            //
            this.grpAlta.Controls.Add(this.lblUsername);
            this.grpAlta.Controls.Add(this.txtUsername);
            this.grpAlta.Controls.Add(this.lblPassword);
            this.grpAlta.Controls.Add(this.txtPassword);
            this.grpAlta.Controls.Add(this.btnCrear);
            this.grpAlta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAlta.Margin = new System.Windows.Forms.Padding(4);
            this.grpAlta.Name = "grpAlta";
            this.grpAlta.Padding = new System.Windows.Forms.Padding(12);
            this.grpAlta.Text = "Alta de usuario";
            //
            // lblUsername
            //
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 24);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Text = "Username";
            //
            // txtUsername
            //
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtUsername.Location = new System.Drawing.Point(12, 44);
            this.txtUsername.MaxLength = 200;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 26);
            this.txtUsername.TabIndex = 0;
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 82);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Password";
            //
            // txtPassword
            //
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtPassword.Location = new System.Drawing.Point(12, 102);
            this.txtPassword.MaxLength = 200;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 26);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            //
            // btnCrear
            //
            this.btnCrear.Location = new System.Drawing.Point(12, 142);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(150, 36);
            this.btnCrear.TabIndex = 2;
            this.btnCrear.Text = "Crear Usuario";
            this.btnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            //
            // grpEstado
            //
            this.grpEstado.Controls.Add(this.lblEstado);
            this.grpEstado.Controls.Add(this.cboEstado);
            this.grpEstado.Controls.Add(this.btnCambiarEstado);
            this.grpEstado.Controls.Add(this.btnRefrescar);
            this.grpEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEstado.Margin = new System.Windows.Forms.Padding(4);
            this.grpEstado.Name = "grpEstado";
            this.grpEstado.Padding = new System.Windows.Forms.Padding(12);
            this.grpEstado.Text = "Estado del usuario seleccionado";
            //
            // lblEstado
            //
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(12, 24);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Nuevo estado";
            //
            // cboEstado
            //
            this.cboEstado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Location = new System.Drawing.Point(12, 44);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(220, 22);
            this.cboEstado.TabIndex = 0;
            //
            // btnCambiarEstado
            //
            this.btnCambiarEstado.Location = new System.Drawing.Point(12, 84);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(150, 36);
            this.btnCambiarEstado.TabIndex = 1;
            this.btnCambiarEstado.Text = "Cambiar Estado";
            this.btnCambiarEstado.Click += new System.EventHandler(this.BtnCambiarEstado_Click);
            //
            // btnRefrescar
            //
            this.btnRefrescar.Location = new System.Drawing.Point(12, 132);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(120, 36);
            this.btnRefrescar.TabIndex = 2;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Click += new System.EventHandler(this.BtnRefrescar_Click);
            //
            // UsuariosForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.splitPrincipal);
            this.Name = "UsuariosForm";
            this.Text = "Gestion de Usuarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UsuariosForm_Load);
            this.Shown += new System.EventHandler(this.UsuariosForm_Shown);
            this.splitPrincipal.Panel1.ResumeLayout(false);
            this.splitPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).EndInit();
            this.splitPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tblInferior.ResumeLayout(false);
            this.grpAlta.ResumeLayout(false);
            this.grpAlta.PerformLayout();
            this.grpEstado.ResumeLayout(false);
            this.grpEstado.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.SplitContainer splitPrincipal;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TableLayoutPanel tblInferior;
        private System.Windows.Forms.GroupBox grpAlta;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.GroupBox grpEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.Button btnRefrescar;
    }
}
