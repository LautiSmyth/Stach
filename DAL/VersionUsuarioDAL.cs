using BE;
using BE.Enums;
using Abstracciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class VersionUsuarioDAL : IVersionUsuarioDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public void Insertar(VersionUsuario version)
        {
            const string consulta = "INSERT INTO HistorialUsuario (IdUsuario, Fecha, Actor, Detalle, Username, PasswordHash, Estado) " +
                                   "VALUES (@IdUsuario, @Fecha, @Actor, @Detalle, @Username, @PasswordHash, @Estado)";
            var p = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", version.IdUsuario),
                new SqlParameter("@Fecha", version.FechaModificacion),
                new SqlParameter("@Actor", version.ModificadoPor),
                new SqlParameter("@Detalle", version.DetalleCambios),
                new SqlParameter("@Username", version.Username),
                new SqlParameter("@PasswordHash", version.PasswordHash),
                new SqlParameter("@Estado", (int)version.Estado)
            };
            _acceso.Escribir(consulta, p);
        }

        public List<VersionUsuario> ObtenerPorUsuario(int idUsuario)
        {
            var p = new SqlParameter[] { new SqlParameter("@IdUsuario", idUsuario) };
            var dt = _acceso.Leer("SELECT * FROM HistorialUsuario WHERE IdUsuario = @IdUsuario ORDER BY Fecha DESC", p);
            var lista = new List<VersionUsuario>();
            foreach (DataRow r in dt.Rows)
            {
                lista.Add(Mapear(r));
            }
            return lista;
        }

        public VersionUsuario ObtenerPorId(int idVersion)
        {
            var p = new SqlParameter[] { new SqlParameter("@IdVersion", idVersion) };
            var dt = _acceso.Leer("SELECT * FROM HistorialUsuario WHERE IdVersion = @IdVersion", p);
            return dt.Rows.Count == 0 ? null : Mapear(dt.Rows[0]);
        }

        private VersionUsuario Mapear(DataRow r)
        {
            return new VersionUsuario
            {
                IdVersion = Convert.ToInt32(r["IdVersion"]),
                IdUsuario = Convert.ToInt32(r["IdUsuario"]),
                FechaModificacion = Convert.ToDateTime(r["Fecha"]),
                ModificadoPor = r["Actor"].ToString(),
                DetalleCambios = r["Detalle"].ToString(),
                Username = r["Username"].ToString(),
                PasswordHash = r["PasswordHash"].ToString(),
                Estado = (EstadoUsuario)Convert.ToInt32(r["Estado"])
            };
        }
    }
}