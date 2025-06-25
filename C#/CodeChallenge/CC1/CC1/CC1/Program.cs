using System;

namespace CodeChallenge1
{
    class Answer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****1.Remove Character at Position***");
            Console.WriteLine(RemChar("Python", 1)); 
            Console.WriteLine(RemChar("Python", 0)); 
            Console.WriteLine(RemChar("Python", 4)); 

            Console.WriteLine("\n****2.Exchange First and Last Characters****");
            Console.WriteLine(Swap("abcd")); 
            Console.WriteLine(Swap("a"));    
            Console.WriteLine(Swap("xy"));   

            Console.WriteLine("\n****3. Largest of Three Integers****");
            Console.WriteLine(GetMax(1, 2, 3)); 
            Console.WriteLine(GetMax(1, 3, 2)); 
            Console.WriteLine(GetMax(1, 1, 1)); 
            Console.WriteLine(GetMax(1, 2, 2)); 

            Console.ReadKey();
        }

        // 1. To Remove character at specified index
        static string RemChar(string str, int posi)
        {
            if (posi < 0 || posi >= str.Length)//posi is the starting index of char to be removed.
            {
                return str;
            }
            return str.Remove(posi, 1);//removing one char
        }

        // 2. Swap first and last characters
        static string Swap(string str)
        {
            if (str.Length <= 1)
            {
                return str;  //if it has less than 1 character swap not possible
            }

            char first = str[0];//first character pos 0
            char last = str[str.Length - 1];//last char= length-1
            string middle = str.Substring(1, str.Length - 2);//middle char btw first and last
            return last + middle + first;
        }

        // 3. Find the largest num among three numbers
        static int GetMax(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));//using Math.max we can easily find larger number
        }
    }
}
