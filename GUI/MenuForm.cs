using Aplicacion;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class MenuForm : Form
    {
        private readonly ConexionServicio _conexionServicio = new ConexionServicio();
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();

        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                    c.BackColor = System.Drawing.Color.FromArgb(248, 244, 255);
            }

            lblUsuario.Text = $"👤 Sesión: {_usuarioServicio.ObtenerUsernameEnSesion()}";
            lblBaseDatos.Text = $"🖳 Servidor / BD: {_conexionServicio.ObtenerNombreBaseDatos()}";

            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            _timer.Start();
            ActualizarHora();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ActualizarHora();
        }

        private void ActualizarHora()
        {
            lblHora.Text = "🕒 " + DateTime.Now.ToString("HH:mm:ss") + "  ";
        }

        private void BtnBitacora_Click(object sender, EventArgs e)
        {
            AbrirOActivar<BitacoraForm>();
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirOActivar<UsuariosForm>();
        }

        private void AbrirOActivar<T>() where T : Form, new()
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is T)
                {
                    form.Activate();
                    return;
                }
            }
            T nuevoForm = new T();
            nuevoForm.MdiParent = this;
            nuevoForm.StartPosition = FormStartPosition.Manual;
            nuevoForm.Location = new Point((this.ClientSize.Width - nuevoForm.Width) / 2, (this.ClientSize.Height - nuevoForm.Height - toolStrip.Height - statusStrip.Height - 40) / 2);
            nuevoForm.Show();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                SalirAplicacion();
            }
        }

        private void CerrarSesion()
        {
            if (MessageBox.Show("¿Esta seguro que desea cerrar la sesion?", "Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _usuarioServicio.Logout(this.Text);
                _timer.Stop();
                Application.Restart();
            }
        }

        private void SalirAplicacion()
        {
            if (MessageBox.Show("¿Esta seguro que desea salir de la aplicacion?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _usuarioServicio.Logout(this.Text);
                _timer.Stop();
                Environment.Exit(0);
            }
        }

        private class EstiloProfesionalMenu : ProfessionalColorTable
        {
            public override System.Drawing.Color ToolStripGradientBegin => System.Drawing.Color.FromArgb(126, 87, 194);
            public override System.Drawing.Color ToolStripGradientMiddle => System.Drawing.Color.FromArgb(126, 87, 194);
            public override System.Drawing.Color ToolStripGradientEnd => System.Drawing.Color.FromArgb(126, 87, 194);
            public override System.Drawing.Color MenuItemSelected => System.Drawing.Color.FromArgb(94, 58, 160);
            public override System.Drawing.Color MenuItemBorder => System.Drawing.Color.FromArgb(171, 136, 220);
            public override System.Drawing.Color ButtonSelectedHighlight => System.Drawing.Color.FromArgb(171, 136, 220);
            public override System.Drawing.Color ButtonSelectedHighlightBorder => System.Drawing.Color.FromArgb(171, 136, 220);
            public override System.Drawing.Color ButtonPressedHighlight => System.Drawing.Color.FromArgb(94, 58, 160);
            public override System.Drawing.Color ButtonCheckedHighlight => System.Drawing.Color.FromArgb(171, 136, 220);
            public override System.Drawing.Color ToolStripDropDownBackground => System.Drawing.Color.FromArgb(237, 231, 249);
            public override System.Drawing.Color ImageMarginGradientBegin => System.Drawing.Color.FromArgb(237, 231, 249);
            public override System.Drawing.Color ImageMarginGradientMiddle => System.Drawing.Color.FromArgb(237, 231, 249);
            public override System.Drawing.Color ImageMarginGradientEnd => System.Drawing.Color.FromArgb(237, 231, 249);
        }
    }
}
