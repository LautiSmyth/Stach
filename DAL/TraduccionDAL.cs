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
            var dt = _acceso.Leer("SELECT Nombre FROM Componente", null);
            var existentes = new System.Collections.Generic.HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow r in dt.Rows)
            {
                existentes.Add(r["Nombre"].ToString());
            }
            Action<string, string, string> seed = (nombre, es, en) =>
            {
                if (!existentes.Contains(nombre))
                {
                    AgregarSeed(nombre, es, en);
                }
            };
            seed("LoginForm.lblTitulo", "Iniciar sesión", "Log In");
            seed("LoginForm.lblSubtitulo", "Ingrese sus credenciales para acceder", "Enter your credentials to access");
            seed("LoginForm.lblUsername", "Usuario:", "Username:");
            seed("LoginForm.lblPassword", "Contraseña:", "Password:");
            seed("LoginForm.btnIngresar", "Ingresar", "Login");
            seed("LoginForm.btnSalir", "Cancelar", "Cancel");
            seed("LoginForm.chkHidePass", "Ocultar contraseña", "Hide password");
            seed("MenuForm.btnUsuarios", "👤 Usuarios", "👤 Users");
            seed("MenuForm.btnBitacora", "📜 Bitácora", "📜 Audit Trail");
            seed("MenuForm.btnIdiomas", "🌐 Idiomas", "🌐 Languages");
            seed("MenuForm.btnPermisos", "🔑 Permisos", "🔑 Permissions");
            seed("MenuForm.btnCambios", "📜 Cambios", "📜 Changes");
            seed("MenuForm.btnCerrarSesion", "❌ Cerrar sesión", "❌ Log Out");
            seed("MenuForm.lblSesionInfo", "👤 Sesión:", "👤 Session:");
            seed("MenuForm.lblServidorInfo", "🖳 Servidor / BD:", "🖳 Server / DB:");
            seed("UsuariosForm.lblTituloGrilla", "Usuarios", "Users");
            seed("UsuariosForm.lblBuscarUsuario", "🔍 Buscar:", "🔍 Search:");
            seed("UsuariosForm.btnRefrescar", "↻ Actualizar", "↻ Refresh");
            seed("UsuariosForm.grpGestion", "Gestión de Usuario", "User Management");
            seed("UsuariosForm.lblUsername", "Nombre de usuario", "Username");
            seed("UsuariosForm.lblPassword", "Contraseña", "Password");
            seed("UsuariosForm.lblConfirmarPassword", "Confirmar contraseña", "Confirm password");
            seed("UsuariosForm.lblRequisitos", "Para modificar, deje vacío para mantener la contraseña.\nDebe tener al menos 6 caracteres, 1 mayúscula y 1 número.", "To modify, leave empty to keep password.\nMust have at least 6 characters, 1 uppercase and 1 number.");
            seed("UsuariosForm.lblEstado", "Estado", "Status");
            seed("UsuariosForm.btnGuardar", "Crear usuario", "Create user");
            seed("UsuariosForm.btnModificar", "Guardar cambios", "Save changes");
            seed("UsuariosForm.btnLimpiar", "Limpiar", "Clear");
            seed("UsuariosForm.btnCorromper", "Simular Fallo DVV", "Simulate DVV Failure");
            seed("BitacoraForm.lblBuscar", "Buscar:", "Search:");
            seed("BitacoraForm.lblCriticidad", "Criticidad:", "Severity:");
            seed("BitacoraForm.lblActividad", "Actividad:", "Activity:");
            seed("BitacoraForm.lblLimite", "Límite:", "Limit:");
            seed("BitacoraForm.btnBuscar", "Buscar", "Search");
            seed("BitacoraForm.btnLimpiar", "Limpiar", "Clear");
            seed("BitacoraForm.btnExportar", "📥 CSV", "📥 CSV");
            seed("BitacoraForm.grpDetalle", "Detalle del Registro", "Log Details");
            seed("BitacoraForm.lblDetFecha", "Fecha y Hora", "Date & Time");
            seed("BitacoraForm.lblDetUsuario", "Usuario", "User");
            seed("BitacoraForm.lblDetModulo", "Módulo", "Module");
            seed("BitacoraForm.lblDetActividad", "Actividad", "Activity");
            seed("BitacoraForm.lblDetCriticidad", "Criticidad", "Severity");
            seed("BitacoraForm.lblDetResultado", "Resultado", "Result");
            seed("BitacoraForm.lblDetDetalle", "Detalle", "Details");
            seed("BitacoraForm.lblDetError", "Detalle del Error", "Error Details");
            seed("IdiomaForm.Text", "Gestión de Idiomas", "Language Management");
            seed("IdiomaForm.lblIdiomasTitulo", "Idiomas", "Languages");
            seed("IdiomaForm.lblNombre", "Nombre", "Name");
            seed("IdiomaForm.lblCodigo", "Código", "Code");
            seed("IdiomaForm.chkDefault", "Por defecto", "Default");
            seed("IdiomaForm.btnAgregarIdioma", "Agregar idioma", "Add language");
            seed("IdiomaForm.btnEliminarIdioma", "Eliminar seleccionado", "Delete selected");
            seed("IdiomaForm.lblTraduccionesTitulo", "Traducciones", "Translations");
            seed("IdiomaForm.lblIdiomaDestino", "Idioma a traducir", "Language to translate");
            seed("IdiomaForm.btnGuardarTraducciones", "Guardar traducciones", "Save translations");
            seed("IdiomaForm.colComponente", "Componente", "Component");
            seed("IdiomaForm.colTexto", "Texto / Traducción", "Translation text");
            seed("PermisosForm.Text", "Gestión de Perfiles y Permisos", "Role & Permission Management");
            seed("PermisosForm.lblCol1Titulo", "Estructura de Permisos", "Permission Structure");
            seed("PermisosForm.lblNombrePermiso", "Nombre", "Name");
            seed("PermisosForm.lblClavePermiso", "Clave", "Key");
            seed("PermisosForm.btnCrearPatente", "Nueva Patente", "New Patent/Permission");
            seed("PermisosForm.btnCrearFamilia", "Nueva Familia", "New Family/Role");
            seed("PermisosForm.btnEliminarPermiso", "Eliminar Seleccionado", "Delete Selected");
            seed("PermisosForm.lblCol2Titulo", "Configurador de Relaciones", "Relationship Configurator");
            seed("PermisosForm.lblDisponibles", "Permisos Disponibles", "Available Permissions");
            seed("PermisosForm.lblMiembros", "Miembros del Rol", "Role Members");
            seed("PermisosForm.btnGuardarRelaciones", "Guardar Relaciones del Rol", "Save Role Relationships");
            seed("PermisosForm.lblCol3Titulo", "Gestión de Usuarios", "User Management");
            seed("PermisosForm.lblUserPerms", "Permisos del Usuario", "User Permissions");
            seed("PermisosForm.lblPatentesPlanas", "Patentes Resultantes", "Resulting Patents/Permissions");
            seed("PermisosForm.btnAsignarUsuario", "Asignar a Usuario >>", "Assign to User >>");
            seed("PermisosForm.btnQuitarUsuario", "<< Quitar de Usuario", "<< Remove from User");
            seed("ControlCambiosForm.Text", "Historial de Cambios y Rollback", "Change History & Rollback");
            seed("ControlCambiosForm.lblSeleccionarUsuario", "Usuario a auditar:", "User to audit:");
            seed("ControlCambiosForm.lblDetalleTitulo", "Detalle de la Versión", "Version Details");
            seed("ControlCambiosForm.lblDetUsername", "Nombre de Usuario", "Username");
            seed("ControlCambiosForm.lblDetEstado", "Estado", "Status");
            seed("ControlCambiosForm.btnRollback", "Revertir a esta versión", "Restore to this version");
            seed("ControlCambiosForm.colId", "ID", "ID");
            seed("ControlCambiosForm.colFecha", "Fecha y Hora", "Date & Time");
            seed("ControlCambiosForm.colActor", "Modificado Por", "Modified By");
            seed("ControlCambiosForm.colDetalle", "Detalle del Cambio", "Change Details");
        }

        private void AgregarSeed(string nombreComponente, string textoEs, string textoEn)
        {
            var pComp = new SqlParameter[] { new SqlParameter("@Nombre", nombreComponente) };
            var dt = _acceso.Leer("INSERT INTO Componente (Nombre) OUTPUT INSERTED.IdComponente VALUES (@Nombre)", pComp);
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
