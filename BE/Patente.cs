using System;
using System.Collections.Generic;

namespace BE
{
    public class Patente : ComponentePermiso
    {
        private readonly List<ComponentePermiso> _hijos = new List<ComponentePermiso>();

        public override List<ComponentePermiso> Hijos
        {
            get { return _hijos; }
        }

        public override void Agregar(ComponentePermiso c)
        {
            throw new InvalidOperationException("No se pueden agregar hijos a una patente.");
        }

        public override void Quitar(ComponentePermiso c)
        {
            throw new InvalidOperationException("No se pueden quitar hijos de una patente.");
        }

        public override string NombreMostrar
        {
            get { return "🔑 " + Nombre; }
        }

        public override void ObtenerPatentes(List<Patente> acumulador, HashSet<int> visitados)
        {
            if (visitados.Add(IdPermiso))
            {
                acumulador.Add(this);
            }
        }
    }
}