using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.DAO
{
    class CuentaDAO : GenericDAO
    {
        public List<Cuenta> ObtenerCuentas()
        {
            const string queryString = "SELECT Cuenta_Id, Cli_Id, Cuenta_Numero, Cuenta_Fecha_Creacion, Cuenta_Pais_Codigo, Cuenta_Estado, Cuenta_Fecha_Cierre, " +
                    "tipo_de_cuenta_cod, Cuenta_Saldo from NN.Cuentas order by Cuenta_Numero";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    List<Cuenta> cuentas = new List<Cuenta>();
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cuenta cuenta = new Cuenta();
                        cuenta.Id = int.Parse(reader[0].ToString());
                        Cliente cliente = new Cliente();
                        cliente.Id = int.Parse(reader[1].ToString());
                        cuenta.Cliente = cliente;
                        cuenta.Numero = reader[2].ToString();
                        DateTime fechaCreacion;
                        DateTime.TryParse(reader[3].ToString(), out fechaCreacion);
                        cuenta.FechaCreacion = fechaCreacion;
                        Pais pais = new Pais();
                        pais.Id = int.Parse(reader[4].ToString());
                        cuenta.Pais = pais;
                        cuenta.Estado = char.Parse(reader[5].ToString());
                        DateTime fechaCierre;
                        DateTime.TryParse(reader[6].ToString(), out fechaCierre);
                        cuenta.FechaCierre = fechaCierre;
                        TipoCuenta tipoCuenta = new TipoCuenta();
                        tipoCuenta.Id = int.Parse(reader[7].ToString());
                        cuenta.TipoCuenta = tipoCuenta;
                        cuenta.Saldo = double.Parse(reader[8].ToString());
                        cuentas.Add(cuenta);
                    }
                    reader.Close();
                    return cuentas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public void GuardarCuenta(Cuenta cuenta)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "INSERT INTO NN.Cuentas (Cli_Id, Cuenta_Numero, Cuenta_Fecha_Creacion, Cuenta_Pais_Codigo, Cuenta_Estado, " +
                            "tipo_de_cuenta_cod, tipo_moneda_cod, Cuenta_Saldo) VALUES (" + cuenta.Cliente.Id + ", '" + cuenta.Numero + "', " + DateTimeToSql(cuenta.FechaCreacion) + ", " +
                            cuenta.Pais.Id + ", '" + cuenta.Estado + "', " + cuenta.TipoCuenta.Id + ", " + cuenta.TipoMoneda + ", " + cuenta.Saldo + ");";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public Cuenta ObtenerCuenta(string numero)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    string queryString = "SELECT Cuenta_Id FROM NN.Cuentas where Cuenta_Numero = " + numero;
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Cuenta cuenta = null;
                    if (reader.Read())
                    {
                        cuenta = new Cuenta();
                        cuenta.Id = int.Parse(reader[0].ToString());
                    }
                    reader.Close();
                    return cuenta;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
    }
}
