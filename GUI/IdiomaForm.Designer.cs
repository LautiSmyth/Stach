namespace GUI
{
    partial class IdiomaForm
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.btnEliminarIdioma = new System.Windows.Forms.Button();
            this.btnAgregarIdioma = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lstIdiomas = new System.Windows.Forms.ListBox();
            this.lblIdiomasTitulo = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnGuardarTraducciones = new System.Windows.Forms.Button();
            this.dgvTraducciones = new System.Windows.Forms.DataGridView();
            this.cboIdiomaDestino = new System.Windows.Forms.ComboBox();
            this.lblIdiomaDestino = new System.Windows.Forms.Label();
            this.lblTraduccionesTitulo = new System.Windows.Forms.Label();
            this.tblLayout.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).BeginInit();
            this.SuspendLayout();

            this.tblLayout.ColumnCount = 2;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblLayout.Controls.Add(this.pnlLeft, 0, 0);
            this.tblLayout.Controls.Add(this.pnlRight, 1, 0);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.Location = new System.Drawing.Point(0, 0);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 1;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(800, 500);
            this.tblLayout.TabIndex = 0;

            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(248, 244, 255);
            this.pnlLeft.Controls.Add(this.chkDefault);
            this.pnlLeft.Controls.Add(this.btnEliminarIdioma);
            this.pnlLeft.Controls.Add(this.btnAgregarIdioma);
            this.pnlLeft.Controls.Add(this.txtCodigo);
            this.pnlLeft.Controls.Add(this.lblCodigo);
            this.pnlLeft.Controls.Add(this.txtNombre);
            this.pnlLeft.Controls.Add(this.lblNombre);
            this.pnlLeft.Controls.Add(this.lstIdiomas);
            this.pnlLeft.Controls.Add(this.lblIdiomasTitulo);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(15);
            this.pnlLeft.Size = new System.Drawing.Size(314, 494);
            this.pnlLeft.TabIndex = 0;

            this.chkDefault.AutoSize = true;
            this.chkDefault.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkDefault.ForeColor = System.Drawing.Color.FromArgb(38, 20, 70);
            this.chkDefault.Location = new System.Drawing.Point(18, 385);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(103, 21);
            this.chkDefault.TabIndex = 8;
            this.chkDefault.Text = "Por defecto";
            this.chkDefault.UseVisualStyleBackColor = true;

            this.btnEliminarIdioma.BackColor = System.Drawing.Color.FromArgb(229, 115, 115);
            this.btnEliminarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarIdioma.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminarIdioma.ForeColor = System.Drawing.Color.White;
            this.btnEliminarIdioma.Location = new System.Drawing.Point(18, 235);
            this.btnEliminarIdioma.Name = "btnEliminarIdioma";
            this.btnEliminarIdioma.Size = new System.Drawing.Size(278, 30);
            this.btnEliminarIdioma.TabIndex = 7;
            this.btnEliminarIdioma.Text = "Eliminar seleccionado";
            this.btnEliminarIdioma.UseVisualStyleBackColor = false;

            this.btnAgregarIdioma.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnAgregarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarIdioma.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAgregarIdioma.ForeColor = System.Drawing.Color.White;
            this.btnAgregarIdioma.Location = new System.Drawing.Point(18, 415);
            this.btnAgregarIdioma.Name = "btnAgregarIdioma";
            this.btnAgregarIdioma.Size = new System.Drawing.Size(278, 32);
            this.btnAgregarIdioma.TabIndex = 6;
            this.btnAgregarIdioma.Text = "Agregar idioma";
            this.btnAgregarIdioma.UseVisualStyleBackColor = false;

            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCodigo.Location = new System.Drawing.Point(18, 350);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(278, 24);
            this.txtCodigo.TabIndex = 5;

            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblCodigo.Location = new System.Drawing.Point(18, 330);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 15);
            this.lblCodigo.TabIndex = 4;
            this.lblCodigo.Text = "Código";

            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombre.Location = new System.Drawing.Point(18, 295);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(278, 24);
            this.txtNombre.TabIndex = 3;

            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblNombre.Location = new System.Drawing.Point(18, 275);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(53, 15);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";

            this.lstIdiomas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstIdiomas.ForeColor = System.Drawing.Color.FromArgb(38, 20, 70);
            this.lstIdiomas.FormattingEnabled = true;
            this.lstIdiomas.ItemHeight = 17;
            this.lstIdiomas.Location = new System.Drawing.Point(18, 48);
            this.lstIdiomas.Name = "lstIdiomas";
            this.lstIdiomas.Size = new System.Drawing.Size(278, 174);
            this.lstIdiomas.TabIndex = 1;

            this.lblIdiomasTitulo.AutoSize = true;
            this.lblIdiomasTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblIdiomasTitulo.ForeColor = System.Drawing.Color.FromArgb(94, 58, 160);
            this.lblIdiomasTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblIdiomasTitulo.Name = "lblIdiomasTitulo";
            this.lblIdiomasTitulo.Size = new System.Drawing.Size(71, 21);
            this.lblIdiomasTitulo.TabIndex = 0;
            this.lblIdiomasTitulo.Text = "Idiomas";

            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.btnGuardarTraducciones);
            this.pnlRight.Controls.Add(this.dgvTraducciones);
            this.pnlRight.Controls.Add(this.cboIdiomaDestino);
            this.pnlRight.Controls.Add(this.lblIdiomaDestino);
            this.pnlRight.Controls.Add(this.lblTraduccionesTitulo);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(323, 3);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(15);
            this.pnlRight.Size = new System.Drawing.Size(474, 494);
            this.pnlRight.TabIndex = 1;

            this.btnGuardarTraducciones.BackColor = System.Drawing.Color.FromArgb(126, 87, 194);
            this.btnGuardarTraducciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarTraducciones.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarTraducciones.ForeColor = System.Drawing.Color.White;
            this.btnGuardarTraducciones.Location = new System.Drawing.Point(18, 445);
            this.btnGuardarTraducciones.Name = "btnGuardarTraducciones";
            this.btnGuardarTraducciones.Size = new System.Drawing.Size(438, 32);
            this.btnGuardarTraducciones.TabIndex = 4;
            this.btnGuardarTraducciones.Text = "Guardar traducciones";
            this.btnGuardarTraducciones.UseVisualStyleBackColor = false;

            this.dgvTraducciones.BackgroundColor = System.Drawing.Color.FromArgb(248, 244, 255);
            this.dgvTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraducciones.Location = new System.Drawing.Point(18, 90);
            this.dgvTraducciones.Name = "dgvTraducciones";
            this.dgvTraducciones.Size = new System.Drawing.Size(438, 345);
            this.dgvTraducciones.TabIndex = 3;

            this.cboIdiomaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdiomaDestino.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboIdiomaDestino.FormattingEnabled = true;
            this.cboIdiomaDestino.Location = new System.Drawing.Point(150, 48);
            this.cboIdiomaDestino.Name = "cboIdiomaDestino";
            this.cboIdiomaDestino.Size = new System.Drawing.Size(306, 25);
            this.cboIdiomaDestino.TabIndex = 2;

            this.lblIdiomaDestino.AutoSize = true;
            this.lblIdiomaDestino.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblIdiomaDestino.ForeColor = System.Drawing.Color.FromArgb(110, 85, 150);
            this.lblIdiomaDestino.Location = new System.Drawing.Point(18, 51);
            this.lblIdiomaDestino.Name = "lblIdiomaDestino";
            this.lblIdiomaDestino.Size = new System.Drawing.Size(107, 17);
            this.lblIdiomaDestino.TabIndex = 1;
            this.lblIdiomaDestino.Text = "Idioma a traducir";

            this.lblTraduccionesTitulo.AutoSize = true;
            this.lblTraduccionesTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTraduccionesTitulo.ForeColor = System.Drawing.Color.FromArgb(94, 58, 160);
            this.lblTraduccionesTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTraduccionesTitulo.Name = "lblTraduccionesTitulo";
            this.lblTraduccionesTitulo.Size = new System.Drawing.Size(111, 21);
            this.lblTraduccionesTitulo.TabIndex = 0;
            this.lblTraduccionesTitulo.Text = "Traducciones";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tblLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IdiomaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de Idiomas";
            this.tblLayout.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblIdiomasTitulo;
        private System.Windows.Forms.ListBox lstIdiomas;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnAgregarIdioma;
        private System.Windows.Forms.Button btnEliminarIdioma;
        private System.Windows.Forms.CheckBox chkDefault;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblTraduccionesTitulo;
        private System.Windows.Forms.Label lblIdiomaDestino;
        private System.Windows.Forms.ComboBox cboIdiomaDestino;
        private System.Windows.Forms.DataGridView dgvTraducciones;
        private System.Windows.Forms.Button btnGuardarTraducciones;
    }
}
