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
                var pUpdate = new SqlParameter[]
                {
                    new SqlParameter("@IdIdioma", t.IdIdioma),
                    new SqlParameter("@IdComponente", t.IdComponente),
                    new SqlParameter("@Texto", t.Texto)
                };
                var rows = _acceso.Escribir("UPDATE Traduccion SET Texto = @Texto WHERE IdIdioma = @IdIdioma AND IdComponente = @IdComponente", pUpdate);
                if (rows == 0)
                {
                    var pInsert = new SqlParameter[]
                    {
                        new SqlParameter("@IdIdioma", t.IdIdioma),
                        new SqlParameter("@IdComponente", t.IdComponente),
                        new SqlParameter("@Texto", t.Texto)
                    };
                    _acceso.Escribir("INSERT INTO Traduccion (IdIdioma, IdComponente, Texto) VALUES (@IdIdioma, @IdComponente, @Texto)", pInsert);
                }
            }
        }

        public void InicializarBaseDatosSiVacio()
        {
            var dtIdiomas = _acceso.Leer("SELECT COUNT(*) FROM Idioma", null);
            if (Convert.ToInt32(dtIdiomas.Rows[0][0]) == 0)
            {
                _acceso.Escribir("SET IDENTITY_INSERT Idioma ON; INSERT INTO Idioma (IdIdioma, Nombre, Codigo, [Default]) VALUES (1, N'Español', 'es', 1); INSERT INTO Idioma (IdIdioma, Nombre, Codigo, [Default]) VALUES (2, N'English', 'en', 0); INSERT INTO Idioma (IdIdioma, Nombre, Codigo, [Default]) VALUES (3, N'Português', 'pt', 0); SET IDENTITY_INSERT Idioma OFF;", null);
            }
            else
            {
                var dtPt = _acceso.Leer("SELECT COUNT(*) FROM Idioma WHERE Codigo = 'pt'", null);
                if (Convert.ToInt32(dtPt.Rows[0][0]) == 0)
                {
                    _acceso.Escribir("SET IDENTITY_INSERT Idioma ON; INSERT INTO Idioma (IdIdioma, Nombre, Codigo, [Default]) VALUES (3, N'Português', 'pt', 0); SET IDENTITY_INSERT Idioma OFF;", null);
                }
            }
            var dt = _acceso.Leer("SELECT Nombre FROM Componente", null);
            var existentes = new System.Collections.Generic.HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow r in dt.Rows)
            {
                existentes.Add(r["Nombre"].ToString());
            }
            Action<string, string, string, string> seed = (nombre, es, en, pt) =>
            {
                AgregarSeed(nombre, es, en, pt);
            };
            seed("LoginForm.lblTitulo", "Iniciar sesión", "Log In", "Iniciar sessão");
            seed("LoginForm.lblSubtitulo", "Ingrese sus credenciales para acceder", "Enter your credentials to access", "Insira as suas credenciais para aceder");
            seed("LoginForm.lblBienvenida", "Sistema de\nGestión", "Management\nSystem", "Sistema de\nGestão");
            seed("LoginForm.lblTagline", "Acceso seguro y centralizado\na todos los módulos", "Secure and centralized access\nto all modules", "Acesso seguro e centralizado\na todos os módulos");
            seed("LoginForm.lblUsername", "Usuario:", "Username:", "Usuário:");
            seed("LoginForm.lblPassword", "Contraseña:", "Password:", "Senha:");
            seed("LoginForm.btnIngresar", "Ingresar", "Login", "Entrar");
            seed("LoginForm.btnSalir", "Cancelar", "Cancel", "Cancelar");
            seed("LoginForm.chkHidePass", "Ocultar contraseña", "Hide password", "Ocultar senha");
            seed("MenuForm.btnUsuarios", "👤 Usuarios", "👤 Users", "👤 Usuários");
            seed("MenuForm.btnBitacora", "📜 Bitácora", "📜 Audit Trail", "📜 Auditoria");
            seed("MenuForm.btnIdiomas", "🌐 Idiomas", "🌐 Languages", "🌐 Idiomas");
            seed("MenuForm.btnPermisos", "🔑 Permisos", "🔑 Permissions", "🔑 Permissões");
            seed("MenuForm.btnCambios", "📜 Cambios", "📜 Changes", "📜 Alterações");
            seed("MenuForm.btnCerrarSesion", "❌ Cerrar sesión", "❌ Log Out", "❌ Sair");
            seed("MenuForm.lblSesionInfo", "👤 Sesión:", "👤 Session:", "👤 Sessão:");
            seed("MenuForm.lblServidorInfo", "🖳 Servidor / BD:", "🖳 Server / DB:", "🖳 Servidor / BD:");
            seed("UsuariosForm.lblTituloGrilla", "Usuarios", "Users", "Usuários");
            seed("UsuariosForm.lblBuscarUsuario", "🔍 Buscar:", "🔍 Search:", "🔍 Buscar:");
            seed("UsuariosForm.btnRefrescar", "↻ Actualizar", "↻ Refresh", "↻ Atualizar");
            seed("UsuariosForm.grpGestion", "Gestión de Usuario", "User Management", "Gestão de Usuários");
            seed("UsuariosForm.lblUsername", "Nombre de usuario", "Username", "Nome de usuário");
            seed("UsuariosForm.lblPassword", "Contraseña", "Password", "Senha");
            seed("UsuariosForm.lblConfirmarPassword", "Confirmar contraseña", "Confirm password", "Confirmar senha");
            seed("UsuariosForm.lblRequisitos", "Para modificar, deje vacío para mantener la contraseña.\nDebe tener al menos 6 caracteres, 1 mayúscula y 1 número.", "To modify, leave empty to keep password.\nMust have at least 6 characters, 1 uppercase and 1 number.", "Para modificar, deixe em branco para manter a senha.\nDeve ter pelo menos 6 caracteres, 1 maiúscula e 1 número.");
            seed("UsuariosForm.lblEstado", "Estado", "Status", "Status");
            seed("UsuariosForm.btnGuardar", "Crear usuario", "Create user", "Criar usuário");
            seed("UsuariosForm.btnModificar", "Guardar cambios", "Save changes", "Salvar alterações");
            seed("UsuariosForm.btnLimpiar", "Limpiar", "Clear", "Limpar");
            seed("UsuariosForm.btnCorromper", "Simular Fallo DVV", "Simulate DVV Failure", "Simular Falha DVV");
            seed("BitacoraForm.lblBuscar", "Buscar:", "Search:", "Buscar:");
            seed("BitacoraForm.lblCriticidad", "Criticidad:", "Severity:", "Criticidade:");
            seed("BitacoraForm.lblActividad", "Actividad:", "Activity:", "Atividade:");
            seed("BitacoraForm.lblLimite", "Límite:", "Limit:", "Limite:");
            seed("BitacoraForm.btnBuscar", "Buscar", "Search", "Buscar");
            seed("BitacoraForm.btnLimpiar", "Limpiar", "Clear", "Limpar");
            seed("BitacoraForm.btnExportar", "📥 CSV", "📥 CSV", "📥 CSV");
            seed("BitacoraForm.grpDetalle", "Detalle del Registro", "Log Details", "Detalhes do Registro");
            seed("BitacoraForm.lblDetFecha", "Fecha y Hora", "Date & Time", "Data e Hora");
            seed("BitacoraForm.lblDetUsuario", "Usuario", "User", "Usuário");
            seed("BitacoraForm.lblDetModulo", "Módulo", "Module", "Módulo");
            seed("BitacoraForm.lblDetActividad", "Actividad", "Activity", "Atividade");
            seed("BitacoraForm.lblDetCriticidad", "Criticidad", "Severity", "Criticidade");
            seed("BitacoraForm.lblDetResultado", "Resultado", "Result", "Resultado");
            seed("BitacoraForm.lblDetDetalle", "Detalle", "Details", "Detalhe");
            seed("BitacoraForm.lblDetError", "Detalle del Error", "Error Details", "Detalhe do Erro");
            seed("IdiomaForm.Text", "Gestión de Idiomas", "Language Management", "Gestão de Idiomas");
            seed("IdiomaForm.lblIdiomasTitulo", "Idiomas", "Languages", "Idiomas");
            seed("IdiomaForm.lblNombre", "Nombre", "Name", "Nome");
            seed("IdiomaForm.lblCodigo", "Código", "Code", "Código");
            seed("IdiomaForm.chkDefault", "Por defecto", "Default", "Padrão");
            seed("IdiomaForm.btnAgregarIdioma", "Agregar idioma", "Add language", "Adicionar idioma");
            seed("IdiomaForm.btnEliminarIdioma", "Eliminar seleccionado", "Delete selected", "Excluir selecionado");
            seed("IdiomaForm.lblTraduccionesTitulo", "Traducciones", "Translations", "Traduções");
            seed("IdiomaForm.lblIdiomaDestino", "Idioma a traducir", "Language to translate", "Idioma a traduzir");
            seed("IdiomaForm.btnGuardarTraducciones", "Guardar traducciones", "Save translations", "Salvar traduções");
            seed("IdiomaForm.colComponente", "Componente", "Component", "Componente");
            seed("IdiomaForm.colTexto", "Texto / Traducción", "Translation text", "Texto / Tradução");
            seed("PermisosForm.Text", "Gestión de Perfiles y Permisos", "Role & Permission Management", "Gestão de Perfis e Permissões");
            seed("PermisosForm.lblCol1Titulo", "Estructura de Permisos", "Permission Structure", "Estrutura de Permissões");
            seed("PermisosForm.lblNombrePermiso", "Nombre", "Name", "Nome");
            seed("PermisosForm.lblClavePermiso", "Clave", "Key", "Chave");
            seed("PermisosForm.btnCrearPatente", "Nueva Patente", "New Patent/Permission", "Nova Patente");
            seed("PermisosForm.btnCrearFamilia", "Nueva Familia", "New Family/Role", "Nova Família");
            seed("PermisosForm.btnEliminarPermiso", "Eliminar Seleccionado", "Delete Selected", "Excluir Selecionado");
            seed("PermisosForm.lblCol2Titulo", "Configurador de Relaciones", "Relationship Configurator", "Configurador de Relações");
            seed("PermisosForm.lblDisponibles", "Permisos Disponibles", "Available Permissions", "Permissões Disponíveis");
            seed("PermisosForm.lblMiembros", "Miembros del Rol", "Role Members", "Membros do Grupo");
            seed("PermisosForm.btnGuardarRelaciones", "Guardar Relaciones del Rol", "Save Role Relationships", "Salvar Relações do Grupo");
            seed("PermisosForm.lblCol3Titulo", "Gestión de Usuarios", "User Management", "Gestão de Usuários");
            seed("PermisosForm.lblUserPerms", "Permisos del Usuario", "User Permissions", "Permissões do Usuário");
            seed("PermisosForm.lblPatentesPlanas", "Patentes Resultantes", "Resulting Patents/Permissions", "Patentes Resultantes");
            seed("PermisosForm.btnAsignarUsuario", "Asignar a Usuario >>", "Assign to User >>", "Atribuir ao Usuário >>");
            seed("PermisosForm.btnQuitarUsuario", "<< Quitar de Usuario", "<< Remove from User", "<< Remover do Usuário");
            seed("ControlCambiosForm.Text", "Historial de Cambios y Rollback", "Change History & Rollback", "Histórico de Alterações e Rollback");
            seed("ControlCambiosForm.lblSeleccionarUsuario", "Usuario a auditar:", "User to audit:", "Usuário a auditar:");
            seed("ControlCambiosForm.lblDetalleTitulo", "Detalle de la Versión", "Version Details", "Detalhes da Versão");
            seed("ControlCambiosForm.lblDetUsername", "Nombre de Usuario", "Username", "Nome de Usuário");
            seed("ControlCambiosForm.lblDetEstado", "Estado", "Status", "Status");
            seed("ControlCambiosForm.btnRollback", "Revertir a esta versión", "Restore to this version", "Reverter para esta versão");
            seed("ControlCambiosForm.colId", "ID", "ID", "ID");
            seed("ControlCambiosForm.colFecha", "Fecha y Hora", "Date & Time", "Data e Hora");
            seed("ControlCambiosForm.colActor", "Modificado Por", "Modified By", "Modificado Por");
            seed("ControlCambiosForm.colDetalle", "Detalle del Cambio", "Change Details", "Detalhes da Alteração");
            seed("BitacoraForm.lblFiltrarUsuario", "Usuario:", "User:", "Usuário:");
            seed("BitacoraForm.Todos", "Todos", "All", "Todos");
            seed("MenuForm.btnBackup", "💾 Backup", "💾 Backup", "💾 Backup");
            seed("BackupForm.Text", "Copia de Seguridad y Restauración", "Backup & Restore", "Cópia de Segurança y Restauração");
            seed("BackupForm.lblTitulo", "Gestión de Backups", "Backup Management", "Gestão de Backups");
            seed("BackupForm.btnCrear", "Generar Copia de Seguridad (.bak)", "Generate Backup (.bak)", "Gerar Cópia de Segurança (.bak)");
            seed("BackupForm.btnRestaurar", "Restaurar Copia de Seguridad (.bak)", "Restore Backup (.bak)", "Restaurar Cópia de Segurança (.bak)");
            seed("BackupForm.lblInfo", "Nota: La restauración cerrará las conexiones activas temporalmente para poder sobrescribir la base de datos.", "Note: Restoration will temporarily close active connections to overwrite the database.", "Nota: A restauração fechará as conexões ativas temporariamente para poder sobrescrever a base de datos.");
            seed("MisPermisosForm.Text", "Mis Permisos y Roles", "My Permissions & Roles", "Minhas Permissões e Perfis");
            seed("MisPermisosForm.lblTitulo", "Mis Roles y Permisos", "My Roles & Permissions", "Minhas Permissões e Perfis");
            seed("MisPermisosForm.lblDirectos", "Roles y Permisos Asignados", "Assigned Roles & Permissions", "Perfis e Permissões Atribuídos");
            seed("MisPermisosForm.lblResueltos", "Permisos Finales (Resueltos)", "Final Permissions (Resolved)", "Permissões Finais (Resolvidas)");
            seed("MisPermisosForm.btnCerrar", "Cerrar", "Close", "Fechar");
        }

        private void AgregarSeed(string nombreComponente, string textoEs, string textoEn, string textoPt)
        {
            int idComp;
            var pSel = new SqlParameter[] { new SqlParameter("@Nombre", nombreComponente) };
            var dtSel = _acceso.Leer("SELECT IdComponente FROM Componente WHERE Nombre = @Nombre", pSel);
            if (dtSel.Rows.Count > 0)
            {
                idComp = Convert.ToInt32(dtSel.Rows[0]["IdComponente"]);
            }
            else
            {
                var pIns = new SqlParameter[] { new SqlParameter("@Nombre", nombreComponente) };
                var dt = _acceso.Leer("INSERT INTO Componente (Nombre) OUTPUT INSERTED.IdComponente VALUES (@Nombre)", pIns);
                idComp = Convert.ToInt32(dt.Rows[0][0]);
            }
            Action<int, string> insTrad = (idIdioma, texto) =>
            {
                var pCheck = new SqlParameter[]
                {
                    new SqlParameter("@IdIdioma", idIdioma),
                    new SqlParameter("@IdComponente", idComp)
                };
                var dtCheck = _acceso.Leer("SELECT COUNT(*) FROM Traduccion WHERE IdIdioma = @IdIdioma AND IdComponente = @IdComponente", pCheck);
                if (Convert.ToInt32(dtCheck.Rows[0][0]) == 0)
                {
                    var pIns = new SqlParameter[]
                    {
                        new SqlParameter("@IdIdioma", idIdioma),
                        new SqlParameter("@IdComponente", idComp),
                        new SqlParameter("@Texto", texto)
                    };
                    _acceso.Escribir("INSERT INTO Traduccion (IdIdioma, IdComponente, Texto) VALUES (@IdIdioma, @IdComponente, @Texto)", pIns);
                }
            };
            insTrad(1, textoEs);
            insTrad(2, textoEn);
            insTrad(3, textoPt);
        }
    }
}