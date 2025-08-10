using System;
using System.Data.SqlClient;

class Program
{
    static string connectionString = "Data Source=ICS-LT-4C2BJ84\\SQLEXPRESS;Initial Catalog=assignments;User ID=sa;Password=Infinite@1234;";

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------- Railway Reservation System ----------");
            Console.WriteLine("1. Book Ticket");
            Console.WriteLine("2. Check Ticket Status");
            Console.WriteLine("3. Cancel Booking");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
                BookTicket();
            else if (choice == "2")
                CheckStatus();
            else if (choice == "3")
                CancelBooking();
            else if (choice == "4")
                break;
            else
                Console.WriteLine("Invalid choice.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void BookTicket()
    {
        Console.Write("Enter Source: ");
        string source = Console.ReadLine();
        Console.Write("Enter Destination: ");
        string destination = Console.ReadLine();
        Console.Write("Enter Journey Date (yyyy-mm-dd): ");
        string journeyDate = Console.ReadLine();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            using (SqlCommand cmdTrain = new SqlCommand(
                "SELECT trainid, trainname FROM train WHERE source=@src AND destination=@dest AND dateofjourney=@date", con))
            {
                cmdTrain.Parameters.AddWithValue("@src", source);
                cmdTrain.Parameters.AddWithValue("@dest", destination);
                cmdTrain.Parameters.AddWithValue("@date", journeyDate);

                using (SqlDataReader reader = cmdTrain.ExecuteReader())
                {
                    Console.WriteLine("\nAvailable Trains:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["trainid"]} --> {reader["trainname"]}");  //retrieving data
                    }
                }
            }

            Console.Write("Choose Train ID: ");
            int trainId = int.Parse(Console.ReadLine());

            using (SqlCommand cmdCompartments = new SqlCommand(
                "SELECT compartmentid, compartmenttype, seatprice, availableseats FROM train_compartments WHERE trainid=@id", con))
            {
                cmdCompartments.Parameters.AddWithValue("@id", trainId);
                using (SqlDataReader compReader = cmdCompartments.ExecuteReader())
                {
                    Console.WriteLine("\nAvailable Compartments:");
                    while (compReader.Read())
                    {
                        Console.WriteLine($"{compReader["compartmentid"]}: {compReader["compartmenttype"]} - ₹{compReader["seatprice"]} - Seats Left: {compReader["availableseats"]}");
                    }
                }
            }

            Console.Write("Select Compartment ID: ");
            int compartmentId = int.Parse(Console.ReadLine());
            Console.Write("Number of Seats: ");
            int numSeats = int.Parse(Console.ReadLine());

            int available = 0;  //To store the number of available seats in the selected train compartment.
            decimal price = 0;  //To store the price of one seat in the selected compartment.

            using (SqlCommand checkSeats = new SqlCommand("SELECT availableseats, seatprice FROM train_compartments WHERE compartmentid=@cid", con))
            {
                checkSeats.Parameters.AddWithValue("@cid", compartmentId);
                using (SqlDataReader seatReader = checkSeats.ExecuteReader())
                {
                    if (!seatReader.Read()) return;
                    available = (int)seatReader["availableseats"];
                    price = (decimal)seatReader["seatprice"];
                }
            }

            if (numSeats > available)
            {
                Console.WriteLine("Sorry, not enough seats available.");
                return;
            }

            string status = "Confirmed";
            string[] seatTypes = { "Upper", "Middle", "Lower" };

            for (int i = 1; i <= numSeats; i++)
            {
                Console.WriteLine($"\nEnter details for Passenger {i}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Phone: ");
                string phone = Console.ReadLine();
                Console.Write("Address: ");
                string address = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Aadhar: ");
                string aadhar = Console.ReadLine();

                string seatPosition = seatTypes[(i - 1) % seatTypes.Length];  //ensures seat types are assigned in a rotating pattern.
                decimal total = price;   // fare for one passenger.

                using (SqlCommand insert = new SqlCommand(
                    "INSERT INTO booking (trainid, compartmentid, name, age, phone, address, email, aadhar, numseats, totalprice, seatposition, status) " +
                    "VALUES (@trainid, @compid, @name, @age, @phone, @addr, @email, @aadhaar, @num, @total, @seat, @status); " +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);", con))
                {
                    insert.Parameters.AddWithValue("@trainid", trainId);
                    insert.Parameters.AddWithValue("@compid", compartmentId);
                    insert.Parameters.AddWithValue("@name", name);
                    insert.Parameters.AddWithValue("@age", age);
                    insert.Parameters.AddWithValue("@phone", phone);
                    insert.Parameters.AddWithValue("@addr", address);
                    insert.Parameters.AddWithValue("@email", email);
                    insert.Parameters.AddWithValue("@aadhaar", aadhar);
                    insert.Parameters.AddWithValue("@num", 1);
                    insert.Parameters.AddWithValue("@total", total);
                    insert.Parameters.AddWithValue("@seat", seatPosition);
                    insert.Parameters.AddWithValue("@status", status);

                    int bookingId = (int)insert.ExecuteScalar();

                    Console.WriteLine($"\n Passenger {i} Booked Successfully!");
                    Console.WriteLine($" Passenger {i} — Booking ID: {bookingId}");
                    Console.WriteLine($" Seat Type: {seatPosition}");
                    Console.WriteLine($" Fare: ₹{total}");
                }
            }

            using (SqlCommand updateSeats = new SqlCommand(
                "UPDATE train_compartments SET availableseats = availableseats - @n WHERE compartmentid = @cid", con))
            {
                updateSeats.Parameters.AddWithValue("@n", numSeats);
                updateSeats.Parameters.AddWithValue("@cid", compartmentId);
                updateSeats.ExecuteNonQuery();
            }

            Console.WriteLine("\nAll passengers booked! Don’t forget to save each Booking ID for status check or cancellation.");
        }
    }

    static void CheckStatus()
    {
        Console.Write("Enter Booking ID: ");
        int bookingId = int.Parse(Console.ReadLine());

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            string query = @"SELECT b.status, b.name, b.age, b.phone, b.email, b.seatposition, 
                        t.trainname, t.source, t.destination, t.dateofjourney
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
                        Console.WriteLine("\n Ticket Details:");
                        Console.WriteLine($" Name: {reader["name"]}, Age: {reader["age"]}");
                        Console.WriteLine($" Phone: {reader["phone"]},  Email: {reader["email"]}");
                        Console.WriteLine($" Seat Type: {reader["seatposition"]}");
                        Console.WriteLine($" Train: {reader["trainname"]}");
                        Console.WriteLine($" Route: {reader["source"]}  {reader["destination"]}");
                        Console.WriteLine($"Date of Journey: {Convert.ToDateTime(reader["dateofjourney"]).ToShortDateString()}");
                        Console.WriteLine($" Booking Status: {reader["status"]}");
                    }
                    else
                    {
                        Console.WriteLine(" No booking found for the given ID.");
                    }
                }
            }
        }
    }

    static void CancelBooking()
    {
        Console.Write("Enter Booking ID to cancel: ");
        int bookingId = int.Parse(Console.ReadLine());

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            decimal total = 0;
            string status = "";

            using (SqlCommand fetch = new SqlCommand("SELECT totalprice, status FROM booking WHERE bookingid=@id", con))
            {
                fetch.Parameters.AddWithValue("@id", bookingId);
                using (SqlDataReader reader = fetch.ExecuteReader())
                {
                    if (!reader.Read()) { Console.WriteLine("Invalid Booking ID."); return; }
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

            decimal refund = total * 0.5m;   //multiplies total fare by 50% so user get half amount back refund

            using (SqlCommand cancel = new SqlCommand(
                "INSERT INTO cancellation (bookingid, refundamount, canceldate) VALUES (@id, @refund, GETDATE())", con))
            {
                cancel.Parameters.AddWithValue("@id", bookingId);
                cancel.Parameters.AddWithValue("@refund", refund);
                cancel.ExecuteNonQuery();
            }

            using (SqlCommand update = new SqlCommand(
      "UPDATE booking SET status='Cancelled', isdeleted=1 WHERE bookingid=@id", con))//status='Cancelled' updates the booking status to show it's no longer active.
            {//isdeleted=1 indicates it is logically deleted but still it exist in booking table flagging it as deleted
                update.Parameters.AddWithValue("@id", bookingId);
                update.ExecuteNonQuery();
            }


            Console.WriteLine($"Booking cancelled successfully.");
            Console.WriteLine($" Refund Amount: ₹{refund} has been initiated.");
        }
    }
}