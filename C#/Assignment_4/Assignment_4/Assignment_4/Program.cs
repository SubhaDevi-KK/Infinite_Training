using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_4
{
    // ------------------ Employee Management ------------------
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }

    class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n******* Employee Management Menu *****");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Back to Main Menu");
                Console.WriteLine("***************************************");
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: AddEmployee(); break;
                        case 2: ViewEmployees(); break;
                        case 3: SearchEmployee(); break;
                        case 4: UpdateEmployee(); break;
                        case 5: DeleteEmployee(); break;
                        case 6: running = false; break;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input must be a valid number.");
                }
            }
        }

        private void AddEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID: ");
                int id = int.Parse(Console.ReadLine());

                if (employees.Any(e => e.Id == id))
                {
                    Console.WriteLine("Employee with this ID already exists.");
                    return;
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Department: ");
                string dept = Console.ReadLine();
                Console.Write("Enter Salary: ");
                double salary = double.Parse(Console.ReadLine());

                employees.Add(new Employee { Id = id, Name = name, Department = dept, Salary = salary });
                Console.WriteLine("Employee added successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter correct data types.");
            }
        }

        private void ViewEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees to display.");
                return;
            }

            Console.WriteLine("\n--- Employee List ---");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Dept: {emp.Department}, Salary: ₹{emp.Salary:F2}");
            }
        }

        private void SearchEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to search: ");
                int id = int.Parse(Console.ReadLine());

                var emp = employees.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Dept: {emp.Department}, Salary: ₹{emp.Salary:F2}");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        private void UpdateEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to update: ");
                int id = int.Parse(Console.ReadLine());

                var emp = employees.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    Console.Write("Enter new Name (or press Enter to skip): ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName)) emp.Name = newName;

                    Console.Write("Enter new Department (or press Enter to skip): ");
                    string newDept = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newDept)) emp.Department = newDept;

                    Console.Write("Enter new Salary (or press Enter to skip): ");
                    string salaryInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(salaryInput)) emp.Salary = double.Parse(salaryInput);

                    Console.WriteLine("Employee details updated.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format. Please enter correct data types.");
            }
        }

        private void DeleteEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                var emp = employees.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    employees.Remove(emp);
                    Console.WriteLine("Employee deleted.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. ID must be a number.");
            }
        }
    }

    // ------------------ MobilePhone Event Handling ------------------
    class MobilePhone
    {
        public delegate void RingEventHandler();
        public event RingEventHandler OnRing;

        public void ReceiveCall()
        {
            Console.WriteLine("\nIncoming call...");
            OnRing?.Invoke();
        }
    }

    class RingtonePlayer
    {
        public void PlayRingtone() => Console.WriteLine("Playing ringtone...");
    }

    class ScreenDisplay
    {
        public void ShowCallerInfo() => Console.WriteLine("Displaying caller information...");
    }

    class VibrationMotor
    {
        public void Vibrate() => Console.WriteLine("Phone is vibrating...");
    }

    class MobilePhoneDemo
    {
        public void Run()
        {
            var phone = new MobilePhone();
            var ringer = new RingtonePlayer();
            var screen = new ScreenDisplay();
            var motor = new VibrationMotor();

            phone.OnRing += ringer.PlayRingtone;
            phone.OnRing += screen.ShowCallerInfo;
            phone.OnRing += motor.Vibrate;

            phone.ReceiveCall();
        }
    }

    // ------------------ Main Menu ------------------
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            var empManager = new EmployeeManager();
            var phoneDemo = new MobilePhoneDemo();

            while (running)
            {
                Console.WriteLine("\n========== Main Menu ==========");
                Console.WriteLine("1. Employee Management System");
                Console.WriteLine("2. Mobile Phone Event Simulation");
                Console.WriteLine("3. Exit");
                Console.WriteLine("================================");
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            empManager.Run();
                            break;
                        case 2:
                            phoneDemo.Run();
                            break;
                        case 3:
                            running = false;
                            Console.WriteLine("Exiting program.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select 1–3.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
