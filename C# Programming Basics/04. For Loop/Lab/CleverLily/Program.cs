using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceOfWashingMachine = double.Parse(Console.ReadLine());
            double priceOfToys = double.Parse(Console.ReadLine());

            double totalMoneySaved = 0;
            double moneyPerBirthday = 10;
            int totalNumOfToys = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    totalMoneySaved += moneyPerBirthday;
                    moneyPerBirthday += 10;
                    totalMoneySaved--;
                }
                else
                {
                    totalNumOfToys++;
                }
                
            }

            double totalPriceOfToys = totalNumOfToys * priceOfToys;
            double totalMoneyForWashingMachine = totalPriceOfToys + totalMoneySaved;
            if (totalMoneyForWashingMachine >= priceOfWashingMachine)
            {
                Console.WriteLine($"Yes! {totalMoneyForWashingMachine - priceOfWashingMachine:f2}");
            }
            else
            {
                Console.WriteLine($"No! {priceOfWashingMachine - totalMoneyForWashingMachine:f2}");
            }
        }
    }
}
