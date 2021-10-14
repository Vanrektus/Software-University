using System;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] easierMaze = new string[]
            {
                "000",
                "010",
                "00E",
            };

            string[] harderMaze = new string[]
            {
                "010001",
                "01010E",
                "010100",
                "000000",
            };

            FindAllPaths(easierMaze, 0, 0, new bool[easierMaze.Length, easierMaze[0].Length], "");
            Console.WriteLine();
            FindAllPaths(harderMaze, 0, 0, new bool[harderMaze.Length, harderMaze[0].Length], "");
        }

        private static void FindAllPaths(string[] maze, int row, int col, bool[,] isVisited, string currentPath)
        {
            if (maze[row][col] == 'E')
            {
                Console.WriteLine(currentPath);
                return;
            }

            isVisited[row, col] = true;

            if (IsSafe(maze, row + 1, col, isVisited))
            {
                FindAllPaths(maze, row + 1, col, isVisited, currentPath + "D ");
            }

            if (IsSafe(maze, row - 1, col, isVisited))
            {
                FindAllPaths(maze, row - 1, col, isVisited, currentPath + "U ");
            }

            if (IsSafe(maze, row, col + 1, isVisited))
            {
                FindAllPaths(maze, row, col + 1, isVisited, currentPath + "R ");
            }

            if (IsSafe(maze, row, col - 1, isVisited))
            {
                FindAllPaths(maze, row, col - 1, isVisited, currentPath + "L ");
            }

            isVisited[row, col] = false;
        }

        private static bool IsSafe(string[] maze, int row, int col, bool[,] isVisited)
        {
            if (row < 0 || col < 0 || row >= maze.Length || col >= maze[0].Length)
            {
                return false;
            }

            if (maze[row][col] == '1' || isVisited[row, col])
            {
                return false;
            }

            return true;
        }
    }
}
