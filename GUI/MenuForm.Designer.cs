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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripLabel();
            this.sepNavegacion = new System.Windows.Forms.ToolStripSeparator();
            this.btnBitacora = new System.Windows.Forms.ToolStripButton();
            this.btnUsuarios = new System.Windows.Forms.ToolStripButton();
            this.btnCerrarSesion = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblBaseDatos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparador = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblUsuario, this.sepNavegacion,
                this.btnBitacora, this.btnUsuarios, this.btnCerrarSesion});
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1100, 42);
            this.toolStrip.Height = 42;

            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUsuario.Text = "  Usuario";
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);

            this.sepNavegacion.Name = "sepNavegacion";

            this.btnBitacora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.Padding = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.btnBitacora.Text = "Bitácora";
            this.btnBitacora.Click += new System.EventHandler(this.BtnBitacora_Click);

            this.btnUsuarios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.Click += new System.EventHandler(this.BtnUsuarios_Click);

            this.btnCerrarSesion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrarSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);

            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblBaseDatos, this.lblSeparador, this.lblHora});
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1100, 24);

            this.lblBaseDatos.Name = "lblBaseDatos";
            this.lblBaseDatos.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblBaseDatos.Text = "Base de datos:";

            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Spring = true;

            this.lblHora.Name = "lblHora";
            this.lblHora.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblHora.Text = "00:00:00";

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión";
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
        private System.Windows.Forms.ToolStripButton btnCerrarSesion;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblBaseDatos;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparador;
        private System.Windows.Forms.ToolStripStatusLabel lblHora;
    }
}
