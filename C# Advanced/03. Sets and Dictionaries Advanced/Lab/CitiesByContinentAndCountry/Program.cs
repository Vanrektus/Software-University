using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> citiesByCC = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Revision")
                {
                    break;
                }

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!citiesByCC.ContainsKey(continent))
                {
                    citiesByCC.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!citiesByCC[continent].ContainsKey(country))
                {
                    citiesByCC[continent].Add(country, new List<string>());
                }

                citiesByCC[continent][country].Add(city);
            }

            foreach (var currentContinent in citiesByCC)
            {
                Console.WriteLine($"{currentContinent.Key}:");

                foreach (var currentCountry in currentContinent.Value)
                {
                    Console.WriteLine($"{currentCountry.Key} -> {string.Join(", ", currentCountry.Value)}");
                }
            }
        }
    }
}
