using Aplicacion;
using BE;
using System;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class BackupForm : Form, IObserver
    {
        private readonly BackupServicio _backupServicio = new BackupServicio();

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
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Copia de Seguridad SQL (*.bak)|*.bak";
                sfd.Title = "Guardar Copia de Seguridad";
                sfd.FileName = $"Stach_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _backupServicio.RealizarBackup(this.Text, sfd.FileName);
                        MessageBox.Show("Copia de seguridad generada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al generar copia de seguridad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Copia de Seguridad SQL (*.bak)|*.bak";
                ofd.Title = "Seleccionar Copia de Seguridad para Restaurar";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string confirmMsg = "¿Está seguro de restaurar la base de datos? " +
                                       "Esta operación cerrará las sesiones activas, sobrescribirá todos los datos actuales " +
                                       "y reiniciará la aplicación.";

                    if (MessageBox.Show(confirmMsg, "Confirmar Restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            _backupServicio.RestaurarBackup(this.Text, ofd.FileName);
                            MessageBox.Show("Base de datos restaurada con éxito. La aplicación se reiniciará.", "Restauración Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Restart();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al restaurar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        public void ActualizarIdioma()
        {
            this.Text = ManejadorIdioma.Instancia.ObtenerTexto("BackupForm.Text") ?? "Copia de Seguridad y Restauración";
            lblTitulo.Text = ManejadorIdioma.Instancia.ObtenerTexto("BackupForm.lblTitulo") ?? "Gestión de Backups";
            btnCrear.Text = ManejadorIdioma.Instancia.ObtenerTexto("BackupForm.btnCrear") ?? "Generar Copia de Seguridad (.bak)";
            btnRestaurar.Text = ManejadorIdioma.Instancia.ObtenerTexto("BackupForm.btnRestaurar") ?? "Restaurar Copia de Seguridad (.bak)";
            lblInfo.Text = ManejadorIdioma.Instancia.ObtenerTexto("BackupForm.lblInfo") ?? "Nota: La restauración cerrará las conexiones activas temporalmente para poder sobrescribir la base de datos.";
        }
    }
}
