using Home_Business_Managing_App.Entitas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing_App.Entitas
{
    public static class Helper
    {
        private static ProdukContext produkDBContext;
        private static SqlConnection connection;
        private static string connStr;

        public static ProdukContext AksesTabel()
        {
            if (produkDBContext == null)
                produkDBContext = new ProdukContext();

            return produkDBContext;
        }

        public static void SetConnectionString(string connectionString)
        {
            connStr = connectionString;
        }

        public static SqlConnection GetSqlConnection()
        {
            if (connection == null)
                connection = new SqlConnection(connStr);

            return connection;
        }

        public static SqlConnection GetSqlConnection(string connectionString)
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
