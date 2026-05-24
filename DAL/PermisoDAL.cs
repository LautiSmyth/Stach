using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PermisoDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public List<ComponentePermiso> ObtenerTodos()
        {
            var dt = _acceso.Leer("SELECT IdPermiso, Nombre, PermisoKey, EsFamilia FROM Permiso", null);
            var nodes = new Dictionary<int, ComponentePermiso>();

            foreach (DataRow r in dt.Rows)
            {
                int id = Convert.ToInt32(r["IdPermiso"]);
                string nombre = r["Nombre"].ToString();
                string key = r["PermisoKey"] == DBNull.Value ? null : r["PermisoKey"].ToString();
                bool esFamilia = Convert.ToBoolean(r["EsFamilia"]);

                if (esFamilia)
                {
                    nodes[id] = new Familia { IdPermiso = id, Nombre = nombre, PermisoKey = key };
                }
                else
                {
                    nodes[id] = new Patente { IdPermiso = id, Nombre = nombre, PermisoKey = key };
                }
            }

            var rels = _acceso.Leer("SELECT IdPadre, IdHijo FROM PermisoRelacion", null);
            foreach (DataRow r in rels.Rows)
            {
                int idPadre = Convert.ToInt32(r["IdPadre"]);
                int idHijo = Convert.ToInt32(r["IdHijo"]);

                if (nodes.ContainsKey(idPadre) && nodes.ContainsKey(idHijo))
                {
                    var padre = nodes[idPadre] as Familia;
                    var hijo = nodes[idHijo];
                    if (padre != null && hijo != null)
                    {
                        padre.Agregar(hijo);
                    }
                }
            }

            return new List<ComponentePermiso>(nodes.Values);
        }

        public void Insertar(ComponentePermiso permiso)
        {
            if (permiso == null) throw new ArgumentNullException(nameof(permiso));
            bool esFamilia = permiso is Familia;
            var p = new SqlParameter[]
            {
                new SqlParameter("@Nombre", permiso.Nombre),
                new SqlParameter("@PermisoKey", (object)permiso.PermisoKey ?? DBNull.Value),
                new SqlParameter("@EsFamilia", esFamilia)
            };
            _acceso.Escribir("INSERT INTO Permiso (Nombre, PermisoKey, EsFamilia) VALUES (@Nombre, @PermisoKey, @EsFamilia)", p);

            var dt = _acceso.Leer("SELECT @@IDENTITY", null);
            permiso.IdPermiso = Convert.ToInt32(dt.Rows[0][0]);
        }

        public void Eliminar(int idPermiso)
        {
            var p = new SqlParameter[] { new SqlParameter("@IdPermiso", idPermiso) };
            _acceso.Escribir("DELETE FROM PermisoRelacion WHERE IdPadre = @IdPermiso OR IdHijo = @IdPermiso", p);
            _acceso.Escribir("DELETE FROM UsuarioPermiso WHERE IdPermiso = @IdPermiso", p);
            _acceso.Escribir("DELETE FROM Permiso WHERE IdPermiso = @IdPermiso", p);
        }

        public void GuardarRelaciones(Familia familia)
        {
            if (familia == null) throw new ArgumentNullException(nameof(familia));
            var pDel = new SqlParameter[] { new SqlParameter("@IdPadre", familia.IdPermiso) };
            _acceso.Escribir("DELETE FROM PermisoRelacion WHERE IdPadre = @IdPadre", pDel);

            foreach (var hijo in familia.Hijos)
            {
                var pIns = new SqlParameter[]
                {
                    new SqlParameter("@IdPadre", familia.IdPermiso),
                    new SqlParameter("@IdHijo", hijo.IdPermiso)
                };
                _acceso.Escribir("INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (@IdPadre, @IdHijo)", pIns);
            }
        }

        public List<ComponentePermiso> ObtenerPermisosUsuario(int idUsuario)
        {
            var todos = ObtenerTodos();
            var p = new SqlParameter[] { new SqlParameter("@IdUsuario", idUsuario) };
            var dt = _acceso.Leer("SELECT IdPermiso FROM UsuarioPermiso WHERE IdUsuario = @IdUsuario", p);
            var list = new List<ComponentePermiso>();
            foreach (DataRow r in dt.Rows)
            {
                int id = Convert.ToInt32(r["IdPermiso"]);
                var found = todos.Find(x => x.IdPermiso == id);
                if (found != null)
                {
                    list.Add(found);
                }
            }
            return list;
        }

        public void GuardarPermisosUsuario(int idUsuario, List<ComponentePermiso> permisos)
        {
            var pDel = new SqlParameter[] { new SqlParameter("@IdUsuario", idUsuario) };
            _acceso.Escribir("DELETE FROM UsuarioPermiso WHERE IdUsuario = @IdUsuario", pDel);

            foreach (var perm in permisos)
            {
                var pIns = new SqlParameter[]
                {
                    new SqlParameter("@IdUsuario", idUsuario),
                    new SqlParameter("@IdPermiso", perm.IdPermiso)
                };
                _acceso.Escribir("INSERT INTO UsuarioPermiso (IdUsuario, IdPermiso) VALUES (@IdUsuario, @IdPermiso)", pIns);
            }
        }
    }
}
