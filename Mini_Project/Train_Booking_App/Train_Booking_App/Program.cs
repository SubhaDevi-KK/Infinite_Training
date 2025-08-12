using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------- Railway Reservation System ----------");
            Console.WriteLine("1. Login as Admin");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string roleChoice = Console.ReadLine();

            switch (roleChoice)
            {
                case "1":
                    
                    if (AdminLogin())
                    {
                        ShowAdminMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid credentials. Access denied.");
                        Console.ReadKey();
                    }
                    break;

                case "2":
                    ShowCustomerMenu();
                    break;

                case "3":
                    Console.WriteLine("Thank you for using the Railway Reservation System!");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static bool AdminLogin()
    {
        Console.Clear();
        Console.WriteLine("------ Admin Login ------");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        return username == "admin" && password == "adminrails";
    }

    static void ShowAdminMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("------ Admin Panel ------");
            Console.WriteLine("1. View All Trains");
            Console.WriteLine("2. View All Bookings");
            Console.WriteLine("3. Deactivate Train");
            Console.WriteLine("4. Add Train");
            Console.WriteLine("5. Reactivate Train");
            Console.WriteLine("6. View Cancelled Bookings");
            Console.WriteLine("7. Logout");

            Console.Write("Choose an option: ");
            string adminChoice = Console.ReadLine();

            switch (adminChoice)
            {
                case "1":
                    ViewTrains.DisplayAllTrains();
                    break;
                case "2":
                    ViewAllBookings.Display();
                    break;
                case "3":
                    DeactivateTrain.Deactivate();
                    break;
                case "4":
                    AddTrain.AddNewTrain();
                    break;
                case "5":
                    ReactivateTrain.Reactivate();
                    break;
                case "6":
                    BookingViewer.ShowCancelledBookings();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void ShowCustomerMenu()
    {
        Console.Clear();
        Console.WriteLine("------ Customer Access ------");
        Console.WriteLine("1. Register");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Back to Main Menu");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CustomerAuth.Register();
                break;
            case "2":
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                if (CustomerAuth.Login(username,password))
                {
                    ShowCustomerDashboard(username);
                }
                break;
            case "3":
                return;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ShowCustomerDashboard(string username)
    {
        BookingService bookingService = new BookingService();
        StatusService statusService = new StatusService();
        CancellationService cancellationService = new CancellationService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"------ Welcome, {username} ------");
            Console.WriteLine("1. Book Ticket");
            Console.WriteLine("2. Check Ticket Status");
            Console.WriteLine("3. Cancel Booking");
          
            Console.WriteLine("4. Logout");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    bookingService.BookTicket(username);
                    break;
                case "2":
                    statusService.CheckStatus(username);
                    break;
                case "3":
                    cancellationService.CancelBooking(username);
                    break;
                case "4":
                    return;
                  
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
