using System;
using System.Linq;

namespace MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonRooms = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int health = 100;
            int bitcoins = 0;
            bool isDead = false;

            for (int i = 0; i < dungeonRooms.Length; i++)
            {
                string[] currentRoom = dungeonRooms[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (currentRoom[0])
                {
                    case "potion":
                        int oldHealth = health;

                        health += int.Parse(currentRoom[1]);

                        if (health > 100)
                        {
                            health -= health - 100;
                        }

                        Console.WriteLine($"You healed for {health - oldHealth} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        bitcoins += int.Parse(currentRoom[1]);

                        Console.WriteLine($"You found {int.Parse(currentRoom[1])} bitcoins.");
                        break;
                    default:
                        health -= int.Parse(currentRoom[1]);

                        if (health <= 0)
                        {
                            Console.WriteLine($"You died! Killed by {currentRoom[0]}.");
                            Console.WriteLine($"Best room: {i + 1}");
                            isDead = true;
                        }
                        else
                        {
                            Console.WriteLine($"You slayed {currentRoom[0]}.");
                        }
                        break;
                }

                if (isDead == true)
                {
                    break;
                }
            }

            if (health > 0)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
