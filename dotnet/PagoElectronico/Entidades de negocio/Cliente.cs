using System;

namespace PagoElectronico.Entidades_de_negocio
{
    class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public long Documento { get; set; }
        public string Email { get; set; }
        public Pais Pais { get; set; }
        public string Calle { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Usuario Usuario { get; set; }
    }
}
