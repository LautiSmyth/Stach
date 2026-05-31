using BE;
using BLL;
using Abstracciones;
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
        private readonly IManejadorIdioma _manejadorIdioma = IoCContainer.Resolver<IManejadorIdioma>();
        private List<ComponentePermiso> _todosPermisos;
        private ComponentePermiso _seleccionado;
        private Usuario _usuarioSeleccionado;

        public PermisosForm()
        {
            InitializeComponent();
            _manejadorIdioma.Attach(this);
        }

        private void PermisosForm_Load(object sender, EventArgs e)
        {
            CargarDatos();
            ActualizarIdioma();

            txtNombrePermiso.MaxLength = 100;

            var formTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(Form).IsAssignableFrom(t) && !t.IsAbstract)
                .OrderBy(t => t.Name)
                .ToList();

            cboFormularios.DataSource = formTypes;
            cboFormularios.DisplayMember = "Name";

            ManejadorSeguridad.AplicarSeguridad(this, SessionManager.GetInstance().Usuario);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _manejadorIdioma.Detach(this);
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
            List<ComponentePermiso> raices = _todosPermisos.Where(p => !_todosPermisos.Any(parent => parent.Hijos.Any(child => child.IdPermiso == p.IdPermiso))).ToList();

            foreach (ComponentePermiso r in raices)
            {
                TreeNode nodo = CrearNodoRecursivo(r);
                tvEstructura.Nodes.Add(nodo);
            }
            tvEstructura.ExpandAll();
        }

        private TreeNode CrearNodoRecursivo(ComponentePermiso comp)
        {
            TreeNode nodo = new TreeNode(comp.NombreMostrar) { Tag = comp };
            if (comp is Rol fam)
            {
                foreach (ComponentePermiso hijo in fam.Hijos)
                {
                    nodo.Nodes.Add(CrearNodoRecursivo(hijo));
                }
            }
            return nodo;
        }

        private void CargarUsuarios()
        {
            List<Usuario> usuarios = _usuarioBll.ObtenerTodos();
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
                CargarControlesMapeados();
            }
        }

        private void CargarListasRelacion()
        {
            lstDisponibles.DataSource = null;
            lstMiembros.DataSource = null;

            if (_seleccionado is Rol fam)
            {
                lblCol2Titulo.Text = $"{_manejadorIdioma.ObtenerTexto("PermisosForm.lblCol2Titulo")} - {fam.Nombre}";

                List<ComponentePermiso> miembros = fam.Hijos;
                lstMiembros.DisplayMember = "NombreMostrar";
                lstMiembros.DataSource = miembros;

                List<ComponentePermiso> disponibles = _todosPermisos.Where(p =>
                    p.IdPermiso != fam.IdPermiso &&
                    !miembros.Any(m => m.IdPermiso == p.IdPermiso) &&
                    !EsAncestroRecursivo(p, fam.IdPermiso)
                ).ToList();

                lstDisponibles.DisplayMember = "NombreMostrar";
                lstDisponibles.DataSource = disponibles;
            }
            else
            {
                lblCol2Titulo.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblCol2Titulo");
            }
        }

        private bool EsAncestroRecursivo(ComponentePermiso parent, int idHijoBuscado)
        {
            if (parent.IdPermiso == idHijoBuscado) return true;
            foreach (ComponentePermiso h in parent.Hijos)
            {
                if (EsAncestroRecursivo(h, idHijoBuscado)) return true;
            }
            return false;
        }

        private void BtnCrearPermiso_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePermiso.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingrese un nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _permisoBll.CrearPermiso(this.Text, nombre);
                txtNombrePermiso.Clear();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCrearRol_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePermiso.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingrese un nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _permisoBll.CrearRol(this.Text, nombre);
                txtNombrePermiso.Clear();
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
            if (_seleccionado is Rol fam && lstDisponibles.SelectedItem is ComponentePermiso comp)
            {
                fam.Agregar(comp);
                CargarListasRelacion();
            }
        }

        private void BtnQuitarRelacion_Click(object sender, EventArgs e)
        {
            if (_seleccionado is Rol fam && lstMiembros.SelectedItem is ComponentePermiso comp)
            {
                fam.Quitar(comp);
                CargarListasRelacion();
            }
        }

        private void BtnGuardarRelaciones_Click(object sender, EventArgs e)
        {
            if (_seleccionado is Rol fam)
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
            lstPermisosPlanas.Items.Clear();

            if (_usuarioSeleccionado != null)
            {
                foreach (ComponentePermiso p in _usuarioSeleccionado.Permisos)
                {
                    tvUsuarioPermisos.Nodes.Add(CrearNodoRecursivo(p));
                }
                tvUsuarioPermisos.ExpandAll();

                List<Permiso> planas = _permisoBll.ResolverPermisos(_usuarioSeleccionado.Permisos);
                foreach (Permiso pl in planas)
                {
                    lstPermisosPlanas.Items.Add(pl.Nombre);
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

            ComponentePermiso p = _usuarioSeleccionado.Permisos.FirstOrDefault(x => x.IdPermiso == target.IdPermiso);
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
            this.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.Text");
            lblCol1Titulo.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblCol1Titulo");
            lblNombrePermiso.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblNombrePermiso");
            btnCrearPermiso.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.btnCrearPermiso");
            btnCrearRol.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.btnCrearRol");
            btnEliminarPermiso.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.btnEliminarPermiso");

            lblCol2Titulo.Text = _seleccionado is Rol fam
                 ? $"{_manejadorIdioma.ObtenerTexto("PermisosForm.lblCol2Titulo")} - {fam.Nombre}"
                 : _manejadorIdioma.ObtenerTexto("PermisosForm.lblCol2Titulo");

            lblDisponibles.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblDisponibles");
            lblMiembros.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblMiembros");
            btnGuardarRelaciones.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.btnGuardarRelaciones");

            lblCol2ControlesTitulo.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblCol2ControlesTitulo") ?? "Mapeo de Controles";
            lblFormulario.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblFormulario") ?? "Formulario:";
            lblControlesDisponibles.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblControlesDisponibles") ?? "Disponibles";
            lblControlesAsociados.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblControlesAsociados") ?? "Asociados";
            btnGuardarControles.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.btnGuardarControles") ?? "Guardar Controles";

            lblCol3Titulo.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblCol3Titulo");
            lblUserPerms.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblUserPerms");
            lblPermisosPlanas.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblPermisosPlanas");
            btnAsignarUsuario.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.btnAsignarUsuario");
            btnQuitarUsuario.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.btnQuitarUsuario");
        }

        private List<ControlMapeado> _controlesDelPermiso = new List<ControlMapeado>();

        private void CargarControlesMapeados()
        {
            if (_seleccionado == null)
            {
                _controlesDelPermiso = new List<ControlMapeado>();
                lstControlesDisponibles.DataSource = null;
                lstControlesAsociados.DataSource = null;
                return;
            }

            try
            {
                _controlesDelPermiso = _permisoBll.ObtenerControlesPorPermiso(_seleccionado.IdPermiso);
                ActualizarListasControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar controles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarListasControles()
        {
            lstControlesDisponibles.DataSource = null;
            lstControlesAsociados.DataSource = null;

            if (_seleccionado == null || cboFormularios.SelectedItem == null) return;

            Type formType = cboFormularios.SelectedItem as Type;
            if (formType == null) return;

            string selectedFormName = formType.Name;

            List<string> todosControles = ObtenerControlesDeFormulario(formType);
            List<string> asociados = _controlesDelPermiso
                .Where(c => c.Formulario.Equals(selectedFormName, StringComparison.OrdinalIgnoreCase))
                .Select(c => c.NombreControl)
                .ToList();

            List<string> disponibles = todosControles
                .Where(c => !asociados.Contains(c))
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            lstControlesDisponibles.DataSource = disponibles;
            lstControlesAsociados.DataSource = asociados.OrderBy(c => c).ToList();
        }

        private List<string> ObtenerControlesDeFormulario(Type formType)
        {
            List<string> nombres = new List<string>();
            try
            {
                using (Form temp = (Form)Activator.CreateInstance(formType))
                {
                    AgregarControlesRecursivo(temp.Controls, nombres);
                }
            }
            catch { }
            return nombres;
        }

        private void AgregarControlesRecursivo(Control.ControlCollection controls, List<string> nombres)
        {
            foreach (Control c in controls)
            {
                if (c is Button)
                {
                    if (!string.IsNullOrEmpty(c.Name))
                    {
                        nombres.Add(c.Name);
                    }
                }
                else if (c is ToolStrip ts)
                {
                    AgregarItemsToolStrip(ts, nombres);
                }
                if (c.Controls.Count > 0)
                {
                    AgregarControlesRecursivo(c.Controls, nombres);
                }
            }
        }

        private void AgregarItemsToolStrip(ToolStrip ts, List<string> nombres)
        {
            foreach (ToolStripItem item in ts.Items)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    nombres.Add(item.Name);
                }
                if (item is ToolStripDropDownItem dropDown)
                {
                    AgregarItemsDropDownItem(dropDown, nombres);
                }
            }
        }

        private void AgregarItemsDropDownItem(ToolStripDropDownItem parent, List<string> nombres)
        {
            foreach (ToolStripItem item in parent.DropDownItems)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    nombres.Add(item.Name);
                }
                if (item is ToolStripDropDownItem dropDown)
                {
                    AgregarItemsDropDownItem(dropDown, nombres);
                }
            }
        }

        private void CboFormularios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarListasControles();
        }

        private void BtnAgregarControl_Click(object sender, EventArgs e)
        {
            if (_seleccionado == null)
            {
                MessageBox.Show("Seleccione un permiso o rol en la estructura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Type selectedType = cboFormularios.SelectedItem as Type;
            if (selectedType == null || lstControlesDisponibles.SelectedItem == null) return;

            string selectedFormName = selectedType.Name;
            string ctrlName = lstControlesDisponibles.SelectedItem.ToString();

            if (!_controlesDelPermiso.Any(c => c.Formulario.Equals(selectedFormName, StringComparison.OrdinalIgnoreCase) && c.NombreControl.Equals(ctrlName, StringComparison.OrdinalIgnoreCase)))
            {
                _controlesDelPermiso.Add(new ControlMapeado
                {
                    IdPermiso = _seleccionado.IdPermiso,
                    Formulario = selectedFormName,
                    NombreControl = ctrlName
                });
                ActualizarListasControles();
            }
        }

        private void BtnQuitarControl_Click(object sender, EventArgs e)
        {
            if (_seleccionado == null) return;

            Type selectedType = cboFormularios.SelectedItem as Type;
            if (selectedType == null || lstControlesAsociados.SelectedItem == null) return;

            string selectedFormName = selectedType.Name;
            string ctrlName = lstControlesAsociados.SelectedItem.ToString();

            var target = _controlesDelPermiso.FirstOrDefault(c =>
                c.Formulario.Equals(selectedFormName, StringComparison.OrdinalIgnoreCase) &&
                c.NombreControl.Equals(ctrlName, StringComparison.OrdinalIgnoreCase));

            if (target != null)
            {
                _controlesDelPermiso.Remove(target);
                ActualizarListasControles();
            }
        }

        private void BtnGuardarControles_Click(object sender, EventArgs e)
        {
            if (_seleccionado == null)
            {
                MessageBox.Show("Seleccione un permiso o rol en la estructura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _permisoBll.GuardarControlesAsociados(_seleccionado.IdPermiso, _controlesDelPermiso);
                MessageBox.Show("Controles guardados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar controles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}