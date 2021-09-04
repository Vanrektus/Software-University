using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> elements = new Dictionary<string, int>();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x = x.ToLower())
                .ToArray();

            foreach (var key in input)
            {
                if (elements.ContainsKey(key))
                {
                    elements[key]++;
                }
                else
                {
                    elements.Add(key, 1);
                }
            }

            foreach (var item in elements)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
