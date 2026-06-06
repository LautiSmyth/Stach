using BE;
using Abstracciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PermisoDAL : IPermisoDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public List<ComponentePermiso> ObtenerTodos()
        {
            DataTable dtCount = _acceso.Leer("SELECT COUNT(*) FROM Permiso WHERE IdPermiso = 7", null);
            if (Convert.ToInt32(dtCount.Rows[0][0]) == 0)
            {
                _acceso.Escribir("SET IDENTITY_INSERT Permiso ON; INSERT INTO Permiso (IdPermiso, Nombre, EsRol) VALUES (7, N'Ver Bitácora de Todos', 0); SET IDENTITY_INSERT Permiso OFF;", null);
                _acceso.Escribir("INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (100, 7);", null);
                _acceso.Escribir("INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (101, 7);", null);
            }
            DataTable dtCount8 = _acceso.Leer("SELECT COUNT(*) FROM Permiso WHERE IdPermiso = 8", null);
            if (Convert.ToInt32(dtCount8.Rows[0][0]) == 0)
            {
                _acceso.Escribir("SET IDENTITY_INSERT Permiso ON; INSERT INTO Permiso (IdPermiso, Nombre, EsRol) VALUES (8, N'Gestión de Backups', 0); SET IDENTITY_INSERT Permiso OFF;", null);
                _acceso.Escribir("INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (100, 8);", null);
            }
            DataTable dt = _acceso.Leer("SELECT IdPermiso, Nombre, EsRol FROM Permiso", null);
            Dictionary<int, ComponentePermiso> nodes = new Dictionary<int, ComponentePermiso>();

            foreach (DataRow r in dt.Rows)
            {
                int id = Convert.ToInt32(r["IdPermiso"]);
                string nombre = r["Nombre"].ToString();
                bool esRol = Convert.ToBoolean(r["EsRol"]);

                if (esRol)
                {
                    nodes[id] = new Rol { IdPermiso = id, Nombre = nombre };
                }
                else
                {
                    nodes[id] = new Permiso { IdPermiso = id, Nombre = nombre };
                }
            }

            DataTable rels = _acceso.Leer("SELECT IdPadre, IdHijo FROM PermisoRelacion", null);
            foreach (DataRow r in rels.Rows)
            {
                int idPadre = Convert.ToInt32(r["IdPadre"]);
                int idHijo = Convert.ToInt32(r["IdHijo"]);

                if (nodes.ContainsKey(idPadre) && nodes.ContainsKey(idHijo))
                {
                    Rol padre = nodes[idPadre] as Rol;
                    ComponentePermiso hijo = nodes[idHijo];
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
            bool esRol = permiso is Rol;
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Nombre", permiso.Nombre),
                new SqlParameter("@EsRol", esRol)
            };
            DataTable dt = _acceso.Leer("INSERT INTO Permiso (Nombre, EsRol) OUTPUT INSERTED.IdPermiso VALUES (@Nombre, @EsRol)", p);
            permiso.IdPermiso = Convert.ToInt32(dt.Rows[0][0]);
        }

        public bool EstaEnUso(int idPermiso)
        {
            SqlParameter[] p1 = new SqlParameter[] { new SqlParameter("@IdPermiso", idPermiso) };
            DataTable dt1 = _acceso.Leer("SELECT COUNT(*) FROM UsuarioPermiso WHERE IdPermiso = @IdPermiso", p1);
            if (Convert.ToInt32(dt1.Rows[0][0]) > 0)
            {
                return true;
            }
            SqlParameter[] p2 = new SqlParameter[] { new SqlParameter("@IdPermiso", idPermiso) };
            DataTable dt2 = _acceso.Leer("SELECT COUNT(*) FROM PermisoRelacion WHERE IdHijo = @IdPermiso", p2);
            if (Convert.ToInt32(dt2.Rows[0][0]) > 0)
            {
                return true;
            }
            return false;
        }

        public void Eliminar(int idPermiso)
        {
            SqlParameter[] p1 = new SqlParameter[] { new SqlParameter("@IdPermiso", idPermiso) };
            _acceso.Escribir("DELETE FROM PermisoRelacion WHERE IdPadre = @IdPermiso OR IdHijo = @IdPermiso", p1);
            SqlParameter[] p2 = new SqlParameter[] { new SqlParameter("@IdPermiso", idPermiso) };
            _acceso.Escribir("DELETE FROM UsuarioPermiso WHERE IdPermiso = @IdPermiso", p2);
            SqlParameter[] p3 = new SqlParameter[] { new SqlParameter("@IdPermiso", idPermiso) };
            _acceso.Escribir("DELETE FROM Permiso WHERE IdPermiso = @IdPermiso", p3);
        }

        public void GuardarRelaciones(Rol rol)
        {
            if (rol == null) throw new ArgumentNullException(nameof(rol));
            SqlParameter[] pDel = new SqlParameter[] { new SqlParameter("@IdPadre", rol.IdPermiso) };
            _acceso.Escribir("DELETE FROM PermisoRelacion WHERE IdPadre = @IdPadre", pDel);

            foreach (ComponentePermiso hijo in rol.Hijos)
            {
                SqlParameter[] pIns = new SqlParameter[]
                {
                    new SqlParameter("@IdPadre", rol.IdPermiso),
                    new SqlParameter("@IdHijo", hijo.IdPermiso)
                };
                _acceso.Escribir("INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (@IdPadre, @IdHijo)", pIns);
            }
        }

        public List<ComponentePermiso> ObtenerPermisosUsuario(int idUsuario)
        {
            List<ComponentePermiso> todos = ObtenerTodos();
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@IdUsuario", idUsuario) };
            DataTable dt = _acceso.Leer("SELECT IdPermiso FROM UsuarioPermiso WHERE IdUsuario = @IdUsuario", p);
            List<ComponentePermiso> list = new List<ComponentePermiso>();
            foreach (DataRow r in dt.Rows)
            {
                int id = Convert.ToInt32(r["IdPermiso"]);
                ComponentePermiso found = todos.Find(x => x.IdPermiso == id);
                if (found != null)
                {
                    list.Add(found);
                }
            }
            return list;
        }

        public void GuardarPermisosUsuario(int idUsuario, List<ComponentePermiso> permisos)
        {
            SqlParameter[] pDel = new SqlParameter[] { new SqlParameter("@IdUsuario", idUsuario) };
            _acceso.Escribir("DELETE FROM UsuarioPermiso WHERE IdUsuario = @IdUsuario", pDel);

            foreach (ComponentePermiso perm in permisos)
            {
                SqlParameter[] pIns = new SqlParameter[]
                {
                    new SqlParameter("@IdUsuario", idUsuario),
                    new SqlParameter("@IdPermiso", perm.IdPermiso)
                };
                _acceso.Escribir("INSERT INTO UsuarioPermiso (IdUsuario, IdPermiso) VALUES (@IdUsuario, @IdPermiso)", pIns);
            }
        }

        
        public void GuardarControlesAsociados(int idPermiso, List<ControlMapeado> controles)
        {
            SqlParameter[] pDel = new SqlParameter[] { new SqlParameter("@IdPermiso", idPermiso) };
            _acceso.Escribir("DELETE FROM PermisoControl WHERE IdPermiso = @IdPermiso", pDel);

            foreach (ControlMapeado ctrl in controles)
            {
                SqlParameter[] pIns = new SqlParameter[]
                {
                    new SqlParameter("@IdPermiso", idPermiso),
                    new SqlParameter("@Formulario", ctrl.Formulario),
                    new SqlParameter("@NombreControl", ctrl.NombreControl)
                };
                _acceso.Escribir("INSERT INTO PermisoControl (IdPermiso, Formulario, NombreControl) VALUES (@IdPermiso, @Formulario, @NombreControl)", pIns);
            }
        }

        public List<ControlMapeado> ObtenerControlesPorPermiso(int idPermiso)
        {
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@IdPermiso", idPermiso) };
            DataTable dt = _acceso.Leer("SELECT Formulario, NombreControl FROM PermisoControl WHERE IdPermiso = @IdPermiso", p);
            List<ControlMapeado> list = new List<ControlMapeado>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ControlMapeado
                {
                    IdPermiso = idPermiso,
                    Formulario = r["Formulario"].ToString(),
                    NombreControl = r["NombreControl"].ToString()
                });
            }
            return list;
        }

        public List<ControlMapeado> ObtenerTodosLosControlesProtegidos()
        {
            DataTable dt = _acceso.Leer("SELECT IdPermiso, Formulario, NombreControl FROM PermisoControl", null);
            List<ControlMapeado> list = new List<ControlMapeado>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ControlMapeado
                {
                    IdPermiso = Convert.ToInt32(r["IdPermiso"]),
                    Formulario = r["Formulario"].ToString(),
                    NombreControl = r["NombreControl"].ToString()
                });
            }
            return list;
        }
    }
}