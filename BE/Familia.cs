using System.Collections.Generic;

namespace BE
{
    public class Familia : ComponentePermiso
    {
        private readonly List<ComponentePermiso> _hijos = new List<ComponentePermiso>();

        public override List<ComponentePermiso> Hijos
        {
            get { return _hijos; }
        }

        public override void Agregar(ComponentePermiso c)
        {
            if (!_hijos.Contains(c))
            {
                _hijos.Add(c);
            }
        }

        public override void Quitar(ComponentePermiso c)
        {
            if (_hijos.Contains(c))
            {
                _hijos.Remove(c);
            }
        }

        public override string NombreMostrar
        {
            get { return "📁 " + Nombre; }
        }

        public override void ObtenerPatentes(List<Patente> acumulador, HashSet<int> visitados)
        {
            if (visitados.Add(IdPermiso))
            {
                foreach (ComponentePermiso hijo in Hijos)
                {
                    hijo.ObtenerPatentes(acumulador, visitados);
                }
            }
        }
    }
}