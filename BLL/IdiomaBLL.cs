using BE;
using Abstracciones;
using System.Collections.Generic;

namespace BLL
{
    public class IdiomaBLL
    {
        private readonly IIdiomaDAL _dal;

        public IdiomaBLL(IIdiomaDAL dal)
        {
            _dal = dal;
        }

        public List<Idioma> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        public void Insertar(Idioma idioma)
        {
            _dal.Insertar(idioma);
        }

        public void Eliminar(int idIdioma)
        {
            _dal.Eliminar(idIdioma);
        }
    }
}