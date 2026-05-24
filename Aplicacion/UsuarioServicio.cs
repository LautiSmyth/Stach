using BE;
using BE.Enums;
using BLL;
using Seguridad;
using System;
using System.Collections.Generic;

namespace Aplicacion
{
    public class UsuarioServicio
    {
        private readonly UsuarioBLL _bll = new UsuarioBLL();
        private readonly BitacoraServicio _bitacora = new BitacoraServicio();

        public void Alta(string modulo, string username, string password)
        {
            try
            {
                _bll.ValidarPassword(password);
                Usuario usuario = new Usuario
                {
                    Username = username,
                    PasswordHash = Encriptador.Hash(password),
                    Estado = EstadoUsuario.Activo,
                    FechaAlta = DateTime.Now,
                    IntentosFallidos = 0,
                    CantidadBloqueos = 0
                };
                _bll.Alta(usuario);
                _bitacora.Registrar(modulo, "Alta", $"Alta de usuario '{username}'.", true);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "Alta", $"Error al dar de alta usuario '{username}'.", false, ex.Message);
                throw;
            }
        }

        public void Modificar(string modulo, int idUsuario, string nuevoUsername, string nuevoPassword, EstadoUsuario nuevoEstado)
        {
            try
            {
                Usuario usuario = _bll.ObtenerPorId(idUsuario);
                if (usuario == null)
                    throw new ArgumentException("El usuario no existe.");

                var versionServ = new VersionUsuarioServicio();
                string actor = ObtenerUsernameEnSesion();
                if (string.IsNullOrEmpty(actor)) actor = "Sistema";
                versionServ.GrabarVersion(idUsuario, actor, $"Antes de modificación. Nuevo username: '{nuevoUsername}', Estado: {nuevoEstado}.");

                string anteriorUsername = usuario.Username;
                string nuevoPasswordHash = null;
                if (!string.IsNullOrEmpty(nuevoPassword))
                {
                    _bll.ValidarPassword(nuevoPassword);
                    nuevoPasswordHash = Encriptador.Hash(nuevoPassword);
                }

                _bll.Modificar(usuario, nuevoUsername, nuevoPasswordHash, nuevoEstado);

                string detalle = $"Modificacion de usuario '{anteriorUsername}'. Nuevo username: '{nuevoUsername}', Estado: {nuevoEstado}.";
                if (!string.IsNullOrEmpty(nuevoPassword))
                {
                    detalle += " Contraseña actualizada.";
                }
                _bitacora.Registrar(modulo, "Modificacion", detalle, true);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "Modificacion", $"Error al modificar usuario '{nuevoUsername}'.", false, ex.Message);
                throw;
            }
        }

        public void Login(string modulo, string username, string passwordIngresada)
        {
            try
            {
                Usuario usuario = _bll.ObtenerPorUsername(username);

                if (usuario == null)
                {
                    ContadorSesion.GetInstance().RegistrarIntento();
                    _bitacora.RegistrarSinSesion(username, modulo, "IntentoFallido", "Credenciales invalidas.", false, "Credenciales invalidas.");
                    throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
                }

                if (!Encriptador.Verificar(passwordIngresada, usuario.PasswordHash))
                {
                    _bll.RegistrarIntentoFallido(usuario);
                    ContadorSesion.GetInstance().RegistrarIntento();
                    _bitacora.RegistrarSinSesion(username, modulo, "IntentoFallido", "Credenciales invalidas.", false, "Credenciales invalidas.");
                    throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
                }

                try
                {
                    _bll.ValidarEstado(usuario);
                }
                catch (UnauthorizedAccessException)
                {
                    ContadorSesion.GetInstance().RegistrarIntento();
                    _bitacora.RegistrarSinSesion(username, modulo, "IntentoFallido", "Cuenta bloqueada.", false, "Cuenta bloqueada.");
                    throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
                }

                _bll.RegistrarLoginExitoso(usuario);
                ContadorSesion.GetInstance().Resetear();
                SessionManager.GetInstance().Login(usuario);
                _bitacora.Registrar(modulo, "Login", "Login exitoso.", true);
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _bitacora.RegistrarSinSesion(username, modulo, "IntentoFallido", "Error inesperado.", false, ex.Message);
                throw;
            }
        }

        public List<Usuario> ObtenerTodos()
        {
            return _bll.ObtenerTodos();
        }

        public void CambiarEstado(string modulo, int idUsuario, EstadoUsuario nuevoEstado)
        {
            Usuario usuario = _bll.ObtenerPorId(idUsuario);
            if (usuario == null) return;

            var versionServ = new VersionUsuarioServicio();
            string actor = ObtenerUsernameEnSesion();
            if (string.IsNullOrEmpty(actor)) actor = "Sistema";
            versionServ.GrabarVersion(idUsuario, actor, $"Antes de cambio de estado a {nuevoEstado}.");

            _bll.CambiarEstado(usuario, nuevoEstado);
            _bitacora.Registrar(modulo, "CambioEstado", $"Estado cambiado a {nuevoEstado} para '{usuario.Username}'.", true);
        }

        public bool LimiteAlcanzadoEnSesion()
        {
            return ContadorSesion.GetInstance().LimiteAlcanzado;
        }

        public void Logout(string modulo)
        {
            _bitacora.Registrar(modulo, "Logout", "Cierre de sesion.", true);
            SessionManager.GetInstance().Logout();
        }

        public string ObtenerUsernameEnSesion()
        {
            Usuario usuario = SessionManager.GetInstance().Usuario;
            return usuario == null ? string.Empty : usuario.Username;
        }

        public bool UsuarioLogueadoTienePermiso(string patenteKey)
        {
            Usuario usuario = SessionManager.GetInstance().Usuario;
            if (usuario == null) return false;
            var permisoServicio = new PermisoServicio();
            return permisoServicio.UsuarioTienePermiso(usuario, patenteKey);
        }

        public bool ValidarCredencialesAdmin(string username, string password, List<string> permisosRequeridos)
        {
            Usuario usuario = _bll.ObtenerPorUsername(username);
            if (usuario == null) return false;
            if (!Encriptador.Verificar(password, usuario.PasswordHash)) return false;
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase)) return true;
            var permisoServicio = new PermisoServicio();
            foreach (var permiso in permisosRequeridos)
            {
                if (permisoServicio.UsuarioTienePermiso(usuario, permiso)) return true;
            }
            return false;
        }
    }
}
