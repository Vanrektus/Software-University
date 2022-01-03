using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int filter = int.Parse(Console.ReadLine());

            Func<int, int, bool> isDivisible = (number, filter) => number % filter == 0;

            for (int i = 0; i <= numbers.Count - 1; i++)
            {
                if (isDivisible(numbers[i], filter))
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
