using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[matrixSizes[0], matrixSizes[1]];

            MatrixFill(matrix);

            while (true)
            {
                string[] command = StringArrayReadFromConsole();

                if (command[0] == "END")
                {
                    break;
                }

                if (InvalidInputCheck(matrixSizes, command))
                {
                    continue;
                }

                int firstElementRow = int.Parse(command[1]);
                int firstElementCol = int.Parse(command[2]);
                int secondElementRow = int.Parse(command[3]);
                int secondElementCol = int.Parse(command[4]);

                MatrixShuffling(matrix, command, firstElementRow, firstElementCol, secondElementRow, secondElementCol);
            }
        }

        static void MatrixShuffling(string[,] matrix, string[] command, 
            int firstElementRow, int firstElementCol, int secondElementRow, int secondElementCol)
        {
            if (command[0] == "swap")
            {
                string matrixElementCopy = matrix[firstElementRow, firstElementCol];

                matrix[firstElementRow, firstElementCol] = matrix[secondElementRow, secondElementCol];
                matrix[secondElementRow, secondElementCol] = matrixElementCopy;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }

                    Console.WriteLine();
                }
            }
        }

        static bool InvalidInputCheck(int[] matrixSizes, string[] command)
        {
            bool isInvalid = false;

            if (command.Length != 5)
            {
                Console.WriteLine("Invalid input!");
                isInvalid = true;
                return isInvalid;
            }

            int firstElementRow = int.Parse(command[1]);
            int firstElementCol = int.Parse(command[2]);
            int secondElementRow = int.Parse(command[3]);
            int secondElementCol = int.Parse(command[4]);

            if (firstElementRow < 0 || firstElementRow > matrixSizes[0] ||
                firstElementCol < 0 || firstElementCol > matrixSizes[1] ||
                secondElementRow < 0 || secondElementRow > matrixSizes[0] ||
                secondElementCol < 0 || secondElementCol > matrixSizes[1])
            {
                Console.WriteLine("Invalid input!");
                isInvalid = true;
            }

            return isInvalid;
        }

        static void MatrixFill(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] arr = StringArrayReadFromConsole();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
        }

        private static string[] StringArrayReadFromConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
