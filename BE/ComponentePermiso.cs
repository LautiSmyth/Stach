using System.Collections.Generic;

namespace BE
{
    public abstract class ComponentePermiso
    {
        public int IdPermiso { get; set; }
        public string Nombre { get; set; }
        public bool EsSistema { get; set; }
        public abstract List<ComponentePermiso> Hijos { get; }

        public abstract void Agregar(ComponentePermiso c);

        public abstract void Quitar(ComponentePermiso c);

        public abstract void ObtenerPermisos(List<Permiso> acumulador, HashSet<int> visitados);

        public abstract string NombreMostrar { get; }

        public override string ToString()
        {
            return NombreMostrar;
        }
    }
}