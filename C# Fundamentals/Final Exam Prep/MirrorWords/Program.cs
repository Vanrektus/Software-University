using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(#|@){1}(?<firstWord>[A-Za-z]{3,})\1{2}(?<secondWord>[A-Za-z]{3,})\1{1}";

            MatchCollection regex = Regex.Matches(input, pattern);

            Dictionary<string, string> mirrorWords = new Dictionary<string, string>();

            if (regex.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");

                return;
            }

            foreach (Match item in regex)
            {
                char[] charArray = item.Groups["secondWord"].Value.ToCharArray();
                Array.Reverse(charArray);
                string reversedWord = new string(charArray);

                if (item.Groups["firstWord"].Value == reversedWord)
                {
                    mirrorWords.Add(item.Groups["firstWord"].Value, item.Groups["secondWord"].Value);
                }
            }

            Console.WriteLine($"{regex.Count} word pairs found!");

            if (mirrorWords.Count > 0)
            {
                Console.WriteLine("The mirror words are:");

                int count = 1;

                foreach (var item in mirrorWords)
                {
                    if (count != mirrorWords.Count)
                    {
                        Console.Write($"{item.Key} <=> {item.Value}, ");
                    }
                    else
                    {
                        Console.Write($"{item.Key} <=> {item.Value}");
                    }

                    count++;
                }
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
