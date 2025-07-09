using System;

delegate int Delegate(int a, int b);

class Calculator
{
    public static int Add(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiply(int a, int b) => a * b;
}

class Program
{
    static void Execute(Delegate calc, int x, int y, string operation)
    {
        int result = calc(x, y);
        Console.WriteLine($"{operation} of {x} and {y} is: {result}");
    }

    static void Main()
    {
        Console.Write("Enter first number: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = int.Parse(Console.ReadLine());

        Execute(Calculator.Add, num1, num2, "Addition");
        Execute(Calculator.Subtract, num1, num2, "Subtraction");
        Execute(Calculator.Multiply, num1, num2, "Multiplication");
        Console.ReadKey();
    }
}
