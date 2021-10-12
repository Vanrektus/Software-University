using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] guestsArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> guests = new Queue<int>(guestsArray);
            int[] platesArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> plates = new Stack<int>(platesArray);

            int wastedGramsOfFood = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                int currentGuest = guests.Peek();

                while (currentGuest > 0)
                {
                    if (currentGuest > plates.Peek())
                    {
                        currentGuest -= plates.Pop();
                    }
                    else
                    {
                        wastedGramsOfFood += plates.Pop() - currentGuest;
                        guests.Dequeue();
                        break;
                    }
                }
            }

            Console.WriteLine(guests.Count <= 0 ? $"Plates: {plates.Sum()}" : $"Guests: {string.Join(" ", guests)}");
            Console.WriteLine($"Wasted grams of food: {wastedGramsOfFood}");
        }
    }
}
