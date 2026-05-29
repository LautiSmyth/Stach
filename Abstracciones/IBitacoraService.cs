using BE;
using System.Collections.Generic;

namespace Abstracciones
{
    public interface IBitacoraService
    {
        List<Bitacora> ObtenerTodos();
        void Registrar(string modulo, string actividad, string detalle, bool exitoso, string error = "");
        void RegistrarSinSesion(string usernameIngresado, string modulo, string actividad, string detalle, bool exitoso, string error = "");
    }
}
