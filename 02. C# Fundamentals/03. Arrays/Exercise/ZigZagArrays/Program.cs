using System;
using System.Linq;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArray = new int[n];
            int[] secondArray = new int[n];

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    int[] zigZagArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                    firstArray[i] = zigZagArray[0];
                    secondArray[i] = zigZagArray[1];
                }
                else
                {
                    int[] zigZagArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                    firstArray[i] = zigZagArray[1];
                    secondArray[i] = zigZagArray[0];
                }
            }

            Console.WriteLine(string.Join(' ', firstArray));
            Console.WriteLine(string.Join(' ', secondArray));
        }
    }
}
