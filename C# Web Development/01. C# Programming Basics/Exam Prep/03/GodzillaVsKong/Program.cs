using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numOfStatists = int.Parse(Console.ReadLine());
            double priceForClothesPerStatist = double.Parse(Console.ReadLine());

            double decor = budget * 0.1;
            double totalPriceForClothes = numOfStatists * priceForClothesPerStatist;

            if (numOfStatists > 150)
            {
                totalPriceForClothes -= totalPriceForClothes * 0.1;
            }

            if ((decor + totalPriceForClothes) <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - (decor + totalPriceForClothes):f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(decor + totalPriceForClothes) - budget:f2} leva more.");
            }
        }
    }
}
