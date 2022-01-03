using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();

            double[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var key in input)
            {
                if (numbers.ContainsKey(key))
                {
                    numbers[key]++;
                }
                else
                {
                    numbers.Add(key, 1);
                }
            }

            foreach (var item in numbers)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
