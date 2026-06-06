namespace GUI
{
    partial class MenuForm
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
            this.components = new System.ComponentModel.Container();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._timer.Tick += new System.EventHandler(this.Timer_Tick);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripLabel();
            this.sepNavegacion = new System.Windows.Forms.ToolStripSeparator();
            this.btnBitacora = new System.Windows.Forms.ToolStripButton();
            this.btnUsuarios = new System.Windows.Forms.ToolStripButton();
            this.btnPermisos = new System.Windows.Forms.ToolStripButton();
            this.btnCambios = new System.Windows.Forms.ToolStripButton();
            this.btnBackup = new System.Windows.Forms.ToolStripButton();
            this.sepIdiomas = new System.Windows.Forms.ToolStripSeparator();
            this.cboIdioma = new System.Windows.Forms.ToolStripComboBox();
            this.btnIdiomas = new System.Windows.Forms.ToolStripButton();
            this.btnCerrarSesion = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblBaseDatos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparador = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            
            
            
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.toolStrip.ForeColor = System.Drawing.Color.White;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.sepNavegacion,
            this.btnBitacora,
            this.btnUsuarios,
            this.btnPermisos,
            this.btnCambios,
            this.btnBackup,
            this.sepIdiomas,
            this.cboIdioma,
            this.btnIdiomas,
            this.btnCerrarSesion});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolStrip.Size = new System.Drawing.Size(1224, 32);
            this.toolStrip.TabIndex = 0;
            
            
            
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.lblUsuario.Size = new System.Drawing.Size(83, 29);
            this.lblUsuario.Text = "  Usuario";
            this.lblUsuario.IsLink = true;
            this.lblUsuario.LinkColor = System.Drawing.Color.White;
            this.lblUsuario.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(249)))));
            this.lblUsuario.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblUsuario.Click += new System.EventHandler(this.LblUsuario_Click);
            
            
            
            this.sepNavegacion.Name = "sepNavegacion";
            this.sepNavegacion.Size = new System.Drawing.Size(6, 32);
            
            
            
            this.btnBitacora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBitacora.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBitacora.ForeColor = System.Drawing.Color.White;
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.btnBitacora.Size = new System.Drawing.Size(101, 29);
            this.btnBitacora.Text = "📜 Bitácora";
            this.btnBitacora.Click += new System.EventHandler(this.BtnBitacora_Click);
            
            
            
            this.btnUsuarios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.btnUsuarios.Size = new System.Drawing.Size(105, 29);
            this.btnUsuarios.Text = "👤 Usuarios";
            this.btnUsuarios.Click += new System.EventHandler(this.BtnUsuarios_Click);

            this.btnPermisos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPermisos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnPermisos.ForeColor = System.Drawing.Color.White;
            this.btnPermisos.Name = "btnPermisos";
            this.btnPermisos.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.btnPermisos.Size = new System.Drawing.Size(105, 29);
            this.btnPermisos.Text = "🔑 Permisos";
            this.btnPermisos.Click += new System.EventHandler(this.BtnPermisos_Click);

            this.btnCambios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCambios.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCambios.ForeColor = System.Drawing.Color.White;
            this.btnCambios.Name = "btnCambios";
            this.btnCambios.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.btnCambios.Size = new System.Drawing.Size(105, 29);
            this.btnCambios.Text = "📜 Cambios";
            this.btnCambios.Click += new System.EventHandler(this.BtnCambios_Click);
            this.btnBackup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.btnBackup.Size = new System.Drawing.Size(105, 29);
            this.btnBackup.Text = "💾 Backup";
            this.btnBackup.Click += new System.EventHandler(this.BtnBackup_Click);

            this.sepIdiomas.Name = "sepIdiomas";
            this.sepIdiomas.Size = new System.Drawing.Size(6, 32);

            this.cboIdioma.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cboIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdioma.Name = "cboIdioma";
            this.cboIdioma.Size = new System.Drawing.Size(120, 32);
            this.cboIdioma.SelectedIndexChanged += new System.EventHandler(this.CboIdioma_SelectedIndexChanged);

            this.btnIdiomas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnIdiomas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnIdiomas.ForeColor = System.Drawing.Color.White;
            this.btnIdiomas.Name = "btnIdiomas";
            this.btnIdiomas.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.btnIdiomas.Size = new System.Drawing.Size(101, 29);
            this.btnIdiomas.Text = "🌐 Idiomas";
            this.btnIdiomas.Click += new System.EventHandler(this.BtnIdiomas_Click);

            this.btnCerrarSesion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrarSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.btnCerrarSesion.Size = new System.Drawing.Size(132, 29);
            this.btnCerrarSesion.Text = "❌ Cerrar sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            
            
            
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(249)))));
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.statusStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBaseDatos,
            this.lblSeparador,
            this.lblHora});
            this.statusStrip.Location = new System.Drawing.Point(0, 719);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip.Size = new System.Drawing.Size(1224, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            
            
            
            this.lblBaseDatos.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBaseDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.lblBaseDatos.Name = "lblBaseDatos";
            this.lblBaseDatos.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblBaseDatos.Size = new System.Drawing.Size(88, 17);
            this.lblBaseDatos.Text = "Base de datos:";
            
            
            
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(785, 17);
            this.lblSeparador.Spring = true;
            
            
            
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.lblHora.Name = "lblHora";
            this.lblHora.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblHora.Size = new System.Drawing.Size(57, 17);
            this.lblHora.Text = "00:00:00";
            
            
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 741);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1084, 708);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stach - Sistema de Gestión";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel lblUsuario;
        private System.Windows.Forms.ToolStripSeparator sepNavegacion;
        private System.Windows.Forms.ToolStripButton btnBitacora;
        private System.Windows.Forms.ToolStripButton btnUsuarios;
        private System.Windows.Forms.ToolStripButton btnPermisos;
        private System.Windows.Forms.ToolStripButton btnCambios;
        private System.Windows.Forms.ToolStripButton btnBackup;
        private System.Windows.Forms.ToolStripSeparator sepIdiomas;
        private System.Windows.Forms.ToolStripComboBox cboIdioma;
        private System.Windows.Forms.ToolStripButton btnIdiomas;
        private System.Windows.Forms.ToolStripButton btnCerrarSesion;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblBaseDatos;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparador;
        private System.Windows.Forms.ToolStripStatusLabel lblHora;
    }
}
