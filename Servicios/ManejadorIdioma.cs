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
        private readonly Dictionary<string, string> _traduccionesActuales = new Dictionary<string, string>();
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

            try
            {
                ISessionManager session = IoCContainer.Resolver<ISessionManager>();
                if (session != null && session.Usuario != null)
                {
                    session.Usuario.IdIdioma = idioma.IdIdioma;
                    IUsuarioDAL usuarioDal = IoCContainer.Resolver<IUsuarioDAL>();
                    usuarioDal.Actualizar(session.Usuario);
                }
            }
            catch
            {
                // Ignorar excepciones al resolver dependencias en la inicialización inicial del sistema
            }
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
            Notify();
        }

        public void EliminarIdioma(int idIdioma)
        {
            _idiomaDal.Eliminar(idIdioma);
            Notify();
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
            if (_idiomaActual != null)
            {
                CargarTraducciones();
                Notify();
            }
        }

        private void CargarTraducciones()
        {
            _traduccionesActuales.Clear();
            if (_idiomaActual == null) return;

            List<Componente> componentes = _traduccionDal.ObtenerComponentes();
            List<Idioma> idiomas = _idiomaDal.ObtenerTodos();
            Idioma defaultLang = idiomas.FirstOrDefault(i => i.Default) ?? idiomas.FirstOrDefault();

            // 1. Cargar traducción por defecto (fallback)
            if (defaultLang != null)
            {
                List<Traduccion> traduccionesDefault = _traduccionDal.ObtenerTraduccionesPorIdioma(defaultLang.IdIdioma);
                foreach (Traduccion t in traduccionesDefault)
                {
                    Componente comp = componentes.FirstOrDefault(c => c.IdComponente == t.IdComponente);
                    if (comp != null && !string.IsNullOrWhiteSpace(t.Texto))
                    {
                        _traduccionesActuales[comp.Nombre] = t.Texto;
                    }
                }
            }

            // 2. Si el idioma actual no es el default, sobreescribir con las traducciones del idioma actual
            if (defaultLang == null || _idiomaActual.IdIdioma != defaultLang.IdIdioma)
            {
                List<Traduccion> traduccionesActual = _traduccionDal.ObtenerTraduccionesPorIdioma(_idiomaActual.IdIdioma);
                foreach (Traduccion t in traduccionesActual)
                {
                    Componente comp = componentes.FirstOrDefault(c => c.IdComponente == t.IdComponente);
                    if (comp != null && !string.IsNullOrWhiteSpace(t.Texto))
                    {
                        _traduccionesActuales[comp.Nombre] = t.Texto;
                    }
                }
            }
        }
    }
}
