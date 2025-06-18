using System;

namespace Ass1_4
{
    class PrintMulTable
    {
        static void Main()
        {
            Console.Write("Enter a number to print its multiplication table:");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i=1;i<=10;i++)
            {
                Console.WriteLine(number + "x" + i + "=" + (number * i));
            }
            Console.ReadKey();
        }
    }
}
