using BE;
using BE.Repositorios;
using DAL;

namespace BLL
{
    public class CriticidadBLL
    {
        private readonly ICriticidadRepositorio _repositorio = new CriticidadDAL();

        public void Recargar()
        {
            CriticidadMapper.Recargar(_repositorio);
        }
    }
}
