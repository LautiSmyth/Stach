namespace GUI
{
    partial class BackupForm
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.lblInfo);
            this.pnlMain.Controls.Add(this.btnRestaurar);
            this.pnlMain.Controls.Add(this.btnCrear);
            this.pnlMain.Controls.Add(this.lblTitulo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(400, 260);
            this.pnlMain.TabIndex = 0;

            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblInfo.Location = new System.Drawing.Point(20, 180);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(360, 60);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "Nota: La restauración cerrará las conexiones activas temporalmente para poder sobrescribir la base de datos.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnRestaurar.BackColor = System.Drawing.Color.FromArgb(237, 231, 249);
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestaurar.ForeColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnRestaurar.Location = new System.Drawing.Point(20, 120);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(360, 45);
            this.btnRestaurar.TabIndex = 2;
            this.btnRestaurar.Text = "Restaurar Copia de Seguridad (.bak)";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.BtnRestaurar_Click);

            this.btnCrear.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Location = new System.Drawing.Point(20, 60);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(360, 45);
            this.btnCrear.TabIndex = 1;
            this.btnCrear.Text = "Generar Copia de Seguridad (.bak)";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.BtnCrear_Click);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(94, 58, 160);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(182, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Backups";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 244, 255);
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Copia de Seguridad y Restauración";
            this.Load += new System.EventHandler(this.BackupForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Label lblInfo;
    }
}
