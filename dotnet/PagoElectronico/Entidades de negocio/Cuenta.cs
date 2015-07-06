using System;

namespace PagoElectronico.Entidades_de_negocio
{
    class Cuenta
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public string Numero { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Pais Pais { get; set; }
        public char Estado { get; set; }
        public DateTime FechaCierre { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        public int TipoMoneda { get; set; }
        public double Saldo { get; set; }
    }
}
