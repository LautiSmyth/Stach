using BE;
using BLL;
using Seguridad;
using System;
using System.Collections.Generic;

namespace Aplicacion
{
    public class BitacoraServicio
    {
        private readonly BitacoraBLL _bll = new BitacoraBLL();

        public List<Bitacora> ObtenerTodos()
        {
            return _bll.ObtenerTodos();
        }

        public void Registrar(string modulo, string actividad, string detalle, bool exitoso, string error = "")
        {
            Usuario usuario = SessionManager.GetInstance().Usuario;
            if (usuario == null)
            {
                RegistrarSinSesion("sin sesion", modulo, actividad, detalle, exitoso, error);
                return;
            }

            string detalleCompleto = exitoso
                ? $"El usuario '{usuario.Username}' realizo '{actividad}' en '{modulo}'. {detalle}"
                : $"El usuario '{usuario.Username}' intento '{actividad}' en '{modulo}' pero ocurrio un error. {detalle}";

            _bll.Insertar(new Bitacora
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
            _bll.Insertar(new Bitacora
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
