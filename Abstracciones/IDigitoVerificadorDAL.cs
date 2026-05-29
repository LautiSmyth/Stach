using System.Collections.Generic;

namespace Abstracciones
{
    public interface IDigitoVerificadorDAL
    {
        string ObtenerDVV();
        Dictionary<int, string> ObtenerDVHs();
        void GuardarDV(Dictionary<int, string> dvhs, string dvv);
    }
}
