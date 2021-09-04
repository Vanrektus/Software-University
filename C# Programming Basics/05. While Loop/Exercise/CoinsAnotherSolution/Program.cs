using System;

namespace CoinsAnotherSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());

            double convertedChange = change * 100;
            int cents = (int)convertedChange;

            int changeCoins = 0;

            int reminder = cents % 200;
            changeCoins += cents / 200;
            cents = reminder;

             reminder = cents % 100;
            changeCoins += cents / 100;
            cents = reminder;

             reminder = cents % 50;
            changeCoins += cents / 50;
            cents = reminder;

             reminder = cents % 20;
            changeCoins += cents / 20;
            cents = reminder;

             reminder = cents % 10;
            changeCoins += cents / 10;
            cents = reminder;

             reminder = cents % 5;
            changeCoins += cents / 5;
            cents = reminder;

             reminder = cents % 2;
            changeCoins += cents / 2;
            cents = reminder;

             reminder = cents % 1;
            changeCoins += cents / 1;
            cents = reminder;

            Console.WriteLine(changeCoins);
        }
    }
}
