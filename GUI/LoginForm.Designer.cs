namespace GUI
{
    partial class LoginForm
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
            this.tblRaiz = new System.Windows.Forms.TableLayoutPanel();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.lblStach = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.pnlDerecha = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblErrorValidacion = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.chkHidePass = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cboIdioma = new System.Windows.Forms.ComboBox();
            this.tblRaiz.SuspendLayout();
            this.pnlIzquierda.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblRaiz
            // 
            this.tblRaiz.ColumnCount = 2;
            this.tblRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblRaiz.Controls.Add(this.pnlIzquierda, 0, 0);
            this.tblRaiz.Controls.Add(this.pnlDerecha, 1, 0);
            this.tblRaiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRaiz.Location = new System.Drawing.Point(0, 0);
            this.tblRaiz.Name = "tblRaiz";
            this.tblRaiz.RowCount = 1;
            this.tblRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRaiz.Size = new System.Drawing.Size(771, 485);
            this.tblRaiz.TabIndex = 0;
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.pnlIzquierda.Controls.Add(this.lblStach);
            this.pnlIzquierda.Controls.Add(this.lblBienvenida);
            this.pnlIzquierda.Controls.Add(this.lblTagline);
            this.pnlIzquierda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIzquierda.Location = new System.Drawing.Point(3, 3);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Padding = new System.Windows.Forms.Padding(34, 35, 34, 35);
            this.pnlIzquierda.Size = new System.Drawing.Size(302, 479);
            this.pnlIzquierda.TabIndex = 0;
            // 
            // lblStach
            // 
            this.lblStach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStach.BackColor = System.Drawing.Color.Transparent;
            this.lblStach.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblStach.ForeColor = System.Drawing.Color.White;
            this.lblStach.Location = new System.Drawing.Point(28, 280);
            this.lblStach.Name = "lblStach";
            this.lblStach.Size = new System.Drawing.Size(229, 50);
            this.lblStach.TabIndex = 2;
            this.lblStach.Text = "Stach";
            this.lblStach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBienvenida.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.White;
            this.lblBienvenida.Location = new System.Drawing.Point(34, 335);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(223, 70);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Sistema de\nGestión";
            // 
            // lblTagline
            // 
            this.lblTagline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTagline.BackColor = System.Drawing.Color.Transparent;
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.lblTagline.Location = new System.Drawing.Point(34, 418);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(223, 52);
            this.lblTagline.TabIndex = 1;
            this.lblTagline.Text = "Acceso seguro y centralizado\na todos los módulos";
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.ColumnCount = 3;
            this.pnlDerecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.pnlDerecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlDerecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.pnlDerecha.Controls.Add(this.pnlCard, 1, 1);
            this.pnlDerecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDerecha.Location = new System.Drawing.Point(311, 3);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.RowCount = 3;
            this.pnlDerecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.pnlDerecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlDerecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.pnlDerecha.Size = new System.Drawing.Size(457, 479);
            this.pnlDerecha.TabIndex = 1;
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblErrorValidacion);
            this.pnlCard.Controls.Add(this.btnSalir);
            this.pnlCard.Controls.Add(this.btnIngresar);
            this.pnlCard.Controls.Add(this.chkHidePass);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.lblPassword);
            this.pnlCard.Controls.Add(this.txtUsername);
            this.pnlCard.Controls.Add(this.lblUsername);
            this.pnlCard.Controls.Add(this.lblSubtitulo);
            this.pnlCard.Controls.Add(this.lblTitulo);
            this.pnlCard.Controls.Add(this.cboIdioma);
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Location = new System.Drawing.Point(63, 63);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(31, 28, 31, 28);
            this.pnlCard.Size = new System.Drawing.Size(331, 353);
            this.pnlCard.TabIndex = 0;
            // 
            // lblErrorValidacion
            // 
            this.lblErrorValidacion.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorValidacion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblErrorValidacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.lblErrorValidacion.Location = new System.Drawing.Point(31, 180);
            this.lblErrorValidacion.Name = "lblErrorValidacion";
            this.lblErrorValidacion.Size = new System.Drawing.Size(266, 36);
            this.lblErrorValidacion.TabIndex = 9;
            this.lblErrorValidacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(231)))), ((int)(((byte)(249)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(182)))), ((int)(((byte)(228)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnSalir.Location = new System.Drawing.Point(31, 265);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(266, 33);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Cancelar";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // cboIdioma
            // 
            this.cboIdioma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboIdioma.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboIdioma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.cboIdioma.Location = new System.Drawing.Point(31, 308);
            this.cboIdioma.Name = "cboIdioma";
            this.cboIdioma.Size = new System.Drawing.Size(266, 25);
            this.cboIdioma.TabIndex = 5;
            this.cboIdioma.SelectedIndexChanged += new System.EventHandler(this.CboIdioma_SelectedIndexChanged);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(58)))), ((int)(((byte)(160)))));
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(31, 222);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(266, 35);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // chkHidePass
            // 
            this.chkHidePass.AutoSize = true;
            this.chkHidePass.BackColor = System.Drawing.Color.Transparent;
            this.chkHidePass.Checked = true;
            this.chkHidePass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHidePass.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkHidePass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.chkHidePass.Location = new System.Drawing.Point(31, 158);
            this.chkHidePass.Name = "chkHidePass";
            this.chkHidePass.Size = new System.Drawing.Size(137, 21);
            this.chkHidePass.TabIndex = 2;
            this.chkHidePass.Text = "Ocultar contraseña";
            this.chkHidePass.UseVisualStyleBackColor = false;
            this.chkHidePass.CheckedChanged += new System.EventHandler(this.ChkHidePass_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtPassword.Location = new System.Drawing.Point(31, 128);
            this.txtPassword.MaxLength = 200;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(267, 24);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblPassword.Location = new System.Drawing.Point(31, 110);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(77, 17);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Contraseña";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.txtUsername.Location = new System.Drawing.Point(31, 81);
            this.txtUsername.MaxLength = 200;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(267, 24);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUsername_KeyDown);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.lblUsername.Location = new System.Drawing.Point(31, 63);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 17);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Usuario";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(31, 39);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(267, 19);
            this.lblSubtitulo.TabIndex = 7;
            this.lblSubtitulo.Text = "Ingrese sus credenciales para acceder";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.lblTitulo.Location = new System.Drawing.Point(31, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(266, 24);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Iniciar sesión";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(771, 485);
            this.Controls.Add(this.tblRaiz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(688, 421);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stach - Iniciar sesión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.tblRaiz.ResumeLayout(false);
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlDerecha.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tblRaiz;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Label lblStach;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.TableLayoutPanel pnlDerecha;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblErrorValidacion;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkHidePass;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cboIdioma;
    }
}
