using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.DAO
{
    class UsuarioDAO : GenericDAO
    {
        public bool GuardarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "INSERT INTO NN.Usuario (Usu_Nombre, Usu_Password, Usu_Pregunta, Usu_Respuesta, Usu_Activo, Usu_Intentos) VALUES " +
                        "('" + usuario.Nombre + "', '" + EncriptarPassword(usuario.Password) + "', '" + usuario.Pregunta + "', '" + usuario.Respuesta + "', '" + usuario.Activo + "', " + usuario.Intentos + "); SELECT CAST(scope_identity() AS int);";
                    int idUsuario = (int)command.ExecuteScalar();
                    if (usuario.Roles != null)
                    {
                        foreach (Rol rol in usuario.Roles)
                        {
                            command.CommandText = "INSERT INTO NN.RolXUsuario (Usu_Id, Rol_Id) VALUES (" + idUsuario + ", " + rol.Id + ");";
                            command.ExecuteNonQuery();
                        }
                    }
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

        public Usuario ObtenerUsuario(int idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    string queryString = "SELECT Usu_Id, Usu_Nombre, Usu_Password, Usu_Pregunta, Usu_Respuesta, Usu_Intentos, Usu_Activo FROM NN.Usuario where Usu_Id = " + idUsuario;
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Usuario usuario = null;
                    if (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = int.Parse(reader[0].ToString());
                        usuario.Nombre = reader[1].ToString();
                        usuario.Password = reader[2].ToString();
                        usuario.Pregunta = reader[3].ToString();
                        usuario.Respuesta = reader[4].ToString();
                        usuario.Intentos = int.Parse(reader[5].ToString());
                        usuario.Activo = bool.Parse(reader[6].ToString());
                    }
                    reader.Close();

                    if (usuario != null)
                    {
                        queryString = "SELECT R.Rol_Id, Rol_Nombre FROM NN.RolXUsuario U, NN.Rol R where R.Rol_Id = U.Rol_Id and Usu_Id = " + usuario.Id;
                        command = new SqlCommand(queryString, connection);
                        List<Rol> roles = new List<Rol>();
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Rol rol = new Rol();
                            rol.Id = int.Parse(reader[0].ToString());
                            rol.Nombre = reader[1].ToString();
                            roles.Add(rol);
                        }
                        reader.Close();
                        usuario.Roles = roles;
                    }

                    return usuario;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    string queryString = "SELECT Usu_Id, Usu_Nombre, Usu_Password, Usu_Pregunta, Usu_Respuesta, Usu_Intentos, Usu_Activo FROM NN.Usuario where Usu_Nombre = '" + nombreUsuario + "'";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Usuario usuario = null;
                    if (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = int.Parse(reader[0].ToString());
                        usuario.Nombre = reader[1].ToString();
                        usuario.Password = reader[2].ToString();
                        usuario.Pregunta = reader[3].ToString();
                        usuario.Respuesta = reader[4].ToString();
                        usuario.Intentos = int.Parse(reader[5].ToString());
                        usuario.Activo = bool.Parse(reader[6].ToString());
                    }
                    reader.Close();

                    if (usuario != null)
                    {
                        queryString = "SELECT R.Rol_Id, Rol_Nombre FROM NN.RolXUsuario U, NN.Rol R where R.Rol_Id = U.Rol_Id and Usu_Id = " + usuario.Id;
                        command = new SqlCommand(queryString, connection);
                        List<Rol> roles = new List<Rol>();
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Rol rol = new Rol();
                            rol.Id = int.Parse(reader[0].ToString());
                            rol.Nombre = reader[1].ToString();
                            roles.Add(rol);
                        }
                        reader.Close();
                        usuario.Roles = roles;
                    }

                    return usuario;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public bool ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "UPDATE NN.Usuario SET Usu_Password = '" + usuario.Password + "', Usu_Intentos = " + usuario.Intentos + ", Usu_Activo = '" + usuario.Activo + "' WHERE Usu_Id = " + usuario.Id + ";";
                    command.ExecuteNonQuery();
                    command.CommandText = "DELETE FROM NN.RolXUsuario WHERE Usu_Id = " + usuario.Id + ";";
                    command.ExecuteNonQuery();
                    foreach (Rol rol in usuario.Roles)
                    {
                        command.CommandText = "INSERT INTO NN.RolXUsuario (Rol_Id, Usu_Id) VALUES (" + rol.Id + ", " + usuario.Id + ");";
                        command.ExecuteNonQuery();
                    }
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

        private static string EncriptarPassword(string password)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);
            HashAlgorithm hash = new SHA256Managed();
            byte[] hashBytes = hash.ComputeHash(plainTextBytes);
            string hashValue = Convert.ToBase64String(hashBytes);
            return hashValue;
        }

        internal List<Usuario> BuscarUsuarios(string queryNombre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    string queryString = "SELECT TOP 10 Usu_Id, Usu_Nombre, Usu_Activo FROM NN.Usuario where UPPER(Usu_Nombre) LIKE '" + queryNombre.ToUpper() + "%'";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Usuario> usuarios = new List<Usuario>();
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = int.Parse(reader[0].ToString());
                        usuario.Nombre = reader[1].ToString();
                        usuario.Activo = bool.Parse(reader[2].ToString());
                        usuarios.Add(usuario);
                    }
                    reader.Close();
                    return usuarios;
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
