namespace GUI
{
    partial class ControlCambiosForm
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
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarUsuario = new System.Windows.Forms.Label();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.dgvVersiones = new System.Windows.Forms.DataGridView();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.btnRollback = new System.Windows.Forms.Button();
            this.txtDetEstado = new System.Windows.Forms.TextBox();
            this.lblDetEstado = new System.Windows.Forms.Label();
            this.txtDetUsername = new System.Windows.Forms.TextBox();
            this.lblDetUsername = new System.Windows.Forms.Label();
            this.lblDetalleTitulo = new System.Windows.Forms.Label();
            this.tblLayout.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersiones)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.SuspendLayout();

            this.tblLayout.ColumnCount = 1;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Controls.Add(this.pnlHeader, 0, 0);
            this.tblLayout.Controls.Add(this.tblMain, 0, 1);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.Location = new System.Drawing.Point(0, 0);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 2;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(900, 500);
            this.tblLayout.TabIndex = 0;

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(248, 244, 255);
            this.pnlHeader.Controls.Add(this.cboUsuarios);
            this.pnlHeader.Controls.Add(this.lblSeleccionarUsuario);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(894, 64);
            this.pnlHeader.TabIndex = 0;

            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(150, 20);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(300, 25);
            this.cboUsuarios.TabIndex = 1;
            this.cboUsuarios.SelectedIndexChanged += new System.EventHandler(this.CboUsuarios_SelectedIndexChanged);

            this.lblSeleccionarUsuario.AutoSize = true;
            this.lblSeleccionarUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSeleccionarUsuario.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblSeleccionarUsuario.Location = new System.Drawing.Point(18, 23);
            this.lblSeleccionarUsuario.Name = "lblSeleccionarUsuario";
            this.lblSeleccionarUsuario.Size = new System.Drawing.Size(126, 17);
            this.lblSeleccionarUsuario.TabIndex = 0;
            this.lblSeleccionarUsuario.Text = "Usuario a auditar:";

            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblMain.Controls.Add(this.dgvVersiones, 0, 0);
            this.tblMain.Controls.Add(this.pnlDetalle, 1, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(3, 73);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 1;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(894, 424);
            this.tblMain.TabIndex = 1;

            this.dgvVersiones.BackgroundColor = System.Drawing.Color.FromArgb(248, 244, 255);
            this.dgvVersiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVersiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVersiones.Location = new System.Drawing.Point(3, 3);
            this.dgvVersiones.Name = "dgvVersiones";
            this.dgvVersiones.Size = new System.Drawing.Size(575, 418);
            this.dgvVersiones.TabIndex = 0;
            this.dgvVersiones.SelectionChanged += new System.EventHandler(this.DgvVersiones_SelectionChanged);

            this.pnlDetalle.BackColor = System.Drawing.Color.White;
            this.pnlDetalle.Controls.Add(this.btnRollback);
            this.pnlDetalle.Controls.Add(this.txtDetEstado);
            this.pnlDetalle.Controls.Add(this.lblDetEstado);
            this.pnlDetalle.Controls.Add(this.txtDetUsername);
            this.pnlDetalle.Controls.Add(this.lblDetUsername);
            this.pnlDetalle.Controls.Add(this.lblDetalleTitulo);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalle.Location = new System.Drawing.Point(584, 3);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Padding = new System.Windows.Forms.Padding(15);
            this.pnlDetalle.Size = new System.Drawing.Size(307, 418);
            this.pnlDetalle.TabIndex = 1;

            this.btnRollback.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnRollback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRollback.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRollback.ForeColor = System.Drawing.Color.White;
            this.btnRollback.Location = new System.Drawing.Point(18, 360);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(271, 32);
            this.btnRollback.TabIndex = 5;
            this.btnRollback.Text = "Revertir a esta versión";
            this.btnRollback.UseVisualStyleBackColor = false;
            this.btnRollback.Click += new System.EventHandler(this.BtnRollback_Click);

            this.txtDetEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDetEstado.Location = new System.Drawing.Point(18, 150);
            this.txtDetEstado.Name = "txtDetEstado";
            this.txtDetEstado.ReadOnly = true;
            this.txtDetEstado.Size = new System.Drawing.Size(271, 24);
            this.txtDetEstado.TabIndex = 4;
            this.txtDetEstado.TabStop = false;

            this.lblDetEstado.AutoSize = true;
            this.lblDetEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetEstado.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblDetEstado.Location = new System.Drawing.Point(18, 130);
            this.lblDetEstado.Name = "lblDetEstado";
            this.lblDetEstado.Size = new System.Drawing.Size(42, 15);
            this.lblDetEstado.TabIndex = 3;
            this.lblDetEstado.Text = "Estado";

            this.txtDetUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDetUsername.Location = new System.Drawing.Point(18, 90);
            this.txtDetUsername.Name = "txtDetUsername";
            this.txtDetUsername.ReadOnly = true;
            this.txtDetUsername.Size = new System.Drawing.Size(271, 24);
            this.txtDetUsername.TabIndex = 2;
            this.txtDetUsername.TabStop = false;

            this.lblDetUsername.AutoSize = true;
            this.lblDetUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetUsername.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblDetUsername.Location = new System.Drawing.Point(18, 70);
            this.lblDetUsername.Name = "lblDetUsername";
            this.lblDetUsername.Size = new System.Drawing.Size(113, 15);
            this.lblDetUsername.TabIndex = 1;
            this.lblDetUsername.Text = "Nombre de Usuario";

            this.lblDetalleTitulo.AutoSize = true;
            this.lblDetalleTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetalleTitulo.ForeColor = System.Drawing.Color.FromArgb(94, 58, 160);
            this.lblDetalleTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblDetalleTitulo.Name = "lblDetalleTitulo";
            this.lblDetalleTitulo.Size = new System.Drawing.Size(157, 20);
            this.lblDetalleTitulo.TabIndex = 0;
            this.lblDetalleTitulo.Text = "Detalle de la Versión";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.tblLayout);
            this.Name = "ControlCambiosForm";
            this.Text = "Historial de Cambios y Rollback";
            this.Load += new System.EventHandler(this.ControlCambiosForm_Load);
            this.tblLayout.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tblMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersiones)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSeleccionarUsuario;
        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.DataGridView dgvVersiones;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Label lblDetalleTitulo;
        private System.Windows.Forms.Label lblDetUsername;
        private System.Windows.Forms.TextBox txtDetUsername;
        private System.Windows.Forms.Label lblDetEstado;
        private System.Windows.Forms.TextBox txtDetEstado;
        private System.Windows.Forms.Button btnRollback;
    }
}
