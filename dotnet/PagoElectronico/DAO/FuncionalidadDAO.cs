using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.DAO
{
    class FuncionalidadDAO : GenericDAO
    {
        public List<Funcionalidad> ObtenerFuncionalidades()
        {
            const string queryString = "SELECT Func_Id, Func_Nombre from NN.Funcionalidad";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Funcionalidad funcionalidad = new Funcionalidad();
                        funcionalidad.Id = int.Parse(reader[0].ToString());
                        funcionalidad.Nombre = reader[1].ToString();
                        funcionalidades.Add(funcionalidad);
                    }
                    reader.Close();
                    return funcionalidades;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
    }
}
