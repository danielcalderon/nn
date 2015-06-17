using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PagoElectronico.DAO
{
    class LoginDAO : GenericDAO
    {
        public bool GuardarLogin(string usuario, bool loginExitoso, int intentos, bool usuarioActivo)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "INSERT INTO NN.Login (Login_Usuario, Login_Fecha, Login_exitoso, Login_Intentos, Login_UsuarioActivo) VALUES " +
                        "('" + usuario + "', " + DateTimeToSql(DateTime.Now) + ", '" + loginExitoso + "', " + intentos + ", '" + usuarioActivo + "');";
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
    }
}
