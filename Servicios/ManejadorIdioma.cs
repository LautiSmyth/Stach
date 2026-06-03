using Abstracciones;
using BE;
using System.Collections.Generic;
using System.Linq;

namespace Servicios
{
    public class ManejadorIdioma : IManejadorIdioma
    {
        private static ManejadorIdioma _instancia;
        private readonly IIdiomaDAL _idiomaDal;
        private readonly ITraduccionDAL _traduccionDal;
        private readonly List<IObserver> _observers = new List<IObserver>();
        private Dictionary<string, string> _traduccionesActuales = new Dictionary<string, string>();
        private Idioma _idiomaActual;

        private ManejadorIdioma(IIdiomaDAL idiomaDal, ITraduccionDAL traduccionDal)
        {
            _idiomaDal = idiomaDal;
            _traduccionDal = traduccionDal;
            List<Idioma> idiomas = _idiomaDal.ObtenerTodos();
            Idioma def = idiomas.FirstOrDefault(i => i.Default) ?? idiomas.FirstOrDefault();
            if (def != null)
            {
                CambiarIdioma(def);
            }
        }

        public static ManejadorIdioma Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    IIdiomaDAL idiomaDal = IoCContainer.Resolver<IIdiomaDAL>();
                    ITraduccionDAL traduccionDal = IoCContainer.Resolver<ITraduccionDAL>();
                    _instancia = new ManejadorIdioma(idiomaDal, traduccionDal);
                }
                return _instancia;
            }
        }

        public Idioma IdiomaActual
        {
            get { return _idiomaActual; }
        }

        public void Attach(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Detach(IObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void Notify()
        {
            foreach (IObserver observer in _observers.ToList())
            {
                observer.ActualizarIdioma();
            }
        }

        public void CambiarIdioma(Idioma idioma)
        {
            _idiomaActual = idioma;
            CargarTraducciones();
            Notify();
        }

        public string ObtenerTexto(string clave)
        {
            if (_traduccionesActuales.TryGetValue(clave, out string texto))
            {
                return texto;
            }
            return clave;
        }

        public List<Idioma> ObtenerIdiomas()
        {
            return _idiomaDal.ObtenerTodos();
        }

        public void InsertarIdioma(Idioma idioma)
        {
            _idiomaDal.Insertar(idioma);
        }

        public void EliminarIdioma(int idIdioma)
        {
            _idiomaDal.Eliminar(idIdioma);
        }

        public List<Componente> ObtenerComponentes()
        {
            return _traduccionDal.ObtenerComponentes();
        }

        public void InsertarComponente(Componente componente)
        {
            _traduccionDal.InsertarComponente(componente);
        }

        public List<Traduccion> ObtenerTraduccionesPorIdioma(int idIdioma)
        {
            return _traduccionDal.ObtenerTraduccionesPorIdioma(idIdioma);
        }

        public void GuardarTraducciones(List<Traduccion> traducciones)
        {
            _traduccionDal.GuardarTraducciones(traducciones);
            if (_idiomaActual != null && traducciones.Any(t => t.IdIdioma == _idiomaActual.IdIdioma))
            {
                CargarTraducciones();
                Notify();
            }
        }

        private void CargarTraducciones()
        {
            _traduccionesActuales.Clear();
            if (_idiomaActual == null) return;

            List<Traduccion> traducciones = _traduccionDal.ObtenerTraduccionesPorIdioma(_idiomaActual.IdIdioma);
            List<Componente> componentes = _traduccionDal.ObtenerComponentes();

            foreach (Traduccion t in traducciones)
            {
                Componente comp = componentes.FirstOrDefault(c => c.IdComponente == t.IdComponente);
                if (comp != null)
                {
                    _traduccionesActuales[comp.Nombre] = t.Texto;
                }
            }
        }
    }
}
