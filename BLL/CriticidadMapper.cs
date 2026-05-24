using BE;
using BE.Enums;
using BE.Repositorios;
using System;
using System.Collections.Generic;

namespace BLL
{
    public static class CriticidadMapper
    {
        private static readonly Dictionary<string, NivelCriticidad> _diccionario = new Dictionary<string, NivelCriticidad>
        {
            { "Login",            NivelCriticidad.Informativo },
            { "Logout",           NivelCriticidad.Informativo },
            { "Consulta",         NivelCriticidad.Informativo },
            { "Alta",             NivelCriticidad.Bajo },
            { "Modificacion",     NivelCriticidad.Medio },
            { "Eliminacion",      NivelCriticidad.Alto },
            { "CambioPassword",   NivelCriticidad.Critico },
            { "IntentoFallido",   NivelCriticidad.Alto },
            { "UsuarioBloqueado", NivelCriticidad.Critico },
            { "CambioEstado",     NivelCriticidad.Alto },
        };

        private static Dictionary<NivelCriticidad, CriticidadConfig> _configBD = new Dictionary<NivelCriticidad, CriticidadConfig>();
        private static List<CriticidadConfig> _listaOrdenada = new List<CriticidadConfig>();

        public static void Recargar(ICriticidadRepositorio repositorio)
        {
            try
            {
                List<CriticidadConfig> lista = repositorio.ObtenerTodos();
                Dictionary<NivelCriticidad, CriticidadConfig> nuevo = new Dictionary<NivelCriticidad, CriticidadConfig>();

                foreach (CriticidadConfig config in lista)
                    nuevo[config.Nivel] = config;

                _configBD = nuevo;
                _listaOrdenada = lista;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[CriticidadMapper] Error al cargar desde BD: {ex.Message}");
            }
        }

        public static NivelCriticidad Obtener(string actividad)
        {
            NivelCriticidad nivel;
            if (_diccionario.TryGetValue(actividad, out nivel))
                return nivel;

            return NivelCriticidad.Informativo;
        }

        public static CriticidadConfig ObtenerConfig(NivelCriticidad criticidad)
        {
            CriticidadConfig config;
            if (_configBD.TryGetValue(criticidad, out config))
                return config;

            return null;
        }

        public static List<CriticidadConfig> ObtenerTodos()
        {
            return new List<CriticidadConfig>(_listaOrdenada);
        }
    }
}
