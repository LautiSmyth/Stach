using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class TraduccionDAL
    {
        private static readonly List<Componente> _componentes = new List<Componente>();
        private static readonly List<Traduccion> _traducciones = new List<Traduccion>();
        private static int _nextComponenteId = 1;

        static TraduccionDAL()
        {
            AgregarMock("LoginForm.lblUsername", "Usuario:", "Username:");
            AgregarMock("LoginForm.lblPassword", "Contraseña:", "Password:");
            AgregarMock("LoginForm.btnIngresar", "Ingresar", "Login");

            AgregarMock("MenuForm.btnUsuarios", "👤 Usuarios", "👤 Users");
            AgregarMock("MenuForm.btnBitacora", "📜 Bitácora", "📜 Audit Trail");
            AgregarMock("MenuForm.btnIdiomas", "🌐 Idiomas", "🌐 Languages");
            AgregarMock("MenuForm.btnCerrarSesion", "❌ Cerrar sesión", "❌ Log Out");
            AgregarMock("MenuForm.lblSesionInfo", "👤 Sesión:", "👤 Session:");
            AgregarMock("MenuForm.lblServidorInfo", "🖳 Servidor / BD:", "🖳 Server / DB:");

            AgregarMock("UsuariosForm.lblTituloGrilla", "Usuarios", "Users");
            AgregarMock("UsuariosForm.lblBuscarUsuario", "🔍 Buscar:", "🔍 Search:");
            AgregarMock("UsuariosForm.btnRefrescar", "↻ Actualizar", "↻ Refresh");
            AgregarMock("UsuariosForm.grpGestion", "Gestión de Usuario", "User Management");
            AgregarMock("UsuariosForm.lblUsername", "Nombre de usuario", "Username");
            AgregarMock("UsuariosForm.lblPassword", "Contraseña", "Password");
            AgregarMock("UsuariosForm.lblConfirmarPassword", "Confirmar contraseña", "Confirm password");
            AgregarMock("UsuariosForm.lblRequisitos", "Para modificar, deje vacío para mantener la contraseña.\nDebe tener al menos 6 caracteres, 1 mayúscula y 1 número.", "To modify, leave empty to keep password.\nMust have at least 6 characters, 1 uppercase and 1 number.");
            AgregarMock("UsuariosForm.lblEstado", "Estado", "Status");
            AgregarMock("UsuariosForm.btnGuardar", "Crear usuario", "Create user");
            AgregarMock("UsuariosForm.btnModificar", "Guardar cambios", "Save changes");
            AgregarMock("UsuariosForm.btnLimpiar", "Limpiar", "Clear");

            AgregarMock("BitacoraForm.lblBuscar", "Buscar:", "Search:");
            AgregarMock("BitacoraForm.lblCriticidad", "Criticidad:", "Severity:");
            AgregarMock("BitacoraForm.lblActividad", "Actividad:", "Activity:");
            AgregarMock("BitacoraForm.lblLimite", "Límite:", "Limit:");
            AgregarMock("BitacoraForm.btnBuscar", "Buscar", "Search");
            AgregarMock("BitacoraForm.btnLimpiar", "Limpiar", "Clear");
            AgregarMock("BitacoraForm.btnExportar", "📥 CSV", "📥 CSV");
            AgregarMock("BitacoraForm.grpDetalle", "Detalle del Registro", "Log Details");
            AgregarMock("BitacoraForm.lblDetFecha", "Fecha y Hora", "Date & Time");
            AgregarMock("BitacoraForm.lblDetUsuario", "Usuario", "User");
            AgregarMock("BitacoraForm.lblDetModulo", "Módulo", "Module");
            AgregarMock("BitacoraForm.lblDetActividad", "Actividad", "Activity");
            AgregarMock("BitacoraForm.lblDetCriticidad", "Criticidad", "Severity");
            AgregarMock("BitacoraForm.lblDetResultado", "Resultado", "Result");
            AgregarMock("BitacoraForm.lblDetDetalle", "Detalle", "Details");
            AgregarMock("BitacoraForm.lblDetError", "Detalle del Error", "Error Details");

            AgregarMock("IdiomaForm.Text", "Gestión de Idiomas", "Language Management");
            AgregarMock("IdiomaForm.lblIdiomasTitulo", "Idiomas", "Languages");
            AgregarMock("IdiomaForm.lblNombre", "Nombre", "Name");
            AgregarMock("IdiomaForm.lblCodigo", "Código", "Code");
            AgregarMock("IdiomaForm.chkDefault", "Por defecto", "Default");
            AgregarMock("IdiomaForm.btnAgregarIdioma", "Agregar idioma", "Add language");
            AgregarMock("IdiomaForm.btnEliminarIdioma", "Eliminar seleccionado", "Delete selected");
            AgregarMock("IdiomaForm.lblTraduccionesTitulo", "Traducciones", "Translations");
            AgregarMock("IdiomaForm.lblIdiomaDestino", "Idioma a traducir", "Language to translate");
            AgregarMock("IdiomaForm.btnGuardarTraducciones", "Guardar traducciones", "Save translations");
            AgregarMock("IdiomaForm.colComponente", "Componente", "Component");
            AgregarMock("IdiomaForm.colTexto", "Texto / Traducción", "Translation text");
        }

        private static void AgregarMock(string nombreComponente, string textoEs, string textoEn)
        {
            var comp = new Componente { IdComponente = _nextComponenteId++, Nombre = nombreComponente };
            _componentes.Add(comp);

            _traducciones.Add(new Traduccion { IdIdioma = 1, IdComponente = comp.IdComponente, Texto = textoEs });
            _traducciones.Add(new Traduccion { IdIdioma = 2, IdComponente = comp.IdComponente, Texto = textoEn });
        }

        public List<Componente> ObtenerComponentes()
        {
            return new List<Componente>(_componentes);
        }

        public void InsertarComponente(Componente componente)
        {
            if (componente == null) throw new ArgumentNullException(nameof(componente));
            if (_componentes.Any(c => c.Nombre.Equals(componente.Nombre, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("El componente ya existe.");

            componente.IdComponente = _nextComponenteId++;
            _componentes.Add(componente);
        }

        public List<Traduccion> ObtenerTraduccionesPorIdioma(int idIdioma)
        {
            return _traducciones.Where(t => t.IdIdioma == idIdioma).ToList();
        }

        public void GuardarTraducciones(List<Traduccion> traducciones)
        {
            if (traducciones == null) throw new ArgumentNullException(nameof(traducciones));
            foreach (var t in traducciones)
            {
                var existente = _traducciones.FirstOrDefault(tr => tr.IdIdioma == t.IdIdioma && tr.IdComponente == t.IdComponente);
                if (existente != null)
                {
                    existente.Texto = t.Texto;
                }
                else
                {
                    _traducciones.Add(t);
                }
            }
        }
    }
}
