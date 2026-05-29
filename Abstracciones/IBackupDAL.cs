namespace Abstracciones
{
    public interface IBackupDAL
    {
        void RealizarBackup(string rutaDestino);
        void RestaurarBackup(string rutaOrigen);
    }
}
