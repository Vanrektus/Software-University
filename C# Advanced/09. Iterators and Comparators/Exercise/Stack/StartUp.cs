using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<int> customStack = new CustomStack<int>();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "END")
                {
                    break;
                }

                switch (command[0])
                {
                    case "Push":
                        int[] elementsToPush = command.Skip(1)
                            .Select(e => e.Split(",", StringSplitOptions.RemoveEmptyEntries).First())
                            .Select(int.Parse)
                            .ToArray();

                        customStack.Push(elementsToPush);
                        break;

                    case "Pop":
                        try
                        {
                            customStack.Pop();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                }
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
