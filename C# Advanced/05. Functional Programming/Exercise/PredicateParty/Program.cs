using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
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

            Func<List<string>, List<string>, List<string>> doublePeople = (x, y) =>
            {
                foreach (var doubled in y)
                {
                    for (int i = 0; i < x.Count; i++)
                    {
                        if (i < x.Count)
                        {
                            if (x[i] == doubled)
                            {
                                x.Insert(i, doubled);
                                i++;
                            }
                        }
                    }
                }

                return x;
            };

            List<string> filteredGuests = new List<string>();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Party!")
                {
                    break;
                }

                switch (command[1])
                {
                    case "StartsWith":
                        filteredGuests = guests
                            .Where(x => startsWith(x, command[2]))
                            .Distinct()
                            .ToList();
                        break;
                    case "EndsWith":
                        filteredGuests = guests
                            .Where(x => endsWith(x, command[2]))
                            .Distinct()
                            .ToList();
                        break;
                    case "Length":
                        filteredGuests = guests
                            .Where(x => length(x, int.Parse(command[2])))
                            .Distinct()
                            .ToList();
                        break;
                }

                switch (command[0])
                {
                    case "Double":
                        guests = doublePeople(guests, filteredGuests);
                        break;
                    case "Remove":
                        guests = guests
                            .Where(x => !filteredGuests.Contains(x))
                            .ToList();
                        break;
                }
            }

            Console.WriteLine((guests.Count > 0) ? $"{String.Join(", ", guests)} are going to the party!" : "Nobody is going to the party!");
        }
    }
}
