using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine()
                .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                string commandName = command[0];

                if (commandName == "END")
                {
                    break;
                }

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 || row > jagged.Length - 1 || col < 0 || col > jagged[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (commandName)
                {
                    case "Add":
                            jagged[row][col] += value;
                        break;
                    case "Subtract":
                            jagged[row][col] -= value;
                        break;
                }
            }

            foreach (int[] currentRow in jagged)
            {
                Console.WriteLine(string.Join(' ', currentRow));
            }
        }
    }
}
