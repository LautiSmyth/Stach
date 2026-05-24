using BLL;
using System.Collections.Generic;

namespace Aplicacion
{
    public class DigitoVerificadorServicio
    {
        private readonly DigitoVerificadorBLL _bll = new DigitoVerificadorBLL();
        private readonly BitacoraServicio _bitacora = new BitacoraServicio();

        public bool VerificarIntegridad(out List<string> errores)
        {
            bool ok = _bll.VerificarIntegridad(out errores);
            if (!ok)
            {
                string det = string.Join(" | ", errores);
                _bitacora.RegistrarSinSesion("Sistema", "Seguridad", "FalloIntegridad", "Fallo de integridad de digitos verificadores.", false, det);
            }
            return ok;
        }

        public void InicializarDVs()
        {
            _bll.InicializarDVs();
            _bitacora.RegistrarSinSesion("Sistema", "Seguridad", "RestauracionDVs", "Digitos verificadores recalculados y restaurados.", true);
        }

        public void CorromperParaPrueba()
        {
            _bll.CorromperParaPrueba();
        }
    }
}
