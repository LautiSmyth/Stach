namespace GUI
{
    partial class MisPermisosForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tblRaiz = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.tvDirectos = new System.Windows.Forms.TreeView();
            this.lblDirectos = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lstResueltos = new System.Windows.Forms.ListBox();
            this.lblResueltos = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.tblRaiz.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(600, 50);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(600, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "  Mis Roles y Permisos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.tblRaiz.ColumnCount = 2;
            this.tblRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblRaiz.Controls.Add(this.pnlLeft, 0, 0);
            this.tblRaiz.Controls.Add(this.pnlRight, 1, 0);
            this.tblRaiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRaiz.Location = new System.Drawing.Point(0, 50);
            this.tblRaiz.Name = "tblRaiz";
            this.tblRaiz.RowCount = 1;
            this.tblRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRaiz.Size = new System.Drawing.Size(600, 350);
            this.tblRaiz.TabIndex = 1;

            this.pnlLeft.Controls.Add(this.tvDirectos);
            this.pnlLeft.Controls.Add(this.lblDirectos);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(10, 10);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(10);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(280, 330);
            this.pnlLeft.TabIndex = 0;

            this.tvDirectos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvDirectos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDirectos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tvDirectos.Location = new System.Drawing.Point(0, 25);
            this.tvDirectos.Name = "tvDirectos";
            this.tvDirectos.Size = new System.Drawing.Size(280, 305);
            this.tvDirectos.TabIndex = 1;

            this.lblDirectos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDirectos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDirectos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.lblDirectos.Location = new System.Drawing.Point(0, 0);
            this.lblDirectos.Name = "lblDirectos";
            this.lblDirectos.Size = new System.Drawing.Size(280, 25);
            this.lblDirectos.TabIndex = 0;
            this.lblDirectos.Text = "Roles y Permisos Asignados";

            this.pnlRight.Controls.Add(this.lstResueltos);
            this.pnlRight.Controls.Add(this.lblResueltos);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(310, 10);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(10);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(280, 330);
            this.pnlRight.TabIndex = 1;

            this.lstResueltos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstResueltos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResueltos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstResueltos.FormattingEnabled = true;
            this.lstResueltos.ItemHeight = 15;
            this.lstResueltos.Location = new System.Drawing.Point(0, 25);
            this.lstResueltos.Name = "lstResueltos";
            this.lstResueltos.Size = new System.Drawing.Size(280, 305);
            this.lstResueltos.TabIndex = 1;

            this.lblResueltos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResueltos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResueltos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.lblResueltos.Location = new System.Drawing.Point(0, 0);
            this.lblResueltos.Name = "lblResueltos";
            this.lblResueltos.Size = new System.Drawing.Size(280, 25);
            this.lblResueltos.TabIndex = 0;
            this.lblResueltos.Text = "Permisos Finales (Resueltos)";

            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pnlBottom.Controls.Add(this.btnCerrar);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 400);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(600, 50);
            this.pnlBottom.TabIndex = 2;

            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(480, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 30);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.tblRaiz);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MisPermisosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mis Permisos y Roles";
            this.Load += new System.EventHandler(this.MisPermisosForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.tblRaiz.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TableLayoutPanel tblRaiz;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.TreeView tvDirectos;
        private System.Windows.Forms.Label lblDirectos;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.ListBox lstResueltos;
        private System.Windows.Forms.Label lblResueltos;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCerrar;
    }
}
