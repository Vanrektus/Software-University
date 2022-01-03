using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetForFilm = double.Parse(Console.ReadLine());
            int numberOfStatists = int.Parse(Console.ReadLine());
            double priceOfClothingPerStatist = double.Parse(Console.ReadLine());

            double decor = budgetForFilm * 0.1;
            double totalPriceOfClothing = numberOfStatists * priceOfClothingPerStatist;

            if (numberOfStatists > 150)
            {
                totalPriceOfClothing = totalPriceOfClothing - totalPriceOfClothing * 0.1;
            }

            double totalPriceForFilm = decor + totalPriceOfClothing;

            if (budgetForFilm >= totalPriceForFilm )
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budgetForFilm - totalPriceForFilm:f2} leva left.");
            }
            else if (budgetForFilm < totalPriceForFilm)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totalPriceForFilm - budgetForFilm:f2} leva more.");
            }
        }
    }
}
