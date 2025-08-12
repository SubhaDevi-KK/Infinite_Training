using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class ViewAllBookings
{
    public static void Display()
    {
        using (SqlConnection con = DatabaseHelper.GetConnection())
        {
            con.Open();

            string trainQuery = @"
                SELECT DISTINCT t.trainid, t.trainname, t.source, t.destination
                FROM train t
                JOIN booking b ON t.trainid = b.trainid
                WHERE b.isdeleted = 0 AND t.isdeleted = 0
                ORDER BY t.trainid";

            using (SqlCommand trainCmd = new SqlCommand(trainQuery, con))
            using (SqlDataReader trainReader = trainCmd.ExecuteReader())
            {
                if (!trainReader.HasRows)
                {
                    Console.WriteLine("No bookings found.");
                    return;
                }

                var trainList = new List<TrainInfo>();

                while (trainReader.Read())
                {
                    trainList.Add(new TrainInfo
                    {
                        TrainId = (int)trainReader["trainid"],
                        TrainName = trainReader["trainname"].ToString(),
                        Source = trainReader["source"].ToString(),
                        Destination = trainReader["destination"].ToString()
                    });
                }

                trainReader.Close();

                foreach (var train in trainList)
                {
                    Console.WriteLine($"\nTrain ID: {train.TrainId}");
                    Console.WriteLine($"Train Name: {train.TrainName}");
                    Console.WriteLine($"Route: {train.Source} to {train.Destination}");
                    Console.WriteLine("Passengers:");

                    string bookingQuery = @"
                        SELECT b.name, b.age, b.phone, b.email, b.aadhar, b.seatposition, b.status,
                               tc.compartmenttype, b.numseats, b.totalprice
                        FROM booking b
                        JOIN train_compartments tc ON b.compartmentid = tc.compartmentid
                        WHERE b.trainid = @id AND b.isdeleted = 0";

                    using (SqlCommand bookingCmd = new SqlCommand(bookingQuery, con))
                    {
                        bookingCmd.Parameters.AddWithValue("@id", train.TrainId);

                        using (SqlDataReader bookingReader = bookingCmd.ExecuteReader())
                        {
                            int count = 0;
                            while (bookingReader.Read())
                            {
                                count++;
                                Console.WriteLine($"  Passenger {count}:");
                                Console.WriteLine($"    Name: {bookingReader["name"]}, Age: {bookingReader["age"]}");
                                Console.WriteLine($"    Phone: {bookingReader["phone"]}, Email: {bookingReader["email"]}");
                                Console.WriteLine($"    Aadhar: {bookingReader["aadhar"]}");
                                Console.WriteLine($"    Compartment: {bookingReader["compartmenttype"]}");
                                Console.WriteLine($"    Seats Booked: {bookingReader["numseats"]}, Total Price: ₹{bookingReader["totalprice"]}");
                                Console.WriteLine($"    Seat Type: {bookingReader["seatposition"]}, Status: {bookingReader["status"]}");
                            }

                            if (count == 0)
                            {
                                Console.WriteLine("  No active passengers.");
                            }
                        }
                    }
                }
            }
        }
    }

    class TrainInfo
    {
        public int TrainId;
        public string TrainName;
        public string Source;
        public string Destination;
    }
}
