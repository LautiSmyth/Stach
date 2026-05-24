using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TraduccionDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public List<Componente> ObtenerComponentes()
        {
            InicializarBaseDatosSiVacio();
            var dt = _acceso.Leer("SELECT IdComponente, Nombre FROM Componente", null);
            var lista = new List<Componente>();
            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new Componente
                {
                    IdComponente = Convert.ToInt32(r["IdComponente"]),
                    Nombre = r["Nombre"].ToString()
                });
            }
            return lista;
        }

        public void InsertarComponente(Componente componente)
        {
            if (componente == null) throw new ArgumentNullException(nameof(componente));
            var p = new SqlParameter[] { new SqlParameter("@Nombre", componente.Nombre) };
            _acceso.Escribir("INSERT INTO Componente (Nombre) VALUES (@Nombre)", p);
        }

        public List<Traduccion> ObtenerTraduccionesPorIdioma(int idIdioma)
        {
            InicializarBaseDatosSiVacio();
            var p = new SqlParameter[] { new SqlParameter("@IdIdioma", idIdioma) };
            var dt = _acceso.Leer("SELECT IdIdioma, IdComponente, Texto FROM Traduccion WHERE IdIdioma = @IdIdioma", p);
            var lista = new List<Traduccion>();
            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new Traduccion
                {
                    IdIdioma = Convert.ToInt32(r["IdIdioma"]),
                    IdComponente = Convert.ToInt32(r["IdComponente"]),
                    Texto = r["Texto"].ToString()
                });
            }
            return lista;
        }

        public void GuardarTraducciones(List<Traduccion> traducciones)
        {
            if (traducciones == null) throw new ArgumentNullException(nameof(traducciones));
            foreach (var t in traducciones)
            {
                var p = new SqlParameter[]
                {
                    new SqlParameter("@IdIdioma", t.IdIdioma),
                    new SqlParameter("@IdComponente", t.IdComponente),
                    new SqlParameter("@Texto", t.Texto)
                };
                var rows = _acceso.Escribir("UPDATE Traduccion SET Texto = @Texto WHERE IdIdioma = @IdIdioma AND IdComponente = @IdComponente", p);
                if (rows == 0)
                {
                    _acceso.Escribir("INSERT INTO Traduccion (IdIdioma, IdComponente, Texto) VALUES (@IdIdioma, @IdComponente, @Texto)", p);
                }
            }
        }

        private void InicializarBaseDatosSiVacio()
        {
            var dt = _acceso.Leer("SELECT COUNT(*) FROM Componente", null);
            if (Convert.ToInt32(dt.Rows[0][0]) == 0)
            {
                AgregarSeed("LoginForm.lblUsername", "Usuario:", "Username:");
                AgregarSeed("LoginForm.lblPassword", "Contraseña:", "Password:");
                AgregarSeed("LoginForm.btnIngresar", "Ingresar", "Login");

                AgregarSeed("MenuForm.btnUsuarios", "👤 Usuarios", "👤 Users");
                AgregarSeed("MenuForm.btnBitacora", "📜 Bitácora", "📜 Audit Trail");
                AgregarSeed("MenuForm.btnIdiomas", "🌐 Idiomas", "🌐 Languages");
                AgregarSeed("MenuForm.btnPermisos", "🔑 Permisos", "🔑 Permissions");
                AgregarSeed("MenuForm.btnCambios", "📜 Cambios", "📜 Changes");
                AgregarSeed("MenuForm.btnCerrarSesion", "❌ Cerrar sesión", "❌ Log Out");
                AgregarSeed("MenuForm.lblSesionInfo", "👤 Sesión:", "👤 Session:");
                AgregarSeed("MenuForm.lblServidorInfo", "🖳 Servidor / BD:", "🖳 Server / DB:");

                AgregarSeed("UsuariosForm.lblTituloGrilla", "Usuarios", "Users");
                AgregarSeed("UsuariosForm.lblBuscarUsuario", "🔍 Buscar:", "🔍 Search:");
                AgregarSeed("UsuariosForm.btnRefrescar", "↻ Actualizar", "↻ Refresh");
                AgregarSeed("UsuariosForm.grpGestion", "Gestión de Usuario", "User Management");
                AgregarSeed("UsuariosForm.lblUsername", "Nombre de usuario", "Username");
                AgregarSeed("UsuariosForm.lblPassword", "Contraseña", "Password");
                AgregarSeed("UsuariosForm.lblConfirmarPassword", "Confirmar contraseña", "Confirm password");
                AgregarSeed("UsuariosForm.lblRequisitos", "Para modificar, deje vacío para mantener la contraseña.\nDebe tener al menos 6 caracteres, 1 mayúscula y 1 número.", "To modify, leave empty to keep password.\nMust have at least 6 characters, 1 uppercase and 1 number.");
                AgregarSeed("UsuariosForm.lblEstado", "Estado", "Status");
                AgregarSeed("UsuariosForm.btnGuardar", "Crear usuario", "Create user");
                AgregarSeed("UsuariosForm.btnModificar", "Guardar cambios", "Save changes");
                AgregarSeed("UsuariosForm.btnLimpiar", "Limpiar", "Clear");
                AgregarSeed("UsuariosForm.btnCorromper", "Simular Fallo DVV", "Simulate DVV Failure");

                AgregarSeed("BitacoraForm.lblBuscar", "Buscar:", "Search:");
                AgregarSeed("BitacoraForm.lblCriticidad", "Criticidad:", "Severity:");
                AgregarSeed("BitacoraForm.lblActividad", "Actividad:", "Activity:");
                AgregarSeed("BitacoraForm.lblLimite", "Límite:", "Limit:");
                AgregarSeed("BitacoraForm.btnBuscar", "Buscar", "Search");
                AgregarSeed("BitacoraForm.btnLimpiar", "Limpiar", "Clear");
                AgregarSeed("BitacoraForm.btnExportar", "📥 CSV", "📥 CSV");
                AgregarSeed("BitacoraForm.grpDetalle", "Detalle del Registro", "Log Details");
                AgregarSeed("BitacoraForm.lblDetFecha", "Fecha y Hora", "Date & Time");
                AgregarSeed("BitacoraForm.lblDetUsuario", "Usuario", "User");
                AgregarSeed("BitacoraForm.lblDetModulo", "Módulo", "Module");
                AgregarSeed("BitacoraForm.lblDetActividad", "Actividad", "Activity");
                AgregarSeed("BitacoraForm.lblDetCriticidad", "Criticidad", "Severity");
                AgregarSeed("BitacoraForm.lblDetResultado", "Resultado", "Result");
                AgregarSeed("BitacoraForm.lblDetDetalle", "Detalle", "Details");
                AgregarSeed("BitacoraForm.lblDetError", "Detalle del Error", "Error Details");

                AgregarSeed("IdiomaForm.Text", "Gestión de Idiomas", "Language Management");
                AgregarSeed("IdiomaForm.lblIdiomasTitulo", "Idiomas", "Languages");
                AgregarSeed("IdiomaForm.lblNombre", "Nombre", "Name");
                AgregarSeed("IdiomaForm.lblCodigo", "Código", "Code");
                AgregarSeed("IdiomaForm.chkDefault", "Por defecto", "Default");
                AgregarSeed("IdiomaForm.btnAgregarIdioma", "Agregar idioma", "Add language");
                AgregarSeed("IdiomaForm.btnEliminarIdioma", "Eliminar seleccionado", "Delete selected");
                AgregarSeed("IdiomaForm.lblTraduccionesTitulo", "Traducciones", "Translations");
                AgregarSeed("IdiomaForm.lblIdiomaDestino", "Idioma a traducir", "Language to translate");
                AgregarSeed("IdiomaForm.btnGuardarTraducciones", "Guardar traducciones", "Save translations");
                AgregarSeed("IdiomaForm.colComponente", "Componente", "Component");
                AgregarSeed("IdiomaForm.colTexto", "Texto / Traducción", "Translation text");

                AgregarSeed("PermisosForm.Text", "Gestión de Perfiles y Permisos", "Role & Permission Management");
                AgregarSeed("PermisosForm.lblCol1Titulo", "Estructura de Permisos", "Permission Structure");
                AgregarSeed("PermisosForm.lblNombrePermiso", "Nombre", "Name");
                AgregarSeed("PermisosForm.lblClavePermiso", "Clave", "Key");
                AgregarSeed("PermisosForm.btnCrearPatente", "Nueva Patente", "New Patent/Permission");
                AgregarSeed("PermisosForm.btnCrearFamilia", "Nueva Familia", "New Family/Role");
                AgregarSeed("PermisosForm.btnEliminarPermiso", "Eliminar Seleccionado", "Delete Selected");
                AgregarSeed("PermisosForm.lblCol2Titulo", "Configurador de Relaciones", "Relationship Configurator");
                AgregarSeed("PermisosForm.lblDisponibles", "Permisos Disponibles", "Available Permissions");
                AgregarSeed("PermisosForm.lblMiembros", "Miembros del Rol", "Role Members");
                AgregarSeed("PermisosForm.btnGuardarRelaciones", "Guardar Relaciones del Rol", "Save Role Relationships");
                AgregarSeed("PermisosForm.lblCol3Titulo", "Gestión de Usuarios", "User Management");
                AgregarSeed("PermisosForm.lblUserPerms", "Permisos del Usuario", "User Permissions");
                AgregarSeed("PermisosForm.lblPatentesPlanas", "Patentes Resultantes", "Resulting Patents/Permissions");
                AgregarSeed("PermisosForm.btnAsignarUsuario", "Asignar a Usuario >>", "Assign to User >>");
                AgregarSeed("PermisosForm.btnQuitarUsuario", "<< Quitar de Usuario", "<< Remove from User");

                AgregarSeed("ControlCambiosForm.Text", "Historial de Cambios y Rollback", "Change History & Rollback");
                AgregarSeed("ControlCambiosForm.lblSeleccionarUsuario", "Usuario a auditar:", "User to audit:");
                AgregarSeed("ControlCambiosForm.lblDetalleTitulo", "Detalle de la Versión", "Version Details");
                AgregarSeed("ControlCambiosForm.lblDetUsername", "Nombre de Usuario", "Username");
                AgregarSeed("ControlCambiosForm.lblDetEstado", "Estado", "Status");
                AgregarSeed("ControlCambiosForm.btnRollback", "Revertir a esta versión", "Restore to this version");
                AgregarSeed("ControlCambiosForm.colId", "ID", "ID");
                AgregarSeed("ControlCambiosForm.colFecha", "Fecha y Hora", "Date & Time");
                AgregarSeed("ControlCambiosForm.colActor", "Modificado Por", "Modified By");
                AgregarSeed("ControlCambiosForm.colDetalle", "Detalle del Cambio", "Change Details");
            }
        }

        private void AgregarSeed(string nombreComponente, string textoEs, string textoEn)
        {
            var pComp = new SqlParameter[] { new SqlParameter("@Nombre", nombreComponente) };
            _acceso.Escribir("INSERT INTO Componente (Nombre) VALUES (@Nombre)", pComp);

            var dt = _acceso.Leer("SELECT @@IDENTITY", null);
            int idComp = Convert.ToInt32(dt.Rows[0][0]);

            var pEs = new SqlParameter[]
            {
                new SqlParameter("@IdIdioma", 1),
                new SqlParameter("@IdComponente", idComp),
                new SqlParameter("@Texto", textoEs)
            };
            _acceso.Escribir("INSERT INTO Traduccion (IdIdioma, IdComponente, Texto) VALUES (@IdIdioma, @IdComponente, @Texto)", pEs);

            var pEn = new SqlParameter[]
            {
                new SqlParameter("@IdIdioma", 2),
                new SqlParameter("@IdComponente", idComp),
                new SqlParameter("@Texto", textoEn)
            };
            _acceso.Escribir("INSERT INTO Traduccion (IdIdioma, IdComponente, Texto) VALUES (@IdIdioma, @IdComponente, @Texto)", pEn);
        }
    }
}
