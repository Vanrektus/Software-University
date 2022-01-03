using System;

namespace Travelling2
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            double savedMoney = 0.0;

            while (destination != "End")
            {
                double minBudget = double.Parse(Console.ReadLine());
                int money = int.Parse(Console.ReadLine());
                while (savedMoney <= minBudget)
                {
                    savedMoney += money;
                    if (savedMoney >= minBudget)
                    {
                        savedMoney = 0;
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                    money = int.Parse(Console.ReadLine());
                }
                destination = Console.ReadLine();
            }
        }
    }
}
