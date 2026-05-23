using BE;
using BE.Enums;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class CriticidadDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public List<CriticidadConfig> ObtenerTodos()
        {
            List<CriticidadConfig> lista = new List<CriticidadConfig>();
            DataTable tabla = _acceso.Leer(
                "SELECT IdCriticidad, Nombre, ColorHex, Orden FROM Criticidad ORDER BY Orden", null);

            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new CriticidadConfig
                {
                    Nivel = (NivelCriticidad)Convert.ToInt32(fila["IdCriticidad"]),
                    Nombre = fila["Nombre"].ToString(),
                    ColorHex = fila["ColorHex"].ToString(),
                    Orden = Convert.ToInt32(fila["Orden"])
                });
            }
            return lista;
        }
    }
}