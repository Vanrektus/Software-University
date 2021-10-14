using System;
using System.Linq;

namespace SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int sum = 0;

            foreach (int item in array)
            {
                if (item % 2 == 0)
                {
                    sum += item;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
