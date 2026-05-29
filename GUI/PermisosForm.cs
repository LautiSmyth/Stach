using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class PermisosForm : Form, IObserver
    {
        private readonly PermisoBLL _permisoBll = IoCContainer.Resolver<PermisoBLL>();
        private readonly UsuarioBLL _usuarioBll = IoCContainer.Resolver<UsuarioBLL>();
        private List<ComponentePermiso> _todosPermisos;
        private ComponentePermiso _seleccionado;
        private Usuario _usuarioSeleccionado;

        public PermisosForm()
        {
            InitializeComponent();
            ManejadorIdioma.Instancia.Attach(this);
        }

        private void PermisosForm_Load(object sender, EventArgs e)
        {
            CargarDatos();
            ActualizarIdioma();

            txtNombrePermiso.MaxLength = 100;
            txtClavePermiso.MaxLength = 100;
        }

        private void TxtClavePermiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ManejadorIdioma.Instancia.Detach(this);
            base.OnFormClosed(e);
        }

        private void CargarDatos()
        {
            _todosPermisos = _permisoBll.ObtenerTodos();
            CargarArbolEstructura();
            CargarUsuarios();
            CargarListasRelacion();
        }

        private void CargarArbolEstructura()
        {
            tvEstructura.Nodes.Clear();
            var raices = _todosPermisos.Where(p => !_todosPermisos.Any(parent => parent.Hijos.Any(child => child.IdPermiso == p.IdPermiso))).ToList();

            foreach (var r in raices)
            {
                var nodo = CrearNodoRecursivo(r);
                tvEstructura.Nodes.Add(nodo);
            }
            tvEstructura.ExpandAll();
        }

        private TreeNode CrearNodoRecursivo(ComponentePermiso comp)
        {
            var nodo = new TreeNode(comp.NombreMostrar) { Tag = comp };
            if (comp is Familia fam)
            {
                foreach (var hijo in fam.Hijos)
                {
                    nodo.Nodes.Add(CrearNodoRecursivo(hijo));
                }
            }
            return nodo;
        }

        private void CargarUsuarios()
        {
            var usuarios = _usuarioBll.ObtenerTodos();
            cboUsuarios.DataSource = null;
            cboUsuarios.DisplayMember = "Username";
            cboUsuarios.DataSource = usuarios;
        }

        private void TvEstructura_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                _seleccionado = e.Node.Tag as ComponentePermiso;
                CargarListasRelacion();
            }
        }

        private void CargarListasRelacion()
        {
            lstDisponibles.DataSource = null;
            lstMiembros.DataSource = null;

            if (_seleccionado is Familia fam)
            {
                lblCol2Titulo.Text = $"{ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.lblCol2Titulo")} - {fam.Nombre}";

                var miembros = fam.Hijos;
                lstMiembros.DisplayMember = "NombreMostrar";
                lstMiembros.DataSource = miembros;

                var disponibles = _todosPermisos.Where(p =>
                    p.IdPermiso != fam.IdPermiso &&
                    !miembros.Any(m => m.IdPermiso == p.IdPermiso) &&
                    !EsAncestroRecursivo(p, fam.IdPermiso)
                ).ToList();

                lstDisponibles.DisplayMember = "NombreMostrar";
                lstDisponibles.DataSource = disponibles;
            }
            else
            {
                lblCol2Titulo.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.lblCol2Titulo");
            }
        }

        private bool EsAncestroRecursivo(ComponentePermiso parent, int idHijoBuscado)
        {
            if (parent.IdPermiso == idHijoBuscado) return true;
            foreach (var h in parent.Hijos)
            {
                if (EsAncestroRecursivo(h, idHijoBuscado)) return true;
            }
            return false;
        }

        private void BtnCrearPatente_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePermiso.Text.Trim();
            string clave = txtClavePermiso.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor, complete nombre y clave.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _permisoBll.CrearPatente(this.Text, nombre, clave);
                txtNombrePermiso.Clear();
                txtClavePermiso.Clear();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCrearFamilia_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePermiso.Text.Trim();
            string clave = txtClavePermiso.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor, complete nombre y clave.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _permisoBll.CrearFamilia(this.Text, nombre, clave);
                txtNombrePermiso.Clear();
                txtClavePermiso.Clear();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarPermiso_Click(object sender, EventArgs e)
        {
            if (_seleccionado == null)
            {
                MessageBox.Show("Seleccione un permiso a eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Está seguro de eliminar '{_seleccionado.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _permisoBll.EliminarPermiso(this.Text, _seleccionado.IdPermiso, _seleccionado.Nombre);
                    _seleccionado = null;
                    CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAgregarRelacion_Click(object sender, EventArgs e)
        {
            if (_seleccionado is Familia fam && lstDisponibles.SelectedItem is ComponentePermiso comp)
            {
                fam.Agregar(comp);
                CargarListasRelacion();
            }
        }

        private void BtnQuitarRelacion_Click(object sender, EventArgs e)
        {
            if (_seleccionado is Familia fam && lstMiembros.SelectedItem is ComponentePermiso comp)
            {
                fam.Quitar(comp);
                CargarListasRelacion();
            }
        }

        private void BtnGuardarRelaciones_Click(object sender, EventArgs e)
        {
            if (_seleccionado is Familia fam)
            {
                try
                {
                    _permisoBll.GuardarRelaciones(this.Text, fam);
                    CargarDatos();
                    MessageBox.Show("Relaciones guardadas con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            _usuarioSeleccionado = cboUsuarios.SelectedItem as Usuario;
            CargarPermisosUsuario();
        }

        private void CargarPermisosUsuario()
        {
            tvUsuarioPermisos.Nodes.Clear();
            lstPatentesPlanas.Items.Clear();

            if (_usuarioSeleccionado != null)
            {
                foreach (var p in _usuarioSeleccionado.Permisos)
                {
                    tvUsuarioPermisos.Nodes.Add(CrearNodoRecursivo(p));
                }
                tvUsuarioPermisos.ExpandAll();

                var planas = _permisoBll.ResolverPatentes(_usuarioSeleccionado.Permisos);
                foreach (var pl in planas)
                {
                    lstPatentesPlanas.Items.Add(pl.Nombre);
                }
            }
        }

        private void BtnAsignarUsuario_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionado == null || _seleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario y un permiso a asignar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_usuarioSeleccionado.Permisos.Any(p => p.IdPermiso == _seleccionado.IdPermiso))
            {
                MessageBox.Show("El usuario ya tiene asignado este permiso/rol.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _usuarioSeleccionado.Permisos.Add(_seleccionado);
            try
            {
                _permisoBll.GuardarPermisosUsuario(this.Text, _usuarioSeleccionado.IdUsuario, _usuarioSeleccionado.Username, _usuarioSeleccionado.Permisos);
                CargarPermisosUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuitarUsuario_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ComponentePermiso target = null;
            if (tvUsuarioPermisos.SelectedNode != null)
            {
                target = tvUsuarioPermisos.SelectedNode.Tag as ComponentePermiso;
            }
            else if (_seleccionado != null)
            {
                target = _seleccionado;
            }

            if (target == null)
            {
                MessageBox.Show("Seleccione el permiso o rol a quitar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var p = _usuarioSeleccionado.Permisos.FirstOrDefault(x => x.IdPermiso == target.IdPermiso);
            if (p == null)
            {
                MessageBox.Show("El usuario no tiene asignado directamente este permiso/rol.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _usuarioSeleccionado.Permisos.Remove(p);
            try
            {
                _permisoBll.GuardarPermisosUsuario(this.Text, _usuarioSeleccionado.IdUsuario, _usuarioSeleccionado.Username, _usuarioSeleccionado.Permisos);
                CargarPermisosUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ActualizarIdioma()
        {
            this.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.Text");
            lblCol1Titulo.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.lblCol1Titulo");
            lblNombrePermiso.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.lblNombrePermiso");
            lblClavePermiso.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.lblClavePermiso");
            btnCrearPatente.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.btnCrearPatente");
            btnCrearFamilia.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.btnCrearFamilia");
            btnEliminarPermiso.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.btnEliminarPermiso");

            lblCol2Titulo.Text = _seleccionado is Familia fam
                 ? $"{ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.lblCol2Titulo")} - {fam.Nombre}"
                 : ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.lblCol2Titulo");

            lblDisponibles.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.lblDisponibles");
            lblMiembros.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.lblMiembros");
            btnGuardarRelaciones.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.btnGuardarRelaciones");

            lblCol3Titulo.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.lblCol3Titulo");
            lblUserPerms.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.lblUserPerms");
            lblPatentesPlanas.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.lblPatentesPlanas");
            btnAsignarUsuario.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.btnAsignarUsuario");
            btnQuitarUsuario.Text = ManejadorIdioma.Instancia.ObtenerTexto("PermisosForm.btnQuitarUsuario");
        }
    }
}