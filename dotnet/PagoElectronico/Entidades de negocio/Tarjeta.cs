using System;

namespace PagoElectronico.Entidades_de_negocio
{
    class Tarjeta
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public string Numero { get; set; }
        public int Codigo { get; set; }
        public Emisor Emisor { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Activo { get; set; }
    }
}
