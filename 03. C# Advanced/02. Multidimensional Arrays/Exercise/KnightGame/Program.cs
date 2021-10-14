using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] chessBoard = new char[size, size];

            BoardFill(size, chessBoard);

            int removedKnights = 0;
            int maxAttacksRow = 0;
            int maxAttacksCol = 0;

            while (true)
            {
                int maxAttacks = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        int attacksCounter = 0;

                        if (chessBoard[row, col] == 'K')
                        {
                            attacksCounter = KnightAttacksCounter(size, chessBoard,
                                attacksCounter, row, col);

                            if (attacksCounter > maxAttacks)
                            {
                                maxAttacks = attacksCounter;
                                maxAttacksRow = row;
                                maxAttacksCol = col;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    chessBoard[maxAttacksRow, maxAttacksCol] = '0';
                    removedKnights++;
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }
        }

        static void BoardFill(int size, char[,] board)
        {
            for (int row = 0; row < size; row++)
            {
                char[] inputArray = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = inputArray[col];
                }
            }
        }

        static bool IsInside(int size, int row, int col)
        {
            return row >= 0 && row < size
                && col >= 0 && col < size;
        }

        static int KnightAttacksCounter(int size, char[,] chessBoard,
            int attacksCounter, int row, int col)
        {
            if (IsInside(size, row + 2, col + 1)
                && chessBoard[row + 2, col + 1] == 'K')
            {
                attacksCounter++;
            }

            if (IsInside(size, row + 2, col - 1)
                && chessBoard[row + 2, col - 1] == 'K')
            {
                attacksCounter++;
            }

            if (IsInside(size, row - 2, col + 1)
                && chessBoard[row - 2, col + 1] == 'K')
            {
                attacksCounter++;
            }

            if (IsInside(size, row - 2, col - 1)
                && chessBoard[row - 2, col - 1] == 'K')
            {
                attacksCounter++;
            }

            if (IsInside(size, row + 1, col + 2)
                && chessBoard[row + 1, col + 2] == 'K')
            {
                attacksCounter++;
            }

            if (IsInside(size, row + 1, col - 2)
                && chessBoard[row + 1, col - 2] == 'K')
            {
                attacksCounter++;
            }

            if (IsInside(size, row - 1, col + 2)
                && chessBoard[row - 1, col + 2] == 'K')
            {
                attacksCounter++;
            }

            if (IsInside(size, row - 1, col - 2)
                && chessBoard[row - 1, col - 2] == 'K')
            {
                attacksCounter++;
            }

            return attacksCounter;
        }
    }
}
