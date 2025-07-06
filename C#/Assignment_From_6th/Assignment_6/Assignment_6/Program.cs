using System;
using System.IO;

namespace Ass_6
{
    // 1. Books class
    public class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
        }
    }

    // BookShelf class using composition and indexer
    public class BookShelf
    {
        private Books[] books = new Books[5];

        public Books this[int index]
        {
            get
            {
                if (index >= 0 && index < books.Length)
                    return books[index];
                else
                    throw new IndexOutOfRangeException("Invalid index");
            }
            set
            {
                if (index >= 0 && index < books.Length)
                    books[index] = value;
                else
                    throw new IndexOutOfRangeException("Invalid index");
            }
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("\nBookShelf Contents:");
            foreach (var book in books)
            {
                book?.Display();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // question 1: Using Book and BookShelf
            BookShelf shelf = new BookShelf();
            shelf[0] = new Books("2017", "its not late today");
            shelf[1] = new Books("2019", "Harper Lee");
            shelf[2] = new Books("The Great Gatsby", "F. Scott ");
            shelf[3] = new Books("Pride and Prejudice", "Jane Austen");
            shelf[4] = new Books("The Hobbit", "J.R.R. Tolkien");

            shelf.DisplayAllBooks();

            // question 2: Write array of strings to a file
            string[] lines = {
                "Line 1: Welcome to disney channel",
                "Line 2: This is a cartoon based channel",
                "Line 3: created for kids."
            };

            string filePath = "output.txt";
            File.WriteAllLines(filePath, lines);
            Console.WriteLine($"\nFile '{filePath}' created and written successfully.");

            // question 3: Count number of lines in the file
            int lineCount = File.ReadAllLines(filePath).Length;
            Console.WriteLine($"The file '{filePath}' contains {lineCount} lines.");
            Console.ReadKey();
        }
    }
}
