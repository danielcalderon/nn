using System.Collections.Generic;

namespace PagoElectronico.Entidades_de_negocio
{
    class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public List<Rol> Roles { get; set; }
        public int Intentos { get; set; }
        public bool Activo { get; set; }
    }
}
