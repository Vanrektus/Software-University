using System;
using System.Linq;
using System.Numerics;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jagged = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            AnalyzeMatrix(rows, jagged);

            ManipulateMatrix(rows, jagged);

            foreach (double[] currentRow in jagged)
            {
                Console.WriteLine(string.Join(' ', currentRow));
            }
        }

        static void AnalyzeMatrix(int rows, double[][] jagged)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        if (jagged[row][col] == 0)
                        {
                            continue;
                        }

                        jagged[row][col] *= 2;
                    }

                    for (int col2 = 0; col2 < jagged[row + 1].Length; col2++)
                    {
                        if (jagged[row][col2] == 0)
                        {
                            continue;
                        }

                        jagged[row + 1][col2] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /= 2;

                    }

                    for (int col2 = 0; col2 < jagged[row + 1].Length; col2++)
                    {
                        jagged[row + 1][col2] /= 2;
                    }
                }
            }
        }

        static void ManipulateMatrix(int rows, double[][] jagged)
        {
            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string commandName = command[0].ToUpper();

                if (commandName == "END")
                {
                    break;
                }

                int currentRow = int.Parse(command[1]);
                int currentCol = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (currentRow < 0 || currentRow > rows ||
                    currentCol < 0 || currentCol > jagged[currentRow].Length - 1)
                {
                    continue;
                }

                switch (commandName)
                {
                    case "ADD":
                        jagged[currentRow][currentCol] += value;
                        break;
                    case "SUBTRACT":
                        jagged[currentRow][currentCol] -= value;
                        break;
                }
            }
        }
    }
}
