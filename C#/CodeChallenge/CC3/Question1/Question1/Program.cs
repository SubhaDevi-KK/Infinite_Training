using System;

class CricketTeam
{
    public (int Count, int Sum, double Average) Pointscalculation(int no_of_matches)
    {
        int sum = 0;
        for (int i = 0; i < no_of_matches; i++)
        {
            Console.Write($"Enter score for match {i + 1}: ");    //input
            int score = int.Parse(Console.ReadLine());
            sum += score;
        }
        double average = (double)sum / no_of_matches;
        return (no_of_matches, sum, average);               //return the values
    }

    static void Main()
    {
        CricketTeam team = new CricketTeam();
        Console.Write("Enter number of matches: ");
        int matches = int.Parse(Console.ReadLine());

        var result = team.Pointscalculation(matches);
        Console.WriteLine($"\nTotal Matches: {result.Count}");    //output
        Console.WriteLine($"Sum of Scores: {result.Sum}");
        Console.WriteLine($"Average Score: {result.Average:F2}");
        Console.ReadKey();
    }
}
