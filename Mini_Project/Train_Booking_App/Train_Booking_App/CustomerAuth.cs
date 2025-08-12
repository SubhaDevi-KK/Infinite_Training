using System;
using System.Data.SqlClient;

public class CustomerAuth
{
    public static bool Register()
    {
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();

        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        Console.Write("Confirm Password: ");
        string confirm = Console.ReadLine();

        if (password != confirm)
        {
            Console.WriteLine("Passwords do not match.");
            return false;
        }

        using (SqlConnection con = DatabaseHelper.GetConnection())
        {
            con.Open();

            string checkQuery = "SELECT COUNT(*) FROM customer_login WHERE username = @user";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
            {
                checkCmd.Parameters.AddWithValue("@user", username);
                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    Console.WriteLine("Username already exists.");
                    return false;
                }
            }

            string insertQuery = "INSERT INTO customer_login (username, password) VALUES (@user, @pass)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, con))
            {
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Registered successfully.");
            return true;
        }
    }

    public static bool Login(string username,string password)
    {
       

        using (SqlConnection con = DatabaseHelper.GetConnection())
        {
            con.Open();

            string query = "SELECT COUNT(*) FROM customer_login WHERE username = @user AND password = @pass";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);
                int match = (int)cmd.ExecuteScalar();

                if (match > 0)
                {
                    Console.WriteLine("Login successful.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid credentials.");
                    return false;
                }
            }
        }
    }
}

