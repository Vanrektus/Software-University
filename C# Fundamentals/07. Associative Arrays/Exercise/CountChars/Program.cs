using System;
using System.Collections.Generic;

namespace CountChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> countChars = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    continue;
                }

                if (!countChars.ContainsKey(input[i]))
                {
                    countChars.Add(input[i], 1);
                }
                else
                {
                    countChars[input[i]]++;
                }
            }

            foreach (var item in countChars)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
