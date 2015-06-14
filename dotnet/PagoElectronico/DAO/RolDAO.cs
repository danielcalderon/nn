using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.DAO
{
    class RolDAO : GenericDAO
    {
        public List<Rol> ObtenerRoles()
        {
            const string queryString = "SELECT Rol_Id, Rol_Nombre, Rol_Activo from Rol";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    List<Rol> roles = new List<Rol>();
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Rol rol = new Rol();
                        rol.Id = int.Parse(reader[0].ToString());
                        rol.Nombre = reader[1].ToString();
                        rol.Activo = bool.Parse(reader[2].ToString());
                        roles.Add(rol);
                    }
                    reader.Close();
                    return roles;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public Rol ObtenerRol(int idRol)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    string queryString = "SELECT Rol_Id, Rol_Nombre, Rol_Activo FROM Rol where Rol_Id = " + idRol;
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Rol rol = null;
                    if (reader.Read())
                    {
                        rol = new Rol();
                        rol.Id = int.Parse(reader[0].ToString());
                        rol.Nombre = reader[1].ToString();
                        rol.Activo = bool.Parse(reader[2].ToString());
                    }
                    reader.Close();

                    if(rol != null)
                    {
                        queryString = "SELECT F.Func_Id, Func_Nombre FROM FuncionalidadXRol R, Funcionalidad F where F.Func_Id = R.Func_Id and Rol_Id = " + idRol;
                        command = new SqlCommand(queryString, connection);
                        List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Funcionalidad funcionalidad = new Funcionalidad();
                            funcionalidad.Id = int.Parse(reader[0].ToString());
                            funcionalidad.Nombre = reader[1].ToString();
                            funcionalidades.Add(funcionalidad);
                        }
                        reader.Close();
                        rol.Funcionalidades = funcionalidades;
                    }

                    return rol;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public bool GuardarRol(Rol rol)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "INSERT INTO Rol (Rol_Nombre, Rol_Activo) VALUES ('" + rol.Nombre + "', '" + rol.Activo + "'); SELECT CAST(scope_identity() AS int);";
                    int idRol = (int)command.ExecuteScalar();
                    foreach (Funcionalidad funcionalidad in rol.Funcionalidades)
                    {
                        command.CommandText = "INSERT INTO FuncionalidadXRol (Func_Id, Rol_Id) VALUES (" + funcionalidad.Id + ", " + idRol + ");";
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

        public bool ModificarRol(Rol rol)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "UPDATE Rol SET Rol_Nombre = '" + rol.Nombre + "', Rol_Activo = '" + rol.Activo + "' WHERE Rol_Id = " + rol.Id + ";";
                    command.ExecuteNonQuery();
                    command.CommandText = "DELETE FROM FuncionalidadXRol WHERE Rol_Id = " + rol.Id + ";";
                    command.ExecuteNonQuery();
                    foreach (Funcionalidad funcionalidad in rol.Funcionalidades)
                    {
                        command.CommandText = "INSERT INTO FuncionalidadXRol (Func_Id, Rol_Id) VALUES (" + funcionalidad.Id + ", " + rol.Id + ");";
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
    }
}
