using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfPuzzle = 2.60;
            double priceOfDoll = 3;
            double priceOfBear = 4.10;
            double priceOfMinion = 8.20;
            double priceOfTruck = 2;

            double priceOfExcursion = double.Parse(Console.ReadLine());
            double numberOfPuzzles = double.Parse(Console.ReadLine());
            double numberOfDolls = double.Parse(Console.ReadLine());
            double numberOfBears = double.Parse(Console.ReadLine());
            double numberOfMinions = double.Parse(Console.ReadLine());
            double numberOfTrucks = double.Parse(Console.ReadLine());

            double priceOfToys = (numberOfPuzzles * priceOfPuzzle) + (numberOfDolls * priceOfDoll) + (numberOfBears * priceOfBear) + 
                (numberOfMinions * priceOfMinion) + (numberOfTrucks * priceOfTruck);
            bool numberOfToys = (numberOfPuzzles + numberOfDolls + numberOfBears + numberOfMinions + numberOfTrucks) >= 50;
            if (numberOfToys)
            {
                double discount = priceOfToys * 0.25;
                double totalPriceOfToys = priceOfToys - discount;
                double rent = totalPriceOfToys * 0.10;
                double proffit = totalPriceOfToys - rent;
                double moneyLeft = proffit - priceOfExcursion;
                double neededMoney = priceOfExcursion - proffit;
                if (proffit >= priceOfExcursion)
                {
                    Console.WriteLine($"Yes! {moneyLeft:f2} lv left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! {neededMoney:f2} lv needed.");
                }
            }
            else
            {
                double rent2 = priceOfToys * 0.10;
                double proffit2 = priceOfToys - rent2;
                double moneyLeft2 = proffit2 - priceOfExcursion;
                double neededMoney2 = priceOfExcursion - proffit2;
                if (proffit2 >= priceOfExcursion)
                {
                    Console.WriteLine($"Yes! {moneyLeft2:f2} lv left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! {neededMoney2:f2} lv needed.");
                }

            }
        }
    }
}
