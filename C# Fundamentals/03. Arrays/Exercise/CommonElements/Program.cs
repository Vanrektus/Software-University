using System;
using System.Linq;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] secondArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (string item in secondArray)
            {
                foreach (string item2 in firstArray)
                {
                    if (item == item2)
                    {
                        Console.Write($"{item} ");
                    }
                }
            }
        }
    }
}
