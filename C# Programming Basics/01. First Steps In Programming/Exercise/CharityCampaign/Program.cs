using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfCampaign = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());
            double cakePrice = 45;
            double wafflePrice = 5.8;
            double pancakePrice = 3.2;
            double totalCakes = cakes * cakePrice;
            double totalWaffles = waffles * wafflePrice;
            double totalPancakes = pancakes * pancakePrice;
            double totalSumPerDay = (totalCakes + totalPancakes + totalWaffles) * bakers;
            double totalCharitySum = totalSumPerDay * daysOfCampaign;
            double TotalCharityCampaignSum = totalCharitySum - totalCharitySum / 8;
            Console.WriteLine(TotalCharityCampaignSum);
        }
    }
}
