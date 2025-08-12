using System;
using System.Data.SqlClient;

public class BookingService
{
    public void BookTicket(string username)
    {
        Console.Write("Enter Source: ");
        string source = Console.ReadLine();

        Console.Write("Enter Destination: ");
        string destination = Console.ReadLine();

        Console.Write("Enter Journey Date (yyyy-mm-dd): ");
        string dateInput = Console.ReadLine();

        if (!DateTime.TryParse(dateInput, out DateTime journeyDate))
        {
            Console.WriteLine("Invalid date format.");
            return;
        }

        if (journeyDate.Date < DateTime.Today)
        {
            Console.WriteLine(" Journey date cannot be in the past.");
            return;
        }

        using (SqlConnection con = DatabaseHelper.GetConnection())
        {
            con.Open();


            using (SqlCommand cmdTrain = new SqlCommand(
    "SELECT trainid, trainname FROM train WHERE source=@src AND destination=@dest AND isdeleted = 0", con))
            {
                cmdTrain.Parameters.AddWithValue("@src", source);
                cmdTrain.Parameters.AddWithValue("@dest", destination);

                using (SqlDataReader reader = cmdTrain.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine(" No trains available for the selected route.");
                        return; // Stop the booking process
                    }

                    Console.WriteLine("\n Available Trains:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["trainid"]} --> {reader["trainname"]}");
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
                        Console.WriteLine($"{compReader["compartmentid"]}: {compReader["compartmenttype"]} - fare: ₹{compReader["seatprice"]} - Seats Left: {compReader["availableseats"]}");
                    }
                }
            }

            Console.Write("Select Compartment ID: ");
            int compartmentId = int.Parse(Console.ReadLine());

            Console.Write("Number of Seats: ");
            int numSeats = int.Parse(Console.ReadLine());

            int available = 0;
            decimal price = 0;

            using (SqlCommand checkSeats = new SqlCommand(
                "SELECT availableseats, seatprice FROM train_compartments WHERE compartmentid=@cid", con))
            {
                checkSeats.Parameters.AddWithValue("@cid", compartmentId);
                using (SqlDataReader seatReader = checkSeats.ExecuteReader())
                {
                    if (!seatReader.Read())
                    {
                        Console.WriteLine("Invalid compartment.");
                        return;
                    }

                    available = (int)seatReader["availableseats"];
                    price = (decimal)seatReader["seatprice"];
                }
            }

            if (numSeats > available)
            {
                Console.WriteLine("Not enough seats available.");
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

                string seatPosition = seatTypes[(i - 1) % seatTypes.Length];
                decimal total = price;

                using (SqlCommand insert = new SqlCommand(
                    "INSERT INTO booking (trainid, compartmentid, name, age, phone, address, email, aadhar, numseats, totalprice, seatposition, status, journey_date) " +
                    "VALUES (@trainid, @compid, @name, @age, @phone, @addr, @email, @aadhaar, @num, @total, @seat, @status, @journeyDate); " +
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
                    insert.Parameters.AddWithValue("@journeyDate", journeyDate);

                    int bookingId = (int)insert.ExecuteScalar();

                    Console.WriteLine($"\n Passenger {i} Booked Successfully!");
                    Console.WriteLine($"Booking ID: {bookingId}, Seat Type: {seatPosition}, Fare: ₹{total}");
                }
            }

            using (SqlCommand updateSeats = new SqlCommand(
                "UPDATE train_compartments SET availableseats = availableseats - @n WHERE compartmentid = @cid", con))
            {
                updateSeats.Parameters.AddWithValue("@n", numSeats);
                updateSeats.Parameters.AddWithValue("@cid", compartmentId);
                updateSeats.ExecuteNonQuery();
            }

            Console.WriteLine("\n All passengers booked! Save your Booking IDs for future reference.");
        }
    }
}
