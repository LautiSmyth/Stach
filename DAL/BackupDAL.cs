using Abstracciones;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace DAL
{
    public class BackupDAL : IBackupDAL
    {
        private readonly string _cadenaConexionMaster;

        public BackupDAL()
        {
            ConnectionStringSettings entrada = ConfigurationManager.ConnectionStrings["ConexionSQL"];
            if (entrada != null)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(entrada.ConnectionString)
                {
                    InitialCatalog = "master"
                };
                _cadenaConexionMaster = builder.ConnectionString;
            }
        }

        private static string ObtenerDirectorioBackupDefault()
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TempBackups");
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                DirectoryInfo dInfo = new DirectoryInfo(dir);
                DirectorySecurity dSecurity = dInfo.GetAccessControl();
                SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                dSecurity.AddAccessRule(new FileSystemAccessRule(
                    everyone,
                    FileSystemRights.FullControl,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow));
                dInfo.SetAccessControl(dSecurity);
            }
            catch
            {
                dir = Path.Combine(Path.GetTempPath(), "TempBackups");
                try
                {
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.TraceError(ex.Message);
                }
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
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.TraceError(ex.Message);
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
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.TraceError(ex.Message);
                    }
                }
            }
        }

        public int ObtenerCantRegistrosBitacoraNuevos(DateTime fecha)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Bitacora WHERE Fecha > @Fecha", conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch
            {
                return 0;
            }
        }

        public int ObtenerCantRegistrosCambiosNuevos(DateTime fecha)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM VersionUsuario WHERE FechaModificacion > @Fecha", conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}