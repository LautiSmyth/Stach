using BE;
using BE.Enums;
using Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PermisoBLL
    {
        private const string AltaPermisoActividad = "AltaPermiso";

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
            List<ComponentePermiso> todos = _dal.ObtenerTodos();
            if (todos.Any(p => p.Nombre.Equals(permiso.Nombre, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("Ya existe un permiso o rol con el mismo nombre.");
            }
            _dal.Insertar(permiso);
        }

        public void CrearPermiso(string modulo, string nombre)
        {
            try
            {
                Permiso p = new Permiso { Nombre = nombre };
                Insertar(p);
                _bitacora.Registrar(modulo, AltaPermisoActividad, $"Creación de permiso '{nombre}'.", true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, AltaPermisoActividad, $"Error al crear permiso '{nombre}'.", false, ex.Message);
                throw;
            }
        }

        public void CrearRol(string modulo, string nombre)
        {
            try
            {
                Rol r = new Rol { Nombre = nombre };
                Insertar(r);
                _bitacora.Registrar(modulo, AltaPermisoActividad, $"Creación de rol '{nombre}'.", true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, AltaPermisoActividad, $"Error al crear rol '{nombre}'.", false, ex.Message);
                throw;
            }
        }

        public void EliminarPermiso(string modulo, int idPermiso, string nombre)
        {
            try
            {
                if (_dal.EstaEnUso(idPermiso))
                {
                    throw new InvalidOperationException("No se puede eliminar el permiso/rol porque está asignado a un usuario o forma parte de otro rol.");
                }
                _dal.Eliminar(idPermiso);
                _bitacora.Registrar(modulo, "BajaPermiso", $"Eliminación de permiso/rol '{nombre}'.", true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "BajaPermiso", $"Error al eliminar permiso/rol '{nombre}'.", false, ex.Message);
                throw;
            }
        }

        public void GuardarRelaciones(string modulo, Rol rol)
        {
            try
            {
                List<ComponentePermiso> todos = _dal.ObtenerTodos();
                int index = todos.FindIndex(p => p.IdPermiso == rol.IdPermiso);
                if (index >= 0)
                {
                    todos[index] = rol;
                }
                else
                {
                    todos.Add(rol);
                }

                foreach (ComponentePermiso comp in todos)
                {
                    if (TieneDependenciaCircular(comp, new HashSet<int>()))
                    {
                        throw new InvalidOperationException("No se permiten relaciones circulares de roles.");
                    }
                }

                Usuario logueado = _sessionManager.Usuario;
                if (logueado != null)
                {
                    List<ComponentePermiso> componentesPropuestosUsuario = new List<ComponentePermiso>();
                    foreach (var userPerm in logueado.Permisos)
                    {
                        var propuesto = todos.FirstOrDefault(p => p.IdPermiso == userPerm.IdPermiso);
                        if (propuesto != null)
                        {
                            componentesPropuestosUsuario.Add(propuesto);
                        }
                        else
                        {
                            componentesPropuestosUsuario.Add(userPerm);
                        }
                    }

                    List<Permiso> resolvedPropuestos = ResolverPermisos(componentesPropuestosUsuario);
                    if (!resolvedPropuestos.Any(p => p.Nombre.Equals("Gestión de Permisos", StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new InvalidOperationException("No puedes modificar las relaciones de este rol porque te quitaría el permiso de Gestión de Permisos de tu propia cuenta.");
                    }
                }

                
                ValidarUltimoAdminActivo(rolModificado: rol);

                _dal.GuardarRelaciones(rol);
                _bitacora.Registrar(modulo, "ModificacionPermiso", $"Modificación de relaciones de la familia/rol '{rol.Nombre}'. Hijos: {rol.Hijos.Count}.", true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "ModificacionPermiso", $"Error al modificar relaciones de la familia/rol '{rol.Nombre}'.", false, ex.Message);
                throw;
            }
        }

        private bool TieneDependenciaCircular(ComponentePermiso actual, HashSet<int> visitados)
        {
            if (actual == null) return false;
            if (!visitados.Add(actual.IdPermiso))
            {
                return true;
            }
            foreach (var hijo in actual.Hijos)
            {
                if (TieneDependenciaCircular(hijo, new HashSet<int>(visitados)))
                {
                    return true;
                }
            }
            return false;
        }

        public List<ComponentePermiso> ObtenerPermisosUsuario(int idUsuario)
        {
            return _dal.ObtenerPermisosUsuario(idUsuario);
        }

        public void GuardarPermisosUsuario(string modulo, int idUsuario, string username, List<ComponentePermiso> permisos)
        {
            try
            {
                Usuario logueado = _sessionManager.Usuario;
                if (logueado != null && logueado.IdUsuario == idUsuario)
                {
                    List<Permiso> resolved = ResolverPermisos(permisos);
                    if (!resolved.Any(p => p.Nombre.Equals("Gestión de Permisos", StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new ArgumentException("No puedes remover el permiso de Gestión de Permisos de tu propia cuenta.");
                    }
                }

                
                ValidarUltimoAdminActivo(idUsuarioAfectado: idUsuario, permisosPropuestosAfectado: permisos);

                _dal.GuardarPermisosUsuario(idUsuario, permisos);
                _bitacora.Registrar(modulo, "ModificacionPermisosUsuario", $"Asignación de permisos al usuario '{username}'.", true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "ModificacionPermisosUsuario", $"Error al asignar permisos al usuario '{username}'.", false, ex.Message);
                throw;
            }
        }

        public List<Permiso> ResolverPermisos(List<ComponentePermiso> componentes)
        {
            List<Permiso> permisos = new List<Permiso>();
            HashSet<int> visitados = new HashSet<int>();
            foreach (ComponentePermiso comp in componentes)
            {
                comp.ObtenerPermisos(permisos, visitados);
            }
            return permisos;
        }

        public bool UsuarioTienePermiso(Usuario usuario, string nombrePermiso)
        {
            if (usuario == null) return false;
            List<Permiso> permisos = ResolverPermisos(usuario.Permisos);
            return permisos.Any(p => p.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase));
        }

        public void GuardarControlesAsociados(int idPermiso, List<ControlMapeado> controles)
        {
            _dal.GuardarControlesAsociados(idPermiso, controles);
        }

        public List<ControlMapeado> ObtenerControlesPorPermiso(int idPermiso)
        {
            return _dal.ObtenerControlesPorPermiso(idPermiso);
        }

        public List<ControlMapeado> ObtenerTodosLosControlesProtegidos()
        {
            return _dal.ObtenerTodosLosControlesProtegidos();
        }

        private void ValidarUltimoAdminActivo(int? idUsuarioAfectado = null, List<ComponentePermiso> permisosPropuestosAfectado = null, Rol rolModificado = null)
        {
            var usuarioDal = IoCContainer.Resolver<IUsuarioDAL>();
            List<Usuario> todosLosUsuarios = usuarioDal.ObtenerTodos();
            int adminsActivosCount = 0;

            foreach (Usuario u in todosLosUsuarios)
            {
                if (u.Estado == EstadoUsuario.Activo)
                {
                    
                    List<ComponentePermiso> permsUser;
                    if (idUsuarioAfectado.HasValue && u.IdUsuario == idUsuarioAfectado.Value)
                    {
                        permsUser = permisosPropuestosAfectado != null ? new List<ComponentePermiso>(permisosPropuestosAfectado) : new List<ComponentePermiso>();
                    }
                    else
                    {
                        permsUser = _dal.ObtenerPermisosUsuario(u.IdUsuario);
                    }

                    
                    if (rolModificado != null)
                    {
                        ActualizarRolEnLista(permsUser, rolModificado);
                    }

                    List<Permiso> resolved = ResolverPermisos(permsUser);
                    bool esAdmin = u.Username.Equals("admin", StringComparison.OrdinalIgnoreCase) ||
                                   resolved.Any(p => p.Nombre.Equals("Gestión de Usuarios", StringComparison.OrdinalIgnoreCase)) ||
                                   resolved.Any(p => p.Nombre.Equals("Gestión de Permisos", StringComparison.OrdinalIgnoreCase));
                    if (esAdmin)
                    {
                        adminsActivosCount++;
                    }
                }
            }

            if (adminsActivosCount == 0)
            {
                throw new InvalidOperationException("No se permite realizar esta acción porque dejaría al sistema sin ningún administrador activo.");
            }
        }

        private void ActualizarRolEnLista(List<ComponentePermiso> perms, Rol rolModificado)
        {
            if (perms == null) return;
            for (int i = 0; i < perms.Count; i++)
            {
                if (perms[i].IdPermiso == rolModificado.IdPermiso)
                {
                    perms[i] = rolModificado;
                }
                else
                {
                    var hijos = perms[i].Hijos;
                    if (hijos != null && hijos.Count > 0)
                    {
                        ActualizarRolEnLista(hijos, rolModificado);
                    }
                }
            }
        }
    }
}