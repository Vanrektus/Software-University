using System;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, bool> isDivisible = (number, divider) => number % divider != 0;

            for (int i = 1; i <= n; i++)
            {
                bool isDivisibleToAll = true;

                foreach (var currentDivider in dividers)
                {
                    if (isDivisible(i, currentDivider))
                    {
                        isDivisibleToAll = false;
                        break;
                    }
                }

                if (isDivisibleToAll)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
