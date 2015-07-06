using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.DAO
{
    class ClienteDAO : GenericDAO
    {
        public List<Cliente> ObtenerClientes(string nombre, string apellido, int idTipoDocumento, string documento, string email)
        {
            string queryString = "SELECT Cli_Id, Cli_Tipo_Doc_Cod, Tipo_Doc_Desc, Cli_Nro_Doc, Cli_Nombre, Cli_Apellido, Cli_Usuario, Usu_Nombre, Cli_Mail from " +
                    "NN.Clientes C left join NN.Usuario U on C.Cli_Usuario = U.Usu_Id join NN.Documentos D on C.Cli_Tipo_Doc_Cod = D.Tipo_Doc_Cod " +
                    "WHERE UPPER(Cli_Nombre) LIKE '%" + nombre.ToUpper() + "%' " +
                    "AND UPPER(Cli_Apellido) LIKE '%" + apellido.ToUpper() + "%' " +
                    (idTipoDocumento != 0 ? "AND Cli_Tipo_Doc_Cod = " + idTipoDocumento + " " : "") +
                    "AND UPPER(Cli_Nro_Doc) LIKE '%" + documento.ToUpper() + "%' " +
                    "AND UPPER(Cli_Mail) LIKE '%" + email.ToUpper() + "%'";
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
                        cliente.Id = int.Parse(reader[0].ToString());
                        TipoDocumento tipoDocumento = new TipoDocumento();
                        tipoDocumento.Id = int.Parse(reader[1].ToString());
                        tipoDocumento.Nombre = reader[2].ToString();
                        cliente.TipoDocumento = tipoDocumento;
                        cliente.Documento = long.Parse(reader[3].ToString());
                        cliente.Nombre = reader[4].ToString();
                        cliente.Apellido = reader[5].ToString();
                        if (reader[6].ToString().Length > 0)
                        {
                            Usuario usuario = new Usuario();
                            usuario.Id = int.Parse(reader[6].ToString());
                            usuario.Nombre = reader[7].ToString();
                            cliente.Usuario = usuario;
                        }
                        cliente.Email = reader[8].ToString();
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
                    command.CommandText = "INSERT INTO NN.Clientes (Cli_Pais_Codigo, Cli_Nombre, Cli_Apellido, Cli_Tipo_Doc_Cod, Cli_Nro_Doc, Cli_Dom_Calle, " +
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

        public void ModificarCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "UPDATE NN.Clientes SET Cli_Pais_Codigo = " + cliente.Pais.Id + ", Cli_Nombre = '" + cliente.Nombre + "', " +
                        "Cli_Apellido = '" + cliente.Apellido + "', Cli_Tipo_Doc_Cod = " + cliente.TipoDocumento.Id + ", Cli_Nro_Doc = " + cliente.Documento + ", " +
                        "Cli_Dom_Calle = '" + cliente.Calle + "', Cli_Dom_Piso = " + cliente.Piso + ", Cli_Dom_Depto = '" + cliente.Departamento + "', " +
                        "Cli_Fecha_Nac = " + DateTimeToSql(cliente.FechaNacimiento) + ", Cli_Mail = '" + cliente.Email + "', Cli_Usuario = " + cliente.Usuario.Id + ", " +
                        "Cli_Localidad = '" + cliente.Localidad + "', Cli_Nacionalidad = '" + cliente.Nacionalidad + "', Cli_Activo = '" + cliente.Activo + "' " +
                        "WHERE Cli_Id = " + cliente.Id;
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

        public Cliente ObtenerCliente(int idCliente)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    string queryString = "SELECT Cli_Id, Cli_Pais_Codigo, Pais_desc, Cli_Nombre, Cli_Apellido, Cli_Tipo_Doc_Cod, Cli_Nro_Doc, Cli_Dom_Calle, Cli_Dom_Piso, Cli_Dom_Depto" +
                        ", Cli_Fecha_Nac, Cli_Mail, Cli_Usuario, Cli_Localidad, Cli_Nacionalidad, Cli_Activo FROM NN.Clientes C, NN.Paises P where C.Cli_Pais_Codigo = P.Pais_codigo and Cli_Id = " + idCliente;
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Cliente cliente = null;
                    if (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.Id = int.Parse(reader[0].ToString());
                        Pais pais = new Pais();
                        pais.Id = int.Parse(reader[1].ToString());
                        pais.Nombre = reader[2].ToString();
                        cliente.Pais = pais;
                        cliente.Nombre = reader[3].ToString();
                        cliente.Apellido = reader[4].ToString();
                        TipoDocumento tipoDocumento = new TipoDocumento();
                        tipoDocumento.Id = int.Parse(reader[5].ToString());
                        cliente.TipoDocumento = tipoDocumento;
                        cliente.Documento = long.Parse(reader[6].ToString());
                        cliente.Calle = reader[7].ToString();
                        cliente.Piso = reader[8].ToString();
                        cliente.Departamento = reader[9].ToString();
                        DateTime fechaNacimiento;
                        DateTime.TryParse(reader[10].ToString(), out fechaNacimiento);
                        cliente.FechaNacimiento = fechaNacimiento;
                        cliente.Email = reader[11].ToString();
                        Usuario usuario = new Usuario();
                        usuario.Id = int.Parse(reader[12].ToString());
                        cliente.Usuario = usuario;
                        cliente.Localidad = reader[13].ToString();
                        cliente.Nacionalidad = reader[14].ToString();
                        cliente.Activo = bool.Parse(reader[15].ToString());
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

        public Cliente ObtenerCliente(int tipoDocumento, long documento)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    string queryString = "SELECT Cli_Id FROM NN.Clientes where Cli_Tipo_Doc_Cod = " + tipoDocumento + " AND Cli_Nro_Doc = " + documento;
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Cliente cliente = null;
                    if (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.Id = int.Parse(reader[0].ToString());
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
                    string queryString = "SELECT Cli_Id FROM NN.Clientes where Cli_Mail = '" + email + "'";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Cliente cliente = null;
                    if (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.Id = int.Parse(reader[0].ToString());
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

        public Cliente ObtenerCliente(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    string queryString = "SELECT Cli_Id FROM NN.Clientes where Cli_Nombre = '" + usuario.Nombre + "'";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Cliente cliente = null;
                    if (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.Id = int.Parse(reader[0].ToString());
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

        public List<Cliente> BuscarClientes(string queryDocumento)
        {
            string queryString = "SELECT TOP 10 Cli_Id, Cli_Nro_Doc FROM NN.Clientes where Cli_Nro_Doc LIKE '" + queryDocumento + "%' order by Cli_Nro_Doc";
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
                        cliente.Id = int.Parse(reader[0].ToString());
                        cliente.Documento = int.Parse(reader[1].ToString());
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
    }
}
