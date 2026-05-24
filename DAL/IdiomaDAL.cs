using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class IdiomaDAL
    {
        private static readonly List<Idioma> _idiomas = new List<Idioma>
        {
            new Idioma { IdIdioma = 1, Nombre = "Español", Codigo = "es", Default = true },
            new Idioma { IdIdioma = 2, Nombre = "English", Codigo = "en", Default = false }
        };

        private static int _nextId = 3;

        public List<Idioma> ObtenerTodos()
        {
            return new List<Idioma>(_idiomas);
        }

        public void Insertar(Idioma idioma)
        {
            if (idioma == null) throw new ArgumentNullException(nameof(idioma));
            if (_idiomas.Any(i => i.Nombre.Equals(idioma.Nombre, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("El idioma ya existe.");
            if (_idiomas.Any(i => i.Codigo.Equals(idioma.Codigo, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("El código de idioma ya existe.");

            idioma.IdIdioma = _nextId++;
            if (idioma.Default)
            {
                foreach (var i in _idiomas) i.Default = false;
            }
            _idiomas.Add(idioma);
        }

        public void Eliminar(int idIdioma)
        {
            var idioma = _idiomas.FirstOrDefault(i => i.IdIdioma == idIdioma);
            if (idioma != null)
            {
                if (idioma.Default)
                    throw new InvalidOperationException("No se puede eliminar el idioma por defecto.");
                _idiomas.Remove(idioma);
            }
        }
    }
}
