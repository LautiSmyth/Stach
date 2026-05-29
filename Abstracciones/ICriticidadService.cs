using BE;
using System.Collections.Generic;

namespace Abstracciones
{
    public interface ICriticidadService
    {
        CriticidadConfig ObtenerConfig(BE.Enums.NivelCriticidad criticidad);
        List<CriticidadConfig> ObtenerTodos();
    }
}
