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

            lstDisponibles.MouseMove += LstListBox_MouseMove;
            lstMiembros.MouseMove += LstListBox_MouseMove;
            lstPermisosPlanas.MouseMove += LstListBox_MouseMove;

            lstDisponibles.HorizontalScrollbar = true;
            lstMiembros.HorizontalScrollbar = true;
            lstPermisosPlanas.HorizontalScrollbar = true;

            HabilitarPanelesSegunSeleccion();
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
                HabilitarPanelesSegunSeleccion();
                if (_seleccionado is Rol)
                {
                    CargarListasRelacion();
                }
                else if (_seleccionado is Permiso)
                {
                    CargarControlesMapeados();
                }
                else
                {
                    lstDisponibles.DataSource = null;
                    lstMiembros.DataSource = null;
                }
            }
        }

        private void HabilitarPanelesSegunSeleccion()
        {
            bool esRol = _seleccionado is Rol;
            bool esPermiso = _seleccionado is Permiso;

            if (esPermiso)
            {
                lblCol2Titulo.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblCol2ControlesTitulo") ?? "Mapeo de Controles";
            }
            else if (esRol)
            {
                lblCol2Titulo.Text = $"{_manejadorIdioma.ObtenerTexto("PermisosForm.lblCol2Titulo")} - {_seleccionado.Nombre}";
            }
            else
            {
                lblCol2Titulo.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblCol2Titulo") ?? "Configurador de Relaciones";
            }
            
            lblDisponibles.Text = esPermiso 
                ? (_manejadorIdioma.ObtenerTexto("PermisosForm.lblControlesDisponibles") ?? "Disponibles")
                : (_manejadorIdioma.ObtenerTexto("PermisosForm.lblDisponibles") ?? "Permisos Disponibles");

            lblMiembros.Text = esPermiso 
                ? (_manejadorIdioma.ObtenerTexto("PermisosForm.lblControlesAsociados") ?? "Asociados")
                : (_manejadorIdioma.ObtenerTexto("PermisosForm.lblMiembros") ?? "Miembros del Rol");

            lblFormulario.Visible = esPermiso;
            cboFormularios.Visible = esPermiso;

            tblCol2Transfer.Enabled = esRol || esPermiso;

            btnGuardarRelaciones.Visible = esRol;
            btnGuardarRelaciones.Enabled = esRol;
            
            btnGuardarControles.Visible = esPermiso;
            btnGuardarControles.Enabled = esPermiso;
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

            SetListBoxHorizontalExtent(lstDisponibles);
            SetListBoxHorizontalExtent(lstMiembros);
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
            if (!_usuarioBll.UsuarioLogueadoTienePermiso("Gestión de Permisos"))
            {
                MessageBox.Show("No tiene autorización para realizar esta acción.", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            if (!_usuarioBll.UsuarioLogueadoTienePermiso("Gestión de Permisos"))
            {
                MessageBox.Show("No tiene autorización para realizar esta acción.", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            if (!_usuarioBll.UsuarioLogueadoTienePermiso("Gestión de Permisos"))
            {
                MessageBox.Show("No tiene autorización para realizar esta acción.", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            if (!_usuarioBll.UsuarioLogueadoTienePermiso("Gestión de Permisos"))
            {
                MessageBox.Show("No tiene autorización para realizar esta acción.", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_seleccionado is Rol fam && lstDisponibles.SelectedItem is ComponentePermiso comp)
            {
                fam.Agregar(comp);
                CargarListasRelacion();
            }
            else if (_seleccionado is Permiso && lstDisponibles.SelectedItem is ControlItem controlItem)
            {
                FormularioItem selectedItem = cboFormularios.SelectedItem as FormularioItem;
                if (selectedItem == null) return;
                Type selectedType = selectedItem.FormType;
                string selectedFormName = selectedType.Name;
                string ctrlName = controlItem.NombreControl;

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
        }

        private void BtnQuitarRelacion_Click(object sender, EventArgs e)
        {
            if (!_usuarioBll.UsuarioLogueadoTienePermiso("Gestión de Permisos"))
            {
                MessageBox.Show("No tiene autorización para realizar esta acción.", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_seleccionado is Rol fam && lstMiembros.SelectedItem is ComponentePermiso comp)
            {
                fam.Quitar(comp);
                CargarListasRelacion();
            }
            else if (_seleccionado is Permiso && lstMiembros.SelectedItem is ControlItem controlItem)
            {
                FormularioItem selectedItem = cboFormularios.SelectedItem as FormularioItem;
                if (selectedItem == null) return;
                Type selectedType = selectedItem.FormType;
                string selectedFormName = selectedType.Name;
                string ctrlName = controlItem.NombreControl;

                var target = _controlesDelPermiso.FirstOrDefault(c =>
                    c.Formulario.Equals(selectedFormName, StringComparison.OrdinalIgnoreCase) &&
                    c.NombreControl.Equals(ctrlName, StringComparison.OrdinalIgnoreCase));

                if (target != null)
                {
                    _controlesDelPermiso.Remove(target);
                    ActualizarListasControles();
                }
            }
        }

        private void BtnGuardarRelaciones_Click(object sender, EventArgs e)
        {
            if (!_usuarioBll.UsuarioLogueadoTienePermiso("Gestión de Permisos"))
            {
                MessageBox.Show("No tiene autorización para realizar esta acción.", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            SetListBoxHorizontalExtent(lstPermisosPlanas);
        }

        private void BtnAsignarUsuario_Click(object sender, EventArgs e)
        {
            if (!_usuarioBll.UsuarioLogueadoTienePermiso("Gestión de Permisos"))
            {
                MessageBox.Show("No tiene autorización para realizar esta acción.", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            if (!_usuarioBll.UsuarioLogueadoTienePermiso("Gestión de Permisos"))
            {
                MessageBox.Show("No tiene autorización para realizar esta acción.", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            btnGuardarRelaciones.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.btnGuardarRelaciones");
            lblFormulario.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblFormulario") ?? "Formulario:";
            btnGuardarControles.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.btnGuardarControles") ?? "Guardar Controles";

            lblCol3Titulo.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblCol3Titulo");
            lblUserPerms.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblUserPerms");
            lblPermisosPlanas.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.lblPermisosPlanas");
            btnAsignarUsuario.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.btnAsignarUsuario");
            btnQuitarUsuario.Text = _manejadorIdioma.ObtenerTexto("PermisosForm.btnQuitarUsuario");

            CargarFormularios();
            HabilitarPanelesSegunSeleccion();
        }

        private List<ControlMapeado> _controlesDelPermiso = new List<ControlMapeado>();

        private void CargarControlesMapeados()
        {
            if (_seleccionado == null)
            {
                _controlesDelPermiso = new List<ControlMapeado>();
                lstDisponibles.DataSource = null;
                lstMiembros.DataSource = null;
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

        private void CargarFormularios()
        {
            Type selectedType = null;
            if (cboFormularios.SelectedItem is FormularioItem selectedItem)
            {
                selectedType = selectedItem.FormType;
            }

            var formTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(Form).IsAssignableFrom(t) && !t.IsAbstract)
                .OrderBy(t => t.Name)
                .ToList();

            var items = new List<FormularioItem>();
            foreach (var type in formTypes)
            {
                string key = $"{type.Name}.Text";
                string translatedText = _manejadorIdioma.ObtenerTexto(key);
                string displayName = translatedText == key ? type.Name : translatedText;

                items.Add(new FormularioItem
                {
                    FormType = type,
                    NombreMostrar = displayName
                });
            }

            cboFormularios.SelectedIndexChanged -= CboFormularios_SelectedIndexChanged;
            cboFormularios.DataSource = items;
            cboFormularios.DisplayMember = "NombreMostrar";

            if (selectedType != null)
            {
                var toSelect = items.FirstOrDefault(i => i.FormType == selectedType);
                if (toSelect != null)
                {
                    cboFormularios.SelectedItem = toSelect;
                }
            }
            cboFormularios.SelectedIndexChanged += CboFormularios_SelectedIndexChanged;

            ActualizarListasControles();
        }

        private void ActualizarListasControles()
        {
            lstDisponibles.DataSource = null;
            lstMiembros.DataSource = null;

            if (_seleccionado == null || cboFormularios.SelectedItem == null) return;

            FormularioItem selectedItem = cboFormularios.SelectedItem as FormularioItem;
            if (selectedItem == null) return;
            Type formType = selectedItem.FormType;

            string selectedFormName = formType.Name;

            List<ControlItem> todosControles = ObtenerControlesDeFormulario(formType);
            
            // Build asociados
            List<ControlItem> asociados = todosControles
                .Where(ctrl => _controlesDelPermiso.Any(c => 
                    c.Formulario.Equals(selectedFormName, StringComparison.OrdinalIgnoreCase) && 
                    c.NombreControl.Equals(ctrl.NombreControl, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            // Add any other control mapped that wasn't dynamically found (e.g. if deleted/moved but still mapped in database)
            var mappedControlNames = _controlesDelPermiso
                .Where(c => c.Formulario.Equals(selectedFormName, StringComparison.OrdinalIgnoreCase))
                .Select(c => c.NombreControl)
                .ToList();

            foreach (var mappedName in mappedControlNames)
            {
                if (!asociados.Any(a => a.NombreControl.Equals(mappedName, StringComparison.OrdinalIgnoreCase)))
                {
                    asociados.Add(new ControlItem
                    {
                        NombreControl = mappedName,
                        Texto = ""
                    });
                }
            }

            // Build disponibles
            List<ControlItem> disponibles = todosControles
                .Where(ctrl => !asociados.Any(a => a.NombreControl.Equals(ctrl.NombreControl, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            asociados = asociados.OrderBy(c => c.NombreControl).ToList();
            disponibles = disponibles.OrderBy(c => c.NombreControl).ToList();

            lstDisponibles.DisplayMember = "DisplayText";
            lstDisponibles.DataSource = disponibles;

            lstMiembros.DisplayMember = "DisplayText";
            lstMiembros.DataSource = asociados;

            SetListBoxHorizontalExtent(lstDisponibles);
            SetListBoxHorizontalExtent(lstMiembros);
        }

        private List<ControlItem> ObtenerControlesDeFormulario(Type formType)
        {
            List<ControlItem> controles = new List<ControlItem>();
            try
            {
                using (Form temp = (Form)Activator.CreateInstance(formType))
                {
                    if (temp is IObserver obs)
                    {
                        _manejadorIdioma.Detach(obs);
                    }
                    AgregarControlesRecursivo(temp.Controls, formType.Name, controles);
                }
            }
            catch (Exception ex)
            {
                // Ignorar excepciones al intentar instanciar formularios que puedan requerir parámetros específicos de DI o fallar en tiempo de diseño/construcción
                System.Diagnostics.Debug.WriteLine($"Error al instanciar formulario {formType.Name}: {ex.Message}");
            }
            return controles;
        }

        private void AgregarControlesRecursivo(Control.ControlCollection controls, string formName, List<ControlItem> list)
        {
            foreach (Control c in controls)
            {
                if (c is Button)
                {
                    if (!string.IsNullOrEmpty(c.Name))
                    {
                        string key = $"{formName}.{c.Name}";
                        string translated = _manejadorIdioma.ObtenerTexto(key);
                        string text = translated == key ? c.Text : translated;
                        list.Add(new ControlItem { NombreControl = c.Name, Texto = text });
                    }
                }
                else if (c is ToolStrip ts)
                {
                    AgregarItemsToolStrip(ts, formName, list);
                }
                if (c.Controls.Count > 0)
                {
                    AgregarControlesRecursivo(c.Controls, formName, list);
                }
            }
        }

        private void AgregarItemsToolStrip(ToolStrip ts, string formName, List<ControlItem> list)
        {
            foreach (ToolStripItem item in ts.Items)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    string key = $"{formName}.{item.Name}";
                    string translated = _manejadorIdioma.ObtenerTexto(key);
                    string text = translated == key ? item.Text : translated;
                    list.Add(new ControlItem { NombreControl = item.Name, Texto = text });
                }
                if (item is ToolStripDropDownItem dropDown)
                {
                    AgregarItemsDropDownItem(dropDown, formName, list);
                }
            }
        }

        private void AgregarItemsDropDownItem(ToolStripDropDownItem parent, string formName, List<ControlItem> list)
        {
            foreach (ToolStripItem item in parent.DropDownItems)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    string key = $"{formName}.{item.Name}";
                    string translated = _manejadorIdioma.ObtenerTexto(key);
                    string text = translated == key ? item.Text : translated;
                    list.Add(new ControlItem { NombreControl = item.Name, Texto = text });
                }
                if (item is ToolStripDropDownItem dropDown)
                {
                    AgregarItemsDropDownItem(dropDown, formName, list);
                }
            }
        }

        private void CboFormularios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarListasControles();
        }

        public class FormularioItem
        {
            public Type FormType { get; set; }
            public string NombreMostrar { get; set; }
        }

        public class ControlItem
        {
            public string NombreControl { get; set; }
            public string Texto { get; set; }
            public string DisplayText => string.IsNullOrEmpty(Texto) ? NombreControl : $"{NombreControl} - {Texto}";
        }



        private void BtnGuardarControles_Click(object sender, EventArgs e)
        {
            if (!_usuarioBll.UsuarioLogueadoTienePermiso("Gestión de Permisos"))
            {
                MessageBox.Show("No tiene autorización para realizar esta acción.", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

        private int _lastHoveredIndex = -1;
        private ToolTip _listboxToolTip = new ToolTip();

        private void LstListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is ListBox listBox)
            {
                int index = listBox.IndexFromPoint(e.Location);
                if (index != _lastHoveredIndex)
                {
                    _lastHoveredIndex = index;
                    if (index >= 0 && index < listBox.Items.Count)
                    {
                        string text = listBox.GetItemText(listBox.Items[index]);
                        _listboxToolTip.SetToolTip(listBox, text);
                    }
                    else
                    {
                        _listboxToolTip.SetToolTip(listBox, "");
                    }
                }
            }
        }

        private void SetListBoxHorizontalExtent(ListBox listBox)
        {
            int maxExtent = listBox.Width;
            if (listBox.Items.Count > 0)
            {
                using (System.Drawing.Graphics g = listBox.CreateGraphics())
                {
                    foreach (var item in listBox.Items)
                    {
                        string text = listBox.GetItemText(item);
                        int width = (int)g.MeasureString(text, listBox.Font).Width;
                        if (width > maxExtent)
                        {
                            maxExtent = width;
                        }
                    }
                }
            }
            listBox.HorizontalExtent = maxExtent + 15;
        }
    }
}