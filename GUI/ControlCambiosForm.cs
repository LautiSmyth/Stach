using Aplicacion;
using BE;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class ControlCambiosForm : Form, IObserver
    {
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();
        private readonly VersionUsuarioServicio _versionServicio = new VersionUsuarioServicio();
        private List<VersionUsuario> _versiones;
        private VersionUsuario _seleccionado;

        public ControlCambiosForm()
        {
            InitializeComponent();
            ManejadorIdioma.Instancia.Attach(this);
        }

        private void ControlCambiosForm_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            ConfigurarGrilla();
            ActualizarIdioma();

            cboUsuarios.SelectedIndexChanged += CboUsuarios_SelectedIndexChanged;
            dgvVersiones.SelectionChanged += DgvVersiones_SelectionChanged;
            btnRollback.Click += BtnRollback_Click;
            CargarVersiones();
            DesactivarTabStopReadOnly(this);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ManejadorIdioma.Instancia.Detach(this);
            base.OnFormClosed(e);
        }

        private void CargarUsuarios()
        {
            var usuarios = _usuarioServicio.ObtenerTodos();
            cboUsuarios.DataSource = null;
            cboUsuarios.DisplayMember = "Username";
            cboUsuarios.DataSource = usuarios;
        }

        private void ConfigurarGrilla()
        {
            dgvVersiones.AutoGenerateColumns = false;
            dgvVersiones.AllowUserToAddRows = false;
            dgvVersiones.AllowUserToDeleteRows = false;
            dgvVersiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVersiones.RowHeadersVisible = false;

            dgvVersiones.Columns.Clear();

            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdVersion",
                HeaderText = "ID",
                Width = 50,
                ReadOnly = true
            };
            dgvVersiones.Columns.Add(colId);

            var colFecha = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaModificacion",
                HeaderText = "Fecha y Hora",
                Width = 150,
                ReadOnly = true
            };
            dgvVersiones.Columns.Add(colFecha);

            var colActor = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ModificadoPor",
                HeaderText = "Modificado Por",
                Width = 120,
                ReadOnly = true
            };
            dgvVersiones.Columns.Add(colActor);

            var colDetalle = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DetalleCambios",
                HeaderText = "Detalle del Cambio",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            };
            dgvVersiones.Columns.Add(colDetalle);
        }

        private void CboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarVersiones();
        }

        private void CargarVersiones()
        {
            LimpiarCampos();
            if (cboUsuarios.SelectedItem is Usuario u)
            {
                _versiones = _versionServicio.ObtenerPorUsuario(u.IdUsuario);
                dgvVersiones.DataSource = null;
                dgvVersiones.DataSource = _versiones;
            }
            else
            {
                dgvVersiones.DataSource = null;
            }
        }

        private void DgvVersiones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVersiones.CurrentRow != null)
            {
                _seleccionado = dgvVersiones.CurrentRow.DataBoundItem as VersionUsuario;
                if (_seleccionado != null)
                {
                    txtDetUsername.Text = _seleccionado.Username;
                    txtDetEstado.Text = _seleccionado.Estado.ToString();
                }
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            _seleccionado = null;
            txtDetUsername.Clear();
            txtDetEstado.Clear();
        }

        private void BtnRollback_Click(object sender, EventArgs e)
        {
            if (_seleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione una versión para restaurar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Está seguro de revertir el usuario a la versión del {_seleccionado.FechaModificacion}?", "Confirmar Rollback", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string actor = _usuarioServicio.ObtenerUsernameEnSesion();
                    if (string.IsNullOrEmpty(actor)) actor = "Sistema";

                    _versionServicio.RestaurarVersion(this.Text, _seleccionado.IdVersion, actor);
                    MessageBox.Show("Rollback completado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarVersiones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ActualizarIdioma()
        {
            this.Text = ManejadorIdioma.Instancia.ObtenerTexto("ControlCambiosForm.Text");
            lblSeleccionarUsuario.Text = ManejadorIdioma.Instancia.ObtenerTexto("ControlCambiosForm.lblSeleccionarUsuario");
            lblDetalleTitulo.Text = ManejadorIdioma.Instancia.ObtenerTexto("ControlCambiosForm.lblDetalleTitulo");
            lblDetUsername.Text = ManejadorIdioma.Instancia.ObtenerTexto("ControlCambiosForm.lblDetUsername");
            lblDetEstado.Text = ManejadorIdioma.Instancia.ObtenerTexto("ControlCambiosForm.lblDetEstado");
            btnRollback.Text = ManejadorIdioma.Instancia.ObtenerTexto("ControlCambiosForm.btnRollback");

            if (dgvVersiones.Columns.Count >= 4)
            {
                dgvVersiones.Columns[0].HeaderText = ManejadorIdioma.Instancia.ObtenerTexto("ControlCambiosForm.colId") ?? "ID";
                dgvVersiones.Columns[1].HeaderText = ManejadorIdioma.Instancia.ObtenerTexto("ControlCambiosForm.colFecha") ?? "Fecha y Hora";
                dgvVersiones.Columns[2].HeaderText = ManejadorIdioma.Instancia.ObtenerTexto("ControlCambiosForm.colActor") ?? "Modificado Por";
                dgvVersiones.Columns[3].HeaderText = ManejadorIdioma.Instancia.ObtenerTexto("ControlCambiosForm.colDetalle") ?? "Detalle del Cambio";
            }
        }

        private void DesactivarTabStopReadOnly(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox txt && txt.ReadOnly)
                {
                    txt.TabStop = false;
                }
                if (c.HasChildren)
                {
                    DesactivarTabStopReadOnly(c);
                }
            }
        }
    }
}
