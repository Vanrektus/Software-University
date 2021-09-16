using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            bool partyStared = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (input == "PARTY")
                {
                    partyStared = true;
                }

                if (!partyStared)
                {
                    if (char.IsNumber(char.Parse(input.Substring(0, 1))))
                    {
                        vipGuests.Add(input);
                    }
                    else
                    {
                        regularGuests.Add(input);
                    }
                }
                else
                {
                    if (char.IsNumber(char.Parse(input.Substring(0, 1))))
                    {
                        vipGuests.Remove(input);
                    }
                    else
                    {
                        regularGuests.Remove(input);
                    }
                }
            }

            Console.WriteLine(vipGuests.Count + regularGuests.Count);

            foreach (var currentGuest in vipGuests)
            {
                Console.WriteLine(currentGuest);
            }

            foreach (var currentGuest in regularGuests)
            {
                Console.WriteLine(currentGuest);
            }
        }
    }
}
