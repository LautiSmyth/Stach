using BE;
using Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Servicios
{
    public static class ManejadorSeguridad
    {
        private static readonly HashSet<string> _controlesControlados = new HashSet<string>();

        public static void ActualizarSeguridadFormulariosAbiertos(Usuario usuario)
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                AplicarSeguridad(form, usuario);
            }
        }

        public static void AplicarSeguridad(Form formulario, Usuario usuario)
        {
            if (formulario == null || usuario == null) return;

            try
            {
                IPermisoDAL permisoDal = IoCContainer.Resolver<IPermisoDAL>();
                List<ControlMapeado> todosControles = permisoDal.ObtenerTodosLosControlesProtegidos();

                var controlesForm = todosControles.Where(c => c.Formulario.Equals(formulario.Name, StringComparison.OrdinalIgnoreCase)).ToList();

                HashSet<string> controlesActuales = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                HashSet<int> permisosUsuario = ObtenerIdsPermisosUsuario(usuario.Permisos);

                foreach (var mapping in controlesForm)
                {
                    string key = $"{formulario.Name}.{mapping.NombreControl}";
                    controlesActuales.Add(key);

                    object controlFisico = EncontrarControl(formulario, mapping.NombreControl);
                    if (controlFisico != null)
                    {
                        bool tieneAcceso = permisosUsuario.Contains(mapping.IdPermiso);

                        if (controlFisico is Control c)
                        {
                            c.Visible = tieneAcceso;
                        }
                        else if (controlFisico is ToolStripItem tsi)
                        {
                            tsi.Visible = tieneAcceso;
                        }

                        _controlesControlados.Add(key);
                    }
                }

                List<string> aRemover = new List<string>();
                foreach (string key in _controlesControlados)
                {
                    if (key.StartsWith(formulario.Name + ".", StringComparison.OrdinalIgnoreCase) && !controlesActuales.Contains(key))
                    {
                        string ctrlName = key.Substring(formulario.Name.Length + 1);
                        object controlFisico = EncontrarControl(formulario, ctrlName);
                        if (controlFisico != null)
                        {
                            if (controlFisico is Control c)
                            {
                                c.Visible = true;
                            }
                            else if (controlFisico is ToolStripItem tsi)
                            {
                                tsi.Visible = true;
                            }
                        }
                        aRemover.Add(key);
                    }
                }

                foreach (string key in aRemover)
                {
                    _controlesControlados.Remove(key);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError($"[ManejadorSeguridad] Error al aplicar seguridad: {ex.Message}");
            }
        }

        private static HashSet<int> ObtenerIdsPermisosUsuario(List<ComponentePermiso> componentes)
        {
            HashSet<int> ids = new HashSet<int>();
            if (componentes == null) return ids;

            foreach (var comp in componentes)
            {
                AgregarIdsRecursivo(comp, ids);
            }
            return ids;
        }

        private static void AgregarIdsRecursivo(ComponentePermiso comp, HashSet<int> ids)
        {
            if (comp == null) return;
            if (ids.Add(comp.IdPermiso))
            {
                foreach (var hijo in comp.Hijos)
                {
                    AgregarIdsRecursivo(hijo, ids);
                }
            }
        }

        private static object EncontrarControl(Form form, string name)
        {
            Control[] match = form.Controls.Find(name, true);
            if (match.Length > 0) return match[0];

            foreach (Control c in form.Controls)
            {
                if (c is ToolStrip ts)
                {
                    object found = EncontrarEnToolStrip(ts, name);
                    if (found != null) return found;
                }
            }

            return null;
        }

        private static object EncontrarEnToolStrip(ToolStrip ts, string name)
        {
            foreach (ToolStripItem item in ts.Items)
            {
                if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
                if (item is ToolStripDropDownItem dropDown)
                {
                    object found = EncontrarEnItem(dropDown, name);
                    if (found != null) return found;
                }
            }
            return null;
        }

        private static object EncontrarEnItem(ToolStripDropDownItem parent, string name)
        {
            foreach (ToolStripItem item in parent.DropDownItems)
            {
                if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
                if (item is ToolStripDropDownItem dropDown)
                {
                    object found = EncontrarEnItem(dropDown, name);
                    if (found != null) return found;
                }
            }
            return null;
        }
    }
}
