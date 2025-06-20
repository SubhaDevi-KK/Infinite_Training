using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3
{
    class Strings
    {
        static void Main()
        {
            Console.WriteLine("*****display length of the word****");
            Console.Write("Enter a word:");
            string word = Console.ReadLine();
            Console.WriteLine("Length of the word is \"{0}\" is:{1}", word, word.Length);
            Console.WriteLine();

            //reverse the word
            Console.WriteLine("*****reverse the string*****");
            Console.WriteLine("enter a word2");
            string word2 = Console.ReadLine();
            string reversed = "";
            for(int i=word2.Length-1;i>=0;i--)
            {
                reversed += word2[i];
            }
            Console.WriteLine("reversed word: " + reversed);
            Console.WriteLine();

            //check two words are same
            Console.WriteLine("Enter first word:");
            string firstword = Console.ReadLine();
            Console.WriteLine("Enter second word:");
            string secondword = Console.ReadLine();
            if(firstword==secondword)
            {
                Console.WriteLine("words are same");
            }
            else
            {
                Console.WriteLine("Words are not same");
            }
            Console.ReadKey();
        }
        
    }


}
