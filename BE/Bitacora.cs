using System;

namespace BE
{
    public class Bitacora
    {
        public int IdBitacora { get; set; }
        public int? IdUsuario { get; set; }
        public string Username { get; set; }
        public string Modulo { get; set; }
        public string Actividad { get; set; }
        public Enums.NivelCriticidad Criticidad { get; set; }
        public string Detalle { get; set; }
        public string Error { get; set; }
        public DateTime Fecha { get; set; }
        public bool Exitoso { get; set; }
    }
}