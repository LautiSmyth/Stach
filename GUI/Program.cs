using System;
using System.Windows.Forms;
using Abstracciones;
using Servicios;
using BLL;
using DAL;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += (sender, args) => ManejarExcepcionGlobal(args.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => ManejarExcepcionGlobal(args.ExceptionObject as Exception);

            IoCContainer.RegistrarSingleton<IUsuarioDAL>(() => new UsuarioDAL());
            IoCContainer.RegistrarSingleton<IPermisoDAL>(() => new PermisoDAL());
            IoCContainer.RegistrarSingleton<IIdiomaDAL>(() => new IdiomaDAL());
            IoCContainer.RegistrarSingleton<ITraduccionDAL>(() => new TraduccionDAL());
            IoCContainer.RegistrarSingleton<IBitacoraDAL>(() => new BitacoraDAL());
            IoCContainer.RegistrarSingleton<IVersionUsuarioDAL>(() => new VersionUsuarioDAL());
            IoCContainer.RegistrarSingleton<IBackupDAL>(() => new BackupDAL());
            IoCContainer.RegistrarSingleton<IConexionDAL>(() => new ConexionDAL());
            IoCContainer.RegistrarSingleton<IDigitoVerificadorDAL>(() => new DigitoVerificadorDAL());
            IoCContainer.RegistrarSingleton<ICriticidadRepositorio>(() => new CriticidadDAL());

            IoCContainer.RegistrarSingleton<IContadorSesion>(() => new ContadorSesion());
            IoCContainer.RegistrarSingleton<IEncriptador>(() => new Encriptador());
            IoCContainer.RegistrarSingleton<ISessionManager>(() => SessionManager.GetInstance());
            IoCContainer.RegistrarSingleton<IManejadorIdioma>(() => ManejadorIdioma.Instancia);
            IoCContainer.RegistrarSingleton<IBitacoraService>(() => new BitacoraService(
                IoCContainer.Resolver<IBitacoraDAL>(),
                IoCContainer.Resolver<ISessionManager>()
            ));
            IoCContainer.RegistrarSingleton<ICriticidadService>(() => new CriticidadService(
                IoCContainer.Resolver<ICriticidadRepositorio>()
            ));
            IoCContainer.RegistrarSingleton<IDigitoVerificadorService>(() => new DigitoVerificadorService(
                IoCContainer.Resolver<IDigitoVerificadorDAL>(),
                IoCContainer.Resolver<IUsuarioDAL>(),
                IoCContainer.Resolver<IEncriptador>()
            ));
            IoCContainer.RegistrarSingleton<IBackupService>(() => new BackupService(
                IoCContainer.Resolver<IBackupDAL>(),
                IoCContainer.Resolver<IBitacoraService>(),
                IoCContainer.Resolver<ISessionManager>(),
                IoCContainer.Resolver<IDigitoVerificadorService>()
            ));
            IoCContainer.RegistrarSingleton<IConexionService>(() => new ConexionService(
                IoCContainer.Resolver<IConexionDAL>()
            ));

            IoCContainer.RegistrarSingleton<UsuarioBLL>(() => new UsuarioBLL(
                IoCContainer.Resolver<IUsuarioDAL>(),
                IoCContainer.Resolver<IPermisoDAL>(),
                IoCContainer.Resolver<IDigitoVerificadorService>(),
                IoCContainer.Resolver<IVersionUsuarioDAL>(),
                IoCContainer.Resolver<ISessionManager>(),
                IoCContainer.Resolver<IBitacoraService>(),
                IoCContainer.Resolver<IEncriptador>(),
                IoCContainer.Resolver<IContadorSesion>()
            ));
            IoCContainer.RegistrarSingleton<PermisoBLL>(() => new PermisoBLL(
                IoCContainer.Resolver<IPermisoDAL>(),
                IoCContainer.Resolver<IBitacoraService>(),
                IoCContainer.Resolver<ISessionManager>()
            ));
            IoCContainer.RegistrarSingleton<IdiomaBLL>(() => new IdiomaBLL(
                IoCContainer.Resolver<IIdiomaDAL>()
            ));
            IoCContainer.RegistrarSingleton<TraduccionBLL>(() => new TraduccionBLL(
                IoCContainer.Resolver<ITraduccionDAL>()
            ));
            IoCContainer.RegistrarSingleton<VersionUsuarioBLL>(() => new VersionUsuarioBLL(
                IoCContainer.Resolver<IVersionUsuarioDAL>(),
                IoCContainer.Resolver<IUsuarioDAL>(),
                IoCContainer.Resolver<IDigitoVerificadorService>(),
                IoCContainer.Resolver<IBitacoraService>()
            ));

            var conexionService = IoCContainer.Resolver<IConexionService>();
            if (!conexionService.VerificarConexion())
            {
                MessageBox.Show(
                    "No se puede conectar a la base de datos. Contacte al administrador.",
                    "Error de conexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var dvServicio = IoCContainer.Resolver<IDigitoVerificadorService>();
            System.Collections.Generic.List<string> errores;
            if (!dvServicio.VerificarIntegridad(out errores))
            {
                MessageBox.Show("Se ha detectado un fallo de integridad en el sistema. Se abrira el panel de restauracion.", "Fallo de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RestauracionForm restForm = new RestauracionForm(errores);
                Application.Run(restForm);

                if (restForm.RestauradoExitosamente)
                {
                    Application.Run(new LoginForm());
                }
            }
            else
            {
                Application.Run(new LoginForm());
            }
        }

        private static void ManejarExcepcionGlobal(Exception ex)
        {
            if (ex == null) return;
            try
            {
                var bitacora = IoCContainer.Resolver<IBitacoraService>();
                bitacora.Registrar("GUI", "Error No Controlado", ex.Message, false, ex.ToString());
            }
            catch
            {
            }
            MessageBox.Show(
                ex.Message,
                "Error Inesperado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}