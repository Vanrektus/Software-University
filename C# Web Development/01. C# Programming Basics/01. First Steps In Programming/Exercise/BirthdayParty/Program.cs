using System;

namespace BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());
            double cakePrice = rent * 20 / 100;
            double drinksPrice = cakePrice - 45 * cakePrice / 100;
            double animatorPrice = rent / 3;
            double total = rent + cakePrice + drinksPrice + animatorPrice;
            Console.WriteLine(total);
        }
    }
}
