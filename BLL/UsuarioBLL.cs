using BE;
using BE.Enums;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL _dal = new UsuarioDAL();

        private static readonly int[] _minutosBloqueo = { 1, 5, 15, 60 };

        public List<Usuario> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        public Usuario ObtenerPorId(int idUsuario)
        {
            return _dal.ObtenerPorId(idUsuario);
        }

        public Usuario ObtenerPorUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("El nombre de usuario no puede estar vacio.");
            return _dal.ObtenerPorUsername(username);
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

        public void Alta(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Username))
                throw new ArgumentException("El nombre de usuario no puede estar vacio.");
            if (string.IsNullOrEmpty(usuario.PasswordHash))
                throw new ArgumentException("La contraseña no puede estar vacia.");
            if (_dal.ObtenerPorUsername(usuario.Username) != null)
                throw new ArgumentException("El nombre de usuario ya existe.");

            _dal.Insertar(usuario);
        }

        public void CambiarEstado(Usuario usuario, EstadoUsuario nuevoEstado)
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
            _dal.Actualizar(usuario);
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
        }

        public void RegistrarLoginExitoso(Usuario usuario)
        {
            usuario.IntentosFallidos = 0;
            usuario.CantidadBloqueos = 0;
            usuario.UltimoLogin = DateTime.Now;
            _dal.Actualizar(usuario);
        }
    }
}
