using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());

            double convertedChange = change * 100;
            int cents = (int)convertedChange;

            int changeCoins = 0;

            while (cents > 0)
            {
                if (cents - 200 >= 0)
                {
                    changeCoins++;
                    cents -= 200;
                }
                else if (cents - 100 >= 0)
                {
                    changeCoins++;
                    cents -= 100;
                }
                else if (cents - 50 >= 0)
                {
                    changeCoins++;
                    cents -= 50;
                }
                else if (cents - 20 >= 0)
                {
                    changeCoins++;
                    cents -= 20;
                }
                else if (cents - 10 >= 0)
                {
                    changeCoins++;
                    cents -= 10;
                }
                else if (cents - 5 >= 0)
                {
                    changeCoins++;
                    cents -= 5;
                }
                else if (cents - 2 >= 0)
                {
                    changeCoins++;
                    cents -= 2;
                }
                else if (cents - 1 >= 0)
                {
                    changeCoins++;
                    cents -= 1;
                }
            }
            Console.WriteLine(changeCoins);

        }
    }
}
