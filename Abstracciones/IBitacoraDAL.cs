using BE;
using System.Collections.Generic;

namespace Abstracciones
{
    public interface IBitacoraDAL
    {
        List<Bitacora> ObtenerTodos();
        void Insertar(Bitacora bitacora);
    }
}
