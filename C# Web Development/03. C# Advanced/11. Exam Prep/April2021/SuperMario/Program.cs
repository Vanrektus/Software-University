using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingHealth = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            char[][] castle = new char[numberOfRows][];

            int superMarioRow = -1;
            int superMarioCol = -1;

            FillCastle(castle, ref superMarioRow, ref superMarioCol);

            SuperMarioMovement(ref startingHealth, castle, ref superMarioRow, ref superMarioCol);

            PrintCastle(castle);
        }

        private static void FillCastle(char[][] castle, ref int superMarioRow, ref int superMarioCol)
        {
            for (int row = 0; row < castle.Length; row++)
            {
                string currentRowInput = Console.ReadLine();

                castle[row] = new char[currentRowInput.Length];

                for (int col = 0; col < castle[row].Length; col++)
                {
                    castle[row][col] = currentRowInput[col];

                    if (currentRowInput[col] == 'M')
                    {
                        superMarioRow = row;
                        superMarioCol = col;
                    }
                }
            }
        }

        private static void SuperMarioMovement(ref int startingHealth, char[][] castle, ref int superMarioRow, ref int superMarioCol)
        {
            while (startingHealth > 0)
            {
                try
                {
                    string[] command = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    int bowserSpawnRow = int.Parse(command[1]);
                    int bowserSpawnCol = int.Parse(command[2]);

                    SwitchMethod(castle, ref superMarioRow, ref superMarioCol, command, bowserSpawnRow, bowserSpawnCol);

                    if (castle[superMarioRow][superMarioCol] == 'B')
                    {
                        startingHealth -= 3;
                    }
                    else
                    {
                        startingHealth--;
                    }

                    if (castle[superMarioRow][superMarioCol] == 'P')
                    {
                        Console.WriteLine($"Mario has successfully saved the princess! Lives left: {startingHealth}");
                        castle[superMarioRow][superMarioCol] = '-';
                        break;
                    }

                    if (startingHealth <= 0)
                    {
                        Console.WriteLine($"Mario died at {superMarioRow};{superMarioCol}.");
                        castle[superMarioRow][superMarioCol] = 'X';
                        break;
                    }

                    castle[superMarioRow][superMarioCol] = 'M';
                }
                catch
                {
                    startingHealth--;
                }
            }
        }

        private static void SwitchMethod(char[][] castle, ref int superMarioRow, ref int superMarioCol, string[] command, int bowserSpawnRow, int bowserSpawnCol)
        {
            switch (command[0])
            {
                case "W":
                    castle[bowserSpawnRow][bowserSpawnCol] = 'B';

                    //try catch test to see if it's out of array index!!!
                    if (castle[superMarioRow - 1][superMarioCol] == 'C')
                    {
                    }

                    castle[superMarioRow][superMarioCol] = '-';
                    superMarioRow--;
                    break;
                case "S":
                    castle[bowserSpawnRow][bowserSpawnCol] = 'B';

                    //try catch test to see if it's out of array index!!!
                    if (castle[superMarioRow + 1][superMarioCol] == 'C')
                    {
                    }

                    castle[superMarioRow][superMarioCol] = '-';
                    superMarioRow++;
                    break;
                case "A":
                    castle[bowserSpawnRow][bowserSpawnCol] = 'B';

                    //try catch test to see if it's out of array index!!!
                    if (castle[superMarioRow][superMarioCol - 1] == 'C')
                    {
                    }

                    castle[superMarioRow][superMarioCol] = '-';
                    superMarioCol--;
                    break;
                case "D":
                    castle[bowserSpawnRow][bowserSpawnCol] = 'B';

                    //try catch test to see if it's out of array index!!!
                    if (castle[superMarioRow][superMarioCol + 1] == 'C')
                    {
                    }

                    castle[superMarioRow][superMarioCol] = '-';
                    superMarioCol++;
                    break;
            }
        }

        private static void PrintCastle(char[][] castle)
        {
            foreach (char[] currentRow in castle)
            {
                Console.WriteLine(string.Join("", currentRow));
            }
        }
    }
}
