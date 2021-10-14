using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSizes = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSizes, matrixSizes];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = Console.ReadLine()
                .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int sum = 0;

            for (int i = 0; i < matrixSizes; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine(sum);

        }
    }
}
