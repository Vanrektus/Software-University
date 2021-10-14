using System;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfPlayer = Console.ReadLine();

            string bestPlayer = "";
            int biggestScore = int.MinValue;

            while (nameOfPlayer != "END")
            {
                int goals = int.Parse(Console.ReadLine());
                if (goals > biggestScore)
                {
                    bestPlayer = nameOfPlayer;
                    biggestScore = goals;
                }
                if (goals >= 10)
                {
                    break;
                }
                nameOfPlayer = Console.ReadLine();
            }

            Console.WriteLine($"{bestPlayer} is the best player!");
            if (biggestScore >= 3)
            {
                Console.WriteLine($"He has scored {biggestScore} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {biggestScore} goals.");
            }
        }
    }
}
