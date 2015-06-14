using System;
using System.Windows.Forms;

namespace PagoElectronico.DAO
{
    class GenericDAO
    {
        protected string ConnectionString = "Server=localhost\\SQLSERVER2008;Database=GD1C2015;User Id=gd;Password=gd2015;";

        protected static string DateTimeToSql(DateTime dateTime)
        {
            if (dateTime == DateTimePicker.MinDateTime)
            {
                return "NULL";
            }
            return "CONVERT(DATETIME, '" + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', 20)";
        }
    }
}
