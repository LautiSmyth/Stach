namespace Seguridad
{
    public sealed class ContadorSesion
    {
        private static volatile ContadorSesion _instance;
        private static readonly object _lock = new object();

        private int _intentosFallidos = 0;
        private const int MaxIntentos = 5;

        private ContadorSesion()
        { }

        public static ContadorSesion GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new ContadorSesion();
                }
            }
            return _instance;
        }

        public bool LimiteAlcanzado
        {
            get { return _intentosFallidos >= MaxIntentos; }
        }

        public void RegistrarIntento()
        {
            _intentosFallidos++;
        }

        public void Resetear()
        {
            _intentosFallidos = 0;
        }
    }
}