using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numOfVideos = int.Parse(Console.ReadLine());
            int numOfProcessors = int.Parse(Console.ReadLine());
            int numOfRams = int.Parse(Console.ReadLine());

            double priceOfVideos = numOfVideos * 250;
            double priceOfProcessors = numOfProcessors * (priceOfVideos * 0.35);
            double priceOfRams = numOfRams * (priceOfVideos * 0.10);
            double totalPrice = priceOfVideos + priceOfProcessors + priceOfRams;

            if (numOfVideos > numOfProcessors)
            {
                totalPrice -= totalPrice * 0.15;
            }

            if (budget >= totalPrice)
            {
                Console.WriteLine($"You have {budget - totalPrice:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:f2} leva more!");
            }
        }
    }
}
