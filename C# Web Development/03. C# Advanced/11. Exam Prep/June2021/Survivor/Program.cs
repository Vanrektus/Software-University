using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            char[][] beach = new char[numberOfRows][];

            FillBeach(numberOfRows, beach);

            int playerTokens = 0;
            int opponentTokens = 0;
            int opponentPositionRow = -1;
            int opponentPositionCol = -1;

            BeachMovement(beach, ref playerTokens, ref opponentTokens, ref opponentPositionRow, ref opponentPositionCol);

            BeachPrint(beach, playerTokens, opponentTokens);
        }

        private static void FillBeach(int numberOfRows, char[][] beach)
        {
            for (int row = 0; row < numberOfRows; row++)
            {
                char[] currentRowInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                beach[row] = currentRowInput;
            }
        }

        private static void BeachMovement(char[][] beach, ref int playerTokens, ref int opponentTokens, ref int opponentPositionRow, ref int opponentPositionCol)
        {
            while (true)
            {
                try
                {
                    string[] command = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (command[0] == "Gong")
                    {
                        break;
                    }

                    int rowIndex = int.Parse(command[1]);
                    int colIndex = int.Parse(command[2]);

                    switch (command[0])
                    {
                        case "Find":
                            if (beach[rowIndex][colIndex] == 'T')
                            {
                                playerTokens++;
                                beach[rowIndex][colIndex] = '-';
                            }
                            break;
                        case "Opponent":
                            opponentPositionRow = rowIndex;
                            opponentPositionCol = colIndex;

                            if (beach[rowIndex][colIndex] == 'T')
                            {
                                opponentTokens++;
                                beach[rowIndex][colIndex] = '-';
                            }

                            OpponentMovement(beach, ref opponentTokens, ref opponentPositionRow, ref opponentPositionCol, command);
                            break;
                    }
                }
                catch
                {
                }
            }
        }

        private static void OpponentMovement(char[][] beach, ref int opponentTokens, ref int opponentPositionRow, ref int opponentPositionCol, string[] command)
        {
            switch (command[3])
            {
                case "up":
                    for (int i = 0; i < 3; i++)
                    {
                        opponentPositionRow -= 1;

                        if (beach[opponentPositionRow][opponentPositionCol] == 'T')
                        {
                            opponentTokens++;
                            beach[opponentPositionRow][opponentPositionCol] = '-';
                        }
                    }
                    break;
                case "down":
                    for (int i = 0; i < 3; i++)
                    {
                        opponentPositionRow += 1;

                        if (beach[opponentPositionRow][opponentPositionCol] == 'T')
                        {
                            opponentTokens++;
                            beach[opponentPositionRow][opponentPositionCol] = '-';
                        }
                    }
                    break;
                case "left":
                    for (int i = 0; i < 3; i++)
                    {
                        opponentPositionCol -= 1;

                        if (beach[opponentPositionRow][opponentPositionCol] == 'T')
                        {
                            opponentTokens++;
                            beach[opponentPositionRow][opponentPositionCol] = '-';
                        }
                    }
                    break;
                case "right":
                    for (int i = 0; i < 3; i++)
                    {
                        opponentPositionCol += 1;

                        if (beach[opponentPositionRow][opponentPositionCol] == 'T')
                        {
                            opponentTokens++;
                            beach[opponentPositionRow][opponentPositionCol] = '-';
                        }
                    }
                    break;
            }
        }

        private static void BeachPrint(char[][] beach, int playerTokens, int opponentTokens)
        {
            foreach (char[] currentRow in beach)
            {
                Console.WriteLine(string.Join(" ", currentRow));
            }

            Console.WriteLine($"Collected tokens: {playerTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
    }
}
