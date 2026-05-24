using DAL;

namespace Aplicacion
{
    public class ConexionServicio
    {
        private readonly ConexionDAL _dal = new ConexionDAL();

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