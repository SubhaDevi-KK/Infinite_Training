using System;
using System.Data.SqlClient;

public class CancellationService
{
    public void CancelBooking(string username)
    {
        Console.Write("Enter Booking ID to cancel: ");
        int bookingId = int.Parse(Console.ReadLine());

        using (SqlConnection con = DatabaseHelper.GetConnection())
        {
            con.Open();
            decimal total = 0;
            string status = "";

            using (SqlCommand fetch = new SqlCommand("SELECT totalprice, status FROM booking WHERE bookingid=@id", con))
            {
                fetch.Parameters.AddWithValue("@id", bookingId);
                using (SqlDataReader reader = fetch.ExecuteReader())
                {
                    if (!reader.Read()) 
                    { Console.WriteLine("Invalid Booking ID.");
                    return; 
                    }
                    total = (decimal)reader["totalprice"];
                    status = (string)reader["status"];
                }
            }

            if (status == "Cancelled")
            {
                Console.WriteLine("Already cancelled.");
                return;
            }

            Console.Write("Confirm cancellation (y/n): ");
            string confirm = Console.ReadLine();

            if (confirm.ToLower() != "y")
            {
                Console.WriteLine("Cancellation aborted.");
                return;
            }

            decimal refund = total * 0.5m;

            using (SqlCommand cancel = new SqlCommand(
                "INSERT INTO cancellation (bookingid, refundamount, canceldate) VALUES (@id, @refund, GETDATE())", con))
            {
                cancel.Parameters.AddWithValue("@id", bookingId);
                cancel.Parameters.AddWithValue("@refund", refund);
                cancel.ExecuteNonQuery();
            }

            using (SqlCommand update = new SqlCommand(
                "UPDATE booking SET status='Cancelled', isdeleted=1 WHERE bookingid=@id", con))
            {
                update.Parameters.AddWithValue("@id", bookingId);
                update.ExecuteNonQuery();
            }

            Console.WriteLine("Booking cancelled successfully.");
            Console.WriteLine($"Refund Amount: {refund} has been initiated.");
        }
    }
}

