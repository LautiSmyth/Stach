using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DigitoVerificadorDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public Dictionary<int, string> ObtenerDVHs()
        {
            var dict = new Dictionary<int, string>();
            var dt = _acceso.Leer("SELECT IdUsuario, DVH FROM Usuario", null);
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
            var p = new SqlParameter[] { new SqlParameter("@Tabla", "Usuario") };
            var dt = _acceso.Leer("SELECT DVV FROM VerificacionVertical WHERE Tabla = @Tabla", p);
            return dt.Rows.Count == 0 ? string.Empty : dt.Rows[0]["DVV"].ToString();
        }

        public void GuardarDV(Dictionary<int, string> dvhs, string dvv)
        {
            foreach (var kvp in dvhs)
            {
                var p = new SqlParameter[]
                {
                    new SqlParameter("@IdUsuario", kvp.Key),
                    new SqlParameter("@DVH", (object)kvp.Value ?? System.DBNull.Value)
                };
                _acceso.Escribir("UPDATE Usuario SET DVH = @DVH WHERE IdUsuario = @IdUsuario", p);
            }

            var pDvv = new SqlParameter[]
            {
                new SqlParameter("@Tabla", "Usuario"),
                new SqlParameter("@DVV", dvv)
            };
            var rows = _acceso.Escribir("UPDATE VerificacionVertical SET DVV = @DVV WHERE Tabla = @Tabla", pDvv);
            if (rows == 0)
            {
                var pIns = new SqlParameter[]
                {
                    new SqlParameter("@Tabla", "Usuario"),
                    new SqlParameter("@DVV", dvv)
                };
                _acceso.Escribir("INSERT INTO VerificacionVertical (Tabla, DVV) VALUES (@Tabla, @DVV)", pIns);
            }
        }

        public void Corromper()
        {
            var dt = _acceso.Leer("SELECT TOP 1 IdUsuario FROM Usuario ORDER BY IdUsuario", null);
            if (dt.Rows.Count > 0)
            {
                int id = System.Convert.ToInt32(dt.Rows[0]["IdUsuario"]);
                var p = new SqlParameter[]
                {
                    new SqlParameter("@IdUsuario", id),
                    new SqlParameter("@DVH", "CORRUPTO")
                };
                _acceso.Escribir("UPDATE Usuario SET DVH = @DVH WHERE IdUsuario = @IdUsuario", p);
            }
        }
    }
}
