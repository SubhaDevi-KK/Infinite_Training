using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelConcessionApp
{
    
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }

    
    public static class EmployeeManager
    {
        public static void DisplayEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { EmpId = 1, EmpName = "subha", EmpCity = "Bangalore", EmpSalary = 55000 },
                new Employee { EmpId = 2, EmpName = "krish", EmpCity = "Mumbai", EmpSalary = 40000 },
                new Employee { EmpId = 3, EmpName = "karthi", EmpCity = "Bangalore", EmpSalary = 47000 },
                new Employee { EmpId = 4, EmpName = "keerthi", EmpCity = "Delhi", EmpSalary = 30000 }
            };

            Console.WriteLine("\nAll Employees:");
            employees.ForEach(e => PrintEmployee(e));

            Console.WriteLine("\nEmployees with Salary > 45000:");
            employees.Where(e => e.EmpSalary > 45000).ToList().ForEach(PrintEmployee);

            Console.WriteLine("\nEmployees from Bangalore:");
            employees.Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase))
                     .ToList().ForEach(PrintEmployee);

            Console.WriteLine("\nEmployees sorted by Name (Ascending):");
            employees.OrderBy(e => e.EmpName).ToList().ForEach(PrintEmployee);
        }

        private static void PrintEmployee(Employee e)
        {
            Console.WriteLine($"ID: {e.EmpId}, Name: {e.EmpName}, City: {e.EmpCity}, Salary: ₹{e.EmpSalary}");
        }
    }

    
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Employee Management System ===");
            EmployeeManager.DisplayEmployees();
            Console.ReadKey();
        }
        
    }
}

