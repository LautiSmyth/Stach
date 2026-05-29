using BE;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PermisoBLL
    {
        private readonly PermisoDAL _dal = new PermisoDAL();

        public List<ComponentePermiso> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        public void Insertar(ComponentePermiso permiso)
        {
            if (permiso == null) throw new System.ArgumentNullException(nameof(permiso));
            var todos = _dal.ObtenerTodos();
            if (todos.Any(p => p.Nombre.Equals(permiso.Nombre, System.StringComparison.OrdinalIgnoreCase)))
            {
                throw new System.ArgumentException("Ya existe un permiso o rol con el mismo nombre.");
            }
            if (!string.IsNullOrEmpty(permiso.PermisoKey) && todos.Any(p => !string.IsNullOrEmpty(p.PermisoKey) && p.PermisoKey.Equals(permiso.PermisoKey, System.StringComparison.OrdinalIgnoreCase)))
            {
                throw new System.ArgumentException("Ya existe un permiso o rol con la misma clave.");
            }
            _dal.Insertar(permiso);
        }

        public void Eliminar(int idPermiso)
        {
            if (_dal.EstaEnUso(idPermiso))
            {
                throw new System.InvalidOperationException("No se puede eliminar el permiso/rol porque está asignado a un usuario o forma parte de otro rol (familia).");
            }
            _dal.Eliminar(idPermiso);
        }

        public void GuardarRelaciones(Familia familia)
        {
            _dal.GuardarRelaciones(familia);
        }

        public List<ComponentePermiso> ObtenerPermisosUsuario(int idUsuario)
        {
            return _dal.ObtenerPermisosUsuario(idUsuario);
        }

        public void GuardarPermisosUsuario(int idUsuario, List<ComponentePermiso> permisos)
        {
            _dal.GuardarPermisosUsuario(idUsuario, permisos);
        }

        public List<Patente> ResolverPatentes(List<ComponentePermiso> componentes)
        {
            var patentes = new List<Patente>();
            var visitados = new HashSet<int>();
            foreach (var comp in componentes)
            {
                ResolverPatentesRecursivo(comp, patentes, visitados);
            }
            return patentes;
        }

        private void ResolverPatentesRecursivo(ComponentePermiso componente, List<Patente> acumulador, HashSet<int> visitados)
        {
            if (componente == null || visitados.Contains(componente.IdPermiso)) return;
            visitados.Add(componente.IdPermiso);

            if (componente is Patente patente)
            {
                if (acumulador.All(p => p.IdPermiso != patente.IdPermiso))
                {
                    acumulador.Add(patente);
                }
            }
            else if (componente is Familia familia)
            {
                foreach (var hijo in familia.Hijos)
                {
                    ResolverPatentesRecursivo(hijo, acumulador, visitados);
                }
            }
        }

        public bool UsuarioTienePermiso(Usuario usuario, string patenteKey)
        {
            if (usuario == null) return false;
            var patentes = ResolverPatentes(usuario.Permisos);
            return patentes.Any(p => p.PermisoKey.Equals(patenteKey, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}