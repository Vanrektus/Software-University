using System;

namespace AddBags
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfBagsOver20Kgs = double.Parse(Console.ReadLine());
            double weightOfBags = double.Parse(Console.ReadLine());
            int daysUntillTrip = int.Parse(Console.ReadLine());
            int numberOfBags = int.Parse(Console.ReadLine());

            double totalPriceOfBags = 0;

            if (weightOfBags < 10)
            {
                totalPriceOfBags = priceOfBagsOver20Kgs * 0.2;
            }
            else if (weightOfBags >= 10 && weightOfBags <= 20)
            {
                totalPriceOfBags = priceOfBagsOver20Kgs * 0.5;
            }
            else if (weightOfBags > 20)
            {
                totalPriceOfBags = priceOfBagsOver20Kgs;
            }

            if (daysUntillTrip < 7)
            {
                totalPriceOfBags += totalPriceOfBags * 0.4; 
            }
            else if (daysUntillTrip >= 7 && daysUntillTrip <= 30)
            {
                totalPriceOfBags += totalPriceOfBags * 0.15;
            }
            else if (daysUntillTrip > 30)
            {
                totalPriceOfBags += totalPriceOfBags * 0.1;
            }

            Console.WriteLine($"The total price of bags is: {totalPriceOfBags * numberOfBags:f2} lv.");
        }
    }
}
