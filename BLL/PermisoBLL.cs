using BE;
using Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PermisoBLL
    {
        private readonly IPermisoDAL _dal;
        private readonly IBitacoraService _bitacora;
        private readonly ISessionManager _sessionManager;

        public PermisoBLL(IPermisoDAL dal)
        {
            _dal = dal;
        }

        public PermisoBLL(IPermisoDAL dal, IBitacoraService bitacora, ISessionManager sessionManager)
        {
            _dal = dal;
            _bitacora = bitacora;
            _sessionManager = sessionManager;
        }

        public List<ComponentePermiso> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        public void Insertar(ComponentePermiso permiso)
        {
            if (permiso == null) throw new ArgumentNullException(nameof(permiso));
            var todos = _dal.ObtenerTodos();
            if (todos.Any(p => p.Nombre.Equals(permiso.Nombre, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("Ya existe un permiso o rol con el mismo nombre.");
            }
            if (!string.IsNullOrEmpty(permiso.PermisoKey) && todos.Any(p => !string.IsNullOrEmpty(p.PermisoKey) && p.PermisoKey.Equals(permiso.PermisoKey, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("Ya existe un permiso o rol con la misma clave.");
            }
            _dal.Insertar(permiso);
        }

        public void CrearPatente(string modulo, string nombre, string key)
        {
            try
            {
                var p = new Patente { Nombre = nombre, PermisoKey = key };
                Insertar(p);
                _bitacora.Registrar(modulo, "AltaPermiso", $"Creación de patente '{nombre}' con clave '{key}'.", true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "AltaPermiso", $"Error al crear patente '{nombre}'.", false, ex.Message);
                throw;
            }
        }

        public void CrearFamilia(string modulo, string nombre, string key)
        {
            try
            {
                var f = new Familia { Nombre = nombre, PermisoKey = key };
                Insertar(f);
                _bitacora.Registrar(modulo, "AltaPermiso", $"Creación de familia '{nombre}' con clave '{key}'.", true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "AltaPermiso", $"Error al crear familia '{nombre}'.", false, ex.Message);
                throw;
            }
        }

        public void EliminarPermiso(string modulo, int idPermiso, string nombre)
        {
            try
            {
                if (_dal.EstaEnUso(idPermiso))
                {
                    throw new InvalidOperationException("No se puede eliminar el permiso/rol porque está asignado a un usuario o forma parte de otro rol (familia).");
                }
                _dal.Eliminar(idPermiso);
                _bitacora.Registrar(modulo, "BajaPermiso", $"Eliminación de permiso '{nombre}'.", true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "BajaPermiso", $"Error al eliminar permiso '{nombre}'.", false, ex.Message);
                throw;
            }
        }

        public void GuardarRelaciones(string modulo, Familia familia)
        {
            try
            {
                _dal.GuardarRelaciones(familia);
                _bitacora.Registrar(modulo, "ModificacionPermiso", $"Modificación de relaciones de la familia '{familia.Nombre}'. Hijos: {familia.Hijos.Count}.", true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "ModificacionPermiso", $"Error al modificar relaciones de la familia '{familia.Nombre}'.", false, ex.Message);
                throw;
            }
        }

        public List<ComponentePermiso> ObtenerPermisosUsuario(int idUsuario)
        {
            return _dal.ObtenerPermisosUsuario(idUsuario);
        }

        public void GuardarPermisosUsuario(string modulo, int idUsuario, string username, List<ComponentePermiso> permisos)
        {
            try
            {
                var logueado = _sessionManager.Usuario;
                if (logueado != null && logueado.IdUsuario == idUsuario)
                {
                    var resolved = ResolverPatentes(permisos);
                    if (!resolved.Any(p => p.PermisoKey != null && p.PermisoKey.Equals("Permisos", StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new ArgumentException("No puedes remover el permiso de Gestión de Permisos de tu propia cuenta.");
                    }
                }

                _dal.GuardarPermisosUsuario(idUsuario, permisos);
                _bitacora.Registrar(modulo, "ModificacionPermisosUsuario", $"Asignación de permisos al usuario '{username}'.", true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "ModificacionPermisosUsuario", $"Error al asignar permisos al usuario '{username}'.", false, ex.Message);
                throw;
            }
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
            return patentes.Any(p => p.PermisoKey.Equals(patenteKey, StringComparison.OrdinalIgnoreCase));
        }
    }
}