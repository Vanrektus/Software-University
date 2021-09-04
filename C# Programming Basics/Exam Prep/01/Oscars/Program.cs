using System;

namespace Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfActor = Console.ReadLine();
            double AcademyPoints = double.Parse(Console.ReadLine());
            int numberOfJudges = int.Parse(Console.ReadLine());

            double totalPoints = AcademyPoints;

            for (int i = 1; i <= numberOfJudges; i++)
            {
                string nameOfJudge = Console.ReadLine();
                double JudgePoints = double.Parse(Console.ReadLine());

                totalPoints += (nameOfJudge.Length * JudgePoints) / 2;

                if (totalPoints > 1250.5)
                {
                    break;
                }
            }

            if (totalPoints > 1250.5)
            {
                Console.WriteLine($"Congratulations, {nameOfActor} got a nominee for leading role with {totalPoints:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {nameOfActor} you need {1250.5 - totalPoints:f1} more!");
            }
        }
    }
}
