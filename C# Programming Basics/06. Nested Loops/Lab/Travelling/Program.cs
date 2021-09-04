using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double savedMoney = 0.0;
                double minBudget = double.Parse(Console.ReadLine());
                while (savedMoney <= minBudget)
                {
                    savedMoney += double.Parse(Console.ReadLine());
                    if (savedMoney >= minBudget)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                }
                destination = Console.ReadLine();
            }
        }
    }
}
