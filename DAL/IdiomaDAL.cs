using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class IdiomaDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public List<Idioma> ObtenerTodos()
        {
            var dt = _acceso.Leer("SELECT IdIdioma, Nombre, Codigo, [Default] FROM Idioma", null);
            var lista = new List<Idioma>();
            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new Idioma
                {
                    IdIdioma = Convert.ToInt32(r["IdIdioma"]),
                    Nombre = r["Nombre"].ToString(),
                    Codigo = r["Codigo"].ToString(),
                    Default = Convert.ToBoolean(r["Default"])
                });
            }
            return lista;
        }

        public void Insertar(Idioma idioma)
        {
            if (idioma == null) throw new ArgumentNullException(nameof(idioma));

            if (idioma.Default)
            {
                _acceso.Escribir("UPDATE Idioma SET [Default] = 0", null);
            }

            var p = new SqlParameter[]
            {
                new SqlParameter("@Nombre", idioma.Nombre),
                new SqlParameter("@Codigo", idioma.Codigo),
                new SqlParameter("@Default", idioma.Default)
            };
            _acceso.Escribir("INSERT INTO Idioma (Nombre, Codigo, [Default]) VALUES (@Nombre, @Codigo, @Default)", p);
        }

        public void Eliminar(int idIdioma)
        {
            var p = new SqlParameter[] { new SqlParameter("@IdIdioma", idIdioma) };
            _acceso.Escribir("DELETE FROM Idioma WHERE IdIdioma = @IdIdioma", p);
        }
    }
}
