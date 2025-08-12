using System;
using System.Data.SqlClient;

public class StatusService
{
    public void CheckStatus(string username)
    {
        Console.Write("Enter Booking ID: ");
        int bookingId = int.Parse(Console.ReadLine());

        using (SqlConnection con = DatabaseHelper.GetConnection())
        {
            con.Open();

            string query = @"SELECT b.status, b.name, b.age, b.phone, b.email, b.seatposition, 
                             t.trainname, t.source, t.destination, b.journey_date
                             FROM booking b
                             JOIN train t ON b.trainid = t.trainid
                             WHERE b.bookingid = @id AND b.isdeleted = 0";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", bookingId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine("\nTicket Details:");
                        Console.WriteLine($"Name: {reader["name"]}, Age: {reader["age"]}");
                        Console.WriteLine($"Phone: {reader["phone"]}, Email: {reader["email"]}");
                        Console.WriteLine($"Seat Type: {reader["seatposition"]}");
                        Console.WriteLine($"Train: {reader["trainname"]}");
                        Console.WriteLine($"Route: {reader["source"]} to {reader["destination"]}");

                        if (reader["journey_date"] != DBNull.Value)
                        {
                            DateTime journeyDate = Convert.ToDateTime(reader["journey_date"]);
                            Console.WriteLine($"Date of Journey: {journeyDate.ToShortDateString()}");
                        }
                        else
                        {
                            Console.WriteLine("Date of Journey: Not available");
                        }

                        Console.WriteLine($"Booking Status: {reader["status"]}");
                    }
                    else
                    {
                        Console.WriteLine("No booking found for the given ID.");
                    }
                }
            }
        }
    }
}
