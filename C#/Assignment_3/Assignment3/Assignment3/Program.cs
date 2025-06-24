using System;

namespace Assignment3
    //question 1: to create a class  called accounts and its field mebers ,show the status of credit and debit .
{
    class Accounts             
    {   
        int accountNo;         //fields
        string customerName, accountType, transactionType;
        int balance;

        public Accounts(int accNo, string custName, string accType, string transType, int amount)
        {
            accountNo = accNo;
            customerName = custName;
            accountType = accType;
            transactionType = transType.ToLower();
            balance = 0;

            if (transactionType == "d")
                Credit(amount);
            else if (transactionType == "w")
                Debit(amount);
        }

        void Credit(int amount) // when transaction type is deposit 
        {
            balance += amount;
        }

        void Debit(int amount) //when the transaction type is withdraw
        {
            if (amount <= balance)
                balance -= amount;
            else
                Console.WriteLine("Insufficient balance.");
        }

        public void ShowData()
        {
            Console.WriteLine("\n--- Account Details ---");
            Console.WriteLine($"Account No: {accountNo}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Balance: {balance}");
        }
    }
    //question 2:create a class student get their data and display their result
    class Student
    {
        int rollNo;
        string name, className, semester, branch;
        int[] marks = new int[5];

        public Student(int roll, string nam, string cls, string sem, string bra)
        {
            rollNo = roll;
            name = nam;
            className = cls;
            semester = sem;
            branch = bra;
        }

        public void GetMarks()
        {
            Console.WriteLine("\nEnter marks for 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Subject {i + 1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            int total = 0;
            bool isFail = false;

            foreach (int m in marks)
            {
                if (m < 35)
                    isFail = true;
                total += m;
            }

            double average = total / 5.0;
            if (isFail || average < 50)
                Console.WriteLine("Result: Failed");
            else
                Console.WriteLine("Result: Passed");
        }

        public void DisplayData()
        {
            Console.WriteLine("\n--- Student Details ---");
            Console.WriteLine($"Roll No: {rollNo}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Class: {className}");
            Console.WriteLine($"Semester: {semester}");
            Console.WriteLine($"Branch: {branch}");
            Console.WriteLine("Marks: " + string.Join(", ", marks));
        }
    }
    //question 3:create class saledetails with members create constructor,display value without object
    class SaleDetails
    {
        int salesNo, productNo, qty;
        double price, totalAmount;
        string dateOfSale;

        public SaleDetails(int salenum, int prodnum, double pr, int quantity, string date)
        {
            salesNo = salenum;
            productNo = prodnum;
            price = pr;
            qty = quantity;
            dateOfSale = date;
            Sales();
        }

        void Sales()
        {
            totalAmount = qty * price;
        }

        public void ShowData()
        {
            Console.WriteLine("\n--- Sale Details ---");
            Console.WriteLine($"Sales No: {salesNo}");
            Console.WriteLine($"Product No: {productNo}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Quantity: {qty}");
            Console.WriteLine($"Date of Sale: {dateOfSale}");
            Console.WriteLine($"Total Amount: {totalAmount}");
        }
    }

    class Program      
    {
        static void Main(string[] args)
        {
            Accounts acc = new Accounts(106, "Subha", "Savings", "D", 18000);
            acc.ShowData();

            Student stu = new Student(9, "akil", "B.E", "4", "physics");
            stu.GetMarks();
            stu.DisplayResult();
            stu.DisplayData();

            SaleDetails sale = new SaleDetails(5001, 1001, 299.99, 3, "19/09/2003");
            sale.ShowData();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

