using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>();
            SortedDictionary<string, int> junkItems = new SortedDictionary<string, int>();

            legendaryItems.Add("shards", 0);
            legendaryItems.Add("fragments", 0);
            legendaryItems.Add("motes", 0);

            while (legendaryItems["motes"] < 250 && legendaryItems["fragments"] < 250 && legendaryItems["shards"] < 250)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToLower())
                    .ToArray();

                for (int i = 1; i < input.Length; i += 2)
                {
                    switch (input[i])
                    {
                        case "shards":
                        case "fragments":
                        case "motes":
                            legendaryItems[input[i]] += int.Parse(input[i - 1]);

                            break;
                        default:
                            if (!junkItems.ContainsKey(input[i]))
                            {
                                junkItems.Add(input[i], int.Parse(input[i - 1]));
                            }
                            else
                            {
                                junkItems[input[i]] += int.Parse(input[i - 1]);
                            }
                            break;
                    }

                    if (legendaryItems["shards"] >= 250
                        || legendaryItems["fragments"] >= 250
                        || legendaryItems["motes"] >= 250)
                    {
                        break;
                    }
                }
            }

            PrintOutPut(legendaryItems, junkItems);
        }

        static void PrintOutPut(Dictionary<string, int> legendary, SortedDictionary<string, int> junkItems)
        {
            string legendaryItem = null;

            if (legendary["shards"] >= 250)
            {
                legendary["shards"] -= 250;
                legendaryItem = "Shadowmourne";
            }
            else if (legendary["fragments"] >= 250)
            {
                legendary["fragments"] -= 250;
                legendaryItem = "Valanyr";

            }
            else if (legendary["motes"] >= 250)
            {
                legendary["motes"] -= 250;
                legendaryItem = "Dragonwrath";

            }

            Console.WriteLine($"{legendaryItem} obtained!");

            foreach (var item in legendary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
