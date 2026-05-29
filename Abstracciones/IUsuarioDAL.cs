using BE;
using System.Collections.Generic;

namespace Abstracciones
{
    public interface IUsuarioDAL
    {
        List<Usuario> ObtenerTodos();
        Usuario ObtenerPorId(int idUsuario);
        Usuario ObtenerPorUsername(string username);
        void Insertar(Usuario usuario);
        void Actualizar(Usuario usuario);
    }
}
