using System;


namespace Ass1_5
{
    class SumAndTriples
    {
        static void Main()
        {
            Console.Write("Enter first integer:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second Integer:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int sum = num1 + num2;
            if(num1 == num2)
            {
                sum = sum * 3;
            }
            Console.WriteLine("Result:" + sum);
            Console.ReadKey();
        }
       
    }
}
