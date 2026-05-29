namespace Abstracciones
{
    public interface IEncriptador
    {
        string Hash(string contraseña);
        bool Verificar(string contraseñaIngresada, string hashAlmacenado);
        string HashSHA256(string input);
    }
}
