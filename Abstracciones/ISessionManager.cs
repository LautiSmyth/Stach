using BE;

namespace Abstracciones
{
    public interface ISessionManager
    {
        Usuario Usuario { get; }
        void Login(Usuario usuario);
        void Logout();
    }
}
