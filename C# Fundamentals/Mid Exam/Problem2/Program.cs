using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friendsList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int blacklisted = 0;
            int lostContacts = 0;

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Report")
                {
                    break;
                }

                switch (input[0])
                {
                    case "Blacklist":
                        if (friendsList.Any(x => x == input[1]))
                        {
                            for (int i = 0; i < friendsList.Count; i++)
                            {
                                if (friendsList[i] == input[1])
                                {
                                    Console.WriteLine($"{input[1]} was blacklisted.");

                                    friendsList.Insert(i, "Blacklisted");
                                    friendsList.RemoveAt(i + 1);
                                    blacklisted++;

                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{input[1]} was not found.");
                        }
                        break;
                    case "Error":
                        if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < friendsList.Count)
                        {
                            for (int i = 0; i < friendsList.Count; i++)
                            {
                                if (i == int.Parse(input[1]) && friendsList[i] != "Lost" && friendsList[i] != "Blacklisted")
                                {
                                    Console.WriteLine($"{friendsList[i]} was lost due to an error.");

                                    friendsList.Insert(i, "Lost");
                                    friendsList.RemoveAt(i + 1);
                                    lostContacts++;

                                    break;
                                }
                            }
                        }
                        break;
                    case "Change":
                        if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < friendsList.Count)// && !friendsList.Any(x => x == input[2]))
                        {
                            for (int i = 0; i < friendsList.Count; i++)
                            {
                                if (i == int.Parse(input[1]) && friendsList[i] != "Blacklisted" && friendsList[i] != "Lost")
                                {
                                    Console.WriteLine($"{friendsList[i]} changed his username to {input[2]}.");

                                    friendsList.Insert(i, input[2]);
                                    friendsList.RemoveAt(i + 1);

                                    break;
                                }
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"Blacklisted names: {blacklisted}");
            Console.WriteLine($"Lost names: {lostContacts}");

            if (friendsList.Count > 0)
            {
                Console.WriteLine(string.Join(' ', friendsList));
            }
        }
    }
}
