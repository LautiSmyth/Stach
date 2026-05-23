using Aplicacion;
using System;
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
            AppEstilo.AplicarToolStrip(toolStrip);
            AppEstilo.AplicarStatusStrip(statusStrip);
            AppEstilo.AplicarMdiBackground(this);

            lblUsuario.Text = $"  Usuario: {_usuarioServicio.ObtenerUsernameEnSesion()}";
            lblBaseDatos.Text = $"Base de datos: {_conexionServicio.ObtenerNombreBaseDatos()}";

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
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss") + "  ";
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
                CerrarSesion();
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
    }
}
