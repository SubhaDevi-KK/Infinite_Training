using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Queries
{
    class Linq_With_Employees
    {
        public static DataTable GetEmployeeData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EmployeeID", typeof(int));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("DOB", typeof(DateTime));
            dt.Columns.Add("DOJ", typeof(DateTime));
            dt.Columns.Add("City", typeof(string));

            dt.Rows.Add(1001, "Malcolm", "Daruwalla", "Manager", new DateTime(1984, 11, 16), new DateTime(2011, 6, 8), "Mumbai");
            dt.Rows.Add(1002, "Asdin", "Dhalla", "AsstManager", new DateTime(1984, 8, 20), new DateTime(2012, 7, 7), "Mumbai");
            dt.Rows.Add(1003, "Madhavi", "Oza", "Consultant", new DateTime(1987, 11, 14), new DateTime(2015, 4, 12), "Pune");
            dt.Rows.Add(1004, "Saba", "Shaikh", "SE", new DateTime(1990, 6, 3), new DateTime(2016, 2, 2), "Pune");
            dt.Rows.Add(1005, "Nazia", "Shaikh", "SE", new DateTime(1991, 3, 8), new DateTime(2016, 2, 2), "Mumbai");
            dt.Rows.Add(1006, "Amit", "Pathak", "Consultant", new DateTime(1989, 11, 7), new DateTime(2014, 8, 8), "Chennai");
            dt.Rows.Add(1007, "Vijay", "Natrajan", "Consultant", new DateTime(1989, 12, 2), new DateTime(2015, 6, 1), "Mumbai");
            dt.Rows.Add(1008, "Rahul", "Dubey", "Associate", new DateTime(1993, 11, 11), new DateTime(2014, 11, 6), "Chennai");
            dt.Rows.Add(1009, "Suresh", "Mistry", "Associate", new DateTime(1992, 8, 12), new DateTime(2014, 12, 3), "Chennai");
            dt.Rows.Add(1010, "Sumit", "Shah", "Manager", new DateTime(1991, 4, 12), new DateTime(2016, 1, 2), "Pune");

            return dt;
        }

        static void Main()
        {
            DataTable empTable = GetEmployeeData();

            // 1. Employees who joined before 1/1/2015
            var joinedBefore2015 = empTable.AsEnumerable()
                .Where(emp => emp.Field<DateTime>("DOJ") < new DateTime(2015, 1, 1));

            // 2. Employees born after 1/1/1990
            var bornAfter1990 = empTable.AsEnumerable()
                .Where(emp => emp.Field<DateTime>("DOB") > new DateTime(1990, 1, 1));

            // 3. Title is Consultant or Associate
            var consultantOrAssociate = empTable.AsEnumerable()
                .Where(emp => emp.Field<string>("Title") == "Consultant" || emp.Field<string>("Title") == "Associate");

            // 4. Total number of employees
            int totalEmployees = empTable.Rows.Count;

            // 5. Total employees in Chennai
            int totalChennai = empTable.AsEnumerable()
                .Count(emp => emp.Field<string>("City") == "Chennai");

            // 6. Highest EmployeeID
            int highestID = empTable.AsEnumerable()
                .Max(emp => emp.Field<int>("EmployeeID"));

            // 7. Employees who joined after 1/1/2015
            int joinedAfter2015 = empTable.AsEnumerable()
                .Count(emp => emp.Field<DateTime>("DOJ") > new DateTime(2015, 1, 1));

            // 8. Employees whose Title is not Associate
            int notAssociate = empTable.AsEnumerable()
                .Count(emp => emp.Field<string>("Title") != "Associate");

            // 9. Count by City
            var countByCity = empTable.AsEnumerable()
                .GroupBy(emp => emp.Field<string>("City"))
                .Select(g => new { City = g.Key, Count = g.Count() });

            // 10. Count by City and Title
            var countByCityTitle = empTable.AsEnumerable()
                .GroupBy(emp => new { City = emp.Field<string>("City"), Title = emp.Field<string>("Title") })
                .Select(g => new { g.Key.City, g.Key.Title, Count = g.Count() });

            // 11. Youngest Employee
            var youngest = empTable.AsEnumerable()
                .OrderByDescending(emp => emp.Field<DateTime>("DOB"))
                .FirstOrDefault();

            // displaying output
            Console.WriteLine("Total Employees: " + totalEmployees);
            Console.WriteLine("Employees from Chennai: " + totalChennai);
            Console.WriteLine("Highest Employee ID: " + highestID);
            Console.WriteLine("Employees joined after 1/1/2015: " + joinedAfter2015);
            Console.WriteLine("Employees not 'Associate': " + notAssociate);

            Console.WriteLine("\nEmployees who joined before 1/1/2015:");
            foreach (var emp in joinedBefore2015)
                Console.WriteLine($"{emp["FirstName"]} {emp["LastName"]} - DOJ: {emp["DOJ"]}");

            Console.WriteLine("\nEmployees born after 1/1/1990:");
            foreach (var emp in bornAfter1990)
                Console.WriteLine($"{emp["FirstName"]} {emp["LastName"]} - DOB: {emp["DOB"]}");

            Console.WriteLine("\nEmployees who are Consultants or Associates:");
            foreach (var emp in consultantOrAssociate)
                Console.WriteLine($"{emp["FirstName"]} {emp["LastName"]} - Title: {emp["Title"]}");

            Console.WriteLine("\nEmployee Count by City:");
            foreach (var item in countByCity)
                Console.WriteLine($"{item.City}: {item.Count}");

            Console.WriteLine("\nEmployee Count by City and Title:");
            foreach (var item in countByCityTitle)
                Console.WriteLine($"{item.City}, {item.Title}: {item.Count}");

            Console.WriteLine("\nYoungest Employee:");
            if (youngest != null)
                Console.WriteLine($"{youngest["FirstName"]} {youngest["LastName"]} born on {youngest["DOB"]}");

            Console.Read();
        }
    }
}

