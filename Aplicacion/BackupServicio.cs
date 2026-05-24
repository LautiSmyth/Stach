using BLL;
using System;

namespace Aplicacion
{
    public class BackupServicio
    {
        private readonly BackupBLL _bll = new BackupBLL();
        private readonly BitacoraServicio _bitacora = new BitacoraServicio();
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();

        public void RealizarBackup(string modulo, string rutaArchivo)
        {
            string actor = _usuarioServicio.ObtenerUsernameEnSesion();
            if (string.IsNullOrEmpty(actor)) actor = "Sistema";

            _bll.RealizarBackup(rutaArchivo);
            _bitacora.Registrar(modulo, "Backup", $"Copia de seguridad generada en '{rutaArchivo}'.", true);
        }

        public void RestaurarBackup(string modulo, string rutaArchivo)
        {
            string actor = _usuarioServicio.ObtenerUsernameEnSesion();
            if (string.IsNullOrEmpty(actor)) actor = "Sistema";

            _bll.RestaurarBackup(rutaArchivo);
            _bitacora.Registrar(modulo, "Restore", $"Restauración de base de datos desde '{rutaArchivo}'.", true);

            new DigitoVerificadorServicio().InicializarDVs();
        }
    }
}
