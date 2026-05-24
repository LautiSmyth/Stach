using Aplicacion;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class RestauracionForm : Form
    {
        private readonly DigitoVerificadorServicio _dvServicio = new DigitoVerificadorServicio();
        private readonly BackupServicio _backupServicio = new BackupServicio();
        private readonly List<string> _errores;

        public bool RestauradoExitosamente { get; private set; }

        public RestauracionForm(List<string> errores)
        {
            InitializeComponent();
            _errores = errores;
            RestauradoExitosamente = false;
        }

        private void RestauracionForm_Load(object sender, EventArgs e)
        {
            lstErrores.Items.Clear();
            lstErrores.Items.Add("Se ha detectado un fallo de integridad en los datos del sistema (Dígitos Verificadores).");
            lstErrores.Items.Add("El acceso de inicio de sesión ha sido bloqueado preventivamente por seguridad.");
            lstErrores.Items.Add("");
            lstErrores.Items.Add("Para ver los registros específicos que fallaron, presione el botón 'Ver Detalles' e ingrese");
            lstErrores.Items.Add("las credenciales de un Administrador del sistema.");
        }

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            using (ConfirmarAdminForm loginForm = new ConfirmarAdminForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK && loginForm.Autorizado)
                {
                    lstErrores.Items.Clear();
                    foreach (var err in _errores)
                    {
                        lstErrores.Items.Add(err);
                    }
                    btnVerDetalles.Enabled = false;
                }
            }
        }

        private void BtnRecalcular_Click(object sender, EventArgs e)
        {
            using (ConfirmarAdminForm loginForm = new ConfirmarAdminForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK && loginForm.Autorizado)
                {
                    try
                    {
                        _dvServicio.InicializarDVs();
                        MessageBox.Show("Dígitos verificadores recalculados y restaurados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RestauradoExitosamente = true;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al restaurar integridad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnRestaurarBackup_Click(object sender, EventArgs e)
        {
            using (ConfirmarAdminForm loginForm = new ConfirmarAdminForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK && loginForm.Autorizado)
                {
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        ofd.Filter = "Copia de Seguridad SQL (*.bak)|*.bak";
                        ofd.Title = "Seleccionar Copia de Seguridad para Restaurar";
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            string confirmMsg = "¿Está seguro de restaurar la base de datos? Esta operación cerrará las sesiones activas, sobrescribirá todos los datos actuales y reiniciará la aplicación.";
                            if (MessageBox.Show(confirmMsg, "Confirmar Restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                try
                                {
                                    _backupServicio.RestaurarBackup("Restauracion", ofd.FileName);
                                    MessageBox.Show("Base de datos restaurada con éxito. La aplicación se reiniciará.", "Restauración Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    RestauradoExitosamente = true;
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
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
