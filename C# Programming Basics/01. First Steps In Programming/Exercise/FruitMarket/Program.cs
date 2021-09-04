using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine());
            double bananaQuantity = double.Parse(Console.ReadLine());
            double orangeQuantity = double.Parse(Console.ReadLine());
            double raspberryQuantity = double.Parse(Console.ReadLine());
            double strawberryQuantity = double.Parse(Console.ReadLine());
            double raspberryPrice = strawberryPrice / 2;
            double orangePrice = raspberryPrice - (0.4 * raspberryPrice);
            double bananaPrice = raspberryPrice - (0.8 * raspberryPrice);
            double raspberryTotal = raspberryQuantity * raspberryPrice;
            double orangeTotal = orangeQuantity * orangePrice;
            double bananaTotal = bananaPrice * bananaQuantity;
            double strawberryTotal = strawberryPrice * strawberryQuantity;
            double totalPrice = raspberryTotal + orangeTotal + bananaTotal + strawberryTotal;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
