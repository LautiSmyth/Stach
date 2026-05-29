using BE;
using Abstracciones;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public class BitacoraService : IBitacoraService
    {
        private readonly IBitacoraDAL _dal;
        private readonly ISessionManager _session;

        public BitacoraService(IBitacoraDAL dal, ISessionManager session)
        {
            _dal = dal;
            _session = session;
        }

        public List<Bitacora> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        public void Registrar(string modulo, string actividad, string detalle, bool exitoso, string error = "")
        {
            Usuario usuario = _session.Usuario;
            if (usuario == null)
            {
                RegistrarSinSesion("sin sesion", modulo, actividad, detalle, exitoso, error);
                return;
            }

            string detalleCompleto = exitoso
                ? $"El usuario '{usuario.Username}' realizo '{actividad}' en '{modulo}'. {detalle}"
                : $"El usuario '{usuario.Username}' intento '{actividad}' en '{modulo}' pero ocurrio un error. {detalle}";

            _dal.Insertar(new Bitacora
            {
                Fecha = DateTime.Now,
                IdUsuario = usuario.IdUsuario,
                Username = usuario.Username,
                Modulo = modulo,
                Actividad = actividad,
                Criticidad = CriticidadMapper.Obtener(actividad),
                Detalle = detalleCompleto,
                Error = error,
                Exitoso = exitoso
            });
        }

        public void RegistrarSinSesion(string usernameIngresado, string modulo, string actividad, string detalle, bool exitoso, string error = "")
        {
            _dal.Insertar(new Bitacora
            {
                Fecha = DateTime.Now,
                IdUsuario = null,
                Username = usernameIngresado,
                Modulo = modulo,
                Actividad = actividad,
                Criticidad = CriticidadMapper.Obtener(actividad),
                Detalle = detalle,
                Error = error,
                Exitoso = exitoso
            });
        }
    }
}
