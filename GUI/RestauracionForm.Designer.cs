namespace GUI
{
    partial class RestauracionForm
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
            this.tblRaiz = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lstErrores = new System.Windows.Forms.ListBox();
            this.tblBotones = new System.Windows.Forms.TableLayoutPanel();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.btnRestaurarBackup = new System.Windows.Forms.Button();
            this.btnRecalcular = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tblRaiz.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tblBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblRaiz
            // 
            this.tblRaiz.ColumnCount = 1;
            this.tblRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRaiz.Controls.Add(this.pnlHeader, 0, 0);
            this.tblRaiz.Controls.Add(this.lstErrores, 0, 1);
            this.tblRaiz.Controls.Add(this.tblBotones, 0, 2);
            this.tblRaiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRaiz.Location = new System.Drawing.Point(0, 0);
            this.tblRaiz.Name = "tblRaiz";
            this.tblRaiz.RowCount = 3;
            this.tblRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblRaiz.Size = new System.Drawing.Size(600, 400);
            this.tblRaiz.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(600, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(600, 60);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "  Fallo de Integridad - Restauracion";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstErrores
            // 
            this.lstErrores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstErrores.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstErrores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lstErrores.FormattingEnabled = true;
            this.lstErrores.ItemHeight = 17;
            this.lstErrores.Location = new System.Drawing.Point(10, 70);
            this.lstErrores.Margin = new System.Windows.Forms.Padding(10);
            this.lstErrores.Name = "lstErrores";
            this.lstErrores.Size = new System.Drawing.Size(580, 260);
            this.lstErrores.TabIndex = 1;
            // 
            // tblBotones
            // 
            this.tblBotones.ColumnCount = 4;
            this.tblBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tblBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tblBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblBotones.Controls.Add(this.btnRestaurarBackup, 1, 0);
            this.tblBotones.Controls.Add(this.btnRecalcular, 2, 0);
            this.tblBotones.Controls.Add(this.btnSalir, 3, 0);
            this.tblBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBotones.Location = new System.Drawing.Point(0, 340);
            this.tblBotones.Margin = new System.Windows.Forms.Padding(0);
            this.tblBotones.Name = "tblBotones";
            this.tblBotones.RowCount = 1;
            this.tblBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBotones.Size = new System.Drawing.Size(600, 60);
            this.tblBotones.TabIndex = 2;
            this.btnRestaurarBackup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRestaurarBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnRestaurarBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurarBackup.FlatAppearance.BorderSize = 0;
            this.btnRestaurarBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurarBackup.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRestaurarBackup.ForeColor = System.Drawing.Color.White;
            this.btnRestaurarBackup.Location = new System.Drawing.Point(90, 12);
            this.btnRestaurarBackup.Name = "btnRestaurarBackup";
            this.btnRestaurarBackup.Size = new System.Drawing.Size(170, 35);
            this.btnRestaurarBackup.TabIndex = 2;
            this.btnRestaurarBackup.Text = "Restaurar Backup";
            this.btnRestaurarBackup.UseVisualStyleBackColor = false;
            this.btnRestaurarBackup.Click += new System.EventHandler(this.BtnRestaurarBackup_Click);
            this.btnRecalcular.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRecalcular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnRecalcular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecalcular.FlatAppearance.BorderSize = 0;
            this.btnRecalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecalcular.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRecalcular.ForeColor = System.Drawing.Color.White;
            this.btnRecalcular.Location = new System.Drawing.Point(280, 12);
            this.btnRecalcular.Name = "btnRecalcular";
            this.btnRecalcular.Size = new System.Drawing.Size(170, 35);
            this.btnRecalcular.TabIndex = 0;
            this.btnRecalcular.Text = "Recalcular Digitos";
            this.btnRecalcular.UseVisualStyleBackColor = false;
            this.btnRecalcular.Click += new System.EventHandler(this.BtnRecalcular_Click);
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(249)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(182)))), ((int)(((byte)(228)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnSalir.Location = new System.Drawing.Point(460, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(130, 35);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Cerrar Aplicacion";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // RestauracionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.tblRaiz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RestauracionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Integridad del Sistema";
            this.Load += new System.EventHandler(this.RestauracionForm_Load);
            this.tblRaiz.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.tblBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel tblRaiz;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListBox lstErrores;
        private System.Windows.Forms.TableLayoutPanel tblBotones;
        private System.Windows.Forms.Button btnRecalcular;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnRestaurarBackup;
        private System.Windows.Forms.Button btnVerDetalles;
    }
}
