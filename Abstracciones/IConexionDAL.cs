namespace Abstracciones
{
    public interface IConexionDAL
    {
        bool VerificarConexion();
        string ObtenerNombreBaseDatos();
    }
}
