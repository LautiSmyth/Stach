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
            // 
            // tblLayout
            // 
            this.tblLayout.ColumnCount = 2;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblLayout.Controls.Add(this.pnlLeft, 0, 0);
            this.tblLayout.Controls.Add(this.pnlRight, 1, 0);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.Location = new System.Drawing.Point(0, 0);
            this.tblLayout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 1;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(1067, 615);
            this.tblLayout.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
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
            this.pnlLeft.Location = new System.Drawing.Point(4, 4);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.pnlLeft.Size = new System.Drawing.Size(418, 607);
            this.pnlLeft.TabIndex = 0;
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkDefault.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.chkDefault.Location = new System.Drawing.Point(24, 474);
            this.chkDefault.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(110, 25);
            this.chkDefault.TabIndex = 4;
            this.chkDefault.Text = "Por defecto";
            this.chkDefault.UseVisualStyleBackColor = true;
            // 
            // btnEliminarIdioma
            // 
            this.btnEliminarIdioma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnEliminarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarIdioma.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminarIdioma.ForeColor = System.Drawing.Color.White;
            this.btnEliminarIdioma.Location = new System.Drawing.Point(24, 289);
            this.btnEliminarIdioma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminarIdioma.Name = "btnEliminarIdioma";
            this.btnEliminarIdioma.Size = new System.Drawing.Size(371, 37);
            this.btnEliminarIdioma.TabIndex = 1;
            this.btnEliminarIdioma.Text = "Eliminar seleccionado";
            this.btnEliminarIdioma.UseVisualStyleBackColor = false;
            this.btnEliminarIdioma.Click += new System.EventHandler(this.BtnEliminarIdioma_Click);
            // 
            // btnAgregarIdioma
            // 
            this.btnAgregarIdioma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnAgregarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarIdioma.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAgregarIdioma.ForeColor = System.Drawing.Color.White;
            this.btnAgregarIdioma.Location = new System.Drawing.Point(24, 511);
            this.btnAgregarIdioma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarIdioma.Name = "btnAgregarIdioma";
            this.btnAgregarIdioma.Size = new System.Drawing.Size(371, 39);
            this.btnAgregarIdioma.TabIndex = 5;
            this.btnAgregarIdioma.Text = "Agregar idioma";
            this.btnAgregarIdioma.UseVisualStyleBackColor = false;
            this.btnAgregarIdioma.Click += new System.EventHandler(this.BtnAgregarIdioma_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCodigo.Location = new System.Drawing.Point(24, 431);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(369, 29);
            this.txtCodigo.TabIndex = 3;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.lblCodigo.Location = new System.Drawing.Point(24, 406);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(58, 20);
            this.lblCodigo.TabIndex = 4;
            this.lblCodigo.Text = "Código";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombre.Location = new System.Drawing.Point(24, 363);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(369, 29);
            this.txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.lblNombre.Location = new System.Drawing.Point(24, 338);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(67, 20);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // lstIdiomas
            // 
            this.lstIdiomas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstIdiomas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lstIdiomas.FormattingEnabled = true;
            this.lstIdiomas.ItemHeight = 21;
            this.lstIdiomas.Location = new System.Drawing.Point(24, 59);
            this.lstIdiomas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstIdiomas.Name = "lstIdiomas";
            this.lstIdiomas.Size = new System.Drawing.Size(369, 193);
            this.lstIdiomas.TabIndex = 0;
            this.lstIdiomas.SelectedIndexChanged += new System.EventHandler(this.LstIdiomas_SelectedIndexChanged);
            // 
            // lblIdiomasTitulo
            // 
            this.lblIdiomasTitulo.AutoSize = true;
            this.lblIdiomasTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblIdiomasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(58)))), ((int)(((byte)(160)))));
            this.lblIdiomasTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblIdiomasTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdiomasTitulo.Name = "lblIdiomasTitulo";
            this.lblIdiomasTitulo.Size = new System.Drawing.Size(86, 28);
            this.lblIdiomasTitulo.TabIndex = 0;
            this.lblIdiomasTitulo.Text = "Idiomas";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.btnGuardarTraducciones);
            this.pnlRight.Controls.Add(this.dgvTraducciones);
            this.pnlRight.Controls.Add(this.cboIdiomaDestino);
            this.pnlRight.Controls.Add(this.lblIdiomaDestino);
            this.pnlRight.Controls.Add(this.lblTraduccionesTitulo);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(430, 4);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.pnlRight.Size = new System.Drawing.Size(633, 607);
            this.pnlRight.TabIndex = 1;
            // 
            // btnGuardarTraducciones
            // 
            this.btnGuardarTraducciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnGuardarTraducciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarTraducciones.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarTraducciones.ForeColor = System.Drawing.Color.White;
            this.btnGuardarTraducciones.Location = new System.Drawing.Point(24, 548);
            this.btnGuardarTraducciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardarTraducciones.Name = "btnGuardarTraducciones";
            this.btnGuardarTraducciones.Size = new System.Drawing.Size(584, 39);
            this.btnGuardarTraducciones.TabIndex = 2;
            this.btnGuardarTraducciones.Text = "Guardar traducciones";
            this.btnGuardarTraducciones.UseVisualStyleBackColor = false;
            this.btnGuardarTraducciones.Click += new System.EventHandler(this.BtnGuardarTraducciones_Click);
            // 
            // dgvTraducciones
            // 
            this.dgvTraducciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.dgvTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraducciones.Location = new System.Drawing.Point(24, 111);
            this.dgvTraducciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTraducciones.Name = "dgvTraducciones";
            this.dgvTraducciones.RowHeadersWidth = 51;
            this.dgvTraducciones.Size = new System.Drawing.Size(584, 425);
            this.dgvTraducciones.TabIndex = 1;
            // 
            // cboIdiomaDestino
            // 
            this.cboIdiomaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdiomaDestino.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboIdiomaDestino.FormattingEnabled = true;
            this.cboIdiomaDestino.Location = new System.Drawing.Point(200, 59);
            this.cboIdiomaDestino.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboIdiomaDestino.Name = "cboIdiomaDestino";
            this.cboIdiomaDestino.Size = new System.Drawing.Size(407, 29);
            this.cboIdiomaDestino.TabIndex = 0;
            this.cboIdiomaDestino.SelectedIndexChanged += new System.EventHandler(this.CboIdiomaDestino_SelectedIndexChanged);
            // 
            // lblIdiomaDestino
            // 
            this.lblIdiomaDestino.AutoSize = true;
            this.lblIdiomaDestino.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblIdiomaDestino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.lblIdiomaDestino.Location = new System.Drawing.Point(24, 63);
            this.lblIdiomaDestino.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdiomaDestino.Name = "lblIdiomaDestino";
            this.lblIdiomaDestino.Size = new System.Drawing.Size(141, 21);
            this.lblIdiomaDestino.TabIndex = 1;
            this.lblIdiomaDestino.Text = "Idioma a traducir";
            // 
            // lblTraduccionesTitulo
            // 
            this.lblTraduccionesTitulo.AutoSize = true;
            this.lblTraduccionesTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTraduccionesTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(58)))), ((int)(((byte)(160)))));
            this.lblTraduccionesTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTraduccionesTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTraduccionesTitulo.Name = "lblTraduccionesTitulo";
            this.lblTraduccionesTitulo.Size = new System.Drawing.Size(135, 28);
            this.lblTraduccionesTitulo.TabIndex = 0;
            this.lblTraduccionesTitulo.Text = "Traducciones";
            // 
            // IdiomaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 615);
            this.Controls.Add(this.tblLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IdiomaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de Idiomas";
            this.Load += new System.EventHandler(this.IdiomaForm_Load);
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
