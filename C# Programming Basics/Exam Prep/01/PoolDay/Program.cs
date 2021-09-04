using System;

namespace PoolDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            double entryFee = double.Parse(Console.ReadLine());
            double priceOfChair = double.Parse(Console.ReadLine());
            double priceOfUmbrella = double.Parse(Console.ReadLine());

            double totalEntryFee = numberOfPeople * entryFee;
            double wantedChairs = Math.Ceiling(numberOfPeople * 0.75) * priceOfChair;
            double wantedUmbrellas = Math.Ceiling(numberOfPeople * 0.50) * priceOfUmbrella;

            Console.WriteLine($"{totalEntryFee + wantedChairs + wantedUmbrellas:f2} lv.");
        }
    }
}
