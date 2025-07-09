using System;
using System.IO;

class FileAppend
{
    static void Main()
    {
        string filePath = "answer.txt";
        Console.Write("Enter text to append: ");
        string text = Console.ReadLine();

        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine(text);
        }

        Console.WriteLine("Text appended successfully.");
        Console.ReadKey();
    }
}
