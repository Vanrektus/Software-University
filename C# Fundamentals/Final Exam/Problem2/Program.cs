using System;
using System.Text.RegularExpressions;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\|{1})(?<name>[A-Z]{4,})\1:(\#{1})(?<title>[A-Za-z]+\s[A-Za-z]+)\2";

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();

                Match regex = Regex.Match(input, pattern);

                if (regex.Success)
                {
                    Console.WriteLine($"{regex.Groups["name"].Value}, The {regex.Groups["title"].Value}");
                    Console.WriteLine($">> Strength: {regex.Groups["name"].Length}");
                    Console.WriteLine($">> Armor: {regex.Groups["title"].Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
