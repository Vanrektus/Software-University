using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(:{2}|\*{2})([A-Z][a-z]{2,})\1";
            string coolThresholdPattern = @"\d";

            string input = Console.ReadLine();

            BigInteger coolThreshold = 1;

            List<string> coolEmojis = new List<string>();

            MatchCollection emojisRegex = Regex.Matches(input, pattern);
            MatchCollection coolThresholdRegex = Regex.Matches(input, coolThresholdPattern);

            foreach (Match currentNumber in coolThresholdRegex)
            {
                coolThreshold *= int.Parse(currentNumber.Value);
            }

            foreach (Match currentEmoji in emojisRegex)
            {
                int coolSum = 0;

                foreach (char currentChar in currentEmoji.Value)
                {
                    if (currentChar == ':' || currentChar == '*')
                    {
                        continue;
                    }

                    coolSum += currentChar;
                }

                if (coolSum > coolThreshold)
                {
                    coolEmojis.Add(currentEmoji.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");

            Console.WriteLine($"{emojisRegex.Count} emojis found in the text. The cool ones are:");

            Console.WriteLine(string.Join(Environment.NewLine, coolEmojis));
        }
    }
}
