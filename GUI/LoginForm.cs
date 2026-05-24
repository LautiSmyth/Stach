using Aplicacion;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            ConfigurarEstilos();
            ConfigurarEventosPaint();
        }

        private void ConfigurarEstilos()
        {
            this.BackColor = AppEstilo.ColorFondo;

            pnlIzquierda.BackColor = AppEstilo.ColorPrimario;

            pnlCard.BackColor = AppEstilo.ColorFondoCard;

            lblBienvenida.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblBienvenida.ForeColor = AppEstilo.ColorTextoClaro;
            lblBienvenida.BackColor = Color.Transparent;

            lblTagline.Font = new Font("Segoe UI", 9.5f);
            lblTagline.ForeColor = Color.FromArgb(220, 200, 245);
            lblTagline.BackColor = Color.Transparent;

            lblTitulo.Font = AppEstilo.FuenteSubtitulo;
            lblTitulo.ForeColor = AppEstilo.ColorPrimario;
            lblTitulo.BackColor = Color.Transparent;

            lblSubtitulo.Font = AppEstilo.FuenteNormal;
            lblSubtitulo.ForeColor = AppEstilo.ColorTextoSecundario;
            lblSubtitulo.BackColor = Color.Transparent;

            lblUsername.Font = AppEstilo.FuenteSeccion;
            lblUsername.ForeColor = AppEstilo.ColorTexto;
            lblUsername.BackColor = Color.Transparent;

            lblPassword.Font = AppEstilo.FuenteSeccion;
            lblPassword.ForeColor = AppEstilo.ColorTexto;
            lblPassword.BackColor = Color.Transparent;

            chkHidePass.Font = AppEstilo.FuenteNormal;
            chkHidePass.ForeColor = AppEstilo.ColorTextoSecundario;
            chkHidePass.BackColor = Color.Transparent;

            AppEstilo.AplicarTextBox(txtUsername);
            AppEstilo.AplicarTextBox(txtPassword);
            AppEstilo.AplicarBotonPrimario(btnIngresar);
            AppEstilo.AplicarBotonSecundario(btnSalir);
        }

        private void ConfigurarEventosPaint()
        {
            pnlCard.Paint += PnlCard_Paint;
            pnlIzquierda.Paint += PnlIzquierda_Paint;
        }

        private void PnlCard_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(AppEstilo.ColorBordeSuave, 1))
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
            if (!_conexionServicio.VerificarConexion())
            {
                MessageBox.Show("No hay conexion a la base de datos.", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
