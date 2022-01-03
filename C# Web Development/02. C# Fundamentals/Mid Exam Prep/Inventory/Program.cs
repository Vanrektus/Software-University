using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine()
                .Split(", ")
                .ToList();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Craft!")
                {
                    break;
                }

                switch (input[0])
                {
                    case "Collect":
                        if (inventory.Contains(input[1]) == false)
                        {
                            inventory.Add(input[1]);
                        }
                        break;
                    case "Drop":
                        inventory.Remove(input[1]);
                        break;
                    case "Combine Items":
                        string[] combineItems = input[1]
                            .Split(':', StringSplitOptions.RemoveEmptyEntries);

                        if (inventory.Contains(combineItems[0]))
                        {
                            for (int i = 0; i < inventory.Count; i++)
                            {
                                if (inventory[i] == combineItems[0])
                                {
                                    inventory.Insert(i + 1, combineItems[1]);
                                    break;
                                }
                            }
                        }
                        break;
                    case "Renew":
                        if (inventory.Contains(input[1]))
                        {
                            inventory.Add(input[1]);
                            inventory.Remove(input[1]);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}
