using System;
using System.Linq;

namespace MaxSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int maxSequence = int.MinValue;
            int equalElementsSum = 1;
            int equalElement = 0;

            for (int i = 0; i < array.Length; i++)
            {

                if (i > 0 && array[i] == array[i - 1])
                {
                    equalElementsSum++;

                    if (equalElementsSum > maxSequence)
                    {
                        maxSequence = equalElementsSum;
                        equalElement = array[i];
                    }
                }
                else
                {
                    equalElementsSum = 1;
                }
            }

            for (int i = 0; i < maxSequence; i++)
            {
                Console.Write($"{equalElement} ");
            }
        }
    }
}
