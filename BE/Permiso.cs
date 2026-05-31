using System;
using System.Collections.Generic;

namespace BE
{
    public class Permiso : ComponentePermiso
    {
        private readonly List<ComponentePermiso> _hijos = new List<ComponentePermiso>();

        public override List<ComponentePermiso> Hijos
        {
            get { return _hijos; }
        }

        public override void Agregar(ComponentePermiso c)
        {
            throw new InvalidOperationException("No se pueden agregar hijos a un permiso.");
        }

        public override void Quitar(ComponentePermiso c)
        {
            throw new InvalidOperationException("No se pueden quitar hijos de un permiso.");
        }

        public override string NombreMostrar
        {
            get { return "🔑 " + Nombre; }
        }

        public override void ObtenerPermisos(List<Permiso> acumulador, HashSet<int> visitados)
        {
            if (visitados.Add(IdPermiso))
            {
                acumulador.Add(this);
            }
        }
    }
}
