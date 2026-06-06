using BE;
using Abstracciones;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class VersionUsuarioBLL
    {
        private readonly IVersionUsuarioDAL _dal;
        private readonly IUsuarioDAL _usuarioDal;
        private readonly IDigitoVerificadorService _dvService;
        private readonly IBitacoraService _bitacora;

        public VersionUsuarioBLL(IVersionUsuarioDAL dal, IUsuarioDAL usuarioDal, IDigitoVerificadorService dvService, IBitacoraService bitacora)
        {
            _dal = dal;
            _usuarioDal = usuarioDal;
            _dvService = dvService;
            _bitacora = bitacora;
        }

        public void Insertar(VersionUsuario version)
        {
            _dal.Insertar(version);
        }

        public List<VersionUsuario> ObtenerPorUsuario(int idUsuario)
        {
            return _dal.ObtenerPorUsuario(idUsuario);
        }

        public void RestaurarVersion(string modulo, int idVersion, string actor)
        {
            try
            {
                VersionUsuario version = _dal.ObtenerPorId(idVersion) ?? throw new ArgumentException("La versión no existe.");

                Usuario usuario = _usuarioDal.ObtenerPorId(version.IdUsuario) ?? throw new ArgumentException("El usuario de esta versión ya no existe.");

                
                VersionUsuario vActual = new VersionUsuario
                {
                    IdUsuario = usuario.IdUsuario,
                    Username = usuario.Username,
                    PasswordHash = usuario.PasswordHash,
                    Estado = usuario.Estado,
                    ModificadoPor = actor,
                    FechaModificacion = DateTime.Now,
                    DetalleCambios = $"Antes de rollback a versión {idVersion}."
                };
                _dal.Insertar(vActual);

                usuario.Username = version.Username;
                usuario.PasswordHash = version.PasswordHash;
                usuario.Estado = version.Estado;

                _usuarioDal.Actualizar(usuario);
                _dvService.InicializarDVs();
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