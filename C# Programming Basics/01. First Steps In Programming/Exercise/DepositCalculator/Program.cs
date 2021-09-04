using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int depositAmountPerMonth = int.Parse(Console.ReadLine());
            double interestPercent = double.Parse(Console.ReadLine());
            double interest = depositSum * interestPercent / 100;
            double interestForOneMonth = interest / 12;
            double total = depositSum + (depositAmountPerMonth * interestForOneMonth);
            Console.WriteLine(total);
        }
    }
}
