using Aplicacion;
using BE;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class MisPermisosForm : Form, IObserver
    {
        private readonly PermisoServicio _permisoServicio = new PermisoServicio();
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();

        public MisPermisosForm()
        {
            InitializeComponent();
            ManejadorIdioma.Instancia.Attach(this);
        }

        private void MisPermisosForm_Load(object sender, EventArgs e)
        {
            ActualizarIdioma();
            CargarPermisos();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ManejadorIdioma.Instancia.Detach(this);
            base.OnFormClosed(e);
        }

        private void CargarPermisos()
        {
            Usuario usuario = _usuarioServicio.ObtenerUsuarioLogueado();
            if (usuario == null) return;

            tvDirectos.Nodes.Clear();
            foreach (var comp in usuario.Permisos)
            {
                TreeNode node = CrearNodo(comp);
                tvDirectos.Nodes.Add(node);
            }
            tvDirectos.ExpandAll();

            lstResueltos.Items.Clear();
            var patentes = _permisoServicio.ResolverPatentes(usuario.Permisos);
            foreach (var pat in patentes)
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
                foreach (var hijo in fam.Hijos)
                {
                    node.Nodes.Add(CrearNodo(hijo));
                }
            }
            return node;
        }

        public void ActualizarIdioma()
        {
            this.Text = ManejadorIdioma.Instancia.ObtenerTexto("MisPermisosForm.Text") ?? "Mis Permisos y Roles";
            lblTitulo.Text = ManejadorIdioma.Instancia.ObtenerTexto("MisPermisosForm.lblTitulo") ?? "Mis Roles y Permisos";
            lblDirectos.Text = ManejadorIdioma.Instancia.ObtenerTexto("MisPermisosForm.lblDirectos") ?? "Roles y Permisos Asignados";
            lblResueltos.Text = ManejadorIdioma.Instancia.ObtenerTexto("MisPermisosForm.lblResueltos") ?? "Permisos Finales (Resueltos)";
            btnCerrar.Text = ManejadorIdioma.Instancia.ObtenerTexto("MisPermisosForm.btnCerrar") ?? "Cerrar";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}