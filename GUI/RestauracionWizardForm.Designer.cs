using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class RestauracionWizardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStepIndicator = new System.Windows.Forms.Label();
            this.pnlStepContent = new System.Windows.Forms.Panel();
            this.lblStep1Info = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblStep2Warning = new System.Windows.Forms.Label();
            this.txtLossDetail = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            this.lblTitle.Text = "Asistente de Restauración de Base de Datos";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.lblTitle.Left = 20;
            this.lblTitle.Top = 15;
            this.lblTitle.Width = 480;
            this.lblTitle.Height = 25;
            
            this.lblStepIndicator.Text = "Paso 1 de 2: Selección de Archivo y Contraseña";
            this.lblStepIndicator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStepIndicator.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblStepIndicator.Left = 20;
            this.lblStepIndicator.Top = 40;
            this.lblStepIndicator.Width = 480;
            this.lblStepIndicator.Height = 20;
            
            this.pnlStepContent.Left = 20;
            this.pnlStepContent.Top = 70;
            this.pnlStepContent.Width = 480;
            this.pnlStepContent.Height = 210;
            this.pnlStepContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStepContent.BackColor = System.Drawing.Color.White;
            
            this.lblStep1Info.Text = "Seleccione el archivo de respaldo (.stachbak) y escriba la contraseña de cifrado asociada para continuar.";
            this.lblStep1Info.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStep1Info.ForeColor = System.Drawing.Color.FromArgb(38, 20, 70);
            this.lblStep1Info.Left = 15;
            this.lblStep1Info.Top = 15;
            this.lblStep1Info.Width = 450;
            this.lblStep1Info.Height = 35;
            
            this.lblFile.Text = "Archivo de Copia de Seguridad:";
            this.lblFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFile.ForeColor = System.Drawing.Color.FromArgb(38, 20, 70);
            this.lblFile.Left = 15;
            this.lblFile.Top = 55;
            this.lblFile.Width = 250;
            this.lblFile.Height = 20;
            
            this.txtFilePath.Left = 15;
            this.txtFilePath.Top = 75;
            this.txtFilePath.Width = 340;
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.BackColor = System.Drawing.Color.FromArgb(245, 240, 255);
            
            this.btnBrowse.Text = "Examinar...";
            this.btnBrowse.Left = 365;
            this.btnBrowse.Top = 73;
            this.btnBrowse.Width = 100;
            this.btnBrowse.Height = 26;
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(237, 231, 249);
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 182, 228);
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            
            this.lblPassword.Text = "Contraseña de cifrado:";
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(38, 20, 70);
            this.lblPassword.Left = 15;
            this.lblPassword.Top = 115;
            this.lblPassword.Width = 250;
            this.lblPassword.Height = 20;
            
            this.txtPassword.Left = 15;
            this.txtPassword.Top = 135;
            this.txtPassword.Width = 450;
            this.txtPassword.UseSystemPasswordChar = true;
            
            this.lblStep2Warning.Text = "ADVERTENCIA DE PÉRDIDA DE INFORMACIÓN";
            this.lblStep2Warning.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStep2Warning.ForeColor = System.Drawing.Color.FromArgb(229, 115, 115);
            this.lblStep2Warning.Left = 15;
            this.lblStep2Warning.Top = 15;
            this.lblStep2Warning.Width = 450;
            this.lblStep2Warning.Height = 20;
            
            this.txtLossDetail.Left = 15;
            this.txtLossDetail.Top = 40;
            this.txtLossDetail.Width = 450;
            this.txtLossDetail.Height = 150;
            this.txtLossDetail.Multiline = true;
            this.txtLossDetail.ReadOnly = true;
            this.txtLossDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLossDetail.BackColor = System.Drawing.Color.FromArgb(255, 245, 245);
            this.txtLossDetail.ForeColor = System.Drawing.Color.FromArgb(100, 20, 20);
            this.txtLossDetail.Font = new System.Drawing.Font("Consolas", 9F);
            
            this.btnBack.Text = "< Atrás";
            this.btnBack.Left = 190;
            this.btnBack.Top = 300;
            this.btnBack.Width = 100;
            this.btnBack.Height = 30;
            this.btnBack.Enabled = false;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(237, 231, 249);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 182, 228);
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            
            this.btnNext.Text = "Siguiente >";
            this.btnNext.Left = 300;
            this.btnNext.Top = 300;
            this.btnNext.Width = 100;
            this.btnNext.Height = 30;
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Left = 410;
            this.btnCancel.Top = 300;
            this.btnCancel.Width = 90;
            this.btnCancel.Height = 30;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(237, 231, 249);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 182, 228);
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            
            this.Text = "Asistente de Restauración";
            this.ClientSize = new System.Drawing.Size(520, 350);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.FromArgb(248, 244, 255);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStepIndicator);
            this.Controls.Add(this.pnlStepContent);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStepIndicator;
        private System.Windows.Forms.Panel pnlStepContent;
        private System.Windows.Forms.Label lblStep1Info;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblStep2Warning;
        private System.Windows.Forms.TextBox txtLossDetail;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
    }
}
