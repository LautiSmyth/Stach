using Aplicacion;
using BE;
using BE.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class UsuariosForm : Form
    {
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();
        private List<Usuario> _usuarios;
        private Usuario _seleccionado;
        private bool _columnasConfiguradas = false;

        public UsuariosForm()
        {
            InitializeComponent();
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            this.BackColor = AppEstilo.ColorFondo;
            AppEstilo.AplicarGrilla(dgvUsuarios);
            AppEstilo.AplicarGroupBox(grpAlta);
            AppEstilo.AplicarGroupBox(grpEstado);
            AppEstilo.AplicarTextBox(txtUsername);
            AppEstilo.AplicarTextBox(txtPassword);
            AppEstilo.AplicarComboBox(cboEstado);
            AppEstilo.AplicarBotonPrimario(btnCrear);
            AppEstilo.AplicarBotonPrimario(btnCambiarEstado);
            AppEstilo.AplicarBotonSecundario(btnRefrescar);

            foreach (Label lbl in new[] { lblUsername, lblPassword, lblEstado })
            {
                lbl.ForeColor = AppEstilo.ColorTexto;
                lbl.Font = AppEstilo.FuenteNormal;
            }

            cboEstado.DataSource = Enum.GetValues(typeof(EstadoUsuario));
            CargarDatos();
        }

        private void UsuariosForm_Shown(object sender, EventArgs e)
        {
            splitPrincipal.SplitterDistance = (int)(this.ClientSize.Height * 0.60);
        }

        private void CargarDatos()
        {
            _usuarios = _usuarioServicio.ObtenerTodos();
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = _usuarios;

            if (!_columnasConfiguradas && dgvUsuarios.Columns.Count > 0)
            {
                dgvUsuarios.Columns["PasswordHash"].Visible = false;
                dgvUsuarios.Columns["IntentosFallidos"].Visible = false;
                dgvUsuarios.Columns["CantidadBloqueos"].Visible = false;
                dgvUsuarios.Columns["FechaBloqueo"].Visible = false;
                _columnasConfiguradas = true;
            }
        }

        private void DgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                _seleccionado = null;
                return;
            }
            _seleccionado = dgvUsuarios.SelectedRows[0].DataBoundItem as Usuario;
            if (_seleccionado != null)
                cboEstado.SelectedItem = _seleccionado.Estado;
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Complete todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _usuarioServicio.Alta(this.Text, txtUsername.Text.Trim(), txtPassword.Text);
                MessageBox.Show($"Usuario '{txtUsername.Text}' creado.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Text = "";
                txtPassword.Text = "";
                CargarDatos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (_seleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EstadoUsuario nuevoEstado = (EstadoUsuario)cboEstado.SelectedItem;
            if (nuevoEstado == _seleccionado.Estado)
            {
                MessageBox.Show("El estado ya es el seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                _usuarioServicio.CambiarEstado(this.Text, _seleccionado.IdUsuario, nuevoEstado);
                MessageBox.Show("Estado actualizado.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
