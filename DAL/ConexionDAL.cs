namespace DAL
{
    public class ConexionDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public bool VerificarConexion()
        {
            return _acceso.VerificarConexion();
        }

        public string ObtenerNombreBaseDatos()
        {
            return _acceso.ObtenerNombreBaseDatos();
        }
    }
}