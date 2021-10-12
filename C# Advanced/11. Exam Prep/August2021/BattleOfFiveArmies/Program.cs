using System;

namespace BattleOfFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingArmor = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            char[][] map = new char[numberOfRows][];

            int armyRow = -1;
            int armyCol = -1;

            FillMap(map, ref armyRow, ref armyCol);

            ArmyMovement(ref startingArmor, map, ref armyRow, ref armyCol);

            PrintMap(map);
        }

        private static void FillMap(char[][] map, ref int armyRow, ref int armyCol)
        {
            for (int row = 0; row < map.Length; row++)
            {
                string currentRowInput = Console.ReadLine();

                map[row] = new char[currentRowInput.Length];

                for (int col = 0; col < map[row].Length; col++)
                {
                    map[row][col] = currentRowInput[col];

                    if (currentRowInput[col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }
        }

        private static void ArmyMovement(ref int startingArmor, char[][] map, ref int armyRow, ref int armyCol)
        {
            while (startingArmor > 0)
            {
                try
                {
                    string[] command = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    int spawnRow = int.Parse(command[1]);
                    int spawnCol = int.Parse(command[2]);

                    SwitchMethod(map, ref armyRow, ref armyCol, command, spawnRow, spawnCol);

                    if (map[armyRow][armyCol] == 'O')
                    {
                        startingArmor -= 3;
                    }
                    else
                    {
                        startingArmor--;
                    }

                    if (map[armyRow][armyCol] == 'M')
                    {
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {startingArmor}");
                        map[armyRow][armyCol] = '-';
                        break;
                    }

                    if (startingArmor <= 0)
                    {
                        Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                        map[armyRow][armyCol] = 'X';
                        break;
                    }

                    map[armyRow][armyCol] = 'A';
                }
                catch
                {
                    startingArmor--;
                }
            }
        }

        private static void SwitchMethod(char[][] map, ref int armyRow, ref int armyCol, string[] command, int spawnRow, int spawnCol)
        {
            switch (command[0])
            {
                case "up":
                    map[spawnRow][spawnCol] = 'O';

                    if (map[armyRow - 1][armyCol] == 'C')
                    {
                    }

                    map[armyRow][armyCol] = '-';
                    armyRow--;
                    break;
                case "down":
                    map[spawnRow][spawnCol] = 'O';

                    if (map[armyRow + 1][armyCol] == 'C')
                    {
                    }

                    map[armyRow][armyCol] = '-';
                    armyRow++;
                    break;
                case "left":
                    map[spawnRow][spawnCol] = 'O';

                    if (map[armyRow][armyCol - 1] == 'C')
                    {
                    }

                    map[armyRow][armyCol] = '-';
                    armyCol--;
                    break;
                case "right":
                    map[spawnRow][spawnCol] = 'O';

                    if (map[armyRow][armyCol + 1] == 'C')
                    {
                    }

                    map[armyRow][armyCol] = '-';
                    armyCol++;
                    break;
            }
        }

        static void PrintMap(char[][] map)
        {
            foreach (char[] currentRow in map)
            {
                Console.WriteLine(string.Join("", currentRow));
            }
        }
    }
}
