using System;
using System.Data.SqlClient;
using System.Configuration;

namespace ElectricityProject
{
    public class DBHandler
    {
        public static string ConnectionString = "Data Source=ICS-LT-4C2BJ84\\SQLEXPRESS;Initial Catalog=ElectricityBillDB;User ID=sa;Password=Infinite@1234;";
        public static SqlConnection GetConnection()
        {
            
            return new SqlConnection(ConnectionString);
        }
    }
}
