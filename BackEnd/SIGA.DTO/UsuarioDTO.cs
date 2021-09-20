using System;

namespace SIGA.DTO
{
    public class UsuarioDTO
    {
        public string NomUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string NroDocumento { get; set; }
        public string Puesto { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string TipoUsuario { get; set; }
        public string CodigoPersonal { get; set; }
        public string Estado { get; set; }
        public string Token { get; set; }
    }
}
