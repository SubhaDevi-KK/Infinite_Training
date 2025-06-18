using System;


namespace Assignment1_1
{
    class CheckIntEqual
    {
        static void Main()
        {
            Console.Write("Enter the 1st integer: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the 2nd integer: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 == num2)
            {
                Console.WriteLine($"{num1} and {num2} are equal");
            }
            else
            {
                Console.WriteLine($"{ num1} and { num2} are not equal");
            }
            Console.ReadKey();
              
        }
    }
}