using System;
using System.Collections.Generic;
using System.Linq;

namespace Question1and2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqExamples.RunQueries();
        }
    }
    public static class LinqExamples
    {
        public static void RunQueries()
        {
            Console.WriteLine("Numbers and Squares > 20:");
            List<int> numbers = new List<int> { 7, 2, 30 };
            var result = numbers
                .Where(n => n * n > 20)
                .Select(n => $"{n} - {n * n}");
            Console.WriteLine(string.Join(", ", result));

            Console.WriteLine("\n Words starting with 'a' and ending with 'm':");
            List<string> words = new List<string> { "mum", "amsterdam", "bloom" };
            var filteredWords = words
                .Where(w => w.StartsWith("a", StringComparison.OrdinalIgnoreCase) &&
                            w.EndsWith("m", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(string.Join(", ", filteredWords));
            Console.ReadKey();
        }
    }
}
