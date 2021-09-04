using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (true)
            {
                List<string> commands = (input)
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                string command = commands[0];
                int firstCommandNumber = int.Parse(commands[1]);
                int secondCommandNumber = 0;

                if (commands.Count == 3)
                {
                    secondCommandNumber = int.Parse(commands[2]);
                }

                switch (command)
                {
                    case "Add":
                        numbers.Add(firstCommandNumber);
                        break;
                    case "Remove":
                        numbers.Remove(firstCommandNumber);
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(firstCommandNumber);
                        break;
                    case "Insert":
                        numbers.Insert(secondCommandNumber, firstCommandNumber);
                        break;
                }

                input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
