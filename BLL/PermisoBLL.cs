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
            if (_bitacora == null) throw new InvalidOperationException("Esta instancia de PermisoBLL no tiene servicio de bitacora configurado. Use el constructor completo.");
            try
            {
                Permiso p = new Permiso { Nombre = nombre };
                Insertar(p);
                _bitacora.Registrar(modulo, AltaPermisoActividad, string.Format("Creacion de permiso '{0}'.", nombre), true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, AltaPermisoActividad, string.Format("Error al crear permiso '{0}'.", nombre), false, ex.Message);
                throw;
            }
        }

        public void CrearRol(string modulo, string nombre)
        {
            if (_bitacora == null) throw new InvalidOperationException("Esta instancia de PermisoBLL no tiene servicio de bitacora configurado. Use el constructor completo.");
            try
            {
                Rol r = new Rol { Nombre = nombre };
                Insertar(r);
                _bitacora.Registrar(modulo, AltaPermisoActividad, string.Format("Creacion de rol '{0}'.", nombre), true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, AltaPermisoActividad, string.Format("Error al crear rol '{0}'.", nombre), false, ex.Message);
                throw;
            }
        }

        public void EliminarPermiso(string modulo, int idPermiso, string nombre)
        {
            if (_bitacora == null) throw new InvalidOperationException("Esta instancia de PermisoBLL no tiene servicio de bitacora configurado. Use el constructor completo.");
            try
            {
                var todos = _dal.ObtenerTodos();
                var target = todos.FirstOrDefault(p => p.IdPermiso == idPermiso);
                if (target != null && target.EsSistema)
                    throw new InvalidOperationException($"El permiso '{target.Nombre}' es un permiso de sistema y no puede ser eliminado.");
                if (_dal.EstaEnUso(idPermiso))
                {
                    throw new InvalidOperationException("No se puede eliminar el permiso/rol porque esta asignado a un usuario o forma parte de otro rol.");
                }
                _dal.Eliminar(idPermiso);
                _bitacora.Registrar(modulo, "BajaPermiso", string.Format("Eliminacion de permiso/rol '{0}'.", nombre), true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "BajaPermiso", string.Format("Error al eliminar permiso/rol '{0}'.", nombre), false, ex.Message);
                throw;
            }
        }

        public void GuardarRelaciones(string modulo, Rol rol)
        {
            if (_bitacora == null) throw new InvalidOperationException("Esta instancia de PermisoBLL no tiene servicio de bitacora configurado. Use el constructor completo.");
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
                    if (!resolvedPropuestos.Any(p => p.Nombre.Equals(PermisosNombres.GestionPermisos, StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new InvalidOperationException("No puedes modificar las relaciones de este rol porque te quitaria el permiso de Gestion de Permisos de tu propia cuenta.");
                    }
                }

                ValidarUltimoAdminActivo(rolModificado: rol);

                _dal.GuardarRelaciones(rol);
                _bitacora.Registrar(modulo, "ModificacionPermiso", string.Format("Modificacion de relaciones de la familia/rol '{0}'. Hijos: {1}.", rol.Nombre, rol.Hijos.Count), true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "ModificacionPermiso", string.Format("Error al modificar relaciones de la familia/rol '{0}'.", rol.Nombre), false, ex.Message);
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
            if (_bitacora == null) throw new InvalidOperationException("Esta instancia de PermisoBLL no tiene servicio de bitacora configurado. Use el constructor completo.");
            try
            {
                Usuario logueado = _sessionManager.Usuario;
                if (logueado != null && logueado.IdUsuario == idUsuario)
                {
                    List<Permiso> resolved = ResolverPermisos(permisos);
                    if (!resolved.Any(p => p.Nombre.Equals(PermisosNombres.GestionPermisos, StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new ArgumentException("No puedes remover el permiso de Gestion de Permisos de tu propia cuenta.");
                    }
                }

                ValidarUltimoAdminActivo(idUsuarioAfectado: idUsuario, permisosPropuestosAfectado: permisos);

                _dal.GuardarPermisosUsuario(idUsuario, permisos);
                _bitacora.Registrar(modulo, "ModificacionPermisosUsuario", string.Format("Asignacion de permisos al usuario '{0}'.", username), true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "ModificacionPermisosUsuario", string.Format("Error al asignar permisos al usuario '{0}'.", username), false, ex.Message);
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
                                   resolved.Any(p => p.Nombre.Equals(PermisosNombres.GestionUsuarios, StringComparison.OrdinalIgnoreCase)) ||
                                   resolved.Any(p => p.Nombre.Equals(PermisosNombres.GestionPermisos, StringComparison.OrdinalIgnoreCase));
                    if (esAdmin)
                    {
                        adminsActivosCount++;
                    }
                }
            }

            if (adminsActivosCount == 0)
            {
                throw new InvalidOperationException("No se permite realizar esta accion porque dejaria al sistema sin ningun administrador activo.");
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
