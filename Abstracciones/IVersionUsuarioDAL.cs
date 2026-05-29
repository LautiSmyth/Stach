using BE;
using System.Collections.Generic;

namespace Abstracciones
{
    public interface IVersionUsuarioDAL
    {
        List<VersionUsuario> ObtenerPorUsuario(int idUsuario);
        VersionUsuario ObtenerPorId(int idVersion);
        void Insertar(VersionUsuario version);
    }
}
