using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int newNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(newNumber))
                {
                    numbers.Add(newNumber, 1);
                }
                else
                {
                    numbers[newNumber]++;
                }
            }

            foreach (var item in numbers)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
