using Aplicacion;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class RestauracionForm : Form
    {
        private readonly DigitoVerificadorServicio _dvServicio = new DigitoVerificadorServicio();
        private readonly List<string> _errores;

        public bool RestauradoExitosamente { get; private set; }

        public RestauracionForm(List<string> errores)
        {
            InitializeComponent();
            _errores = errores;
            RestauradoExitosamente = false;
        }

        private void RestauracionForm_Load(object sender, EventArgs e)
        {
            lstErrores.Items.Clear();
            foreach (var err in _errores)
            {
                lstErrores.Items.Add(err);
            }
        }

        private void BtnRecalcular_Click(object sender, EventArgs e)
        {
            using (ConfirmarAdminForm loginForm = new ConfirmarAdminForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK && loginForm.Autorizado)
                {
                    try
                    {
                        _dvServicio.InicializarDVs();
                        MessageBox.Show("Dígitos verificadores recalculados y restaurados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RestauradoExitosamente = true;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al restaurar integridad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
