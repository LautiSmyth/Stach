using BE;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class VersionUsuarioDAL
    {
        private static readonly List<VersionUsuario> _historial = new List<VersionUsuario>();
        private static int _nextId = 1;

        public void Insertar(VersionUsuario version)
        {
            version.IdVersion = _nextId++;
            _historial.Add(version);
        }

        public List<VersionUsuario> ObtenerPorUsuario(int idUsuario)
        {
            return _historial
                .Where(v => v.IdUsuario == idUsuario)
                .OrderByDescending(v => v.FechaModificacion)
                .ToList();
        }

        public VersionUsuario ObtenerPorId(int idVersion)
        {
            return _historial.FirstOrDefault(v => v.IdVersion == idVersion);
        }
    }
}
