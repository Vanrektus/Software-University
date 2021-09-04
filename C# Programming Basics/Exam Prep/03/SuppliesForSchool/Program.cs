using System;

namespace SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPens = int.Parse(Console.ReadLine());
            int numOfMarkers = int.Parse(Console.ReadLine());
            double amountOfWhiteBoardCleaner = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double priceOfPens = numOfPens * 5.8;
            double priceOfMarkers = numOfMarkers * 7.2;
            double priceOfCleaner = amountOfWhiteBoardCleaner * 1.2;
            double totalPrice = (priceOfPens + priceOfMarkers + priceOfCleaner) * (100 - discount) / 100;

            Console.WriteLine($"{totalPrice:f3}");
        }
    }
}
