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

        public MisPermisosForm()
        {
            InitializeComponent();
            _manejadorIdioma.Attach(this);
        }

        private void MisPermisosForm_Load(object sender, EventArgs e)
        {
            ActualizarIdioma();
            CargarPermisos();
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
            List<Patente> patentes = _permisoBll.ResolverPatentes(usuario.Permisos);
            foreach (Patente pat in patentes)
            {
                lstResueltos.Items.Add($"{pat.Nombre} ({pat.PermisoKey})");
            }
        }

        private TreeNode CrearNodo(ComponentePermiso comp)
        {
            TreeNode node = new TreeNode(comp.Nombre);
            node.Tag = comp;
            if (comp is Familia fam)
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
    }
}