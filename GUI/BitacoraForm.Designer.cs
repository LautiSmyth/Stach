namespace GUI
{
    partial class BitacoraForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.flpFila2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkExitoso = new System.Windows.Forms.CheckBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.flpFila1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.chkUsername = new System.Windows.Forms.CheckBox();
            this.chkDetalle = new System.Windows.Forms.CheckBox();
            this.chkError = new System.Windows.Forms.CheckBox();
            this.lblCriticidad = new System.Windows.Forms.Label();
            this.cboCriticidad = new System.Windows.Forms.ComboBox();
            this.lblActividad = new System.Windows.Forms.Label();
            this.cboActividad = new System.Windows.Forms.ComboBox();
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.pnlEstado = new System.Windows.Forms.Panel();
            this.lblContador = new System.Windows.Forms.Label();
            this.pnlFiltros.SuspendLayout();
            this.flpFila2.SuspendLayout();
            this.flpFila1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.pnlEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.flpFila2);
            this.pnlFiltros.Controls.Add(this.flpFila1);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1024, 74);
            this.pnlFiltros.TabIndex = 0;
            // 
            // flpFila2
            // 
            this.flpFila2.Controls.Add(this.chkExitoso);
            this.flpFila2.Controls.Add(this.lblDesde);
            this.flpFila2.Controls.Add(this.dtpDesde);
            this.flpFila2.Controls.Add(this.lblHasta);
            this.flpFila2.Controls.Add(this.dtpHasta);
            this.flpFila2.Controls.Add(this.btnLimpiar);
            this.flpFila2.Controls.Add(this.btnBuscar);
            this.flpFila2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFila2.Location = new System.Drawing.Point(0, 31);
            this.flpFila2.Name = "flpFila2";
            this.flpFila2.Padding = new System.Windows.Forms.Padding(12, 4, 12, 0);
            this.flpFila2.Size = new System.Drawing.Size(1024, 40);
            this.flpFila2.TabIndex = 1;
            this.flpFila2.WrapContents = false;
            // 
            // chkExitoso
            // 
            this.chkExitoso.AutoSize = true;
            this.chkExitoso.Checked = true;
            this.chkExitoso.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkExitoso.Location = new System.Drawing.Point(12, 12);
            this.chkExitoso.Margin = new System.Windows.Forms.Padding(0, 8, 12, 0);
            this.chkExitoso.Name = "chkExitoso";
            this.chkExitoso.Size = new System.Drawing.Size(60, 17);
            this.chkExitoso.TabIndex = 0;
            this.chkExitoso.Text = "Exitoso";
            this.chkExitoso.ThreeState = true;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(84, 12);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(0, 8, 3, 0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 1;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(128, 9);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(0, 5, 8, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 2;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(236, 12);
            this.lblHasta.Margin = new System.Windows.Forms.Padding(0, 8, 3, 0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 3;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(277, 9);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(0, 5, 12, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 4;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(389, 7);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(0, 3, 4, 0);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 30);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(468, 7);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 30);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // flpFila1
            // 
            this.flpFila1.Controls.Add(this.lblBuscar);
            this.flpFila1.Controls.Add(this.txtBuscar);
            this.flpFila1.Controls.Add(this.chkUsername);
            this.flpFila1.Controls.Add(this.chkDetalle);
            this.flpFila1.Controls.Add(this.chkError);
            this.flpFila1.Controls.Add(this.lblCriticidad);
            this.flpFila1.Controls.Add(this.cboCriticidad);
            this.flpFila1.Controls.Add(this.lblActividad);
            this.flpFila1.Controls.Add(this.cboActividad);
            this.flpFila1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFila1.Location = new System.Drawing.Point(0, 0);
            this.flpFila1.Name = "flpFila1";
            this.flpFila1.Padding = new System.Windows.Forms.Padding(12, 4, 12, 0);
            this.flpFila1.Size = new System.Drawing.Size(1024, 31);
            this.flpFila1.TabIndex = 0;
            this.flpFila1.WrapContents = false;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(12, 9);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(0, 5, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(43, 13);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(58, 6);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(0, 2, 8, 0);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(150, 20);
            this.txtBuscar.TabIndex = 1;
            // 
            // chkUsername
            // 
            this.chkUsername.AutoSize = true;
            this.chkUsername.Checked = true;
            this.chkUsername.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUsername.Location = new System.Drawing.Point(216, 8);
            this.chkUsername.Margin = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.chkUsername.Name = "chkUsername";
            this.chkUsername.Size = new System.Drawing.Size(74, 17);
            this.chkUsername.TabIndex = 2;
            this.chkUsername.Text = "Username";
            // 
            // chkDetalle
            // 
            this.chkDetalle.AutoSize = true;
            this.chkDetalle.Checked = true;
            this.chkDetalle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDetalle.Location = new System.Drawing.Point(294, 8);
            this.chkDetalle.Margin = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.chkDetalle.Name = "chkDetalle";
            this.chkDetalle.Size = new System.Drawing.Size(59, 17);
            this.chkDetalle.TabIndex = 3;
            this.chkDetalle.Text = "Detalle";
            // 
            // chkError
            // 
            this.chkError.AutoSize = true;
            this.chkError.Location = new System.Drawing.Point(357, 8);
            this.chkError.Margin = new System.Windows.Forms.Padding(0, 4, 12, 0);
            this.chkError.Name = "chkError";
            this.chkError.Size = new System.Drawing.Size(48, 17);
            this.chkError.TabIndex = 4;
            this.chkError.Text = "Error";
            // 
            // lblCriticidad
            // 
            this.lblCriticidad.AutoSize = true;
            this.lblCriticidad.Location = new System.Drawing.Point(417, 9);
            this.lblCriticidad.Margin = new System.Windows.Forms.Padding(0, 5, 3, 0);
            this.lblCriticidad.Name = "lblCriticidad";
            this.lblCriticidad.Size = new System.Drawing.Size(53, 13);
            this.lblCriticidad.TabIndex = 5;
            this.lblCriticidad.Text = "Criticidad:";
            // 
            // cboCriticidad
            // 
            this.cboCriticidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCriticidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCriticidad.Location = new System.Drawing.Point(473, 6);
            this.cboCriticidad.Margin = new System.Windows.Forms.Padding(0, 2, 12, 0);
            this.cboCriticidad.Name = "cboCriticidad";
            this.cboCriticidad.Size = new System.Drawing.Size(100, 21);
            this.cboCriticidad.TabIndex = 6;
            // 
            // lblActividad
            // 
            this.lblActividad.AutoSize = true;
            this.lblActividad.Location = new System.Drawing.Point(585, 9);
            this.lblActividad.Margin = new System.Windows.Forms.Padding(0, 5, 3, 0);
            this.lblActividad.Name = "lblActividad";
            this.lblActividad.Size = new System.Drawing.Size(54, 13);
            this.lblActividad.TabIndex = 7;
            this.lblActividad.Text = "Actividad:";
            // 
            // cboActividad
            // 
            this.cboActividad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboActividad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboActividad.Location = new System.Drawing.Point(642, 6);
            this.cboActividad.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.cboActividad.Name = "cboActividad";
            this.cboActividad.Size = new System.Drawing.Size(110, 21);
            this.cboActividad.TabIndex = 8;
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.AllowUserToAddRows = false;
            this.dgvBitacora.AllowUserToDeleteRows = false;
            this.dgvBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBitacora.Location = new System.Drawing.Point(0, 74);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.ReadOnly = true;
            this.dgvBitacora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBitacora.Size = new System.Drawing.Size(1024, 502);
            this.dgvBitacora.TabIndex = 1;
            // 
            // pnlEstado
            // 
            this.pnlEstado.Controls.Add(this.lblContador);
            this.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEstado.Location = new System.Drawing.Point(0, 576);
            this.pnlEstado.Name = "pnlEstado";
            this.pnlEstado.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.pnlEstado.Size = new System.Drawing.Size(1024, 24);
            this.pnlEstado.TabIndex = 2;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblContador.Location = new System.Drawing.Point(12, 4);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(108, 13);
            this.lblContador.TabIndex = 0;
            this.lblContador.Text = "Mostrando 0 registros";
            // 
            // BitacoraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.dgvBitacora);
            this.Controls.Add(this.pnlEstado);
            this.Controls.Add(this.pnlFiltros);
            this.Name = "BitacoraForm";
            this.Text = "Bitácora";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BitacoraForm_Load);
            this.Shown += new System.EventHandler(this.BitacoraForm_Shown);
            this.pnlFiltros.ResumeLayout(false);
            this.flpFila2.ResumeLayout(false);
            this.flpFila2.PerformLayout();
            this.flpFila1.ResumeLayout(false);
            this.flpFila1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.pnlEstado.ResumeLayout(false);
            this.pnlEstado.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.FlowLayoutPanel flpFila1;
        private System.Windows.Forms.FlowLayoutPanel flpFila2;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.CheckBox chkUsername;
        private System.Windows.Forms.CheckBox chkDetalle;
        private System.Windows.Forms.CheckBox chkError;
        private System.Windows.Forms.Label lblCriticidad;
        private System.Windows.Forms.ComboBox cboCriticidad;
        private System.Windows.Forms.Label lblActividad;
        private System.Windows.Forms.ComboBox cboActividad;
        private System.Windows.Forms.CheckBox chkExitoso;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel pnlEstado;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.DataGridView dgvBitacora;
    }
}
