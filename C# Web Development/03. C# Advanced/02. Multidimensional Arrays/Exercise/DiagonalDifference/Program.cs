using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSizes = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSizes, matrixSizes];

            MatrixFill(matrix);

            int sumFirstDiagonal = 0;
            int sumSecondDiagonal = 0;

            for (int i = 0; i < matrixSizes; i++)
            {
                sumFirstDiagonal += matrix[i, i];
            }

            for (int row = 0; row < matrixSizes; row++)
            {
                sumSecondDiagonal += matrix[row, matrixSizes - 1 - row];
            }

            Console.WriteLine(Math.Abs(sumFirstDiagonal - sumSecondDiagonal));
        }

        static void MatrixFill(int[,] matrix)
        {
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
        }
    }
}
