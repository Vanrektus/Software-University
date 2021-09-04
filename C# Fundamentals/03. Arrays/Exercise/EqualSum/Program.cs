using System;
using System.Linq;

namespace EqualSum
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
                int leftSum = 0;
                int rightSum = 0;

                for (int leftPart = 0; leftPart < currentElement; leftPart++)
                {
                    leftSum += array[leftPart];
                }

                for (int rightPart = currentElement + 1; rightPart < array.Length; rightPart++)
                {
                    rightSum += array[rightPart];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(currentElement);
                    return;
                }
            }

            Console.WriteLine("no");

        }
    }
}
