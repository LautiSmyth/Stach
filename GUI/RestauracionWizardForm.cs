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
    public class RestauracionWizardForm : Form, IObserver
    {
        private readonly IBackupService _backupService = IoCContainer.Resolver<IBackupService>();
        private readonly IManejadorIdioma _manejadorIdioma = IoCContainer.Resolver<IManejadorIdioma>();
        
        private int _currentStep = 1;
        private string _rutaArchivo = string.Empty;
        private string _password = string.Empty;

        
        private Label lblTitle;
        private Label lblStepIndicator;
        
        
        private Panel pnlStepContent;
        
        
        private Label lblStep1Info;
        private Label lblFile;
        private TextBox txtFilePath;
        private Button btnBrowse;
        private Label lblPassword;
        private TextBox txtPassword;

        
        private Label lblStep2Warning;
        private TextBox txtLossDetail;

        
        private Button btnBack;
        private Button btnNext;
        private Button btnCancel;

        public bool RestauradoExitosamente { get; private set; }

        public RestauracionWizardForm()
        {
            RestauradoExitosamente = false;
            InitializeControls();
            _manejadorIdioma.Attach(this);
            ActualizarIdioma();
        }

        private void InitializeControls()
        {
            this.Text = "Asistente de Restauración";
            this.ClientSize = new Size(520, 350);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(248, 244, 255);

            
            lblTitle = new Label
            {
                Text = "Asistente de Restauración de Base de Datos",
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(126, 87, 194),
                Left = 20,
                Top = 15,
                Width = 480,
                Height = 25
            };
            this.Controls.Add(lblTitle);

            
            lblStepIndicator = new Label
            {
                Text = "Paso 1 de 2: Selección de Archivo y Contraseña",
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                ForeColor = Color.FromArgb(110, 85, 150),
                Left = 20,
                Top = 40,
                Width = 480,
                Height = 20
            };
            this.Controls.Add(lblStepIndicator);

            
            pnlStepContent = new Panel
            {
                Left = 20,
                Top = 70,
                Width = 480,
                Height = 210,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };
            this.Controls.Add(pnlStepContent);

            
            lblStep1Info = new Label
            {
                Text = "Seleccione el archivo de respaldo (.stachbak) y escriba la contraseña de cifrado asociada para continuar.",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(38, 20, 70),
                Left = 15,
                Top = 15,
                Width = 450,
                Height = 35
            };

            lblFile = new Label
            {
                Text = "Archivo de Copia de Seguridad:",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(38, 20, 70),
                Left = 15,
                Top = 55,
                Width = 250,
                Height = 20
            };

            txtFilePath = new TextBox
            {
                Left = 15,
                Top = 75,
                Width = 340,
                ReadOnly = true,
                BackColor = Color.FromArgb(245, 240, 255)
            };

            btnBrowse = new Button
            {
                Text = "Examinar...",
                Left = 365,
                Top = 73,
                Width = 100,
                Height = 26,
                BackColor = Color.FromArgb(237, 231, 249),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnBrowse.FlatAppearance.BorderColor = Color.FromArgb(200, 182, 228);
            btnBrowse.Click += BtnBrowse_Click;

            lblPassword = new Label
            {
                Text = "Contraseña de cifrado:",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(38, 20, 70),
                Left = 15,
                Top = 115,
                Width = 250,
                Height = 20
            };

            txtPassword = new TextBox
            {
                Left = 15,
                Top = 135,
                Width = 450,
                UseSystemPasswordChar = true
            };

            
            lblStep2Warning = new Label
            {
                Text = "ADVERTENCIA DE PÉRDIDA DE INFORMACIÓN",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(229, 115, 115), 
                Left = 15,
                Top = 15,
                Width = 450,
                Height = 20
            };

            txtLossDetail = new TextBox
            {
                Left = 15,
                Top = 40,
                Width = 450,
                Height = 150,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                BackColor = Color.FromArgb(255, 245, 245),
                ForeColor = Color.FromArgb(100, 20, 20),
                Font = new Font("Consolas", 9F)
            };

            
            btnBack = new Button
            {
                Text = "< Atrás",
                Left = 190,
                Top = 300,
                Width = 100,
                Height = 30,
                Enabled = false,
                BackColor = Color.FromArgb(237, 231, 249),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderColor = Color.FromArgb(200, 182, 228);
            btnBack.Click += BtnBack_Click;
            this.Controls.Add(btnBack);

            btnNext = new Button
            {
                Text = "Siguiente >",
                Left = 300,
                Top = 300,
                Width = 100,
                Height = 30,
                BackColor = Color.FromArgb(126, 87, 194),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.Click += BtnNext_Click;
            this.Controls.Add(btnNext);

            btnCancel = new Button
            {
                Text = "Cancelar",
                Left = 410,
                Top = 300,
                Width = 90,
                Height = 30,
                BackColor = Color.FromArgb(237, 231, 249),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(200, 182, 228);
            btnCancel.Click += BtnCancel_Click;
            this.Controls.Add(btnCancel);

            
            CargarPaso(1);
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
                if (DateTime.TryParseExact(datePart, "yyyyMMdd_HHmmss", null, System.Globalization.DateTimeStyles.None, out DateTime parsed))
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
                    fechaDetalle = fechaBackup.ToString("dd/MM/yyyy HH:mm:ss");
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
            else if (_currentStep == 2)
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
