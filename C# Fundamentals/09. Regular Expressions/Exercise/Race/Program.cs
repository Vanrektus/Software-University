using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allNames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string namePattern = @"[A-Za-z]+";
            string distancePattern = @"\d";

            Dictionary<string, int> racers = new Dictionary<string, int>();

            RacersAdd(allNames, racers);

            RacersInfoAdd(namePattern, distancePattern, racers);

            PrintOutput(racers);
        }

        static void RacersAdd(string[] allNames, Dictionary<string, int> racers)
        {
            foreach (var currentName in allNames)
            {
                if (!racers.ContainsKey(currentName))
                {
                    racers.Add(currentName, 0);
                }
            }
        }

        static void RacersInfoAdd(string namePattern, string distancePattern, Dictionary<string, int> racers)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                StringBuilder name = new StringBuilder();
                int distance = 0;

                MatchCollection nameMatch = Regex.Matches(input, namePattern);
                MatchCollection distanceMatch = Regex.Matches(input, distancePattern);

                foreach (Match letter in nameMatch)
                {
                    name.Append(letter.Value);
                }

                if (!racers.ContainsKey(name.ToString()))
                {
                    continue;
                }

                foreach (Match km in distanceMatch)
                {
                    distance += int.Parse(km.Value);
                }

                racers[name.ToString()] += distance;
            }
        }

        static void PrintOutput(Dictionary<string, int> racers)
        {
            racers = racers.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"1st place: {racers.Keys.ElementAt(0)}");
            Console.WriteLine($"2nd place: {racers.Keys.ElementAt(1)}");
            Console.WriteLine($"3rd place: {racers.Keys.ElementAt(2)}");
        }
    }
}
