using Abstracciones;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class RestauracionForm : Form
    {
        private readonly IDigitoVerificadorService _dvService = IoCContainer.Resolver<IDigitoVerificadorService>();
        private readonly IBackupService _backupService = IoCContainer.Resolver<IBackupService>();
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
            lstErrores.MouseMove += LstListBox_MouseMove;
            lstErrores.HorizontalScrollbar = true;

            lstErrores.Items.Clear();
            lstErrores.Items.Add("Se ha detectado un fallo de integridad en los datos del sistema (Dígitos Verificadores).");
            lstErrores.Items.Add("El acceso de inicio de sesión ha sido bloqueado preventivamente por seguridad.");
            lstErrores.Items.Add("");
            lstErrores.Items.Add("Para ver los registros específicos que fallaron, presione el botón 'Ver Detalles' e ingrese");
            lstErrores.Items.Add("las credenciales de un Administrador del sistema.");

            SetListBoxHorizontalExtent(lstErrores);
        }

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            using (ConfirmarAdminForm loginForm = new ConfirmarAdminForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK && loginForm.Autorizado)
                {
                    lstErrores.Items.Clear();
                    foreach (string err in _errores)
                    {
                        lstErrores.Items.Add(err);
                    }
                    btnVerDetalles.Enabled = false;
                    SetListBoxHorizontalExtent(lstErrores);
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
                        _dvService.InicializarDVs();
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
                        ofd.Filter = "Copia de Seguridad Cifrada (*.stachbak)|*.stachbak";
                        ofd.Title = "Seleccionar Copia de Seguridad para Restaurar";
                        string dirBackups = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
                        if (System.IO.Directory.Exists(dirBackups))
                        {
                            ofd.InitialDirectory = dirBackups;
                        }
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            string confirmMsg = "¿Está seguro de restaurar la base de datos? Esta operación cerrará las sesiones activas, sobrescribirá todos los datos actuales y reiniciará la aplicación.";
                            if (MessageBox.Show(confirmMsg, "Confirmar Restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                using (InputDialog pwdDlg = new InputDialog("Contraseña del Backup", "Ingrese la contraseña para descifrar el archivo de respaldo:", true))
                                {
                                    if (pwdDlg.ShowDialog() != DialogResult.OK)
                                    {
                                        return;
                                    }
                                    string password = pwdDlg.InputText;
                                    try
                                    {
                                        _backupService.RestaurarBackup("Restauracion", ofd.FileName, password);
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
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private int _lastHoveredIndex = -1;
        private ToolTip _listboxToolTip = new ToolTip();

        private void LstListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is ListBox listBox)
            {
                int index = listBox.IndexFromPoint(e.Location);
                if (index != _lastHoveredIndex)
                {
                    _lastHoveredIndex = index;
                    if (index >= 0 && index < listBox.Items.Count)
                    {
                        string text = listBox.GetItemText(listBox.Items[index]);
                        _listboxToolTip.SetToolTip(listBox, text);
                    }
                    else
                    {
                        _listboxToolTip.SetToolTip(listBox, "");
                    }
                }
            }
        }

        private void SetListBoxHorizontalExtent(ListBox listBox)
        {
            int maxExtent = listBox.Width;
            if (listBox.Items.Count > 0)
            {
                using (System.Drawing.Graphics g = listBox.CreateGraphics())
                {
                    foreach (var item in listBox.Items)
                    {
                        string text = listBox.GetItemText(item);
                        int width = (int)g.MeasureString(text, listBox.Font).Width;
                        if (width > maxExtent)
                        {
                            maxExtent = width;
                        }
                    }
                }
            }
            listBox.HorizontalExtent = maxExtent + 15;
        }
    }
}