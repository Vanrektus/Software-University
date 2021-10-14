using System;
using System.Linq;
using System.Xml.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input = Console.ReadLine();
            char[,] snake = new char[matrixSizes[0], matrixSizes[1]];

            int inputCounter = 0;

            FillSnakeMatrix(input, snake, inputCounter);

            PrintOutput(snake);
        }

        static void FillSnakeMatrix(string input, char[,] snake, int inputCounter)
        {
            for (int row = 0; row < snake.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int colEven = 0; colEven < snake.GetLength(1); colEven++)
                    {
                        if (inputCounter >= input.Length)
                        {
                            inputCounter = 0;
                        }

                        snake[row, colEven] = input[inputCounter];

                        inputCounter++;
                    }
                }
                else
                {
                    for (int colOdd = snake.GetLength(1) - 1; colOdd >= 0; colOdd--)
                    {
                        if (inputCounter >= input.Length)
                        {
                            inputCounter = 0;
                        }

                        snake[row, colOdd] = input[inputCounter];

                        inputCounter++;
                    }
                }
            }
        }

        static void PrintOutput(char[,] snake)
        {
            for (int row = 0; row < snake.GetLength(0); row++)
            {
                for (int col = 0; col < snake.GetLength(1); col++)
                {
                    Console.Write(snake[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
