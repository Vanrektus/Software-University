using System;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            char[,] field = new char[sizeOfField, sizeOfField];

            string[] attackCommands = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            int firstPlayerShips = 0;
            int secondPlaterShips = 0;

            FieldFill(field, ref firstPlayerShips, ref secondPlaterShips);

            int shipsDestroyed = Gameplay(sizeOfField, field, attackCommands, ref firstPlayerShips, ref secondPlaterShips);

            PrintOutput(firstPlayerShips, secondPlaterShips, shipsDestroyed);
        }

        private static void FieldFill(char[,] field, ref int firstPlayerShips, ref int secondPlaterShips)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = char.Parse(input[col]);

                    if (field[row, col] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (field[row, col] == '>')
                    {
                        secondPlaterShips++;
                    }
                }
            }
        }

        private static int Gameplay(int sizeOfField, char[,] field, string[] attackCommands, ref int firstPlayerShips, ref int secondPlaterShips)
        {
            int shipsDestroyed = 0;

            for (int i = 0; i < attackCommands.Length; i++)
            {
                string[] splittedCommands = attackCommands[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int attackRow = int.Parse(splittedCommands[0]);
                int attackCol = int.Parse(splittedCommands[1]);

                if (attackRow < 0 || attackRow >= sizeOfField)
                {
                    continue;
                }

                if (attackCol < 0 || attackCol >= sizeOfField)
                {
                    continue;
                }

                if (field[attackRow, attackCol] == '*')//regular position
                {
                    continue;
                }
                else if (field[attackRow, attackCol] == '<')// first player
                {
                    field[attackRow, attackCol] = 'X';
                    firstPlayerShips--;
                    shipsDestroyed++;
                }
                else if (field[attackRow, attackCol] == '>')//second player
                {
                    field[attackRow, attackCol] = 'X';
                    secondPlaterShips--;
                    shipsDestroyed++;
                }
                else if (field[attackRow, attackCol] == '#')//mine
                {
                    field[attackRow, attackCol] = 'X';

                    if (attackRow - 1 >= 0)
                    {
                        if (field[attackRow - 1, attackCol] == '<')
                        {
                            field[attackRow - 1, attackCol] = 'X';
                            firstPlayerShips--;
                            shipsDestroyed++;
                        }
                        else if (field[attackRow - 1, attackCol] == '>')
                        {
                            field[attackRow - 1, attackCol] = 'X';
                            secondPlaterShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (attackRow + 1 < sizeOfField)
                    {
                        if (field[attackRow + 1, attackCol] == '<')
                        {
                            field[attackRow + 1, attackCol] = 'X';
                            firstPlayerShips--;
                            shipsDestroyed++;
                        }
                        else if (field[attackRow + 1, attackCol] == '>')
                        {
                            field[attackRow + 1, attackCol] = 'X';
                            secondPlaterShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (attackCol - 1 >= 0)
                    {
                        if (field[attackRow, attackCol - 1] == '<')
                        {
                            field[attackRow, attackCol - 1] = 'X';
                            firstPlayerShips--;
                            shipsDestroyed++;
                        }
                        else if (field[attackRow, attackCol - 1] == '>')
                        {
                            field[attackRow, attackCol - 1] = 'X';
                            secondPlaterShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (attackCol + 1 < sizeOfField)
                    {
                        if (field[attackRow, attackCol + 1] == '<')
                        {
                            field[attackRow, attackCol + 1] = 'X';
                            firstPlayerShips--;
                            shipsDestroyed++;
                        }
                        else if (field[attackRow, attackCol + 1] == '>')
                        {
                            field[attackRow, attackCol + 1] = 'X';
                            secondPlaterShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (attackRow - 1 >= 0 && attackCol - 1 >= 0)
                    {
                        if (field[attackRow - 1, attackCol - 1] == '<')
                        {
                            field[attackRow - 1, attackCol - 1] = 'X';
                            firstPlayerShips--;
                            shipsDestroyed++;
                        }
                        else if (field[attackRow - 1, attackCol - 1] == '>')
                        {
                            field[attackRow - 1, attackCol - 1] = 'X';
                            secondPlaterShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (attackRow - 1 >= 0 && attackCol + 1 < sizeOfField)
                    {
                        if (field[attackRow - 1, attackCol + 1] == '<')
                        {
                            field[attackRow - 1, attackCol + 1] = 'X';
                            firstPlayerShips--;
                            shipsDestroyed++;
                        }
                        else if (field[attackRow - 1, attackCol + 1] == '>')
                        {
                            field[attackRow - 1, attackCol + 1] = 'X';
                            secondPlaterShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (attackRow + 1 < sizeOfField && attackCol - 1 >= 0)
                    {
                        if (field[attackRow + 1, attackCol - 1] == '<')
                        {
                            field[attackRow + 1, attackCol - 1] = 'X';
                            firstPlayerShips--;
                            shipsDestroyed++;
                        }
                        else if (field[attackRow + 1, attackCol - 1] == '>')
                        {
                            field[attackRow + 1, attackCol - 1] = 'X';
                            secondPlaterShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (attackRow + 1 < sizeOfField && attackCol + 1 < sizeOfField)
                    {
                        if (field[attackRow + 1, attackCol + 1] == '<')
                        {
                            field[attackRow + 1, attackCol + 1] = 'X';
                            firstPlayerShips--;
                            shipsDestroyed++;
                        }
                        else if (field[attackRow + 1, attackCol + 1] == '>')
                        {
                            field[attackRow + 1, attackCol + 1] = 'X';
                            secondPlaterShips--;
                            shipsDestroyed++;
                        }
                    }
                }

                if (firstPlayerShips <= 0)
                {
                    break;
                }

                if (secondPlaterShips <= 0)
                {
                    break;
                }
            }

            return shipsDestroyed;
        }

        private static void PrintOutput(int firstPlayerShips, int secondPlaterShips, int shipsDestroyed)
        {
            if (firstPlayerShips <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {shipsDestroyed} ships have been sunk in the battle.");
            }
            else if (secondPlaterShips <= 0)
            {
                Console.WriteLine($"Player One has won the game! {shipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlaterShips} ships left.");
            }
        }
    }
}
