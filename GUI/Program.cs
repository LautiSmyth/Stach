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