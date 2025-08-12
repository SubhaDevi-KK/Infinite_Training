using System;
using System.Data.SqlClient;

public class BookingViewer
{
    public static void ShowCancelledBookings()
    {
        using (SqlConnection con = DatabaseHelper.GetConnection())
        {
            con.Open();

            string query = @"SELECT b.name, b.age, b.phone, b.email, b.aadhar, b.seatposition, b.status,
                                    t.trainname, t.source, t.destination
                             FROM booking b
                             JOIN train t ON b.trainid = t.trainid
                             WHERE b.status = 'Cancelled'";

            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("\nCancelled Bookings:");

                if (!reader.HasRows)
                {
                    Console.WriteLine("No cancelled bookings found.");
                    return;
                }

                int count = 0;
                while (reader.Read())
                {
                    count++;
                    Console.WriteLine($"\nPassenger {count}:");
                    Console.WriteLine($"Name: {reader["name"]}, Age: {reader["age"]}");
                    Console.WriteLine($"Phone: {reader["phone"]}, Email: {reader["email"]}");
                    Console.WriteLine($"Aadhar: {reader["aadhar"]}");
                    Console.WriteLine($"Seat Type: {reader["seatposition"]}, Status: {reader["status"]}");
                    Console.WriteLine($"Train: {reader["trainname"]} | Route: {reader["source"]} to {reader["destination"]}");
 
                }
            }
        }
    }
}

