using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, string, bool> startsWith = (x, y) => x.StartsWith(y);
            Func<string, string, bool> endsWith = (x, y) => x.EndsWith(y);
            Func<string, int, bool> length = (x, y) => x.Length == y;
            Func<string, string, bool> contains = (x, y) => x.Contains(y);

            List<string> result = new List<string>(guests);
            List<string> filtered = new List<string>();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Print")
                {
                    break;
                }

                switch (command[1])
                {
                    case "Starts with":
                        filtered = guests
                            .Where(x => startsWith(x, command[2]))
                            .ToList();
                        break;
                    case "Ends with":
                        filtered = guests
                            .Where(x => endsWith(x, command[2]))
                            .ToList();
                        break;
                    case "Length":
                        filtered = guests
                            .Where(x => length(x, int.Parse(command[2])))
                            .ToList();
                        break;
                    case "Contains":
                        filtered = guests
                            .Where(x => contains(x, command[2]))
                            .ToList();
                        break;
                }

                switch (command[0])
                {
                    case "Add filter":
                        result.RemoveAll(x => filtered.Contains(x));
                        break;
                    case "Remove filter":
                        result.AddRange(filtered);
                        result = result
                            .Distinct()
                            .ToList();
                        break;
                }
            }

            guests.RemoveAll(x => !result.Contains(x));
            Console.WriteLine(string.Join(" ", guests));
        }
    }
}
