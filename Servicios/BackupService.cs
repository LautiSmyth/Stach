using Abstracciones;
using System;

namespace Servicios
{
    public class BackupService : IBackupService
    {
        private readonly IBackupDAL _dal;
        private readonly IBitacoraService _bitacora;
        private readonly ISessionManager _session;
        private readonly IDigitoVerificadorService _dvService;

        public BackupService(IBackupDAL dal, IBitacoraService bitacora, ISessionManager session, IDigitoVerificadorService dvService)
        {
            _dal = dal;
            _bitacora = bitacora;
            _session = session;
            _dvService = dvService;
        }

        public void RealizarBackup(string modulo, string rutaArchivo)
        {
            _dal.RealizarBackup(rutaArchivo);
            _bitacora.Registrar(modulo, "Backup", $"Copia de seguridad generada en '{rutaArchivo}'.", true);
        }

        public void RestaurarBackup(string modulo, string rutaArchivo)
        {
            _dal.RestaurarBackup(rutaArchivo);
            _bitacora.Registrar(modulo, "Restore", $"Restauración de base de datos desde '{rutaArchivo}'.", true);
            _dvService.InicializarDVs();
        }
    }
}
