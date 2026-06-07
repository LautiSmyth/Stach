using BE;
using BLL;
using Abstracciones;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class MisPermisosForm : Form, IObserver
    {
        private readonly PermisoBLL _permisoBll = IoCContainer.Resolver<PermisoBLL>();
        private readonly UsuarioBLL _usuarioBll = IoCContainer.Resolver<UsuarioBLL>();
        private readonly IManejadorIdioma _manejadorIdioma = IoCContainer.Resolver<IManejadorIdioma>();
        private readonly IManejadorSeguridad _manejadorSeguridad = IoCContainer.Resolver<IManejadorSeguridad>();
        private readonly ISessionManager _sessionManager = IoCContainer.Resolver<ISessionManager>();

        public MisPermisosForm()
        {
            InitializeComponent();
            _manejadorIdioma.Attach(this);
        }

        private void MisPermisosForm_Load(object sender, EventArgs e)
        {
            lstResueltos.MouseMove += LstListBox_MouseMove;
            lstResueltos.HorizontalScrollbar = true;

            ActualizarIdioma();
            CargarPermisos();
            _manejadorSeguridad.AplicarSeguridad(this, _sessionManager.Usuario);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _manejadorIdioma.Detach(this);
            base.OnFormClosed(e);
        }

        private void CargarPermisos()
        {
            Usuario usuario = _usuarioBll.ObtenerUsuarioLogueado();
            if (usuario == null) return;

            tvDirectos.Nodes.Clear();
            foreach (ComponentePermiso comp in usuario.Permisos)
            {
                TreeNode node = CrearNodo(comp);
                tvDirectos.Nodes.Add(node);
            }
            tvDirectos.ExpandAll();

            lstResueltos.Items.Clear();
            List<Permiso> permisos = _permisoBll.ResolverPermisos(usuario.Permisos);
            foreach (Permiso pat in permisos)
            {
                lstResueltos.Items.Add(pat.Nombre);
            }

            SetListBoxHorizontalExtent(lstResueltos);
        }

        private TreeNode CrearNodo(ComponentePermiso comp)
        {
            TreeNode node = new TreeNode(comp.Nombre);
            node.Tag = comp;
            if (comp is Rol fam)
            {
                foreach (ComponentePermiso hijo in fam.Hijos)
                {
                    node.Nodes.Add(CrearNodo(hijo));
                }
            }
            return node;
        }

        public void ActualizarIdioma()
        {
            this.Text = _manejadorIdioma.ObtenerTexto("MisPermisosForm.Text") ?? "Mis Permisos y Roles";
            lblTitulo.Text = _manejadorIdioma.ObtenerTexto("MisPermisosForm.lblTitulo") ?? "Mis Roles y Permisos";
            lblDirectos.Text = _manejadorIdioma.ObtenerTexto("MisPermisosForm.lblDirectos") ?? "Roles y Permisos Asignados";
            lblResueltos.Text = _manejadorIdioma.ObtenerTexto("MisPermisosForm.lblResueltos") ?? "Permisos Finales (Resueltos)";
            btnCerrar.Text = _manejadorIdioma.ObtenerTexto("MisPermisosForm.btnCerrar") ?? "Cerrar";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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