using System.Collections.Generic;

namespace PagoElectronico.Entidades_de_negocio
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Funcionalidad> Funcionalidades { get; set; }
        public bool Activo { get; set; }
    }
}
