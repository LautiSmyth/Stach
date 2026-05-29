using Abstracciones;

namespace Servicios
{
    public class ContadorSesion : IContadorSesion
    {
        private int _intentosFallidos = 0;
        private const int MaxIntentos = 5;

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
