using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.DAO
{
    class TarjetaDAO : GenericDAO
    {
        public List<Tarjeta> ObtenerTarjetas(int idCliente)
        {
            string queryString = "SELECT Tarjeta_Id, Cli_Id, Tarjeta_Numero, Tarjeta_Codigo_Seg, Tarjeta_Emisor_Codigo, Emisor_Desc, Tarjeta_Fecha_Emision, Tarjeta_Fecha_Vencimiento, "
                + "Tarjeta_Activo from NN.Tarjetas T join NN.Emisores E on E.Emisor_Codigo = T.Tarjeta_Emisor_Codigo where Cli_Id = " + idCliente;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    List<Tarjeta> tarjetas = new List<Tarjeta>();
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Tarjeta tarjeta = new Tarjeta();
                        tarjeta.Id = int.Parse(reader[0].ToString());
                        Cliente cliente = new Cliente();
                        cliente.Id = int.Parse(reader[1].ToString());
                        tarjeta.Cliente = cliente;
                        tarjeta.Numero = reader[2].ToString();
                        tarjeta.Codigo = int.Parse(reader[3].ToString());
                        Emisor emisor = new Emisor();
                        emisor.Id = int.Parse(reader[4].ToString());
                        emisor.Descripcion = reader[5].ToString();
                        tarjeta.Emisor = emisor;
                        DateTime fechaEmision;
                        DateTime.TryParse(reader[6].ToString(), out fechaEmision);
                        tarjeta.FechaEmision = fechaEmision;
                        DateTime fechaVencimiento;
                        DateTime.TryParse(reader[7].ToString(), out fechaVencimiento);
                        tarjeta.FechaVencimiento = fechaVencimiento;
                        tarjeta.Activo = bool.Parse(reader[8].ToString());
                        tarjetas.Add(tarjeta);
                    }
                    reader.Close();
                    return tarjetas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public Tarjeta ObtenerTarjeta(int idTarjeta)
        {
            string queryString = "SELECT Tarjeta_Id, Tarjeta_Numero, Tarjeta_Codigo_Seg, Tarjeta_Emisor_Codigo, Tarjeta_Fecha_Vencimiento, "
                    + "Tarjeta_Activo from NN.Tarjetas where Tarjeta_Id = " + idTarjeta;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    Tarjeta tarjeta = null;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        tarjeta = new Tarjeta();
                        tarjeta.Id = int.Parse(reader[0].ToString());
                        tarjeta.Numero = reader[1].ToString();
                        tarjeta.Codigo = int.Parse(reader[2].ToString());
                        Emisor emisor = new Emisor();
                        emisor.Id = int.Parse(reader[3].ToString());
                        tarjeta.Emisor = emisor;
                        DateTime fechaVencimiento;
                        DateTime.TryParse(reader[4].ToString(), out fechaVencimiento);
                        tarjeta.FechaVencimiento = fechaVencimiento;
                        tarjeta.Activo = bool.Parse(reader[5].ToString());
                    }
                    reader.Close();
                    return tarjeta;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public Tarjeta ObtenerTarjeta(string numeroTarjeta)
        {
            string queryString = "SELECT Tarjeta_Id from NN.Tarjetas where Tarjeta_Numero = '" + numeroTarjeta + "'";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    Tarjeta tarjeta = null;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        tarjeta = new Tarjeta();
                        tarjeta.Id = int.Parse(reader[0].ToString());
                    }
                    reader.Close();
                    return tarjeta;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public void GuardarTarjeta(Tarjeta tarjeta)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "INSERT INTO NN.Tarjetas (Cli_Id, Tarjeta_Numero, Tarjeta_Codigo_Seg, Tarjeta_Emisor_Codigo, Tarjeta_Fecha_Emision, Tarjeta_Fecha_Vencimiento, " +
                        "Tarjeta_Activo) VALUES (" + tarjeta.Cliente.Id + ", '" + tarjeta.Numero + "', " + tarjeta.Codigo + ", " + tarjeta.Emisor.Id + ", " +
                        DateTimeToSql(tarjeta.FechaEmision) + ", " + DateTimeToSql(tarjeta.FechaVencimiento) + ", '" + tarjeta.Activo + "');";
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

        public void ModificarTarjeta(Tarjeta tarjeta)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "UPDATE NN.Tarjetas SET Tarjeta_Codigo_Seg = " + tarjeta.Codigo + ", Tarjeta_Emisor_Codigo = " + tarjeta.Emisor.Id + ", " +
                        "Tarjeta_Fecha_Vencimiento = " + DateTimeToSql(tarjeta.FechaVencimiento) + ", Tarjeta_Activo = '" + tarjeta.Activo + "' " +
                        "WHERE Tarjeta_Id = " + tarjeta.Id;
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
    }
}
