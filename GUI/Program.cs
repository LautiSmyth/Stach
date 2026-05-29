using System;
using System.Configuration;
using System.Windows.Forms;
using Abstracciones;
using IoC;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Bootstrapper.RegistrarDependencias();

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationElement setting = config.AppSettings.Settings["MasterRecoveryKeyHash"];
            if (setting == null || string.IsNullOrEmpty(setting.Value))
            {
                string recoveryKey = $"STACH-RECOVERY-{Guid.NewGuid().ToString("N").Substring(0, 4).ToUpper()}-{Guid.NewGuid().ToString("N").Substring(4, 4).ToUpper()}";
                IEncriptador encriptador = IoCContainer.Resolver<IEncriptador>();
                string hash = encriptador.Hash(recoveryKey);
                if (setting == null)
                {
                    config.AppSettings.Settings.Add("MasterRecoveryKeyHash", hash);
                }
                else
                {
                    setting.Value = hash;
                }
                ConfigurationSection section = config.GetSection("appSettings");
                if (section != null && !section.SectionInformation.IsProtected)
                {
                    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                MessageBox.Show(
                    $"Clave de Recuperación Maestra generada. Guarde esta clave en un lugar seguro (no se volverá a mostrar):\n\n{recoveryKey}",
                    "Clave de Recuperación Maestra",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            Application.ThreadException += (sender, args) => ManejarExcepcionGlobal(args.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => ManejarExcepcionGlobal(args.ExceptionObject as Exception);

            IConexionService conexionService = IoCContainer.Resolver<IConexionService>();
            if (!conexionService.VerificarConexion())
            {
                MessageBox.Show(
                    "No se puede conectar a la base de datos. Contacte al administrador.",
                    "Error de conexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            IDigitoVerificadorService dvServicio = IoCContainer.Resolver<IDigitoVerificadorService>();
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
                IBitacoraService bitacora = IoCContainer.Resolver<IBitacoraService>();
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