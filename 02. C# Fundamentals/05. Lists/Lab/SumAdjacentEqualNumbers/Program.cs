using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            while (true)
            {
                bool isEqual = false;

                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i] == numbers[i + 1])
                    {
                        numbers[i] = numbers[i] * 2;
                        numbers.RemoveAt(i + 1);
                        isEqual = true;
                        break;
                    }
                }

                if (isEqual == false)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
