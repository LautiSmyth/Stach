using BE;
using System.Collections.Generic;

namespace Abstracciones
{
    public interface ITraduccionDAL
    {
        List<Componente> ObtenerComponentes();
        void InsertarComponente(Componente componente);
        List<Traduccion> ObtenerTraduccionesPorIdioma(int idIdioma);
        void GuardarTraducciones(List<Traduccion> traducciones);
    }
}
