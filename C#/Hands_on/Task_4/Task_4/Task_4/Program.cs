using System;

namespace ExceptionHandlingDemo
{
    // 1. Banking System Custom Exception
    class LimitExceeded : Exception
    {
        public decimal AttemptedAmount { get; }

        public LimitExceeded(string message, decimal amount) : base(message)
        {
            AttemptedAmount = amount;
        }
    }

    class BankAccount
    {
        public decimal Balance { get; private set; } = 100000m;
        private const decimal DailyLimit = 50000m;

        public void Withdraw(decimal amount)
        {
            if (amount > DailyLimit)
                throw new LimitExceeded($"Withdrawal of ₹{amount} exceeds daily limit of ₹{DailyLimit}.", amount);

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            Balance -= amount;
            Console.WriteLine($"Withdrawal of ₹{amount} successful. Remaining balance: ₹{Balance}");
        }
    }

    class BankApp
    {
        public static void Run()
        {
            Console.WriteLine(" BANKING SYSTEM");

            BankAccount account = new BankAccount();

            try
            {
                Console.Write("Enter withdrawal amount: ₹");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                account.Withdraw(amount);
            }
            catch (LimitExceeded ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Attempted Amount: ₹{ex.AttemptedAmount}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
            }

            Console.WriteLine();
        }
    }

    // 2. Grade Calculator with Validation
    class GradeCalculator
    {
        public static void Run()
        {
            Console.WriteLine(" GRADE CALCULATOR");
            int[] marks = new int[3];

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Enter marks for Subject {i + 1}: ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out marks[i]))
                        throw new FormatException("Input is not a valid integer.");

                    if (marks[i] < 0 || marks[i] > 100)
                        throw new ArgumentOutOfRangeException($"Marks must be between 0 and 100. You entered: {marks[i]}");
                }

                double average = (marks[0] + marks[1] + marks[2]) / 3.0;
                Console.WriteLine($"Average Marks: {average:F2}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format Error: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Range Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Grade calculation complete.\n");
            }
        }
    }

    // Central control hub
    class Program
    {
        static void Main(string[] args)
        {
            BankApp.Run();         // Scenario 1
            GradeCalculator.Run(); // Scenario 2

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
