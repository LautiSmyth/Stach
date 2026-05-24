using Aplicacion;
using System;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConexionServicio conexionServicio = new ConexionServicio();
            if (!conexionServicio.VerificarConexion())
            {
                MessageBox.Show(
                    "No se puede conectar a la base de datos. Contacte al administrador.",
                    "Error de conexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DigitoVerificadorServicio dvServicio = new DigitoVerificadorServicio();
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
    }
}