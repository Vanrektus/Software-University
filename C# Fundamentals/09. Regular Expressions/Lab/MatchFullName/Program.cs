using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection match = Regex.Matches(input, pattern);

            foreach (Match name in match)
            {
                Console.Write($"{name.Value} ");
            }

            Console.WriteLine();
        }
    }
}
