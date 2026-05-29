using BE;
using System.Collections.Generic;

namespace Abstracciones
{
    public interface IPermisoDAL
    {
        List<ComponentePermiso> ObtenerTodos();
        void Insertar(ComponentePermiso permiso);
        bool EstaEnUso(int idPermiso);
        void Eliminar(int idPermiso);
        void GuardarRelaciones(Familia familia);
        List<ComponentePermiso> ObtenerPermisosUsuario(int idUsuario);
        void GuardarPermisosUsuario(int idUsuario, List<ComponentePermiso> permisos);
    }
}
