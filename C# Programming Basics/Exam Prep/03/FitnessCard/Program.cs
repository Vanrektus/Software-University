using System;

namespace FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string sex = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double neededMoney = 0;

            switch (sport)
            {
                case "Gym":
                    if (sex == "m")
                    {
                        neededMoney += 42;
                    }
                    else if (sex == "f")
                    {
                        neededMoney += 35;
                    }
                    break;
                case "Boxing":
                    if (sex == "m")
                    {
                        neededMoney += 41;
                    }
                    else if (sex == "f")
                    {
                        neededMoney += 37;
                    }
                    break;
                case "Yoga":
                    if (sex == "m")
                    {
                        neededMoney += 45;
                    }
                    else if (sex == "f")
                    {
                        neededMoney += 42;
                    }
                    break;
                case "Zumba":
                    if (sex == "m")
                    {
                        neededMoney += 34;
                    }
                    else if (sex == "f")
                    {
                        neededMoney += 31;
                    }
                    break;
                case "Dances":
                    if (sex == "m")
                    {
                        neededMoney += 51;
                    }
                    else if (sex == "f")
                    {
                        neededMoney += 53;
                    }
                    break;
                case "Pilates":
                    if (sex == "m")
                    {
                        neededMoney += 39;
                    }
                    else if (sex == "f")
                    {
                        neededMoney += 37;
                    }
                    break;
            }

            if (age <= 19)
            {
                neededMoney -= neededMoney * 0.2;
            }

            if (budget >= neededMoney)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${neededMoney - budget:f2} more.");
            }
        }
    }
}
