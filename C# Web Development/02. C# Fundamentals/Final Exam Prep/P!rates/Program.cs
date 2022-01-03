using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> targetedCities = new Dictionary<string, int[]>();

            AddCities(targetedCities);

            PlunderProsperCities(targetedCities);

            PrintOutput(targetedCities);
        }

        static void AddCities(Dictionary<string, int[]> targetedCities)
        {
            while (true)
            {
                string[] newCity = Console.ReadLine()
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);

                if (newCity[0] == "Sail")
                {
                    break;
                }

                if (!targetedCities.ContainsKey(newCity[0]))
                {
                    targetedCities.Add(newCity[0], new int[] { int.Parse(newCity[1]), int.Parse(newCity[2]) });
                }
                else
                {
                    targetedCities[newCity[0]][0] += int.Parse(newCity[1]);
                    targetedCities[newCity[0]][1] += int.Parse(newCity[2]);
                }
            }
        }

        static void PlunderProsperCities(Dictionary<string, int[]> targetedCities)
        {
            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "End")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "Plunder":
                        targetedCities[commands[1]][0] -= int.Parse(commands[2]);
                        targetedCities[commands[1]][1] -= int.Parse(commands[3]);

                        Console.WriteLine($"{commands[1]} plundered! {int.Parse(commands[3])} gold stolen, {int.Parse(commands[2])} citizens killed.");

                        if (targetedCities[commands[1]][0] == 0 || targetedCities[commands[1]][1] == 0)
                        {
                            targetedCities.Remove(commands[1]);

                            Console.WriteLine($"{commands[1]} has been wiped off the map!");
                        }
                        break;
                    case "Prosper":
                        if (int.Parse(commands[2]) > 0)
                        {
                            targetedCities[commands[1]][1] += int.Parse(commands[2]);

                            Console.WriteLine($"{commands[2]} gold added to the city treasury. {commands[1]} now has {targetedCities[commands[1]][1]} gold.");
                        }
                        else
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                        break;
                }
            }
        }

        static void PrintOutput(Dictionary<string, int[]> targetedCities)
        {
            if (targetedCities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {targetedCities.Count} wealthy settlements to go to:");

                foreach (var city in targetedCities.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
