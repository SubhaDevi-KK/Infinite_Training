using System;
using System.Collections.Generic;
using System.Linq;

namespace empList
{
    public class Employee
    {
        public int EmployeeID;
        public string FirstName;
        public string LastName;
        public string Title;
        public string DOB;
        public string DOJ;
        public string City;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();

            empList.Add(new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = "16-11-1984", DOJ = "08-06-2011", City = "Mumbai" });
            empList.Add(new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = "20-08-1994", DOJ = "07-07-2012", City = "Mumbai" });
            empList.Add(new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = "14-11-1987", DOJ = "12-04-2015", City = "Pune" });
            empList.Add(new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = "03-06-1990", DOJ = "02-02-2016", City = "Pune" });
            empList.Add(new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = "08-03-1991", DOJ = "02-02-2016", City = "Mumbai" });
            empList.Add(new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = "07-11-1989", DOJ = "08-08-2014", City = "Chennai" });
            empList.Add(new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = "02-12-1989", DOJ = "01-06-2015", City = "Mumbai" });
            empList.Add(new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = "11-11-1993", DOJ = "06-11-2014", City = "Chennai" });
            empList.Add(new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = "12-08-1992", DOJ = "03-12-2014", City = "Chennai" });
            empList.Add(new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = "12-04-1991", DOJ = "02-01-2016", City = "Pune" });
            //all employee
            Console.WriteLine("All Employees:");
            var allEmployees = from emp in empList select emp;
            foreach (var emp in allEmployees)
            {
                Console.WriteLine(emp.EmployeeID + " " + emp.FirstName + " " + emp.LastName + " " + emp.Title + " " + emp.City);
            }
            // employee not in mumbai
            Console.WriteLine("\nEmployees not in Mumbai:");
            var nonMumbai = from emp in empList where emp.City != "Mumbai" select emp;
            foreach (var emp in nonMumbai)
            {
                Console.WriteLine(emp.FirstName + " " + emp.LastName + " - " + emp.City);
            }
            //title is asstmanager
            Console.WriteLine("\nAssistant Managers:");
            var asstManagers = from emp in empList where emp.Title == "AsstManager" select emp;
            foreach (var emp in asstManagers)
            {
                Console.WriteLine(emp.FirstName + " " + emp.LastName + " - " + emp.Title);
            }
            //name start with s
            Console.WriteLine("\n Employee Last Name starts with 'S':");
            var lastNameS = from emp in empList where emp.LastName.StartsWith("S") select emp;
            foreach (var emp in lastNameS)
            {
                Console.WriteLine(emp.FirstName + " " + emp.LastName);
            }

            Console.ReadLine(); 
        }
    }
}
