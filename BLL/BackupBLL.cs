using DAL;

namespace BLL
{
    public class BackupBLL
    {
        private readonly BackupDAL _dal = new BackupDAL();

        public void RealizarBackup(string rutaArchivo)
        {
            _dal.RealizarBackup(rutaArchivo);
        }

        public void RestaurarBackup(string rutaArchivo)
        {
            _dal.RestaurarBackup(rutaArchivo);
        }
    }
}
