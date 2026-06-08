using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BE;
using Abstracciones;
using BLL;

namespace GUI
{
    public partial class RestauracionWizardForm : Form, IObserver
    {
        private readonly IBackupService _backupService = IoCContainer.Resolver<IBackupService>();
        private readonly IManejadorIdioma _manejadorIdioma = IoCContainer.Resolver<IManejadorIdioma>();
        
        private int _currentStep = 1;
        private string _rutaArchivo = string.Empty;
        private string _password = string.Empty;

        public bool RestauradoExitosamente { get; private set; }

        public RestauracionWizardForm()
        {
            RestauradoExitosamente = false;
            InitializeComponent();
            _manejadorIdioma.Attach(this);
            ActualizarIdioma();
        }

        private void CargarPaso(int paso)
        {
            _currentStep = paso;
            pnlStepContent.Controls.Clear();

            if (paso == 1)
            {
                lblStepIndicator.Text = "Paso 1 de 2: Selección de Archivo y Contraseña";
                pnlStepContent.Controls.Add(lblStep1Info);
                pnlStepContent.Controls.Add(lblFile);
                pnlStepContent.Controls.Add(txtFilePath);
                pnlStepContent.Controls.Add(btnBrowse);
                pnlStepContent.Controls.Add(lblPassword);
                pnlStepContent.Controls.Add(txtPassword);

                btnBack.Enabled = false;
                btnNext.Text = "Siguiente >";
            }
            else if (paso == 2)
            {
                lblStepIndicator.Text = "Paso 2 de 2: Análisis y Confirmación de Pérdida";
                pnlStepContent.Controls.Add(lblStep2Warning);
                pnlStepContent.Controls.Add(txtLossDetail);

                btnBack.Enabled = true;
                btnNext.Text = "Restaurar";
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Copia de Seguridad Cifrada (*.stachbak)|*.stachbak";
                ofd.Title = "Seleccionar Copia de Seguridad";
                string dirBackups = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
                if (Directory.Exists(dirBackups))
                {
                    ofd.InitialDirectory = dirBackups;
                }
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _rutaArchivo = ofd.FileName;
                    txtFilePath.Text = ofd.FileName;
                }
            }
        }

        private DateTime ObtenerFechaDeBackup(string rutaArchivo)
        {
            string nombre = Path.GetFileNameWithoutExtension(rutaArchivo);
            
            if (nombre.StartsWith("Stach_Backup_") && nombre.Length >= 28)
            {
                string datePart = nombre.Substring(13, 15); 
                if (DateTime.TryParseExact(datePart, "yyyyMMdd_HHmmss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime parsed))
                {
                    return parsed;
                }
            }
            return DateTime.MinValue;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_currentStep == 1)
            {
                ProcesarPaso1();
            }
            else if (_currentStep == 2)
            {
                ProcesarPaso2();
            }
        }

        private void ProcesarPaso1()
        {
            if (string.IsNullOrEmpty(_rutaArchivo))
            {
                MessageBox.Show("Por favor, seleccione un archivo de backup.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _password = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(_password))
            {
                MessageBox.Show("Por favor, ingrese la contraseña de descifrado del backup.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaBackup = ObtenerFechaDeBackup(_rutaArchivo);
            int logsPerdidos = 0;
            int cambiosPerdidos = 0;
            string fechaDetalle = "Desconocida (nombre de archivo modificado)";

            if (fechaBackup != DateTime.MinValue)
            {
                fechaDetalle = fechaBackup.ToString("dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                logsPerdidos = _backupService.ObtenerCantRegistrosBitacoraNuevos(fechaBackup);
                cambiosPerdidos = _backupService.ObtenerCantRegistrosCambiosNuevos(fechaBackup);
            }

            txtLossDetail.Clear();
            txtLossDetail.AppendText("==============================================" + Environment.NewLine);
            txtLossDetail.AppendText($"Fecha de copia seleccionada: {fechaDetalle}" + Environment.NewLine);
            txtLossDetail.AppendText("==============================================" + Environment.NewLine + Environment.NewLine);
            txtLossDetail.AppendText("La restauración de este respaldo sobrescribirá la base de datos actual." + Environment.NewLine);
            txtLossDetail.AppendText("Se perderán permanentemente los siguientes registros locales:" + Environment.NewLine + Environment.NewLine);
            
            if (fechaBackup == DateTime.MinValue)
            {
                txtLossDetail.AppendText("⚠️ ADVERTENCIA: No se pudo determinar la fecha del backup." + Environment.NewLine);
                txtLossDetail.AppendText("Se perderán TODOS los registros creados después de la fecha del respaldo." + Environment.NewLine);
            }
            else
            {
                txtLossDetail.AppendText($"* Registros de Auditoría (Bitácora) que se perderán: {logsPerdidos}" + Environment.NewLine);
                txtLossDetail.AppendText($"* Cambios e Historial de Usuarios que se perderán: {cambiosPerdidos}" + Environment.NewLine + Environment.NewLine);
                txtLossDetail.AppendText("Verifique que posee un respaldo alternativo reciente si desea conservar estos datos.");
            }

            CargarPaso(2);
        }

        private void ProcesarPaso2()
        {
            string confirmMsg = "¿Está completamente seguro de continuar con la restauración? " +
                                "Esta acción es irreversible, sobrescribirá todos los datos actuales y reiniciará la aplicación.";
            
            if (MessageBox.Show(confirmMsg, "Confirmación Final de Restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _backupService.RestaurarBackup("RestauracionWizard", _rutaArchivo, _password);
                    MessageBox.Show("Base de datos restaurada con éxito. La aplicación se reiniciará.", "Restauración Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RestauradoExitosamente = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al restaurar base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargarPaso(1);
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (_currentStep == 2)
            {
                CargarPaso(1);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _manejadorIdioma.Detach(this);
            base.OnFormClosed(e);
        }

        public void ActualizarIdioma()
        {
            this.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.Text") ?? "Asistente de Restauración";
            lblTitle.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.lblTitle") ?? "Asistente de Restauración de Base de Datos";
            lblFile.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.lblFile") ?? "Archivo de Copia de Seguridad:";
            btnBrowse.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.btnBrowse") ?? "Examinar...";
            lblPassword.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.lblPassword") ?? "Contraseña de cifrado:";
            btnBack.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.btnBack") ?? "< Atrás";
            btnCancel.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.btnCancel") ?? "Cancelar";
            lblStep1Info.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.lblStep1Info") ?? "Seleccione el archivo de respaldo (.stachbak) y escriba la contraseña de cifrado asociada para continuar.";
            lblStep2Warning.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.lblStep2Warning") ?? "ADVERTENCIA DE PÉRDIDA DE INFORMACIÓN";
            
            if (_currentStep == 1)
            {
                lblStepIndicator.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.lblStep1Indicator") ?? "Paso 1 de 2: Selección de Archivo y Contraseña";
                btnNext.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.btnNextSiguiente") ?? "Siguiente >";
            }
            else
            {
                lblStepIndicator.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.lblStep2Indicator") ?? "Paso 2 de 2: Análisis y Confirmación de Pérdida";
                btnNext.Text = _manejadorIdioma.ObtenerTexto("RestauracionWizardForm.btnNextRestaurar") ?? "Restaurar";
            }
        }
    }
}
