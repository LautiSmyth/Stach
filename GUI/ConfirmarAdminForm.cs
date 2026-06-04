using BLL;
using Abstracciones;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class ConfirmarAdminForm : Form
    {
        private readonly UsuarioBLL _usuarioBll = IoCContainer.Resolver<UsuarioBLL>();

        public bool Autorizado { get; private set; }

        public ConfirmarAdminForm()
        {
            InitializeComponent();
            Autorizado = false;
        }

        private void ConfirmarAdminForm_Load(object sender, EventArgs e)
        {
            txtUsuario.MaxLength = 100;
            txtPassword.MaxLength = 100;
            lblMensaje.Text = "Se requieren credenciales de Administrador o la Clave de Recuperación Maestra.";
            lblUsuario.Text = "Usuario (vacío para Clave Maestra)";
            lblPassword.Text = "Contraseña / Clave de Recuperación";
        }

        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, ingrese la contraseña o clave de recuperación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string hashRecuperacion = System.Configuration.ConfigurationManager.AppSettings["MasterRecoveryKeyHash"];
                IEncriptador encriptador = IoCContainer.Resolver<IEncriptador>();
                if (!string.IsNullOrEmpty(hashRecuperacion) && encriptador.Verificar(password, hashRecuperacion))
                {
                    Autorizado = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Por favor, ingrese el nombre de usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                System.Collections.Generic.List<string> perms = new System.Collections.Generic.List<string> { "Restauración DV", "Gestión de Backups" };
                bool tienePermiso = _usuarioBll.ValidarCredencialesAdmin(username, password, perms);

                if (!tienePermiso)
                {
                    MessageBox.Show("El usuario no cuenta con los permisos necesarios para realizar esta acción o sus credenciales son incorrectas.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                Autorizado = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar credenciales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}