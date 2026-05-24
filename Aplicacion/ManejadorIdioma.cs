using BE;
using BLL;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion
{
    public class ManejadorIdioma : ISubject
    {
        private static ManejadorIdioma _instancia;
        private readonly IdiomaBLL _idiomaBll = new IdiomaBLL();
        private readonly TraduccionBLL _traduccionBll = new TraduccionBLL();
        private readonly List<IObserver> _observers = new List<IObserver>();
        private Dictionary<string, string> _traduccionesActuales = new Dictionary<string, string>();
        private Idioma _idiomaActual;

        private ManejadorIdioma()
        {
            var idiomas = _idiomaBll.ObtenerTodos();
            var def = idiomas.FirstOrDefault(i => i.Default) ?? idiomas.FirstOrDefault();
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
                    _instancia = new ManejadorIdioma();
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
            foreach (var observer in _observers)
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
            return _idiomaBll.ObtenerTodos();
        }

        public void InsertarIdioma(Idioma idioma)
        {
            _idiomaBll.Insertar(idioma);
        }

        public void EliminarIdioma(int idIdioma)
        {
            _idiomaBll.Eliminar(idIdioma);
        }

        public List<Componente> ObtenerComponentes()
        {
            return _traduccionBll.ObtenerComponentes();
        }

        public void InsertarComponente(Componente componente)
        {
            _traduccionBll.InsertarComponente(componente);
        }

        public List<Traduccion> ObtenerTraduccionesPorIdioma(int idIdioma)
        {
            return _traduccionBll.ObtenerTraduccionesPorIdioma(idIdioma);
        }

        public void GuardarTraducciones(List<Traduccion> traducciones)
        {
            _traduccionBll.GuardarTraducciones(traducciones);
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

            var traducciones = _traduccionBll.ObtenerTraduccionesPorIdioma(_idiomaActual.IdIdioma);
            var componentes = _traduccionBll.ObtenerComponentes();

            foreach (var t in traducciones)
            {
                var comp = componentes.FirstOrDefault(c => c.IdComponente == t.IdComponente);
                if (comp != null)
                {
                    _traduccionesActuales[comp.Nombre] = t.Texto;
                }
            }
        }
    }
}