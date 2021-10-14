using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            FillWardrobe(n, wardrobe);

            PrintOutput(wardrobe);
        }

        private static void FillWardrobe(int n, Dictionary<string, Dictionary<string, int>> wardrobe)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string currentColor = input[0];
                string[] clothesSplit = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(currentColor))
                {
                    wardrobe.Add(currentColor, new Dictionary<string, int>());
                }

                foreach (var currentClothing in clothesSplit)
                {
                    if (!wardrobe[currentColor].ContainsKey(currentClothing))
                    {
                        wardrobe[currentColor].Add(currentClothing, 1);
                    }
                    else
                    {
                        wardrobe[currentColor][currentClothing]++;
                    }
                }
            }
        }

        private static void PrintOutput(Dictionary<string, Dictionary<string, int>> wardrobe)
        {
            string[] lookForClothing = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var currentColor in wardrobe)
            {
                Console.WriteLine($"{currentColor.Key} clothes:");

                foreach (var currentClothing in currentColor.Value)
                {
                    if (currentColor.Key == lookForClothing[0] && currentClothing.Key == lookForClothing[1])
                    {
                        Console.WriteLine($"* {currentClothing.Key} - {currentClothing.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {currentClothing.Key} - {currentClothing.Value}");
                    }
                }
            }
        }
    }
}
