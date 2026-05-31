using BE;
using BE.Enums;
using Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S107:Constructor has many parameters")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "S6561:Avoid using DateTime.Now for benchmarking or timespan calculation operations")]
    public class UsuarioBLL
    {
        private readonly IUsuarioDAL _dal;
        private readonly IPermisoDAL _permisoDal;
        private readonly IDigitoVerificadorService _dvService;
        private readonly IVersionUsuarioDAL _versionDal;
        private readonly ISessionManager _sessionManager;
        private readonly IBitacoraService _bitacora;
        private readonly IEncriptador _encriptador;
        private readonly IContadorSesion _contadorSesion;

        private const string IntentoFallidoActividad = "IntentoFallido";
        private const string CredencialesInvalidasDetalle = "Credenciales invalidas.";

        private static readonly int[] _minutosBloqueo = { 1, 5, 15, 60 };

        public UsuarioBLL(IUsuarioDAL dal, IPermisoDAL permisoDal, IDigitoVerificadorService dvService,
            IVersionUsuarioDAL versionDal, ISessionManager sessionManager, IBitacoraService bitacora,
            IEncriptador encriptador, IContadorSesion contadorSesion)
        {
            _dal = dal;
            _permisoDal = permisoDal;
            _dvService = dvService;
            _versionDal = versionDal;
            _sessionManager = sessionManager;
            _bitacora = bitacora;
            _encriptador = encriptador;
            _contadorSesion = contadorSesion;
        }

        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> usuarios = _dal.ObtenerTodos();
            PermisoBLL permisoBll = new PermisoBLL(_permisoDal);
            foreach (Usuario u in usuarios)
            {
                u.Permisos = permisoBll.ObtenerPermisosUsuario(u.IdUsuario);
            }
            return usuarios;
        }

        public Usuario ObtenerPorId(int idUsuario)
        {
            Usuario u = _dal.ObtenerPorId(idUsuario);
            if (u != null)
            {
                PermisoBLL permisoBll = new PermisoBLL(_permisoDal);
                u.Permisos = permisoBll.ObtenerPermisosUsuario(u.IdUsuario);
            }
            return u;
        }

        public Usuario ObtenerPorUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("El nombre de usuario no puede estar vacio.");
            Usuario u = _dal.ObtenerPorUsername(username);
            if (u != null)
            {
                PermisoBLL permisoBll = new PermisoBLL(_permisoDal);
                u.Permisos = permisoBll.ObtenerPermisosUsuario(u.IdUsuario);
            }
            return u;
        }

        public void ValidarEstado(Usuario usuario)
        {
            if (usuario.Estado == EstadoUsuario.Bloqueado)
            {
                if (usuario.CantidadBloqueos <= 0 || usuario.CantidadBloqueos > _minutosBloqueo.Length)
                    throw new UnauthorizedAccessException("Usuario bloqueado permanentemente. Contacte al administrador.");

                int minutosEspera = _minutosBloqueo[usuario.CantidadBloqueos - 1];
                bool expirado = usuario.FechaBloqueo.HasValue &&
                    (DateTime.Now - usuario.FechaBloqueo.Value).TotalMinutes >= minutosEspera;

                if (expirado)
                {
                    usuario.Estado = EstadoUsuario.Activo;
                    usuario.IntentosFallidos = 0;
                    usuario.FechaBloqueo = null;
                    _dal.Actualizar(usuario);
                    _dvService.InicializarDVs();
                }
                else
                {
                    throw new UnauthorizedAccessException(
                        $"Usuario bloqueado. Intente nuevamente en {minutosEspera} minutos.");
                }
            }

            if (usuario.Estado == EstadoUsuario.Inactivo)
                throw new UnauthorizedAccessException("Usuario inactivo. Contacte al administrador.");
        }

        public static void ValidarPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("La contraseña no puede estar vacia.");
            if (password.Length < 6)
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
            bool tieneMayuscula = false;
            bool tieneNumero = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) tieneMayuscula = true;
                if (char.IsDigit(c)) tieneNumero = true;
            }
            if (!tieneMayuscula || !tieneNumero)
                throw new ArgumentException("La contraseña debe contener al menos una letra mayúscula y un número.");
        }

        public void Alta(string modulo, string username, string password)
        {
            try
            {
                ValidarPassword(password);
                if (_dal.ObtenerPorUsername(username) != null)
                    throw new ArgumentException("El nombre de usuario ya existe.");

                Usuario usuario = new Usuario
                {
                    Username = username,
                    PasswordHash = _encriptador.Hash(password),
                    Estado = EstadoUsuario.Activo,
                    FechaAlta = DateTime.Now,
                    IntentosFallidos = 0,
                    CantidadBloqueos = 0
                };
                _dal.Insertar(usuario);
                _dvService.InicializarDVs();
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
                Usuario usuario = _dal.ObtenerPorId(idUsuario) ?? throw new ArgumentException("El usuario no existe.");

                Usuario logueado = ObtenerUsuarioLogueado();
                if (logueado != null && logueado.IdUsuario == idUsuario && nuevoEstado != EstadoUsuario.Activo)
                {
                    throw new ArgumentException("No puedes desactivar o bloquear tu propia cuenta.");
                }

                string actor = ObtenerUsernameEnSesion();
                if (string.IsNullOrEmpty(actor)) actor = "Sistema";

                VersionUsuario v = new VersionUsuario
                {
                    IdUsuario = usuario.IdUsuario,
                    Username = usuario.Username,
                    PasswordHash = usuario.PasswordHash,
                    Estado = usuario.Estado,
                    ModificadoPor = actor,
                    FechaModificacion = DateTime.Now,
                    DetalleCambios = $"Antes de modificación. Nuevo username: '{nuevoUsername}', Estado: {nuevoEstado}."
                };
                _versionDal.Insertar(v);

                string anteriorUsername = usuario.Username;
                string nuevoPasswordHash = null;
                if (!string.IsNullOrEmpty(nuevoPassword))
                {
                    ValidarPassword(nuevoPassword);
                    nuevoPasswordHash = _encriptador.Hash(nuevoPassword);
                }

                usuario.Username = nuevoUsername;
                if (!string.IsNullOrEmpty(nuevoPasswordHash))
                {
                    usuario.PasswordHash = nuevoPasswordHash;
                }

                if (nuevoEstado != usuario.Estado)
                {
                    usuario.Estado = nuevoEstado;
                    if (nuevoEstado == EstadoUsuario.Activo)
                    {
                        usuario.IntentosFallidos = 0;
                        usuario.CantidadBloqueos = 0;
                        usuario.FechaBloqueo = null;
                    }
                    else if (nuevoEstado == EstadoUsuario.Bloqueado)
                    {
                        usuario.FechaBloqueo = DateTime.Now;
                        usuario.CantidadBloqueos++;
                    }
                }

                _dal.Actualizar(usuario);
                _dvService.InicializarDVs();

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

        public void CambiarEstado(string modulo, int idUsuario, EstadoUsuario nuevoEstado)
        {
            Usuario usuario = _dal.ObtenerPorId(idUsuario);
            if (usuario == null) return;

            string actor = ObtenerUsernameEnSesion();
            if (string.IsNullOrEmpty(actor)) actor = "Sistema";

            VersionUsuario v = new VersionUsuario
            {
                IdUsuario = usuario.IdUsuario,
                Username = usuario.Username,
                PasswordHash = usuario.PasswordHash,
                Estado = usuario.Estado,
                ModificadoPor = actor,
                FechaModificacion = DateTime.Now,
                DetalleCambios = $"Antes de cambio de estado a {nuevoEstado}."
            };
            _versionDal.Insertar(v);

            usuario.Estado = nuevoEstado;
            if (nuevoEstado == EstadoUsuario.Activo)
            {
                usuario.IntentosFallidos = 0;
                usuario.CantidadBloqueos = 0;
                usuario.FechaBloqueo = null;
            }
            else if (nuevoEstado == EstadoUsuario.Bloqueado)
            {
                usuario.FechaBloqueo = DateTime.Now;
                usuario.CantidadBloqueos++;
            }
            _dal.Actualizar(usuario);
            _dvService.InicializarDVs();
            _bitacora.Registrar(modulo, "CambioEstado", $"Estado cambiado a {nuevoEstado} para '{usuario.Username}'.", true);
        }

        public void Login(string modulo, string username, string passwordIngresada)
        {
            try
            {
                Usuario usuario = ObtenerPorUsername(username);

                if (usuario == null)
                {
                    _contadorSesion.RegistrarIntento();
                    _bitacora.RegistrarSinSesion(username, modulo, IntentoFallidoActividad, CredencialesInvalidasDetalle, false, CredencialesInvalidasDetalle);
                    throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
                }

                if (!_encriptador.Verificar(passwordIngresada, usuario.PasswordHash))
                {
                    RegistrarIntentoFallido(usuario);
                    _contadorSesion.RegistrarIntento();
                    _bitacora.RegistrarSinSesion(username, modulo, IntentoFallidoActividad, CredencialesInvalidasDetalle, false, CredencialesInvalidasDetalle);
                    throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
                }

                try
                {
                    ValidarEstado(usuario);
                }
                catch (UnauthorizedAccessException)
                {
                    _contadorSesion.RegistrarIntento();
                    _bitacora.RegistrarSinSesion(username, modulo, IntentoFallidoActividad, "Cuenta bloqueada.", false, "Cuenta bloqueada.");
                    throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
                }

                RegistrarLoginExitoso(usuario);
                _contadorSesion.Resetear();
                _sessionManager.Login(usuario);
                _bitacora.Registrar(modulo, "Login", "Login exitoso.", true);
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _bitacora.RegistrarSinSesion(username, modulo, IntentoFallidoActividad, "Error inesperado.", false, ex.Message);
                throw;
            }
        }

        public bool LimiteAlcanzadoEnSesion()
        {
            return _contadorSesion.LimiteAlcanzado;
        }

        public void Logout(string modulo)
        {
            _bitacora.Registrar(modulo, "Logout", "Cierre de sesion.", true);
            _sessionManager.Logout();
        }

        public string ObtenerUsernameEnSesion()
        {
            Usuario usuario = _sessionManager.Usuario;
            return usuario == null ? string.Empty : usuario.Username;
        }

        public bool UsuarioLogueadoTienePermiso(string permisoKey)
        {
            Usuario usuario = _sessionManager.Usuario;
            if (usuario == null) return false;
            PermisoBLL permisoBll = new PermisoBLL(_permisoDal);
            return permisoBll.UsuarioTienePermiso(usuario, permisoKey);
        }

        public bool ValidarCredencialesAdmin(string username, string password, List<string> permisosRequeridos)
        {
            Usuario usuario = ObtenerPorUsername(username);
            if (usuario == null) return false;
            if (!_encriptador.Verificar(password, usuario.PasswordHash)) return false;
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase)) return true;
            PermisoBLL permisoBll = new PermisoBLL(_permisoDal);
            return permisosRequeridos.Any(permiso => permisoBll.UsuarioTienePermiso(usuario, permiso));
        }

        public Usuario ObtenerUsuarioLogueado()
        {
            return _sessionManager.Usuario;
        }

        public void RestaurarVersion(Usuario usuario, string username, string passwordHash, EstadoUsuario estado)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("El nombre de usuario no puede estar vacio.");
            usuario.Username = username;
            usuario.PasswordHash = passwordHash;
            usuario.Estado = estado;
            _dal.Actualizar(usuario);
            _dvService.InicializarDVs();
        }

        public void RegistrarIntentoFallido(Usuario usuario)
        {
            usuario.IntentosFallidos++;
            if (usuario.IntentosFallidos >= 3)
            {
                usuario.Estado = EstadoUsuario.Bloqueado;
                usuario.FechaBloqueo = DateTime.Now;
                usuario.CantidadBloqueos++;
            }
            _dal.Actualizar(usuario);
            _dvService.InicializarDVs();
        }

        public void RegistrarLoginExitoso(Usuario usuario)
        {
            usuario.IntentosFallidos = 0;
            usuario.UltimoLogin = DateTime.Now;
            _dal.Actualizar(usuario);
            _dvService.InicializarDVs();
        }
    }
}