using System;


namespace Ass1_3
{
    class AllOperation
    {
        static void Main()
        {
            Console.Write("enter first integer:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("enter second integer:");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("which operation(+,-,*,/) :");
            char op = Convert.ToChar(Console.ReadLine());
            double result;
            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    Console.WriteLine($"{num1} + {num2} = {result}");
                    break;
                case '-':
                    result = num1 - num2;
                    Console.WriteLine($"{num1} - {num2} = {result}");
                    break;
                case '*':
                    result = num1 * num2;
                    Console.WriteLine($"{num1} * {num2} = {result}");
                    break;
                case '/':
                    result = num1 / num2;
                    Console.WriteLine($"{num1} / {num2} = {result}");
                    break;
                default:
                    Console.WriteLine("invalid operation");
                    break;
                   
                    
            }
            Console.ReadKey();


        }
    }
}
