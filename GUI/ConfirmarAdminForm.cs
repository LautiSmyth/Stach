using Aplicacion;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class ConfirmarAdminForm : Form
    {
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();

        public bool Autorizado { get; private set; }

        public ConfirmarAdminForm()
        {
            InitializeComponent();
            Autorizado = false;
            this.Load += ConfirmarAdminForm_Load;
        }

        private void ConfirmarAdminForm_Load(object sender, EventArgs e)
        {
            txtUsuario.MaxLength = 100;
            txtPassword.MaxLength = 100;
            txtUsuario.KeyPress += TxtUsuario_KeyPress;
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

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var perms = new System.Collections.Generic.List<string> { "RestauracionDV", "Backups" };
                bool tienePermiso = _usuarioServicio.ValidarCredencialesAdmin(username, password, perms);

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