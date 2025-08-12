using System;
using System.Collections.Generic;
using System.Data.SqlClient;

class ViewTrains
{
    public static void DisplayAllTrains()
    {
        var trains = new List<TrainInfo>();

        using (SqlConnection con = DatabaseHelper.GetConnection())
        {
            con.Open();

            string trainQuery = @"SELECT trainid, trainname, source, destination, availableseats 
                                  FROM train 
                                  WHERE isdeleted = 0 
                                  ORDER BY trainname";

            using (SqlCommand trainCmd = new SqlCommand(trainQuery, con))
            using (SqlDataReader trainReader = trainCmd.ExecuteReader())
            {
                while (trainReader.Read())
                {
                    trains.Add(new TrainInfo
                    {
                        TrainId = Convert.ToInt32(trainReader["trainid"]),
                        TrainName = trainReader["trainname"].ToString(),
                        Source = trainReader["source"].ToString(),
                        Destination = trainReader["destination"].ToString(),
                        AvailableSeats = Convert.ToInt32(trainReader["availableseats"])
                    });
                }
            }

            if (trains.Count == 0)
            {
                Console.WriteLine("No trains available.");
                return;
            }

            Console.WriteLine("\n========== Available Train Details ==========");

            foreach (var train in trains)
            {
                Console.WriteLine($"\nTrain ID: {train.TrainId}");
                Console.WriteLine($"Train Name: {train.TrainName}");
                Console.WriteLine($"Route: {train.Source} to {train.Destination}");
                Console.WriteLine($"Available Seats: {train.AvailableSeats}");

                DisplayCompartments(con, train.TrainId);
            }
        }
    }

    private static void DisplayCompartments(SqlConnection con, int trainId)
    {
        string compQuery = @"SELECT compartmenttype, seatprice, availableseats 
                             FROM train_compartments 
                             WHERE trainid = @id";

        using (SqlCommand compCmd = new SqlCommand(compQuery, con))
        {
            compCmd.Parameters.AddWithValue("@id", trainId);

            using (SqlDataReader compReader = compCmd.ExecuteReader())
            {
                Console.WriteLine("Compartments:");
                while (compReader.Read())
                {
                    string type = compReader["compartmenttype"].ToString();
                    decimal price = Convert.ToDecimal(compReader["seatprice"]);
                    int seats = Convert.ToInt32(compReader["availableseats"]);

                    Console.WriteLine($"  - {type}: amount: {price} | Seats Left: {seats}");
                }
            }
        }
    }

    public class TrainInfo
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int AvailableSeats { get; set; }
    }
}

