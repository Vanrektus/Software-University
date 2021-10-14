using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int filter = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isLessOrEqual = (name, filter) => name.Length <= filter;

            foreach (var currentName in names)
            {
                if (isLessOrEqual(currentName, filter))
                {
                    Console.WriteLine(currentName);
                }
            }
        }
    }
}
