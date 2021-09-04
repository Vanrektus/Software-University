using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double totalMoney = 0;

            while (input != "NoMoreMoney")
            {
                double moneyToAdd = double.Parse(input);
                if (moneyToAdd < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {moneyToAdd:f2}");
                totalMoney += moneyToAdd;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {totalMoney:f2}");
        }
    }
}
