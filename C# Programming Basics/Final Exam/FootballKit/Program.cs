using System;

namespace FootballKit
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfShirt = double.Parse(Console.ReadLine());
            double wanterSumForBall = double.Parse(Console.ReadLine());

            double priceOfShorts = priceOfShirt * 0.75;
            double priceOfSocks = priceOfShorts * 0.20;
            double priceOfShoes = (priceOfShirt + priceOfShorts) * 2;
            double totalPrice = priceOfShirt + priceOfShorts + priceOfSocks + priceOfShoes;
            double totalPriceWithDiscount = totalPrice - (totalPrice * 0.15);

            if (totalPriceWithDiscount >= wanterSumForBall)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {totalPriceWithDiscount:f2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {wanterSumForBall - totalPriceWithDiscount:f2} lv. more.");
            }

        }
    }
}
