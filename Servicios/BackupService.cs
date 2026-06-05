using Abstracciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

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

        public void RealizarBackup(string modulo, string rutaArchivo, string claveCifrado)
        {
            if (!_dvService.VerificarIntegridad(out List<string> errores))
            {
                string errorDetalle = string.Join("; ", errores);
                _bitacora.Registrar(modulo, "Backup", "Intento de copia de seguridad fallido debido a fallas de integridad.", false, errorDetalle);
                throw new InvalidOperationException("La base de datos tiene fallas de integridad. No se puede realizar la copia de seguridad para evitar respaldar datos corruptos.");
            }

            string tempPlainPath = Path.Combine(Path.GetTempPath(), $"Stach_Backup_Temp_{Guid.NewGuid():N}.bak");
            try
            {
                _dal.RealizarBackup(tempPlainPath);
                CifradorHelper.CifrarArchivo(tempPlainPath, rutaArchivo, claveCifrado);
                _bitacora.Registrar(modulo, "Backup", $"Copia de seguridad cifrada generada en '{rutaArchivo}'.", true);
            }
            finally
            {
                if (File.Exists(tempPlainPath))
                {
                    try { File.Delete(tempPlainPath); } catch { }
                }
            }
        }

        public void RestaurarBackup(string modulo, string rutaArchivo, string claveCifrado)
        {
            string tempPlainPath = Path.Combine(Path.GetTempPath(), $"Stach_Restore_Temp_{Guid.NewGuid():N}.bak");
            try
            {
                try
                {
                    CifradorHelper.DescifrarArchivo(rutaArchivo, tempPlainPath, claveCifrado);
                }
                catch (CryptographicException)
                {
                    throw new ArgumentException("La contraseña del backup es incorrecta o el archivo de copia de seguridad está dañado.");
                }

                _dal.RestaurarBackup(tempPlainPath);
                _bitacora.Registrar(modulo, "Restore", $"Restauración de base de datos cifrada desde '{rutaArchivo}'.", true);
                _dvService.InicializarDVs();
            }
            finally
            {
                if (File.Exists(tempPlainPath))
                {
                    try { File.Delete(tempPlainPath); } catch { }
                }
            }
        }
    }
}
