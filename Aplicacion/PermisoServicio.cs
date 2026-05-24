using BE;
using BLL;
using System;
using System.Collections.Generic;

namespace Aplicacion
{
    public class PermisoServicio
    {
        private readonly PermisoBLL _bll = new PermisoBLL();
        private readonly UsuarioBLL _usuarioBll = new UsuarioBLL();
        private readonly BitacoraServicio _bitacora = new BitacoraServicio();

        public List<ComponentePermiso> ObtenerTodos()
        {
            return _bll.ObtenerTodos();
        }

        public void CrearPatente(string modulo, string nombre, string key)
        {
            try
            {
                var p = new Patente { Nombre = nombre, PermisoKey = key };
                _bll.Insertar(p);
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
                _bll.Insertar(f);
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
                _bll.Eliminar(idPermiso);
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
                _bll.GuardarRelaciones(familia);
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
            return _bll.ObtenerPermisosUsuario(idUsuario);
        }

        public void GuardarPermisosUsuario(string modulo, int idUsuario, string username, List<ComponentePermiso> permisos)
        {
            try
            {
                _bll.GuardarPermisosUsuario(idUsuario, permisos);
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
            return _bll.ResolverPatentes(componentes);
        }

        public bool UsuarioTienePermiso(Usuario usuario, string patenteKey)
        {
            return _bll.UsuarioTienePermiso(usuario, patenteKey);
        }
    }
}
