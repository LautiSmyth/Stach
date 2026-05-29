using Abstracciones;
using BE;
using BE.Enums;
using System.Collections.Generic;

namespace Servicios
{
    public class CriticidadService : ICriticidadService
    {
        public CriticidadService(ICriticidadRepositorio repositorio)
        {
            CriticidadMapper.Recargar(repositorio);
        }

        public CriticidadConfig ObtenerConfig(NivelCriticidad criticidad)
        {
            return CriticidadMapper.ObtenerConfig(criticidad);
        }

        public List<CriticidadConfig> ObtenerTodos()
        {
            return CriticidadMapper.ObtenerTodos();
        }
    }
}
