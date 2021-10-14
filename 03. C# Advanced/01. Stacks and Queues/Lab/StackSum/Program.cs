using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(input);

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToUpper())
                    .ToArray();

                if (commands[0] == "END")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "ADD":
                        stack.Push(int.Parse(commands[1]));
                        stack.Push(int.Parse(commands[2]));
                        break;
                    case "REMOVE":
                        if (int.Parse(commands[1]) <= stack.Count)
                        {
                            for (int i = 0; i < int.Parse(commands[1]); i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
