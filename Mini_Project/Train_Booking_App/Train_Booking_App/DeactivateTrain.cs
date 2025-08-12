using System;
using System.Data.SqlClient;

public class DeactivateTrain
{
    public static void Deactivate()
    {
        try
        {
            Console.Write("Enter Train ID to deactivate: ");
            if (!int.TryParse(Console.ReadLine(), out int trainId))
            {
                Console.WriteLine("Invalid Train ID format.");
                return;
            }

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                con.Open();

                string checkBookings = @"SELECT COUNT(*) FROM booking 
                                         WHERE trainid = @id AND status != 'Cancelled' AND isdeleted = 0";

                using (SqlCommand checkCmd = new SqlCommand(checkBookings, con))
                {
                    checkCmd.Parameters.AddWithValue("@id", trainId);
                    int activeBookings = (int)checkCmd.ExecuteScalar();

                    if (activeBookings > 0)
                    {
                        Console.WriteLine("Cannot deactivate. Passengers are already booked on this train.");
                        return;
                    }
                }

                string query = "UPDATE train SET isdeleted = 1 WHERE trainid = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", trainId);
                    int rows = cmd.ExecuteNonQuery();

                    Console.WriteLine(rows > 0 ? "Train deactivated successfully." : "Train ID not found or already deactivated.");
                }
            }
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine("SQL Error: " + sqlEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }
}

