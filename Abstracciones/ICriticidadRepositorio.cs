using BE;
using System.Collections.Generic;

namespace Abstracciones
{
    public interface ICriticidadRepositorio
    {
        List<CriticidadConfig> ObtenerTodos();
    }
}
