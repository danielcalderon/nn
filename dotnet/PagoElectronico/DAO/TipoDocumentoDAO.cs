using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.DAO
{
    class TipoDocumentoDAO : GenericDAO
    {
        public List<TipoDocumento> ObtenerDocumentos()
        {
            const string queryString = "SELECT Tipo_Doc_Cod, Tipo_Doc_Desc from Documentos";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    List<TipoDocumento> documentos = new List<TipoDocumento>();
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TipoDocumento documento = new TipoDocumento();
                        documento.Id = int.Parse(reader[0].ToString());
                        documento.Nombre = reader[1].ToString();
                        documentos.Add(documento);
                    }
                    reader.Close();
                    return documentos;
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
