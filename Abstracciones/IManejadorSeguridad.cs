using System.Windows.Forms;
using BE;

namespace Abstracciones
{
    public interface IManejadorSeguridad
    {
        void ActualizarSeguridadFormulariosAbiertos(Usuario usuario);
        void AplicarSeguridad(Form formulario, Usuario usuario);
    }
}
