using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string wantedBook = Console.ReadLine();
            string books = Console.ReadLine();

            int numberOfBooks = 0;

            while (books != "No More Books")
            {
                if (books == wantedBook)
                {
                    break;
                }
                numberOfBooks++;
                books = Console.ReadLine();
            }
            if (books == wantedBook)
            {
                Console.WriteLine($"You checked {numberOfBooks} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {numberOfBooks} books.");
            }
        }
    }
}
