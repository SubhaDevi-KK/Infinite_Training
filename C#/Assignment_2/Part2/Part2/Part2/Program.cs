using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    class Array
    {
        static void Main()
        {
            //to print average value,min ,max of array
            Console.WriteLine("******to print avg,min and max value of the array******");
            int[] numbers = { 10, 20, 30, 40, 50 };
            int sum = 0;
            int min = numbers[0];
            int max = numbers[0];
            for (int a = 0; a < numbers.Length; a++)
            {
                sum += numbers[a];
                if (numbers[a] < min)
                {
                    min = numbers[a];
                }
                if (numbers[a] > max)
                {
                    max = numbers[a];
                }
                double average = (double)sum / numbers.Length;
                Console.WriteLine("Array elements:{0}", string.Join(", ", numbers));
                Console.WriteLine("Average value="+average);
                Console.WriteLine("minimum value="+min);
                Console.WriteLine("maximum value="+max);
                Console.WriteLine();

                //ten marks operation
                Console.WriteLine("******operation using ten marks*****");
                Console.WriteLine("Enter ten marks");
                int[] marks = new int[10];
                for (int b = 0; b < 10; b++)
                {
                    Console.Write("Mark{0}:", b + 1);
                    marks[b] = Convert.ToInt32(Console.ReadLine());
                }
                int total = 0;
                int minmarks = marks[0];
                int maxmarks = marks[0];
                for (int c = 0; c < marks.Length; c++)
                {
                    total += marks[c];
                    if (marks[c] < minmarks)
                    {
                        minmarks = marks[c];
                    }
                    if (marks[c] > maxmarks)
                    {
                        maxmarks = marks[c];
                    }
                    double markAverage = (double)total / marks.Length;
                    //ascending order
                    for (int d = 0; d< marks.Length - 1; d++)
                    {
                        for (int e = 0; e < marks.Length - e - 1; e++)
                        {
                            if (marks[e] > marks[e + 1])
                            {
                                int temp = marks[e];
                                marks[e] = marks[e + 1];
                                marks[e+ 1] = temp;

                            }
                        }

                    }
                    Console.WriteLine("\nTotal marks=" + total);
                    Console.WriteLine("Average marks=" + markAverage);
                    Console.WriteLine("Minimum mark=" + minmarks);
                    Console.WriteLine("Maximum marks=" + maxmarks);
                    Console.WriteLine("Marks in ascending order=" + string.Join(",", marks));

                    //descending order
                    Console.WriteLine("Marks in descending order:");
                    for (int f = marks.Length - 1; f >= 0; f--)
                    {
                        Console.Write(marks[f]);
                        if (f != 0)
                        {
                            Console.Write(" ,");
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        


                        //Copy array elements
                        Console.WriteLine("*****copy array elements****");
                        int[] sourceArray = { 2, 3, 6, 8, 10 };
                        int[] targetArray = new int[sourceArray.Length];
                        for (int g = 0; g < sourceArray.Length; g++)
                        {
                            targetArray[g] = sourceArray[g];
                        }
                        Console.WriteLine("Source Array:" + string.Join(", ", sourceArray));
                        Console.WriteLine("Copied Array:" + string.Join(", ", targetArray));
                    }
                }

            }
            Console.ReadKey();
        }
    }
}
  