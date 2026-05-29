using BE;
using Abstracciones;
using System.Collections.Generic;

namespace BLL
{
    public class TraduccionBLL
    {
        private readonly ITraduccionDAL _dal;

        public TraduccionBLL(ITraduccionDAL dal)
        {
            _dal = dal;
        }

        public List<Componente> ObtenerComponentes()
        {
            return _dal.ObtenerComponentes();
        }

        public void InsertarComponente(Componente componente)
        {
            _dal.InsertarComponente(componente);
        }

        public List<Traduccion> ObtenerTraduccionesPorIdioma(int idIdioma)
        {
            return _dal.ObtenerTraduccionesPorIdioma(idIdioma);
        }

        public void GuardarTraducciones(List<Traduccion> traducciones)
        {
            _dal.GuardarTraducciones(traducciones);
        }
    }
}