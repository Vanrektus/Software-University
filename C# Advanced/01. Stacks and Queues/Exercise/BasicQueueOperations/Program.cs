using System;
using System.Collections.Generic;
using System.Linq;


namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = ReadArrayFromConsole();
            int[] inputNums = ReadArrayFromConsole();

            Queue<int> nums = new Queue<int>();

            for (int i = 0; i < input[0]; i++)
            {
                nums.Enqueue(inputNums[i]);
            }

            for (int i = 0; i < input[1]; i++)
            {
                nums.Dequeue();
            }

            if (nums.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (nums.Count > 0)
                {
                    Console.WriteLine(nums.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
