using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class BitacoraBLL
    {
        private readonly BitacoraDAL _dal = new BitacoraDAL();

        public List<Bitacora> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        public void Insertar(Bitacora bitacora)
        {
            _dal.Insertar(bitacora);
        }
    }
}
