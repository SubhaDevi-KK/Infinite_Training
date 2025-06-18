using System;


namespace Ass1_2
{
    class CheckPosOrNeg
    {
        static void Main()
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number > 0)
            {
                Console.WriteLine("The number is positive");
            }
            else if (number < 0)
            {
                Console.WriteLine("The number is negative");

            }
            else
            {
                Console.WriteLine("The number is 0");
            }

            Console.ReadKey();
        }
    }
}
