namespace Abstracciones
{
    public interface IBackupService
    {
        void RealizarBackup(string modulo, string rutaArchivo);
        void RestaurarBackup(string modulo, string rutaArchivo);
    }
}
