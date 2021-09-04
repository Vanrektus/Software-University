using System;

namespace MovieStars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string actorName = Console.ReadLine();

            double leftBudget = budget;

            while (actorName != "ACTION")
            {
                if (actorName.Length <= 15)
                {
                    double payment = double.Parse(Console.ReadLine());
                    leftBudget -= payment;
                }
                else
                {
                    leftBudget -= leftBudget * 0.2;
                }

                if (leftBudget <= 0)
                {
                    Console.WriteLine($"We need {Math.Abs(leftBudget):f2} leva for our actors.");
                    return;
                }

                actorName = Console.ReadLine();
            }

            Console.WriteLine($"We are left with {leftBudget:f2} leva.");
        }
    }
}
