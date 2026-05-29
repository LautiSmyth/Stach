using Abstracciones;

namespace IoC
{
    public static class Bootstrapper
    {
        public static void RegistrarDependencias()
        {
            IoCContainer.RegistrarSingleton<IUsuarioDAL>(() => new DAL.UsuarioDAL());
            IoCContainer.RegistrarSingleton<IPermisoDAL>(() => new DAL.PermisoDAL());
            IoCContainer.RegistrarSingleton<IIdiomaDAL>(() => new DAL.IdiomaDAL());
            IoCContainer.RegistrarSingleton<ITraduccionDAL>(() => new DAL.TraduccionDAL());
            IoCContainer.RegistrarSingleton<IBitacoraDAL>(() => new DAL.BitacoraDAL());
            IoCContainer.RegistrarSingleton<IVersionUsuarioDAL>(() => new DAL.VersionUsuarioDAL());
            IoCContainer.RegistrarSingleton<IBackupDAL>(() => new DAL.BackupDAL());
            IoCContainer.RegistrarSingleton<IConexionDAL>(() => new DAL.ConexionDAL());
            IoCContainer.RegistrarSingleton<IDigitoVerificadorDAL>(() => new DAL.DigitoVerificadorDAL());
            IoCContainer.RegistrarSingleton<ICriticidadRepositorio>(() => new DAL.CriticidadDAL());

            IoCContainer.RegistrarSingleton<IContadorSesion>(() => new Servicios.ContadorSesion());
            IoCContainer.RegistrarSingleton<IEncriptador>(() => new Servicios.Encriptador());
            IoCContainer.RegistrarSingleton<ISessionManager>(() => Servicios.SessionManager.GetInstance());
            IoCContainer.RegistrarSingleton<IManejadorIdioma>(() => Servicios.ManejadorIdioma.Instancia);

            IoCContainer.RegistrarSingleton<IBitacoraService>(() => new Servicios.BitacoraService(
                IoCContainer.Resolver<IBitacoraDAL>(),
                IoCContainer.Resolver<ISessionManager>()
            ));
            IoCContainer.RegistrarSingleton<ICriticidadService>(() => new Servicios.CriticidadService(
                IoCContainer.Resolver<ICriticidadRepositorio>()
            ));
            IoCContainer.RegistrarSingleton<IDigitoVerificadorService>(() => new Servicios.DigitoVerificadorService(
                IoCContainer.Resolver<IDigitoVerificadorDAL>(),
                IoCContainer.Resolver<IUsuarioDAL>(),
                IoCContainer.Resolver<IEncriptador>()
            ));
            IoCContainer.RegistrarSingleton<IBackupService>(() => new Servicios.BackupService(
                IoCContainer.Resolver<IBackupDAL>(),
                IoCContainer.Resolver<IBitacoraService>(),
                IoCContainer.Resolver<ISessionManager>(),
                IoCContainer.Resolver<IDigitoVerificadorService>()
            ));
            IoCContainer.RegistrarSingleton<IConexionService>(() => new Servicios.ConexionService(
                IoCContainer.Resolver<IConexionDAL>()
            ));

            IoCContainer.RegistrarSingleton<BLL.UsuarioBLL>(() => new BLL.UsuarioBLL(
                IoCContainer.Resolver<IUsuarioDAL>(),
                IoCContainer.Resolver<IPermisoDAL>(),
                IoCContainer.Resolver<IDigitoVerificadorService>(),
                IoCContainer.Resolver<IVersionUsuarioDAL>(),
                IoCContainer.Resolver<ISessionManager>(),
                IoCContainer.Resolver<IBitacoraService>(),
                IoCContainer.Resolver<IEncriptador>(),
                IoCContainer.Resolver<IContadorSesion>()
            ));
            IoCContainer.RegistrarSingleton<BLL.PermisoBLL>(() => new BLL.PermisoBLL(
                IoCContainer.Resolver<IPermisoDAL>(),
                IoCContainer.Resolver<IBitacoraService>(),
                IoCContainer.Resolver<ISessionManager>()
            ));
            IoCContainer.RegistrarSingleton<BLL.IdiomaBLL>(() => new BLL.IdiomaBLL(
                IoCContainer.Resolver<IIdiomaDAL>()
            ));
            IoCContainer.RegistrarSingleton<BLL.TraduccionBLL>(() => new BLL.TraduccionBLL(
                IoCContainer.Resolver<ITraduccionDAL>()
            ));
            IoCContainer.RegistrarSingleton<BLL.VersionUsuarioBLL>(() => new BLL.VersionUsuarioBLL(
                IoCContainer.Resolver<IVersionUsuarioDAL>(),
                IoCContainer.Resolver<IUsuarioDAL>(),
                IoCContainer.Resolver<IDigitoVerificadorService>(),
                IoCContainer.Resolver<IBitacoraService>()
            ));
        }
    }
}
