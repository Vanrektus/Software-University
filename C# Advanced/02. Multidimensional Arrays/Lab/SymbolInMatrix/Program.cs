using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSizes = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSizes, matrixSizes];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                char[] arr = input.ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            char charToFind = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (charToFind == matrix[row, col])
                    {
                        Console.WriteLine($"{(row, col)}");
                        return;
                    }
                }
            }

            Console.WriteLine($"{charToFind} does not occur in the matrix");

        }
    }
}
