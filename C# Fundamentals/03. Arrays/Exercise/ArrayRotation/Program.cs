using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int firstElement = array[0];

                for (int j = 1; j < array.Length; j++)
                {
                    int prevIndex = j - 1;
                    array[prevIndex] = array[j];
                }

                array[array.Length - 1] = firstElement;
            }

            Console.WriteLine(string.Join(' ', array));
        }
    }
}
