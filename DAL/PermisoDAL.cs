using BE;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class PermisoDAL
    {
        private static readonly List<ComponentePermiso> _permisos = new List<ComponentePermiso>();
        private static readonly Dictionary<int, List<int>> _usuarioPermisos = new Dictionary<int, List<int>>();
        private static int _nextId = 10;

        static PermisoDAL()
        {
            var pUsuarios = new Patente { IdPermiso = 1, Nombre = "Gestión de Usuarios", PermisoKey = "Usuarios" };
            var pBitacora = new Patente { IdPermiso = 2, Nombre = "Ver Bitácora", PermisoKey = "Bitacora" };
            var pIdiomas = new Patente { IdPermiso = 3, Nombre = "Gestión de Idiomas", PermisoKey = "Idiomas" };
            var pPermisos = new Patente { IdPermiso = 4, Nombre = "Gestión de Permisos", PermisoKey = "Permisos" };
            var pCambios = new Patente { IdPermiso = 5, Nombre = "Control de Cambios", PermisoKey = "ControlCambios" };
            var pDV = new Patente { IdPermiso = 6, Nombre = "Restauración DV", PermisoKey = "RestauracionDV" };

            _permisos.Add(pUsuarios);
            _permisos.Add(pBitacora);
            _permisos.Add(pIdiomas);
            _permisos.Add(pPermisos);
            _permisos.Add(pCambios);
            _permisos.Add(pDV);

            var fAdmin = new Familia { IdPermiso = 100, Nombre = "Administrador", PermisoKey = "FamiliaAdmin" };
            fAdmin.Agregar(pUsuarios);
            fAdmin.Agregar(pBitacora);
            fAdmin.Agregar(pIdiomas);
            fAdmin.Agregar(pPermisos);
            fAdmin.Agregar(pCambios);
            fAdmin.Agregar(pDV);

            var fSuper = new Familia { IdPermiso = 101, Nombre = "Supervisor", PermisoKey = "FamiliaSupervisor" };
            fSuper.Agregar(pBitacora);
            fSuper.Agregar(pIdiomas);
            fSuper.Agregar(pCambios);

            var fOper = new Familia { IdPermiso = 102, Nombre = "Operador", PermisoKey = "FamiliaOperador" };
            fOper.Agregar(pBitacora);

            _permisos.Add(fAdmin);
            _permisos.Add(fSuper);
            _permisos.Add(fOper);

            _usuarioPermisos[1] = new List<int> { 100 };
            _usuarioPermisos[2] = new List<int> { 102 };
        }

        public List<ComponentePermiso> ObtenerTodos()
        {
            return new List<ComponentePermiso>(_permisos);
        }

        public void Insertar(ComponentePermiso permiso)
        {
            permiso.IdPermiso = _nextId++;
            _permisos.Add(permiso);
        }

        public void Eliminar(int idPermiso)
        {
            var p = _permisos.FirstOrDefault(x => x.IdPermiso == idPermiso);
            if (p != null)
            {
                _permisos.Remove(p);
                foreach (var f in _permisos.OfType<Familia>())
                {
                    f.Quitar(p);
                }
                foreach (var kvp in _usuarioPermisos)
                {
                    kvp.Value.Remove(idPermiso);
                }
            }
        }

        public void GuardarRelaciones(Familia familia)
        {
            var fExistente = _permisos.OfType<Familia>().FirstOrDefault(x => x.IdPermiso == familia.IdPermiso);
            if (fExistente != null)
            {
                fExistente.Hijos.Clear();
                foreach (var hijo in familia.Hijos)
                {
                    fExistente.Agregar(hijo);
                }
            }
        }

        public List<ComponentePermiso> ObtenerPermisosUsuario(int idUsuario)
        {
            var list = new List<ComponentePermiso>();
            if (_usuarioPermisos.TryGetValue(idUsuario, out List<int> ids))
            {
                foreach (var id in ids)
                {
                    var p = _permisos.FirstOrDefault(x => x.IdPermiso == id);
                    if (p != null)
                    {
                        list.Add(p);
                    }
                }
            }
            return list;
        }

        public void GuardarPermisosUsuario(int idUsuario, List<ComponentePermiso> permisos)
        {
            _usuarioPermisos[idUsuario] = permisos.Select(x => x.IdPermiso).ToList();
        }
    }
}
