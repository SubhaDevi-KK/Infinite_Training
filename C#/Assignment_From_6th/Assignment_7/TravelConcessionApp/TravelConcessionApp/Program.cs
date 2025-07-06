using System;
using ConcessionLibrary;

namespace TravelConcessionApp
{
    class Program
    {
        public const double TotalFare = 500;

        static void Main(string[] args)
        {
            Console.WriteLine("Travel Concession Calculator");

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            string result = ConcessionCalculator.CalculateConcession(name, age, TotalFare);
            Console.WriteLine("\nResult:");
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
