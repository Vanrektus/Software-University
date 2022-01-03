using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();

            int unlikedMeals = 0;

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Stop")
                {
                    break;
                }

                string currentGuestName = commands[1];
                string currentMeal = commands[2];

                switch (commands[0])
                {
                    case "Like":
                        if (!guests.ContainsKey(currentGuestName))
                        {
                            guests.Add(currentGuestName, new List<string> { currentMeal });
                        }
                        else
                        {
                            if (!guests[currentGuestName].Contains(currentMeal))
                            {
                                guests[currentGuestName].Add(currentMeal);
                            }
                        }
                        break;
                    case "Unlike":
                        if (guests.ContainsKey(currentGuestName) && guests[currentGuestName].Contains(currentMeal))
                        {
                            guests[currentGuestName].Remove(currentMeal);
                            unlikedMeals++;

                            Console.WriteLine($"{currentGuestName} doesn't like the {currentMeal}.");
                        }
                        else if (guests.ContainsKey(currentGuestName) && !guests[currentGuestName].Contains(currentMeal))
                        {
                            Console.WriteLine($"{currentGuestName} doesn't have the {currentMeal} in his/her collection.");
                        }
                        else if (!guests.ContainsKey(currentGuestName))
                        {
                            Console.WriteLine($"{currentGuestName} is not at the party.");
                        }
                        break;
                }
            }

            foreach (var item in guests.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {string.Join(", ", item.Value)}");
            }

            Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }
    }
}
