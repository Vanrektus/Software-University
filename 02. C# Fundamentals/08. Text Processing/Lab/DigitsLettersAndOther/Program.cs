using System;
using System.Collections.Generic;

namespace DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<char>> characters = new Dictionary<string, List<char>>();

            characters.Add("Digits", new List<char>());
            characters.Add("Letters", new List<char>());
            characters.Add("OtherChars", new List<char>());

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    characters["Letters"].Add(input[i]);
                }
                else if (char.IsDigit(input[i]))
                {
                    characters["Digits"].Add(input[i]);
                }
                else
                {
                    characters["OtherChars"].Add(input[i]);
                }
            }

            foreach (var item in characters)
            {
                Console.WriteLine(string.Join("", item.Value));
            }
        }
    }
}
