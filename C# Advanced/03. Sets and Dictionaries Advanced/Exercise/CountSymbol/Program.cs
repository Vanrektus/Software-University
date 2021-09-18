using System;
using System.Collections.Generic;

namespace CountSymbol
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            SortedDictionary<char, int> countSymbols = new SortedDictionary<char, int>();

            foreach (var currentChar in input)
            {
                if (!countSymbols.ContainsKey(currentChar))
                {
                    countSymbols.Add(currentChar, 1);
                }
                else
                {
                    countSymbols[currentChar]++;
                }
            }

            foreach (var currentSymbol in countSymbols)
            {
                Console.WriteLine($"{currentSymbol.Key}: {currentSymbol.Value} time/s");
            }
        }
    }
}
