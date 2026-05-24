using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class IdiomaBLL
    {
        private readonly IdiomaDAL _dal = new IdiomaDAL();

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