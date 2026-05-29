namespace Abstracciones
{
    public interface IBackupService
    {
        void RealizarBackup(string modulo, string rutaArchivo, string claveCifrado);
        void RestaurarBackup(string modulo, string rutaArchivo, string claveCifrado);
    }
}
