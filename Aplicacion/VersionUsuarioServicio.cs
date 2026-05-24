using BE;
using BLL;
using System;
using System.Collections.Generic;

namespace Aplicacion
{
    public class VersionUsuarioServicio
    {
        private readonly VersionUsuarioBLL _bll = new VersionUsuarioBLL();
        private readonly UsuarioBLL _usuarioBll = new UsuarioBLL();
        private readonly BitacoraServicio _bitacora = new BitacoraServicio();

        public List<VersionUsuario> ObtenerPorUsuario(int idUsuario)
        {
            return _bll.ObtenerPorUsuario(idUsuario);
        }

        public void GrabarVersion(int idUsuario, string modificadoPor, string detalleCambios)
        {
            var u = _usuarioBll.ObtenerPorId(idUsuario);
            if (u != null)
            {
                var v = new VersionUsuario
                {
                    IdUsuario = u.IdUsuario,
                    Username = u.Username,
                    PasswordHash = u.PasswordHash,
                    Estado = u.Estado,
                    ModificadoPor = modificadoPor,
                    FechaModificacion = DateTime.Now,
                    DetalleCambios = detalleCambios
                };
                _bll.Insertar(v);
            }
        }

        public void RestaurarVersion(string modulo, int idVersion, string actor)
        {
            try
            {
                _bll.RestaurarVersion(idVersion, actor);
                _bitacora.Registrar(modulo, "Rollback", $"Rollback a versión {idVersion} ejecutado por '{actor}'.", true);
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "Rollback", $"Error al ejecutar rollback a versión {idVersion}.", false, ex.Message);
                throw;
            }
        }
    }
}