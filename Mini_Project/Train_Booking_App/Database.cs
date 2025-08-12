using System;
using System.Data.SqlClient;

public static class Database
{
    public static void ShowAvailableTrains(SqlConnection con, string source, string destination, string journeyDate)
    {
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
                    Console.WriteLine($"{reader["trainid"]} --> {reader["trainname"]}");
                }
            }
        }
    }

    public static void ShowCompartments(SqlConnection con, int trainId)
    {
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
    }
}
