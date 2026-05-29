using BE;
using BE.Enums;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class UsuariosForm : Form, IObserver
    {
        private readonly UsuarioBLL _usuarioBll = IoCContainer.Resolver<UsuarioBLL>();
        private List<Usuario> _usuarios;
        private Usuario _seleccionado;
        private bool _cargandoSeleccion = false;
        private bool _deseleccionarEnClick = false;

        public UsuariosForm()
        {
            InitializeComponent();
            ManejadorIdioma.Instancia.Attach(this);
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            txtUsername.MaxLength = 100;
            cboEstado.DataSource = Enum.GetValues(typeof(EstadoUsuario));
            CargarDatos();
            ActualizarIdioma();
        }

        private void TxtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UsuariosForm_Shown(object sender, EventArgs e)
        {
            splitPrincipal.SplitterDistance = 600;
        }

        private void CargarDatos()
        {
            _usuarios = _usuarioBll.ObtenerTodos();
            FiltrarGrilla();
        }

        private void FiltrarGrilla()
        {
            if (_usuarios == null) return;
            string fil = txtBuscarUsuario.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(fil))
            {
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = _usuarios;
            }
            else
            {
                var filtrados = _usuarios.FindAll(u => u.Username.ToLower().Contains(fil));
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = filtrados;
            }
            AplicarFormatoGrilla();
        }

        private void AplicarFormatoGrilla()
        {
            if (dgvUsuarios.Columns.Count > 0)
            {
                if (dgvUsuarios.Columns["PasswordHash"] != null) dgvUsuarios.Columns["PasswordHash"].Visible = false;
                if (dgvUsuarios.Columns["IntentosFallidos"] != null) dgvUsuarios.Columns["IntentosFallidos"].Visible = false;
                if (dgvUsuarios.Columns["CantidadBloqueos"] != null) dgvUsuarios.Columns["CantidadBloqueos"].Visible = false;
                if (dgvUsuarios.Columns["FechaBloqueo"] != null) dgvUsuarios.Columns["FechaBloqueo"].Visible = false;
                if (dgvUsuarios.Columns["DVH"] != null) dgvUsuarios.Columns["DVH"].Visible = false;

                if (dgvUsuarios.Columns["IdUsuario"] != null)
                    dgvUsuarios.Columns["IdUsuario"].HeaderText = "ID";
                if (dgvUsuarios.Columns["Username"] != null)
                {
                    dgvUsuarios.Columns["Username"].HeaderText = "Usuario";
                    dgvUsuarios.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (dgvUsuarios.Columns["Estado"] != null)
                    dgvUsuarios.Columns["Estado"].HeaderText = "Estado";
                if (dgvUsuarios.Columns["FechaAlta"] != null)
                    dgvUsuarios.Columns["FechaAlta"].HeaderText = "Fecha alta";
                if (dgvUsuarios.Columns["UltimoLogin"] != null)
                    dgvUsuarios.Columns["UltimoLogin"].HeaderText = "Último login";
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
                            fila.DefaultCellStyle.ForeColor = Color.FromArgb(229, 115, 115);
                            break;

                        case EstadoUsuario.Inactivo:
                            fila.DefaultCellStyle.ForeColor = Color.FromArgb(110, 85, 150);
                            break;

                        default:
                            fila.DefaultCellStyle.ForeColor = Color.FromArgb(38, 20, 70);
                            break;
                    }
                }
            }
        }

        private void Deseleccionar()
        {
            if (_cargandoSeleccion) return;
            _cargandoSeleccion = true;
            try
            {
                _seleccionado = null;
                dgvUsuarios.ClearSelection();
                txtUsername.Clear();
                txtPassword.Clear();
                txtConfirmarPassword.Clear();
                cboEstado.SelectedIndex = 0;
                btnGuardar.Text = ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.btnGuardar");
            }
            finally
            {
                _cargandoSeleccion = false;
            }
        }

        private void CargarCamposModificacion()
        {
            if (_cargandoSeleccion || _seleccionado == null) return;
            _cargandoSeleccion = true;
            try
            {
                txtUsername.Text = _seleccionado.Username;
                txtPassword.Clear();
                txtConfirmarPassword.Clear();
                cboEstado.SelectedItem = _seleccionado.Estado;
                btnGuardar.Text = ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.btnModificar");
            }
            finally
            {
                _cargandoSeleccion = false;
            }
        }

        private void DgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargandoSeleccion) return;
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                Deseleccionar();
                return;
            }
            var u = dgvUsuarios.SelectedRows[0].DataBoundItem as Usuario;
            if (u != null && u != _seleccionado)
            {
                _seleccionado = u;
                CargarCamposModificacion();
            }
        }

        private void DgvUsuarios_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Left)
            {
                _deseleccionarEnClick = dgvUsuarios.Rows[e.RowIndex].Selected;
            }
        }

        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && _deseleccionarEnClick)
            {
                _deseleccionarEnClick = false;
                Deseleccionar();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string pass = txtPassword.Text;
            string confirm = txtConfirmarPassword.Text;
            EstadoUsuario estado = (EstadoUsuario)cboEstado.SelectedItem;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass != confirm)
            {
                MessageBox.Show("Las contraseñas ingresadas no coinciden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_seleccionado == null)
                {
                    if (string.IsNullOrEmpty(pass))
                    {
                        MessageBox.Show("La contraseña es obligatoria para nuevos usuarios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _usuarioBll.Alta(this.Text, username, pass);
                    MessageBox.Show($"Usuario '{username}' creado correctamente.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _usuarioBll.Modificar(this.Text, _seleccionado.IdUsuario, username, pass, estado);
                    MessageBox.Show($"Usuario '{username}' modificado correctamente.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarDatos();
                Deseleccionar();
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void TxtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ManejadorIdioma.Instancia.Detach(this);
            base.OnFormClosed(e);
        }

        public void ActualizarIdioma()
        {
            lblTituloGrilla.Text = ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.lblTituloGrilla");
            lblBuscarUsuario.Text = ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.lblBuscarUsuario");
            btnRefrescar.Text = ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.btnRefrescar");
            grpGestion.Text = ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.grpGestion");
            lblUsername.Text = ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.lblUsername");
            lblPassword.Text = ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.lblPassword");
            lblConfirmarPassword.Text = ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.lblConfirmarPassword");
            lblRequisitos.Text = ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.lblRequisitos");
            lblEstado.Text = ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.lblEstado");
            btnGuardar.Text = _seleccionado == null ? ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.btnGuardar") : ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.btnModificar");
            btnLimpiar.Text = ManejadorIdioma.Instancia.ObtenerTexto("UsuariosForm.btnLimpiar");
        }
    }
}