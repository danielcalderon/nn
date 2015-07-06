using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.DAO
{
    class TipoCuentaDAO : GenericDAO
    {
        public List<TipoCuenta> ObtenerTiposCuenta()
        {
            const string queryString = "SELECT tipo_de_cuenta_cod, tipo_de_cuenta_desc from NN.Tipo_de_Cuentas order by tipo_de_cuenta_dias";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    List<TipoCuenta> tiposCuenta = new List<TipoCuenta>();
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TipoCuenta tipoCuenta = new TipoCuenta();
                        tipoCuenta.Id = int.Parse(reader[0].ToString());
                        tipoCuenta.Nombre = reader[1].ToString();
                        tiposCuenta.Add(tipoCuenta);
                    }
                    reader.Close();
                    return tiposCuenta;
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
