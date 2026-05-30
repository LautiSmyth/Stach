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
    }
}