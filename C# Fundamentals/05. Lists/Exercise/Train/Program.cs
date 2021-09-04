using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> passengers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacityPerWagon = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            while (input != "end")
            {
                List<string> command = (input)
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (command.Count == 1)
                {
                    for (int i = 0; i < passengers.Count; i++)
                    {
                        if (passengers[i] + int.Parse(command[0]) <= maxCapacityPerWagon)
                        {
                            passengers[i] += int.Parse(command[0]);
                            break;
                        }
                    }
                }
                else if (command.Count == 2) //&& int.Parse(command[1]) <= 75) && int.Parse(command[1]) >= 0))
                {
                    passengers.Add(int.Parse(command[1]));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", passengers));
        }
    }
}
