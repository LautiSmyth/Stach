using Abstracciones;

namespace Servicios
{
    public class ConexionService : IConexionService
    {
        private readonly IConexionDAL _dal;

        public ConexionService(IConexionDAL dal)
        {
            _dal = dal;
        }

        public bool VerificarConexion()
        {
            return _dal.VerificarConexion();
        }

        public string ObtenerNombreBaseDatos()
        {
            return _dal.ObtenerNombreBaseDatos();
        }
    }
}
