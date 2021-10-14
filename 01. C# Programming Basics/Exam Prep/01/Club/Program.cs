using System;

namespace Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double wantedProfit = double.Parse(Console.ReadLine());
            string nameOfCocktail = Console.ReadLine();

            double totalProfit = 0.0;

            while (nameOfCocktail != "Party!")
            {
                int numOfCocktails = int.Parse(Console.ReadLine());
                double priceOfOrder = nameOfCocktail.Length * numOfCocktails;
                if (priceOfOrder % 2 != 0)
                {
                    priceOfOrder -= priceOfOrder * 0.25;
                }
                totalProfit += priceOfOrder;

                if (totalProfit >= wantedProfit)
                {
                    break;
                }

                nameOfCocktail = Console.ReadLine();
            }

            if (totalProfit >= wantedProfit)
            {
                Console.WriteLine($"Target acquired.");
                Console.WriteLine($"Club income - {totalProfit:f2} leva.");
            }
            else
            {
                Console.WriteLine($"We need {wantedProfit - totalProfit:f2} leva more.");
                Console.WriteLine($"Club income - {totalProfit:f2} leva.");
            }
        }
    }
}
