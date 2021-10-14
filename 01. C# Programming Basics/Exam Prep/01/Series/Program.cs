using System;

namespace Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfSeries = int.Parse(Console.ReadLine());

            double leftBudget = budget;

            for (int i = 1; i <= numberOfSeries; i++)
            {
                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());

                switch (name)
                {
                    case "Thrones":
                        leftBudget -= price * 0.5;
                        break;
                    case "Lucifer":
                        leftBudget -= price * 0.6;
                        break;
                    case "Protector":
                        leftBudget -= price * 0.7;
                        break;
                    case "TotalDrama":
                        leftBudget -= price * 0.8;
                        break;
                    case "Area":
                        leftBudget -= price * 0.9;
                        break;
                    default:
                        leftBudget -= price;
                        break;
                }
            }
            if (leftBudget < 0)
            {
                Console.WriteLine($"You need {Math.Abs(leftBudget):f2} lv. more to buy the series!");
            }
            else
            {
                Console.WriteLine($"You bought all the series and left with {leftBudget:f2} lv.");
            }
        }
    }
}
