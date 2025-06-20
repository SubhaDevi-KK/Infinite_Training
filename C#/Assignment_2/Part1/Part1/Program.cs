using System;


namespace Part1
{
    class FirstThreeProg
    {
        static void Main()
        {   //Swap
            Console.WriteLine("*****Swapping******");
            Console.WriteLine("Enter number1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Before Swapping: num1= {0},num2={1}", num1, num2);
            int temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine("After swapping: num1 ={0},num2 ={1}",num1,num2);
            Console.WriteLine();

            //display number four times
            Console.WriteLine("*****Display the number four times");
            Console.WriteLine("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} {0} {0} {0}", number);
            Console.WriteLine("{0}{0}{0}{0}", number);
            Console.WriteLine("{0} {0} {0} {0}",number);
            Console.WriteLine("{0}{0}{0}{0}", number);
            Console.WriteLine();

            //day number to day name
            Console.WriteLine("********Day name * *******");
            Console.WriteLine("Enter a day number:");
            int daynum = Convert.ToInt32(Console.ReadLine());
            switch(daynum)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("saturday");
                    break;
                case 7:
                    Console.WriteLine("sunday");
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;

                      
            }

            Console.ReadKey();
        }
    }
}
