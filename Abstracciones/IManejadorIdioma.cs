using BE;
using System.Collections.Generic;

namespace Abstracciones
{
    public interface IManejadorIdioma : ISubject
    {
        Idioma IdiomaActual { get; }
        void CambiarIdioma(Idioma idioma);
        string ObtenerTexto(string clave);
        List<Idioma> ObtenerIdiomas();
        void InsertarIdioma(Idioma idioma);
        void EliminarIdioma(int idIdioma);
        List<Componente> ObtenerComponentes();
        void InsertarComponente(Componente componente);
        List<Traduccion> ObtenerTraduccionesPorIdioma(int idIdioma);
        void GuardarTraducciones(List<Traduccion> traducciones);
    }
}
