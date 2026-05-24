using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class BackupDAL
    {
        private readonly string _cadenaConexionMaster;

        public BackupDAL()
        {
            ConnectionStringSettings entrada = ConfigurationManager.ConnectionStrings["ConexionSQL"];
            if (entrada != null)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(entrada.ConnectionString);
                builder.InitialCatalog = "master";
                _cadenaConexionMaster = builder.ConnectionString;
            }
        }

        private string ObtenerDirectorioBackupDefault()
        {
            string dir = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(_cadenaConexionMaster))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        @"DECLARE @BackupDir NVARCHAR(512); " +
                        @"EXEC master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'BackupDirectory', @BackupDir OUTPUT; " +
                        @"SELECT @BackupDir;", conn))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            dir = result.ToString();
                        }
                    }
                }
            }
            catch
            {
            }
            if (string.IsNullOrEmpty(dir))
            {
                dir = @"C:\Users\Public";
            }
            return dir;
        }

        public void RealizarBackup(string rutaDestino)
        {
            if (string.IsNullOrEmpty(_cadenaConexionMaster))
                throw new InvalidOperationException("Cadena de conexión no configurada.");
            string dirBackupDefault = ObtenerDirectorioBackupDefault();
            string nombreArchivoTemp = $"Stach_Temp_{Guid.NewGuid():N}.bak";
            string rutaTemp = Path.Combine(dirBackupDefault, nombreArchivoTemp);
            try
            {
                using (SqlConnection conn = new SqlConnection(_cadenaConexionMaster))
                using (SqlCommand cmd = new SqlCommand("BACKUP DATABASE Stach TO DISK = @Ruta WITH FORMAT, INIT, NAME = 'StachBackup';", conn))
                {
                    cmd.Parameters.AddWithValue("@Ruta", rutaTemp);
                    cmd.CommandTimeout = 120;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                if (File.Exists(rutaDestino))
                {
                    File.Delete(rutaDestino);
                }
                File.Copy(rutaTemp, rutaDestino);
            }
            finally
            {
                if (File.Exists(rutaTemp))
                {
                    try
                    {
                        File.Delete(rutaTemp);
                    }
                    catch
                    {
                    }
                }
            }
        }

        public void RestaurarBackup(string rutaOrigen)
        {
            if (string.IsNullOrEmpty(_cadenaConexionMaster))
                throw new InvalidOperationException("Cadena de conexión no configurada.");
            string dirBackupDefault = ObtenerDirectorioBackupDefault();
            string nombreArchivoTemp = $"Stach_Restore_Temp_{Guid.NewGuid():N}.bak";
            string rutaTemp = Path.Combine(dirBackupDefault, nombreArchivoTemp);
            try
            {
                File.Copy(rutaOrigen, rutaTemp, true);
                const string query = "ALTER DATABASE Stach SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                                     "RESTORE DATABASE Stach FROM DISK = @Ruta WITH REPLACE; " +
                                     "ALTER DATABASE Stach SET MULTI_USER;";
                using (SqlConnection conn = new SqlConnection(_cadenaConexionMaster))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ruta", rutaTemp);
                    cmd.CommandTimeout = 240;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (File.Exists(rutaTemp))
                {
                    try
                    {
                        File.Delete(rutaTemp);
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
