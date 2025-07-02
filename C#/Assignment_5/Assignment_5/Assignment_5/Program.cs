using System;

namespace Assignment_5
{
    // ------------------ Custom Exception ------------------
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    // ------------------ Accounts Class ------------------
    class Accounts
    {
        public int AccountNo;
        public string CustomerName;
        public string AccountType;
        public int Balance;

        public Accounts(int accNo, string name, string accType, int balance)
        {
            AccountNo = accNo;
            CustomerName = name;
            AccountType = accType;
            Balance = balance;
        }

        public void Credit(int amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited: {amount}");
        }

        public void Debit(int amount)
        {
            if (amount > Balance)
                throw new InsufficientBalanceException("Insufficient balance for withdrawal.");
            Balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}");
        }

        public void PerformTransaction(char type, int amount)
        {
            if (type == 'd' || type == 'D')
                Credit(amount);
            else if (type == 'w' || type == 'W')
                Debit(amount);
            else
                Console.WriteLine("Invalid transaction type.");
        }

        public void ShowData()
        {
            Console.WriteLine($"\n--- Account Details ---");
            Console.WriteLine($"Account No: {AccountNo}");
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Account Type: {AccountType}");
            Console.WriteLine($"Balance: {Balance}");
        }
    }

    // ------------------ Student Class ------------------
    class Student
    {
        int RollNo;
        string Name;
        string Class;
        int Semester;
        string Branch;
        int[] Marks = new int[5];

        public Student(int rollNo, string name, string cls, int sem, string branch)
        {
            RollNo = rollNo;
            Name = name;
            Class = cls;
            Semester = sem;
            Branch = branch;
        }

        public void GetMarks()
        {
            Console.WriteLine("\nEnter marks for 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Subject {i + 1}: ");
                Marks[i] = int.Parse(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            int total = 0;
            bool failed = false;

            foreach (int mark in Marks)
            {
                if (mark < 35)
                    failed = true;
                total += mark;
            }

            double avg = total / 5.0;

            Console.WriteLine("\n--- Student Result ---");
            if (failed || avg < 50)
                Console.WriteLine("Result: Failed");
            else
                Console.WriteLine("Result: Passed");
        }

        public void DisplayData()
        {
            Console.WriteLine($"\n--- Student Details ---");
            Console.WriteLine($"Roll No: {RollNo}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Semester: {Semester}");
            Console.WriteLine($"Branch: {Branch}");
            Console.WriteLine("Marks: " + string.Join(", ", Marks));
        }
    }

    // ------------------ SaleDetails Class ------------------
    class SaleDetails
    {
        int SalesNo, ProductNo, Qty;
        double Price, TotalAmount;
        string DateOfSale;

        public SaleDetails(int salesNo, int productNo, double price, int qty, string date)
        {
            SalesNo = salesNo;
            ProductNo = productNo;
            Price = price;
            Qty = qty;
            DateOfSale = date;
        }

        public void Sales()
        {
            TotalAmount = Qty * Price;
        }

        public void ShowData()
        {
            Console.WriteLine($"\n--- Sale Details ---");
            Console.WriteLine($"Sales No: {SalesNo}");
            Console.WriteLine($"Product No: {ProductNo}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Quantity: {Qty}");
            Console.WriteLine($"Date: {DateOfSale}");
            Console.WriteLine($"Total Amount: {TotalAmount}");
        }
    }

    // ------------------ Scholarship Class ------------------
    class Scholarship
    {
        public double Merit(int marks, double fees)
        {
            if (marks >= 70 && marks <= 80)
                return fees * 0.2;
            else if (marks > 80 && marks <= 90)
                return fees * 0.3;
            else if (marks > 90)
                return fees * 0.5;
            else
                throw new Exception("Not eligible for scholarship.");
        }
    }

    // ------------------ Book and BookShelf Classes ------------------
    class Book
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Book(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
        }
    }

    class BookShelf
    {
        private Book[] books = new Book[5];

        public Book this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }

        public void DisplayAll()
        {
            Console.WriteLine("\n--- Books on Shelf ---");
            for (int i = 0; i < books.Length; i++)
            {
                books[i]?.Display();
            }
        }
    }

    // ------------------ Main Program ------------------
    class Program
    {
        static void Main()
        {
            // Accounts
            var acc = new Accounts(101, "subha", "Savings", 1000);
            try
            {
                acc.PerformTransaction('d', 500);
                acc.PerformTransaction('w', 2000); // Will throw exception
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            acc.ShowData();

            // Student
            var student = new Student(1, "subha", "10th", 2, "Science");
            student.GetMarks();
            student.DisplayResult();
            student.DisplayData();

            // SaleDetails
            var sale = new SaleDetails(1, 101, 250.5, 3, "219/09/2003");
            sale.Sales();
            sale.ShowData();

            // Scholarship
            var scholarship = new Scholarship();
            try
            {
                double amount = scholarship.Merit(85, 10000);
                Console.WriteLine($"\nScholarship Amount: {amount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Scholarship Error: {ex.Message}");
            }

            // BookShelf
            var shelf = new BookShelf();
            shelf[0] = new Book("20013", "its not late today");
            shelf[1] = new Book("fire of wings", "abdul kalam");
            shelf[2] = new Book("The Alchemist", "Paulo Coelho");
            shelf[3] = new Book("its not late today", "proff gold");
            shelf[4] = new Book("thirukural", "valluvar");
            shelf.DisplayAll();

            // Pause before exit
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

