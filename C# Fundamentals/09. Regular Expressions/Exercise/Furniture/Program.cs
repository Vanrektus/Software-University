using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+|\d+\.\d+)!(?<quantity>\d+)";

            List<string> furniture = new List<string>();

            double totalPrice = 0.0;

            while (input != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    furniture.Add(match.Groups["name"].Value);

                    if (double.Parse(match.Groups["price"].Value) != 0 && int.Parse(match.Groups["quantity"].Value) != 0)
                    {
                        totalPrice += double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            if (furniture.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furniture));
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
