using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.DAO
{
    class PaisDAO : GenericDAO
    {
        public List<Pais> BuscarPaises(string queryNombre)
        {
            string queryString = "SELECT TOP 10 Pais_Codigo, Pais_Desc FROM NN.Paises where UPPER(Pais_Desc) LIKE '" + queryNombre.ToUpper() + "%' order by Pais_Desc";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    List<Pais> paises = new List<Pais>();
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Pais pais = new Pais();
                        pais.Id = int.Parse(reader[0].ToString());
                        pais.Nombre = reader[1].ToString();
                        paises.Add(pais);
                    }
                    reader.Close();
                    return paises;
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
