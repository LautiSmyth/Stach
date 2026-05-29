using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public class InputDialog : Form
    {
        private readonly Label lblPrompt;
        private readonly TextBox txtInput;
        private readonly Button btnAccept;
        private readonly Button btnCancel;

        public string InputText => txtInput.Text;

        public InputDialog(string title, string prompt, bool isPassword = false)
        {
            this.Text = title;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(400, 150);

            lblPrompt = new Label
            {
                Text = prompt,
                Left = 20,
                Top = 20,
                Width = 360,
                Height = 30
            };

            txtInput = new TextBox
            {
                Left = 20,
                Top = 50,
                Width = 360,
                UseSystemPasswordChar = isPassword
            };

            btnAccept = new Button
            {
                Text = "Aceptar",
                Left = 210,
                Top = 90,
                Width = 80,
                DialogResult = DialogResult.OK
            };

            btnCancel = new Button
            {
                Text = "Cancelar",
                Left = 300,
                Top = 90,
                Width = 80,
                DialogResult = DialogResult.Cancel
            };

            this.Controls.Add(lblPrompt);
            this.Controls.Add(txtInput);
            this.Controls.Add(btnAccept);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnAccept;
            this.CancelButton = btnCancel;
        }
    }
}
