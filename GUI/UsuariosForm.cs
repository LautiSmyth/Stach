using Aplicacion;
using BE;
using BE.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            pnlEncabezado.BackColor = AppEstilo.ColorPrimarioUltraClaro;

            lblTituloGrilla.Font = AppEstilo.FuenteSubtitulo;
            lblTituloGrilla.ForeColor = AppEstilo.ColorPrimario;
            lblTituloGrilla.BackColor = Color.Transparent;

            AppEstilo.AplicarGrilla(dgvUsuarios);
            AppEstilo.AplicarGroupBox(grpAlta);
            AppEstilo.AplicarGroupBox(grpEstado);
            AppEstilo.AplicarTextBox(txtUsername);
            AppEstilo.AplicarTextBox(txtPassword);
            AppEstilo.AplicarComboBox(cboEstado);
            AppEstilo.AplicarBotonPrimario(btnCrear);
            AppEstilo.AplicarBotonPrimario(btnCambiarEstado);
            AppEstilo.AplicarBotonSecundario(btnRefrescar);

            AppEstilo.AplicarLabelNegrita(lblUsername);
            AppEstilo.AplicarLabelNegrita(lblPassword);
            AppEstilo.AplicarLabel(lblRequisitos, esSecundario: true);
            lblRequisitos.Font = AppEstilo.FuentePequena;

            AppEstilo.AplicarLabelNegrita(lblSeleccionado);
            lblNombreSeleccionado.Font = AppEstilo.FuenteNegrita;
            lblNombreSeleccionado.ForeColor = AppEstilo.ColorPrimario;
            lblNombreSeleccionado.BackColor = Color.Transparent;

            AppEstilo.AplicarLabelNegrita(lblEstado);

            tblInferior.BackColor = AppEstilo.ColorFondo;
            tblAlta.BackColor = Color.Transparent;
            tblEstado.BackColor = Color.Transparent;

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

                if (dgvUsuarios.Columns["IdUsuario"] != null)
                    dgvUsuarios.Columns["IdUsuario"].HeaderText = "ID";
                if (dgvUsuarios.Columns["Username"] != null)
                    dgvUsuarios.Columns["Username"].HeaderText = "Usuario";
                if (dgvUsuarios.Columns["Estado"] != null)
                    dgvUsuarios.Columns["Estado"].HeaderText = "Estado";
                if (dgvUsuarios.Columns["FechaAlta"] != null)
                    dgvUsuarios.Columns["FechaAlta"].HeaderText = "Fecha alta";
                if (dgvUsuarios.Columns["UltimoLogin"] != null)
                    dgvUsuarios.Columns["UltimoLogin"].HeaderText = "Último login";

                _columnasConfiguradas = true;
            }

            AplicarColorEstados();
        }

        private void AplicarColorEstados()
        {
            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
            {
                if (fila.DataBoundItem is Usuario u)
                {
                    switch (u.Estado)
                    {
                        case EstadoUsuario.Bloqueado:
                            fila.DefaultCellStyle.ForeColor = AppEstilo.ColorPeligro;
                            break;
                        case EstadoUsuario.Inactivo:
                            fila.DefaultCellStyle.ForeColor = AppEstilo.ColorTextoSecundario;
                            break;
                        default:
                            fila.DefaultCellStyle.ForeColor = AppEstilo.ColorTexto;
                            break;
                    }
                }
            }
        }

        private void DgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                _seleccionado = null;
                lblNombreSeleccionado.Text = "(ninguno)";
                return;
            }
            _seleccionado = dgvUsuarios.SelectedRows[0].DataBoundItem as Usuario;
            if (_seleccionado != null)
            {
                cboEstado.SelectedItem = _seleccionado.Estado;
                lblNombreSeleccionado.Text = _seleccionado.Username;
            }
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
                MessageBox.Show($"Usuario '{txtUsername.Text.Trim()}' creado correctamente.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
                CargarDatos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Seleccione un usuario de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EstadoUsuario nuevoEstado = (EstadoUsuario)cboEstado.SelectedItem;
            if (nuevoEstado == _seleccionado.Estado)
            {
                MessageBox.Show("El estado seleccionado ya es el actual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                _usuarioServicio.CambiarEstado(this.Text, _seleccionado.IdUsuario, nuevoEstado);
                MessageBox.Show("Estado actualizado correctamente.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
