using System;
using System.Linq;

namespace CustomCoparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> evenNumbers = n => n
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToArray();
            Func<int[], int[]> oddNumbers = n => n
                .Where(n => n % 2 != 0)
                .OrderBy(n => n)
                .ToArray();

            Console.Write(string.Join(" ", evenNumbers(numbers)));
            Console.Write(" ");
            Console.Write(string.Join(" ", oddNumbers(numbers)));
        }
    }
}
