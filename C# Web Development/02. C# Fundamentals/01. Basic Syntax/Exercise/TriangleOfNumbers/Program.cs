using System;

namespace TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int rows = 1; rows <= number; rows++)
            {
                for (int currentRow = 1; currentRow <= rows; currentRow++)
                {
                    Console.Write($"{rows} ");
                }
                Console.WriteLine();
            }
        }
    }
}
