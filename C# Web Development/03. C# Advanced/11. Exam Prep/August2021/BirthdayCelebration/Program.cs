using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

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
