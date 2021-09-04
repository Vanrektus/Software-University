using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoneyForExcursion = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            int currentDay = 0;
            int consistentSpendDays = 0;

            while (consistentSpendDays != 5)
            {
                string typeOfOperation = Console.ReadLine();
                double moneySavedOrSpent = double.Parse(Console.ReadLine());
                currentDay++;
                if (typeOfOperation == "spend")
                {
                    consistentSpendDays++;
                    if (moneySavedOrSpent > availableMoney)
                    {
                        availableMoney -= availableMoney;
                    }
                    else
                    {
                        availableMoney -= moneySavedOrSpent;
                    }
                }
                else if (typeOfOperation == "save")
                {
                    consistentSpendDays = 0;
                    availableMoney += moneySavedOrSpent;
                }
                if (availableMoney >= neededMoneyForExcursion)
                {
                    break;
                }
            }
            if (availableMoney >= neededMoneyForExcursion)
            {
                Console.WriteLine($"You saved the money for {currentDay} days.");
            }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(currentDay);
            }

        }
    }
}
