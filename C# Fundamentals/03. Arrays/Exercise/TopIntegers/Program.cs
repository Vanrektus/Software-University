using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int currentElement = 0; currentElement < array.Length; currentElement++)
            {
                int sum = 0;

                for (int rightElements = currentElement + 1; rightElements < array.Length; rightElements++)
                {
                    if (array[currentElement] > array[rightElements])
                    {
                        sum++;
                    }
                }
                if (sum == array.Length - (currentElement + 1))
                {
                    Console.Write($"{array[currentElement]} ");
                }
            }
        }
    }
}
