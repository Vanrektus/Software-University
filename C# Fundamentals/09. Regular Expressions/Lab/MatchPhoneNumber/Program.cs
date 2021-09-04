using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(\+359)(\s|-){1}[2]{1}\2{1}[\d]{3}\2{1}[\d]{4}\b";

            MatchCollection match = Regex.Matches(input, pattern);

            string[] matches = new string[match.Count];
            int counter = 0;

            foreach (Match phone in match)
            {
                matches[counter] = phone.Value;

                counter++;
            }

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
