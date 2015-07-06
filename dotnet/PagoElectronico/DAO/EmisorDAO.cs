using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.DAO
{
    class EmisorDAO : GenericDAO
    {
        public List<Emisor> ObtenerEmisores()
        {
            const string queryString = "SELECT Emisor_Codigo, Emisor_Desc from NN.Emisores order by Emisor_Desc";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    List<Emisor> emisores = new List<Emisor>();
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Emisor emisor = new Emisor();
                        emisor.Id = int.Parse(reader[0].ToString());
                        emisor.Descripcion = reader[1].ToString();
                        emisores.Add(emisor);
                    }
                    reader.Close();
                    return emisores;
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
