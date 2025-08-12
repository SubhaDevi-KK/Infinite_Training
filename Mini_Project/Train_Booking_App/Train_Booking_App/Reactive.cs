using System;
using System.Data.SqlClient;

public class ReactivateTrain
{
    public static void Reactivate()
    {
        Console.Write("Enter Train ID to reactivate: ");
        int trainId;
        if (!int.TryParse(Console.ReadLine(), out trainId))
        {
            Console.WriteLine("Invalid Train ID format.");
            return;
        }

        using (SqlConnection con = DatabaseHelper.GetConnection())
        {
            con.Open();
            string query = "UPDATE train SET isdeleted = 0 WHERE trainid = @id";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", trainId);
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows > 0 ? "Train reactivated successfully." : "Train ID not found or already active.");
            }
        }
    }
}

