using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int number = int.Parse(Console.ReadLine());

            for (int currentElement = 0; currentElement < array.Length; currentElement++)
            {
                for (int i = currentElement + 1; i < array.Length; i++)
                {
                    if (array[currentElement] + array[i] == number)
                    {
                        Console.WriteLine($"{array[currentElement]} {array[i]}");
                    }
                }
            }

        }
    }
}
