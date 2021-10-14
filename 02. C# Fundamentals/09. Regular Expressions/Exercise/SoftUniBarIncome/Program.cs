using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%,]*\|(?<quantity>\d+)\|[^|$%,]*?(?<price>\d+|\d+\.\d+)\$";

            double totalIncome = 0.0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    Console.WriteLine($"{match.Groups["customer"].Value}: " +
                        $"{match.Groups["product"].Value} - " +
                        $"{int.Parse(match.Groups["quantity"].Value) * double.Parse(match.Groups["price"].Value):f2}");

                    totalIncome += int.Parse(match.Groups["quantity"].Value) * double.Parse(match.Groups["price"].Value);
                }
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
