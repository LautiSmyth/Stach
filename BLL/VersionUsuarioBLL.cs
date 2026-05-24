using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class VersionUsuarioBLL
    {
        private readonly VersionUsuarioDAL _dal = new VersionUsuarioDAL();
        private readonly UsuarioBLL _usuarioBll = new UsuarioBLL();

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
