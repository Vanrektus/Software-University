using System;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string filter = Console.ReadLine();

            Predicate<string> isFilterEven = n => n == "even";
            Predicate<int> isNumberEven = n => n % 2 == 0;

            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                if (isFilterEven(filter) && isNumberEven(i))
                {
                    Console.Write($"{i} ");
                }
                else if (!isFilterEven(filter) && !isNumberEven(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
