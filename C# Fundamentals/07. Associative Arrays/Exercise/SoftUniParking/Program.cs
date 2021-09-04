using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "register":
                        if (!parking.ContainsKey(command[1]))
                        {
                            parking.Add(command[1], command[2]);

                            Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {command[2]}");
                        }
                        break;
                    case "unregister":
                        if (parking.ContainsKey(command[1]))
                        {
                            parking.Remove(command[1]);

                            Console.WriteLine($"{command[1]} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {command[1]} not found");
                        }
                        break;
                }
            }

            foreach (var item in parking)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
