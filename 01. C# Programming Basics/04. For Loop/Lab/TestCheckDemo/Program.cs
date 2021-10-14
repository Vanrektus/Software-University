using System;

namespace TestCheckDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceOfWashingMachine = double.Parse(Console.ReadLine());
            double priceOfToys = double.Parse(Console.ReadLine());

            double sum = 0;
            double plusMoney = 10;
            int totalNumberOfToys = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 != 0)
                {
                    totalNumberOfToys++;
                }
                else
                {
                    sum += plusMoney;
                    plusMoney += 10;
                    sum--;
                }
            }
            double totalPriceOfToys = totalNumberOfToys * priceOfToys;
            double totalMoneySaved = totalPriceOfToys + sum;
            if (totalMoneySaved >= priceOfWashingMachine)
            {
                Console.WriteLine($"Yes! {totalMoneySaved - priceOfWashingMachine:f2}");
            }
            else
            {
                Console.WriteLine($"No! {priceOfWashingMachine - totalMoneySaved:f2}");
            }
        }
    }
}
