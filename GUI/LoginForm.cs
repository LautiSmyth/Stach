using Aplicacion;
using BE;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    public partial class LoginForm : Form, IObserver
    {
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();
        private readonly ConexionServicio _conexionServicio = new ConexionServicio();

        public LoginForm()
        {
            InitializeComponent();
            txtUsername.TextChanged += TxtInput_TextChanged;
            txtPassword.TextChanged += TxtInput_TextChanged;
            ManejadorIdioma.Instancia.Attach(this);
            ActualizarIdioma();
        }

        private void TxtInput_TextChanged(object sender, EventArgs e)
        {
            lblErrorValidacion.Text = "";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ConfigurarEventosPaint();
        }

        private void ConfigurarEventosPaint()
        {
            pnlCard.Paint += PnlCard_Paint;
            pnlIzquierda.Paint += PnlIzquierda_Paint;
        }

        private void PnlCard_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(225, 215, 240), 1))
                e.Graphics.DrawRectangle(pen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
        }

        private void PnlIzquierda_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(30, 255, 255, 255)))
            {
                int r = 80;
                e.Graphics.FillEllipse(brush, pnlIzquierda.Width - r, -r / 2, r * 2, r * 2);
                e.Graphics.FillEllipse(brush, -r / 2, pnlIzquierda.Height - r, r * 2, r * 2);
            }

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(15, 255, 255, 255)))
            {
                int r = 120;
                e.Graphics.FillEllipse(brush, pnlIzquierda.Width - r, pnlIzquierda.Height / 2 - r / 2, r * 2, r * 2);
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            lblErrorValidacion.Text = "";

            if (string.IsNullOrWhiteSpace(txtUsername.Text) && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblErrorValidacion.Text = "Por favor, ingrese usuario y contraseña.";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                lblErrorValidacion.Text = "Por favor, ingrese el usuario.";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblErrorValidacion.Text = "Por favor, ingrese la contraseña.";
                return;
            }

            if (!_conexionServicio.VerificarConexion())
            {
                lblErrorValidacion.Text = "No hay conexion a la base de datos.";
                return;
            }

            btnIngresar.Enabled = false;
            btnIngresar.Text = "Ingresando...";

            try
            {
                _usuarioServicio.Login(this.Text, txtUsername.Text.Trim(), txtPassword.Text);
                new MenuForm().Show();
                this.Hide();
            }
            catch (UnauthorizedAccessException ex)
            {
                lblErrorValidacion.Text = ex.Message;

                if (_usuarioServicio.LimiteAlcanzadoEnSesion())
                {
                    MessageBox.Show("Limite de intentos alcanzado. La aplicacion se cerrara.", "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                lblErrorValidacion.Text = "Ocurrio un error inesperado. Intente nuevamente.";
            }
            finally
            {
                btnIngresar.Enabled = true;
                btnIngresar.Text = "Ingresar";
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
            ManejadorIdioma.Instancia.Detach(this);
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

        private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnIngresar_Click(sender, e);
        }

        public void ActualizarIdioma()
        {
            lblUsername.Text = ManejadorIdioma.Instancia.ObtenerTexto("LoginForm.lblUsername");
            lblPassword.Text = ManejadorIdioma.Instancia.ObtenerTexto("LoginForm.lblPassword");
            btnIngresar.Text = ManejadorIdioma.Instancia.ObtenerTexto("LoginForm.btnIngresar");
        }
    }
}
