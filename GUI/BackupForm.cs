using BE;
using Abstracciones;
using System;
using System.IO;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class BackupForm : Form, IObserver
    {
        private readonly IBackupService _backupService = IoCContainer.Resolver<IBackupService>();
        private readonly IManejadorIdioma _manejadorIdioma = IoCContainer.Resolver<IManejadorIdioma>();
        private readonly IManejadorSeguridad _manejadorSeguridad = IoCContainer.Resolver<IManejadorSeguridad>();
        private readonly ISessionManager _sessionManager = IoCContainer.Resolver<ISessionManager>();
        private readonly UsuarioBLL _usuarioBll = IoCContainer.Resolver<UsuarioBLL>();

        public BackupForm()
        {
            InitializeComponent();
            _manejadorIdioma.Attach(this);
        }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            ActualizarIdioma();
            _manejadorSeguridad.AplicarSeguridad(this, _sessionManager.Usuario);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _manejadorIdioma.Detach(this);
            base.OnFormClosed(e);
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            if (!_usuarioBll.UsuarioLogueadoTienePermiso("Gestión de Backups"))
            {
                MessageBox.Show("No tiene autorización para realizar esta acción.", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string dirBackups = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
                if (!Directory.Exists(dirBackups))
                {
                    Directory.CreateDirectory(dirBackups);
                }
                using (InputDialog pwdDlg = new InputDialog("Contraseña del Backup", "Ingrese una contraseña para cifrar el archivo de respaldo:", true))
                {
                    if (pwdDlg.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    string password = pwdDlg.InputText;
                    if (string.IsNullOrWhiteSpace(password))
                    {
                        MessageBox.Show("La contraseña no puede estar vacía.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string filename = string.Format("Stach_Backup_{0:yyyyMMdd_HHmmss}.stachbak", DateTime.Now);
                    string fullPath = Path.Combine(dirBackups, filename);
                    _backupService.RealizarBackup(this.Text, fullPath, password);
                    MessageBox.Show(string.Format("Copia de seguridad generada con éxito en:\n{0}", fullPath), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error al generar copia de seguridad: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            if (!_usuarioBll.UsuarioLogueadoTienePermiso("Gestión de Backups"))
            {
                MessageBox.Show("No tiene autorización para realizar esta acción.", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (RestauracionWizardForm wizard = new RestauracionWizardForm())
            {
                wizard.ShowDialog();
            }
        }

        public void ActualizarIdioma()
        {
            this.Text = _manejadorIdioma.ObtenerTexto("BackupForm.Text") ?? "Copia de Seguridad y Restauración";
            lblTitulo.Text = _manejadorIdioma.ObtenerTexto("BackupForm.lblTitulo") ?? "Gestión de Backups";
            btnCrear.Text = _manejadorIdioma.ObtenerTexto("BackupForm.btnCrear") ?? "Generar Copia de Seguridad (.stachbak)";
            btnRestaurar.Text = _manejadorIdioma.ObtenerTexto("BackupForm.btnRestaurar") ?? "Restaurar Copia de Seguridad (.stachbak)";
            lblInfo.Text = _manejadorIdioma.ObtenerTexto("BackupForm.lblInfo") ?? "Nota: La restauración cerrará las conexiones activas temporalmente para poder sobrescribir la base de datos.";
        }
    }
}