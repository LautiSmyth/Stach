namespace Abstracciones
{
    public interface IContadorSesion
    {
        bool LimiteAlcanzado { get; }
        void RegistrarIntento();
        void Resetear();
    }
}
