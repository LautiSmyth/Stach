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
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.pnlDerecha = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.chkHidePass = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
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
            this.pnlIzquierda.Controls.Add(this.lblBienvenida);
            this.pnlIzquierda.Controls.Add(this.lblTagline);
            this.pnlIzquierda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIzquierda.Location = new System.Drawing.Point(3, 3);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Padding = new System.Windows.Forms.Padding(34, 35, 34, 35);
            this.pnlIzquierda.Size = new System.Drawing.Size(302, 479);
            this.pnlIzquierda.TabIndex = 0;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBienvenida.Location = new System.Drawing.Point(34, 548);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(223, 69);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Sistema de\nGestión";
            // 
            // lblTagline
            // 
            this.lblTagline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTagline.Location = new System.Drawing.Point(34, 626);
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
            this.pnlCard.Controls.Add(this.btnSalir);
            this.pnlCard.Controls.Add(this.btnIngresar);
            this.pnlCard.Controls.Add(this.chkHidePass);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.lblPassword);
            this.pnlCard.Controls.Add(this.txtUsername);
            this.pnlCard.Controls.Add(this.lblUsername);
            this.pnlCard.Controls.Add(this.lblSubtitulo);
            this.pnlCard.Controls.Add(this.lblTitulo);
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Location = new System.Drawing.Point(63, 63);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(31, 28, 31, 28);
            this.pnlCard.Size = new System.Drawing.Size(331, 353);
            this.pnlCard.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(31, 277);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(266, 33);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Cancelar";
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIngresar.Location = new System.Drawing.Point(31, 233);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(266, 35);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // chkHidePass
            // 
            this.chkHidePass.AutoSize = true;
            this.chkHidePass.Checked = true;
            this.chkHidePass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHidePass.Location = new System.Drawing.Point(31, 200);
            this.chkHidePass.Name = "chkHidePass";
            this.chkHidePass.Size = new System.Drawing.Size(116, 17);
            this.chkHidePass.TabIndex = 2;
            this.chkHidePass.Text = "Ocultar contraseña";
            this.chkHidePass.CheckedChanged += new System.EventHandler(this.ChkHidePass_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(31, 164);
            this.txtPassword.MaxLength = 200;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(267, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(31, 145);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Contraseña";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(31, 105);
            this.txtUsername.MaxLength = 200;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(267, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUsername_KeyDown);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(31, 86);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(43, 13);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Usuario";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtitulo.Location = new System.Drawing.Point(31, 48);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(267, 19);
            this.lblSubtitulo.TabIndex = 7;
            this.lblSubtitulo.Text = "Ingrese sus credenciales para acceder";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Location = new System.Drawing.Point(31, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(266, 29);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Iniciar sesión";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 485);
            this.Controls.Add(this.tblRaiz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(688, 421);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión";
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
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.TableLayoutPanel pnlDerecha;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkHidePass;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;
    }
}
