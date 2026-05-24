using System;

namespace BE
{
    public class VersionUsuario
    {
        public int IdVersion { get; set; }
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public Enums.EstadoUsuario Estado { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string DetalleCambios { get; set; }
    }
}
