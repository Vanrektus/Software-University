using System;

namespace EasterCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBreads = int.Parse(Console.ReadLine());

            int totalPointsOfCurrentChef = 0;
            int biggestScore = int.MinValue;
            string chefWithBiggestScore = "";

            for (int i = 1; i <= numberOfBreads; i++)
            {
                string nameOfChef = Console.ReadLine();
                string input = Console.ReadLine();
                while (input != "Stop")
                {
                    int points = int.Parse(input);
                    totalPointsOfCurrentChef += points;

                    input = Console.ReadLine();
                }
                Console.WriteLine($"{nameOfChef} has {totalPointsOfCurrentChef} points.");
                if (totalPointsOfCurrentChef > biggestScore)
                {
                    Console.WriteLine($"{nameOfChef} is the new number 1!");
                    chefWithBiggestScore = nameOfChef;
                    biggestScore = totalPointsOfCurrentChef;
                }
                totalPointsOfCurrentChef = 0;
            }
            Console.WriteLine($"{chefWithBiggestScore} won competition with {biggestScore} points!");
        }
    }
}
