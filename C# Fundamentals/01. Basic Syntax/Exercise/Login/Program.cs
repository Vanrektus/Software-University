using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string correctPassword = "";
            int wrongPasswordCounter = 0;

            for (int currentChar = username.Length - 1; currentChar > -1; currentChar--)
            {
                correctPassword += username[currentChar];
            }

            while (password != correctPassword)
            {
                if (password != correctPassword)
                {

                    wrongPasswordCounter++;
                    if (wrongPasswordCounter == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        return;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
                password = Console.ReadLine();
            }

            Console.WriteLine($"User {username} logged in.");
        }
    }
}
