using BE;
using BLL;
using Abstracciones;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class ControlCambiosForm : Form, IObserver
    {
        private readonly UsuarioBLL _usuarioBll = IoCContainer.Resolver<UsuarioBLL>();
        private readonly VersionUsuarioBLL _versionBll = IoCContainer.Resolver<VersionUsuarioBLL>();
        private readonly IManejadorIdioma _manejadorIdioma = IoCContainer.Resolver<IManejadorIdioma>();
        private List<VersionUsuario> _versiones;
        private VersionUsuario _seleccionado;

        public ControlCambiosForm()
        {
            InitializeComponent();
            _manejadorIdioma.Attach(this);
        }

        private void ControlCambiosForm_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            ConfigurarGrilla();
            ActualizarIdioma();
            CargarVersiones();
            DesactivarTabStopReadOnly(this);
            ManejadorSeguridad.AplicarSeguridad(this, SessionManager.GetInstance().Usuario);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _manejadorIdioma.Detach(this);
            base.OnFormClosed(e);
        }

        private void CargarUsuarios()
        {
            List<Usuario> usuarios = _usuarioBll.ObtenerTodos();
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

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdVersion",
                HeaderText = "ID",
                Width = 50,
                ReadOnly = true
            };
            dgvVersiones.Columns.Add(colId);

            DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaModificacion",
                HeaderText = "Fecha y Hora",
                Width = 150,
                ReadOnly = true
            };
            dgvVersiones.Columns.Add(colFecha);

            DataGridViewTextBoxColumn colActor = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ModificadoPor",
                HeaderText = "Modificado Por",
                Width = 120,
                ReadOnly = true
            };
            dgvVersiones.Columns.Add(colActor);

            DataGridViewTextBoxColumn colDetalle = new DataGridViewTextBoxColumn
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
                _versiones = _versionBll.ObtenerPorUsuario(u.IdUsuario);
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
                    string actor = _usuarioBll.ObtenerUsernameEnSesion();
                    if (string.IsNullOrEmpty(actor)) actor = "Sistema";

                    _versionBll.RestaurarVersion(this.Text, _seleccionado.IdVersion, actor);
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
            this.Text = _manejadorIdioma.ObtenerTexto("ControlCambiosForm.Text");
            lblSeleccionarUsuario.Text = _manejadorIdioma.ObtenerTexto("ControlCambiosForm.lblSeleccionarUsuario");
            lblDetalleTitulo.Text = _manejadorIdioma.ObtenerTexto("ControlCambiosForm.lblDetalleTitulo");
            lblDetUsername.Text = _manejadorIdioma.ObtenerTexto("ControlCambiosForm.lblDetUsername");
            lblDetEstado.Text = _manejadorIdioma.ObtenerTexto("ControlCambiosForm.lblDetEstado");
            btnRollback.Text = _manejadorIdioma.ObtenerTexto("ControlCambiosForm.btnRollback");

            if (dgvVersiones.Columns.Count >= 4)
            {
                dgvVersiones.Columns[0].HeaderText = _manejadorIdioma.ObtenerTexto("ControlCambiosForm.colId") ?? "ID";
                dgvVersiones.Columns[1].HeaderText = _manejadorIdioma.ObtenerTexto("ControlCambiosForm.colFecha") ?? "Fecha y Hora";
                dgvVersiones.Columns[2].HeaderText = _manejadorIdioma.ObtenerTexto("ControlCambiosForm.colActor") ?? "Modificado Por";
                dgvVersiones.Columns[3].HeaderText = _manejadorIdioma.ObtenerTexto("ControlCambiosForm.colDetalle") ?? "Detalle del Cambio";
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