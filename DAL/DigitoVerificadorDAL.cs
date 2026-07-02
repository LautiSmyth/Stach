using Abstracciones;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DigitoVerificadorDAL : IDigitoVerificadorDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public Dictionary<int, string> ObtenerDVHs()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            DataTable dt = _acceso.Leer("SELECT IdUsuario, DVH FROM Usuario", null);
            foreach (DataRow r in dt.Rows)
            {
                int id = System.Convert.ToInt32(r["IdUsuario"]);
                string dvh = r["DVH"] == System.DBNull.Value ? string.Empty : r["DVH"].ToString();
                dict[id] = dvh;
            }
            return dict;
        }

        public string ObtenerDVV()
        {
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@Tabla", "Usuario") };
            DataTable dt = _acceso.Leer("SELECT DVV FROM VerificacionVertical WHERE Tabla = @Tabla", p);
            return dt.Rows.Count == 0 ? string.Empty : dt.Rows[0]["DVV"].ToString();
        }

        public void GuardarDV(Dictionary<int, string> dvhs, string dvv)
        {
            foreach (KeyValuePair<int, string> kvp in dvhs)
            {
                SqlParameter[] p = new SqlParameter[]
                {
                    new SqlParameter("@IdUsuario", kvp.Key),
                    new SqlParameter("@DVH", (object)kvp.Value ?? System.DBNull.Value)
                };
                _acceso.Escribir("UPDATE Usuario SET DVH = @DVH WHERE IdUsuario = @IdUsuario", p);
            }

            SqlParameter[] pMerge = new SqlParameter[]
            {
                new SqlParameter("@Tabla", "Usuario"),
                new SqlParameter("@DVV", dvv)
            };
            _acceso.Escribir(
                "MERGE INTO VerificacionVertical AS target " +
                "USING (VALUES (@Tabla, @DVV)) AS source(Tabla, DVV) " +
                "ON target.Tabla = source.Tabla " +
                "WHEN MATCHED THEN UPDATE SET DVV = source.DVV " +
                "WHEN NOT MATCHED THEN INSERT (Tabla, DVV) VALUES (source.Tabla, source.DVV);",
                pMerge);
        }
    }
}