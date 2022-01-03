using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int filter = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isValidName = (name, filter) => name.ToCharArray()
                .Select(ch => (int)ch)
                .Sum() >= filter;

            Func<string[], int, Func<string, int, bool>, string> firstValidName = (arr, filter, func) => arr
                .First(name => func(name, filter));

            Console.WriteLine(firstValidName(names, filter, isValidName));
        }
    }
}
