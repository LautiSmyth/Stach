using BE;
using BE.Enums;
using BLL;
using System.Collections.Generic;

namespace Aplicacion
{
    public class CriticidadServicio
    {
        public CriticidadServicio()
        {
            new CriticidadBLL().Recargar();
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
