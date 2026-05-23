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

            Application.Run(new LoginForm());
        }
    }
}
