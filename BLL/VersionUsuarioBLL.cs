using BE;
using Abstracciones;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class VersionUsuarioBLL
    {
        private readonly IVersionUsuarioDAL _dal;
        private readonly UsuarioBLL _usuarioBll;

        public VersionUsuarioBLL(IVersionUsuarioDAL dal, UsuarioBLL usuarioBll)
        {
            _dal = dal;
            _usuarioBll = usuarioBll;
        }

        public void Insertar(VersionUsuario version)
        {
            _dal.Insertar(version);
        }

        public List<VersionUsuario> ObtenerPorUsuario(int idUsuario)
        {
            return _dal.ObtenerPorUsuario(idUsuario);
        }

        public void RestaurarVersion(int idVersion, string actor)
        {
            var version = _dal.ObtenerPorId(idVersion);
            if (version == null)
            {
                throw new ArgumentException("La versión no existe.");
            }

            var usuario = _usuarioBll.ObtenerPorId(version.IdUsuario);
            if (usuario == null)
            {
                throw new ArgumentException("El usuario de esta versión ya no existe.");
            }

            _usuarioBll.RestaurarVersion(usuario, version.Username, version.PasswordHash, version.Estado);
        }
    }
}