using BE;
using System.Collections.Generic;

namespace Abstracciones
{
    public interface IIdiomaDAL
    {
        List<Idioma> ObtenerTodos();
        void Insertar(Idioma idioma);
        void Eliminar(int idIdioma);
    }
}
