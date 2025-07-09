using System;

class Box
{
    public int Length { get; set; }
    public int Breadth { get; set; }

    public Box(int length, int breadth)
    {
        Length = length;
        Breadth = breadth;
    }

    // Overload (+) operator to add two Box objects
    public static Box operator +(Box b1, Box b2)
    {
        return new Box(b1.Length + b2.Length, b1.Breadth + b2.Breadth);
    }

    public void Display()
    {
        Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
    }
}

class Test
{
    static void Main()
    {
        // Input for Box 1
        Console.WriteLine("Enter dimensions for Box 1:");
        Console.Write("Length: ");
        int length1 = int.Parse(Console.ReadLine());
        Console.Write("Breadth: ");
        int breadth1 = int.Parse(Console.ReadLine());

        // Input for Box 2
        Console.WriteLine("\nEnter dimensions for Box 2:");
        Console.Write("Length: ");
        int length2 = int.Parse(Console.ReadLine());
        Console.Write("Breadth: ");
        int breadth2 = int.Parse(Console.ReadLine());

        // Creating Box objects
        Box box1 = new Box(length1, breadth1);
        Box box2 = new Box(length2, breadth2);

        // Add boxes
        Box box3 = box1 + box2;

        // Displaying the result
        Console.WriteLine("\nResulting Box after addition:");
        box3.Display();
        Console.ReadKey();
    }
}

