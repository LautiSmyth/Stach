using Aplicacion;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class LoginForm : Form
    {
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();
        private readonly ConexionServicio _conexionServicio = new ConexionServicio();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.BackColor = AppEstilo.ColorFondo;
            tblCentro.BackColor = AppEstilo.ColorFondo;

            pnlCard.BackColor = Color.White;
            pnlCard.Paint += (s, pe) =>
            {
                using (Pen pen = new Pen(AppEstilo.ColorBorde, 1))
                    pe.Graphics.DrawRectangle(pen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
            };

            lblTitulo.Font = AppEstilo.FuenteTitulo;
            lblTitulo.ForeColor = AppEstilo.ColorPrimario;

            lblSubtitulo.Font = AppEstilo.FuenteNormal;
            lblSubtitulo.ForeColor = AppEstilo.ColorAccent;

            lblUsername.Font = AppEstilo.FuenteNegrita;
            lblUsername.ForeColor = AppEstilo.ColorTexto;

            lblPassword.Font = AppEstilo.FuenteNegrita;
            lblPassword.ForeColor = AppEstilo.ColorTexto;

            chkHidePass.Font = AppEstilo.FuenteNormal;
            chkHidePass.ForeColor = AppEstilo.ColorTexto;
            chkHidePass.BackColor = Color.Transparent;

            AppEstilo.AplicarTextBox(txtUsername);
            AppEstilo.AplicarTextBox(txtPassword);
            AppEstilo.AplicarBotonPrimario(btnIngresar);
            AppEstilo.AplicarBotonSecundario(btnSalir);

            AjustarSizes();
        }

        private void AjustarSizes()
        {
            int margen = 32;
            int ancho = pnlCard.Width - margen * 2;

            lblTitulo.SetBounds(margen, 24, ancho, 38);
            lblSubtitulo.SetBounds(margen, 62, ancho, 22);
            lblUsername.SetBounds(margen, 100, ancho, 20);
            txtUsername.SetBounds(margen, 122, ancho, 28);
            lblPassword.SetBounds(margen, 162, ancho, 20);
            txtPassword.SetBounds(margen, 184, ancho, 28);
            chkHidePass.SetBounds(margen, 222, ancho, 22);
            btnIngresar.SetBounds(margen, 258, ancho, 40);
            btnSalir.SetBounds(margen, 308, ancho, 40);
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (!_conexionServicio.VerificarConexion())
            {
                MessageBox.Show("No hay conexion a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _usuarioServicio.Login(this.Text, txtUsername.Text.Trim(), txtPassword.Text);
                new MenuForm().Show();
                this.Hide();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (_usuarioServicio.LimiteAlcanzadoEnSesion())
                {
                    MessageBox.Show("Limite de intentos alcanzado. La aplicacion se cerrara.", "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error inesperado. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Salir();
            }
        }

        private void Salir()
        {
            if (MessageBox.Show("¿Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void ChkHidePass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = chkHidePass.Checked;
        }
    }
}
