using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.DAO
{
    class ClienteDAO : GenericDAO
    {
        public List<Cliente> ObtenerClientes()
        {
            const string queryString = "SELECT Cli_Tipo_Doc_Cod, Tipo_Doc_Desc, Cli_Nro_Doc, Cli_Nombre, Cli_Apellido, Cli_Usuario, Usu_Nombre, Cli_Mail from " +
                    "Clientes C left join Usuario U on C.Cli_Usuario = U.Usu_Id join Documentos D on C.Cli_Tipo_Doc_Cod = D.Tipo_Doc_Cod";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    List<Cliente> clientes = new List<Cliente>();
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        TipoDocumento tipoDocumento = new TipoDocumento();
                        tipoDocumento.Id = int.Parse(reader[0].ToString());
                        tipoDocumento.Nombre = reader[1].ToString();
                        cliente.TipoDocumento = tipoDocumento;
                        cliente.Documento = long.Parse(reader[2].ToString());
                        cliente.Nombre = reader[3].ToString();
                        cliente.Apellido = reader[4].ToString();
                        if (reader[5].ToString().Length > 0)
                        {
                            Usuario usuario = new Usuario();
                            usuario.Id = int.Parse(reader[5].ToString());
                            usuario.Nombre = reader[6].ToString();
                            cliente.Usuario = usuario;
                        }
                        cliente.Email = reader[7].ToString();
                        clientes.Add(cliente);
                    }
                    reader.Close();
                    return clientes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public bool GuardarCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "INSERT INTO Clientes (Cli_Pais_Codigo, Cli_Nombre, Cli_Apellido, Cli_Tipo_Doc_Cod, Cli_Nro_Doc, Cli_Dom_Calle, " +
                        "Cli_Dom_Piso, Cli_Dom_Depto, Cli_Fecha_Nac, Cli_Mail, Cli_Usuario, Cli_Localidad, Cli_Nacionalidad) VALUES " +
                        "(" + cliente.Pais.Id + ", '" + cliente.Nombre + "', '" + cliente.Apellido + "', " + cliente.TipoDocumento.Id + ", " + cliente.Documento +", " +
                        "'" + cliente.Calle + "', " + cliente.Piso + ", '" + cliente.Departamento + "', " + DateTimeToSql(cliente.FechaNacimiento) + ", " +
                        "'" + cliente.Email + "', " + cliente.Usuario.Id + ", '" + cliente.Localidad + "', '" + cliente.Nacionalidad + "');";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public Cliente ObtenerCliente(int tipoDocumento, long documento)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    string queryString = "SELECT Cli_Nro_Doc FROM Clientes where Cli_Tipo_Doc_Cod = " + tipoDocumento + " AND Cli_Nro_Doc = " + documento;
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Cliente cliente = null;
                    if (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.Documento = long.Parse(reader[0].ToString());
                    }
                    reader.Close();
                    return cliente;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public Cliente ObtenerCliente(string email)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    string queryString = "SELECT Cli_Nro_Doc FROM Clientes where Cli_Mail = '" + email + "'";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Cliente cliente = null;
                    if (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.Documento = long.Parse(reader[0].ToString());
                    }
                    reader.Close();
                    return cliente;
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
