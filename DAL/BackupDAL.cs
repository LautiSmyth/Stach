using System;
using System.Configuration;
using System.Data.SqlClient;

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

        public void RealizarBackup(string rutaArchivo)
        {
            if (string.IsNullOrEmpty(_cadenaConexionMaster))
                throw new InvalidOperationException("Cadena de conexión no configurada.");

            const string query = "BACKUP DATABASE Stach TO DISK = @Ruta WITH FORMAT, INIT, NAME = 'StachBackup';";

            using (SqlConnection conn = new SqlConnection(_cadenaConexionMaster))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Ruta", rutaArchivo);
                cmd.CommandTimeout = 120;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RestaurarBackup(string rutaArchivo)
        {
            if (string.IsNullOrEmpty(_cadenaConexionMaster))
                throw new InvalidOperationException("Cadena de conexión no configurada.");

            const string query = "ALTER DATABASE Stach SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                                 "RESTORE DATABASE Stach FROM DISK = @Ruta WITH REPLACE; " +
                                 "ALTER DATABASE Stach SET MULTI_USER;";

            using (SqlConnection conn = new SqlConnection(_cadenaConexionMaster))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Ruta", rutaArchivo);
                cmd.CommandTimeout = 240;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
