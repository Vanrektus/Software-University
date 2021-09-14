using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> numbers = new Queue<int>(input);
            List<int> output = new List<int>();

            while (numbers.Count > 0)
            {
                if (numbers.Peek() % 2 == 0)
                {
                    output.Add(numbers.Dequeue());
                }
                else
                {
                    numbers.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", output));
        }
    }
}
