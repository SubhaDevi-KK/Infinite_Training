using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge_2
{
    // 1. Abstract Class and Inheritance
    abstract class Student    //creating a abstract class of student
    {
        public string Name { get; set; }  
        public int StudentId { get; set; }
        public double Grade { get; set; }

        public abstract bool IsPassed(double grade); //take grade as input and check student pass or not
    }
    //creating two subclass
    class Undergraduate : Student  //inherits all members of student
    {
        public override bool IsPassed(double grade) //overriding Ispassed method
        {
            return grade > 70.0;  //passes if grade is above 70
        }
    }

    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80.0; //pass if grade is above 80
        }
    }

    // 2. Product Class and Sorting
    class Product     
    {   //input
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }

    class Program
    {
        // 3. Method to throw exception for negative numbers
        static void CheckNumber(int number) //thorws expection if num is negative
        {
            if (number < 0)
                throw new ArgumentException("Number cannot be negative.");
            Console.WriteLine($"Valid number: {number}");
        }

        static void Main(string[] args)
        {
            // question 1: Test Student 
            Console.WriteLine("*********Student Pass Check ***********");
            Student ugrad = new Undergraduate { Name = "Subha", StudentId = 6, Grade = 65};
            Student grad = new Graduate { Name = "akil", StudentId = 3, Grade = 98 };

            Console.WriteLine($"{ugrad.Name} Passed: {ugrad.IsPassed(ugrad.Grade)}");
            Console.WriteLine($"{grad.Name} Passed: {grad.IsPassed(grad.Grade)}");

            // question 2: Product Sorting
            Console.WriteLine("\n******* Enter 10 Products********");
            List<Product> products = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"\nEnter details for Product {i + 1}:");

                Console.Write("Product ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                products.Add(new Product
                {
                    ProductId = id,
                    ProductName = name,
                    Price = price
                });
            }

            // Sort by price
            var sortedProducts = products.OrderBy(p => p.Price).ToList();

            Console.WriteLine("\n********Sorted Products by Price********");
            foreach (var p in sortedProducts)
            {
                Console.WriteLine($"ID: {p.ProductId}, Name: {p.ProductName}, Price: ₹{p.Price}");
            }

            // question 3: Exception Handling
            Console.WriteLine("\n*********Exception Handling ********");
            try
            {
                Console.Write("Enter a number: ");
                int input = int.Parse(Console.ReadLine());
                CheckNumber(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}

