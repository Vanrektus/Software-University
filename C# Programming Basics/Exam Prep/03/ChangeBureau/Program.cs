using System;

namespace ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfBitcoins = int.Parse(Console.ReadLine());
            double numOfChineseCurrency = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            double priceOfBitcoinBgn = numOfBitcoins * 1168;
            double priceOfChineseCurrencyUsd = numOfChineseCurrency * 0.15;
            double priceOfChineseCurrencyBgn = priceOfChineseCurrencyUsd * 1.76;
            double moneyInEuro = (priceOfBitcoinBgn + priceOfChineseCurrencyBgn) / 1.95;
            double totalMoney = moneyInEuro - moneyInEuro * (commission / 100);

            Console.WriteLine($"{totalMoney:f2}");
        }
    }
}
