namespace IoC
{
    public static class Bootstrapper
    {
        public static void RegistrarDependencias()
        {
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IUsuarioDAL>(() => new DAL.UsuarioDAL());
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IPermisoDAL>(() => new DAL.PermisoDAL());
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IIdiomaDAL>(() => new DAL.IdiomaDAL());
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.ITraduccionDAL>(() => new DAL.TraduccionDAL());
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IBitacoraDAL>(() => new DAL.BitacoraDAL());
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IVersionUsuarioDAL>(() => new DAL.VersionUsuarioDAL());
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IBackupDAL>(() => new DAL.BackupDAL());
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IConexionDAL>(() => new DAL.ConexionDAL());
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IDigitoVerificadorDAL>(() => new DAL.DigitoVerificadorDAL());
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.ICriticidadRepositorio>(() => new DAL.CriticidadDAL());

            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IContadorSesion>(() => new Servicios.ContadorSesion());
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IEncriptador>(() => new Servicios.Encriptador());
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.ISessionManager>(() => Servicios.SessionManager.GetInstance());
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IManejadorIdioma>(() => Servicios.ManejadorIdioma.Instancia);

            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IBitacoraService>(() => new Servicios.BitacoraService(
                Servicios.IoCContainer.Resolver<Abstracciones.IBitacoraDAL>(),
                Servicios.IoCContainer.Resolver<Abstracciones.ISessionManager>()
            ));
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.ICriticidadService>(() => new Servicios.CriticidadService(
                Servicios.IoCContainer.Resolver<Abstracciones.ICriticidadRepositorio>()
            ));
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IDigitoVerificadorService>(() => new Servicios.DigitoVerificadorService(
                Servicios.IoCContainer.Resolver<Abstracciones.IDigitoVerificadorDAL>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IUsuarioDAL>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IEncriptador>()
            ));
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IBackupService>(() => new Servicios.BackupService(
                Servicios.IoCContainer.Resolver<Abstracciones.IBackupDAL>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IBitacoraService>(),
                Servicios.IoCContainer.Resolver<Abstracciones.ISessionManager>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IDigitoVerificadorService>()
            ));
            Servicios.IoCContainer.RegistrarSingleton<Abstracciones.IConexionService>(() => new Servicios.ConexionService(
                Servicios.IoCContainer.Resolver<Abstracciones.IConexionDAL>()
            ));

            Servicios.IoCContainer.RegistrarSingleton<BLL.UsuarioBLL>(() => new BLL.UsuarioBLL(
                Servicios.IoCContainer.Resolver<Abstracciones.IUsuarioDAL>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IPermisoDAL>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IDigitoVerificadorService>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IVersionUsuarioDAL>(),
                Servicios.IoCContainer.Resolver<Abstracciones.ISessionManager>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IBitacoraService>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IEncriptador>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IContadorSesion>()
            ));
            Servicios.IoCContainer.RegistrarSingleton<BLL.PermisoBLL>(() => new BLL.PermisoBLL(
                Servicios.IoCContainer.Resolver<Abstracciones.IPermisoDAL>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IBitacoraService>(),
                Servicios.IoCContainer.Resolver<Abstracciones.ISessionManager>()
            ));
            Servicios.IoCContainer.RegistrarSingleton<BLL.IdiomaBLL>(() => new BLL.IdiomaBLL(
                Servicios.IoCContainer.Resolver<Abstracciones.IIdiomaDAL>()
            ));
            Servicios.IoCContainer.RegistrarSingleton<BLL.TraduccionBLL>(() => new BLL.TraduccionBLL(
                Servicios.IoCContainer.Resolver<Abstracciones.ITraduccionDAL>()
            ));
            Servicios.IoCContainer.RegistrarSingleton<BLL.VersionUsuarioBLL>(() => new BLL.VersionUsuarioBLL(
                Servicios.IoCContainer.Resolver<Abstracciones.IVersionUsuarioDAL>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IUsuarioDAL>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IDigitoVerificadorService>(),
                Servicios.IoCContainer.Resolver<Abstracciones.IBitacoraService>()
            ));
        }
    }
}
