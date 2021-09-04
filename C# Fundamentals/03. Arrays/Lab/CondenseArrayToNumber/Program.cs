using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (array.Length == 1)
            {
                Console.WriteLine(array[0]);
            }
            else
            {
                while (array.Length > 1)
                {
                    int[] condensed = new int[array.Length - 1];

                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        condensed[i] = array[i] + array[i + 1];
                    }

                    array = condensed;
                }

                Console.WriteLine(array[0]);
            }
        }
    }
}
