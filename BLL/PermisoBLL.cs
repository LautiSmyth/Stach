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
            _dal.Insertar(permiso);
        }

        public void Eliminar(int idPermiso)
        {
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
