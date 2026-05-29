using System.Collections.Generic;

namespace Abstracciones
{
    public interface IDigitoVerificadorService
    {
        bool VerificarIntegridad(out List<string> errores);
        void InicializarDVs();
    }
}
