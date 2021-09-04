using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> peopleGoing = new List<string>();

            for (int i = 1; i <= numberOfCommands; i++)
            {
                List<string> commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                bool isInList = true;
                bool isAlreadyInList = false;

                switch (commands[2])
                {
                    case "going!":
                        for (int j = 0; j < peopleGoing.Count; j++)
                        {
                            if (commands[0] == peopleGoing[j])
                            {
                                Console.WriteLine($"{commands[0]} is already in the list!");
                                isAlreadyInList = true;
                                break;
                            }
                        }

                        if (isAlreadyInList == false)
                        {
                            peopleGoing.Add(commands[0]);
                        }
                        break;
                    case "not":
                        for (int k = 0; k < peopleGoing.Count; k++)
                        {
                            if (commands[0] == peopleGoing[k])
                            {
                                peopleGoing.RemoveAt(k);
                                isInList = false;
                            }
                        }

                        if (isInList == true)
                        {
                            Console.WriteLine($"{commands[0]} is not in the list!");
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join("\n", peopleGoing));
        }
    }
}
