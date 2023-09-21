using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    public class Provider
    {
        private static readonly string connectionString = "Data Source =MSI-GF75-10UEK;Database=db_mcc81;Connect Timeout=30;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static SqlCommand GetCommand()
        {
            return new SqlCommand();
        }

        public static SqlParameter SetParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }
    }
}
