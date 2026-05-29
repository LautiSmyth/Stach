using BE;
using Abstracciones;
using Servicios;
using System;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class BackupForm : Form, IObserver
    {
        private readonly IBackupService _backupService = IoCContainer.Resolver<IBackupService>();

        public BackupForm()
        {
            InitializeComponent();
            ManejadorIdioma.Instancia.Attach(this);
        }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            ActualizarIdioma();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ManejadorIdioma.Instancia.Detach(this);
            base.OnFormClosed(e);
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                string dirBackups = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
                if (!Directory.Exists(dirBackups))
                {
                    Directory.CreateDirectory(dirBackups);
                }
                using (var pwdDlg = new InputDialog("Contraseña del Backup", "Ingrese una contraseña para cifrar el archivo de respaldo:", true))
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
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Copia de Seguridad Cifrada (*.stachbak)|*.stachbak";
                ofd.Title = "Seleccionar Copia de Seguridad para Restaurar";
                string dirBackups = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
                if (Directory.Exists(dirBackups))
                {
                    ofd.InitialDirectory = dirBackups;
                }
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string confirmMsg = "¿Está seguro de restaurar la base de datos? " +
                                       "Esta operación cerrará las sesiones activas, sobrescribirá todos los datos actuales " +
                                       "y reiniciará la aplicación.";
                    if (MessageBox.Show(confirmMsg, "Confirmar Restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        using (var pwdDlg = new InputDialog("Contraseña del Backup", "Ingrese la contraseña para descifrar el archivo de respaldo:", true))
                        {
                            if (pwdDlg.ShowDialog() != DialogResult.OK)
                            {
                                return;
                            }
                            string password = pwdDlg.InputText;
                            try
                            {
                                _backupService.RestaurarBackup(this.Text, ofd.FileName, password);
                                MessageBox.Show("Base de datos restaurada con éxito. La aplicación se reiniciará.", "Restauración Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.Restart();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(string.Format("Error al restaurar la base de datos: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        public void ActualizarIdioma()
        {
            this.Text = ManejadorIdioma.Instancia.ObtenerTexto("BackupForm.Text") ?? "Copia de Seguridad y Restauración";
            lblTitulo.Text = ManejadorIdioma.Instancia.ObtenerTexto("BackupForm.lblTitulo") ?? "Gestión de Backups";
            btnCrear.Text = ManejadorIdioma.Instancia.ObtenerTexto("BackupForm.btnCrear") ?? "Generar Copia de Seguridad (.stachbak)";
            btnRestaurar.Text = ManejadorIdioma.Instancia.ObtenerTexto("BackupForm.btnRestaurar") ?? "Restaurar Copia de Seguridad (.stachbak)";
            lblInfo.Text = ManejadorIdioma.Instancia.ObtenerTexto("BackupForm.lblInfo") ?? "Nota: La restauración cerrará las conexiones activas temporalmente para poder sobrescribir la base de datos.";
        }
    }
}