using System;
using System.Data.SqlClient;

public class AddTrain
{
    public static void AddNewTrain()
    {
        Console.Write("Train ID: ");
        int trainId = int.Parse(Console.ReadLine());

        Console.Write("Train Name: ");
        string trainName = Console.ReadLine();

        Console.Write("Source: ");
        string source = Console.ReadLine();

        Console.Write("Destination: ");
        string destination = Console.ReadLine();

        Console.Write("Available Seats: ");
        int availableSeats = int.Parse(Console.ReadLine());

        using (SqlConnection con = DatabaseHelper.GetConnection())
        {
            con.Open();

            string insertTrain = @"INSERT INTO train (trainid, trainname, source, destination, availableseats, isdeleted)
                                   VALUES (@id, @name, @src, @dest, @avail, 0)";

            using (SqlCommand cmd = new SqlCommand(insertTrain, con))
            {
                cmd.Parameters.AddWithValue("@id", trainId);
                cmd.Parameters.AddWithValue("@name", trainName);
                cmd.Parameters.AddWithValue("@src", source);
                cmd.Parameters.AddWithValue("@dest", destination);
                cmd.Parameters.AddWithValue("@avail", availableSeats);
                cmd.ExecuteNonQuery();
            }

            Console.Write("How many compartments to add? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"\nCompartment {i}:");
                Console.Write("Type: ");
                string type = Console.ReadLine();

                Console.Write("Seat Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.Write("Available Seats: ");
                int seats = int.Parse(Console.ReadLine());

                string insertComp = @"INSERT INTO train_compartments (trainid, compartmenttype, seatprice, availableseats)
                                      VALUES (@tid, @type, @price, @seats)";

                using (SqlCommand compCmd = new SqlCommand(insertComp, con))
                {
                    compCmd.Parameters.AddWithValue("@tid", trainId);
                    compCmd.Parameters.AddWithValue("@type", type);
                    compCmd.Parameters.AddWithValue("@price", price);
                    compCmd.Parameters.AddWithValue("@seats", seats);
                    compCmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine("\nNew train and compartments added successfully.");
        }
    }
}
