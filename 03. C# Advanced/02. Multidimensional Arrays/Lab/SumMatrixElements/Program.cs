using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = ReadArrayFromConsole();
            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];

            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = ReadArrayFromConsole();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                    sum += arr[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
