using BE;
using BE.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuarioDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public List<Usuario> ObtenerTodos()
        {
            DataTable tabla = _acceso.Leer("SELECT * FROM Usuario", null);
            List<Usuario> lista = new List<Usuario>();
            foreach (DataRow fila in tabla.Rows)
                lista.Add(Mapear(fila));
            return lista;
        }

        public Usuario ObtenerPorId(int idUsuario)
        {
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@IdUsuario", idUsuario) };
            DataTable tabla = _acceso.Leer("SELECT * FROM Usuario WHERE IdUsuario = @IdUsuario", p);
            return tabla.Rows.Count == 0 ? null : Mapear(tabla.Rows[0]);
        }

        public Usuario ObtenerPorUsername(string username)
        {
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@Username", username) };
            DataTable tabla = _acceso.Leer("SELECT * FROM Usuario WHERE Username = @Username", p);
            return tabla.Rows.Count == 0 ? null : Mapear(tabla.Rows[0]);
        }

        public void Insertar(Usuario usuario)
        {
            const string consulta =
                "INSERT INTO Usuario (Username, PasswordHash, Estado, FechaAlta, IntentosFallidos, CantidadBloqueos, DVH) " +
                "VALUES (@Username, @PasswordHash, @Estado, @FechaAlta, @IntentosFallidos, @CantidadBloqueos, @DVH)";

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Username", usuario.Username),
                new SqlParameter("@PasswordHash", usuario.PasswordHash),
                new SqlParameter("@Estado", (int)usuario.Estado),
                new SqlParameter("@FechaAlta", usuario.FechaAlta),
                new SqlParameter("@IntentosFallidos", usuario.IntentosFallidos),
                new SqlParameter("@CantidadBloqueos", usuario.CantidadBloqueos),
                new SqlParameter("@DVH", (object)usuario.DVH ?? DBNull.Value)
            };
            _acceso.Escribir(consulta, p);
        }

        public void Actualizar(Usuario usuario)
        {
            const string consulta =
                "UPDATE Usuario SET Username = @Username, PasswordHash = @PasswordHash, Estado = @Estado, " +
                "IntentosFallidos = @IntentosFallidos, CantidadBloqueos = @CantidadBloqueos, " +
                "FechaBloqueo = @FechaBloqueo, UltimoLogin = @UltimoLogin, DVH = @DVH " +
                "WHERE IdUsuario = @IdUsuario";

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", usuario.IdUsuario),
                new SqlParameter("@Username", usuario.Username),
                new SqlParameter("@PasswordHash", usuario.PasswordHash),
                new SqlParameter("@Estado", (int)usuario.Estado),
                new SqlParameter("@IntentosFallidos", usuario.IntentosFallidos),
                new SqlParameter("@CantidadBloqueos", usuario.CantidadBloqueos),
                new SqlParameter("@FechaBloqueo", (object)usuario.FechaBloqueo ?? DBNull.Value),
                new SqlParameter("@UltimoLogin", (object)usuario.UltimoLogin ?? DBNull.Value),
                new SqlParameter("@DVH", (object)usuario.DVH ?? DBNull.Value)
            };
            _acceso.Escribir(consulta, p);
        }

        private Usuario Mapear(DataRow fila)
        {
            Usuario u = new Usuario
            {
                IdUsuario = Convert.ToInt32(fila["IdUsuario"]),
                Username = fila["Username"].ToString(),
                PasswordHash = fila["PasswordHash"].ToString(),
                Estado = (EstadoUsuario)Convert.ToInt32(fila["Estado"]),
                FechaAlta = Convert.ToDateTime(fila["FechaAlta"]),
                IntentosFallidos = Convert.ToInt32(fila["IntentosFallidos"]),
                CantidadBloqueos = Convert.ToInt32(fila["CantidadBloqueos"])
            };
            if (fila["UltimoLogin"] != DBNull.Value)
                u.UltimoLogin = Convert.ToDateTime(fila["UltimoLogin"]);
            if (fila["FechaBloqueo"] != DBNull.Value)
                u.FechaBloqueo = Convert.ToDateTime(fila["FechaBloqueo"]);
            if (fila.Table.Columns.Contains("DVH") && fila["DVH"] != DBNull.Value)
                u.DVH = fila["DVH"].ToString();
            return u;
        }
    }
}