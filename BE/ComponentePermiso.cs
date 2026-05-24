using System.Collections.Generic;

namespace BE
{
    public abstract class ComponentePermiso
    {
        public int IdPermiso { get; set; }
        public string Nombre { get; set; }
        public string PermisoKey { get; set; }
        public abstract List<ComponentePermiso> Hijos { get; }

        public abstract void Agregar(ComponentePermiso c);

        public abstract void Quitar(ComponentePermiso c);

        public string NombreMostrar
        {
            get { return (this is Familia ? "📁 " : "🔑 ") + Nombre; }
        }

        public override string ToString()
        {
            return NombreMostrar;
        }
    }
}