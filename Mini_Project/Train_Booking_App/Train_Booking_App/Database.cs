using System.Data.SqlClient;

public static class DatabaseHelper
{
    public static string ConnectionString = "Data Source=ICS-LT-4C2BJ84\\SQLEXPRESS;Initial Catalog=assignments;User ID=sa;Password=Infinite@1234;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}
