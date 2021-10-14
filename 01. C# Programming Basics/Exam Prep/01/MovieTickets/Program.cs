using System;

namespace MovieTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int firstSymbol = a1; firstSymbol <= a2 - 1; firstSymbol++)
            {
                //firstSymbol digits sum (87 -> 8 + 7 = 15)
                //int firstSymboCurrentlNumber = firstSymbol;
                //int firstSymbolSum = 0;
                //while (firstSymboCurrentlNumber != 0)
                //{
                //    firstSymbolSum += firstSymboCurrentlNumber % 10;
                //    firstSymboCurrentlNumber /= 10;
                //}
                for (int secondSymbol = 1; secondSymbol <= n - 1; secondSymbol++)
                {
                    for (int thirdSymbol = 1; thirdSymbol <= n / 2 - 1; thirdSymbol++)
                    {
                        if (firstSymbol % 2 != 0 && (secondSymbol + thirdSymbol + firstSymbol) % 2 != 0)
                        {
                            Console.WriteLine($"{Convert.ToChar(firstSymbol)}-{secondSymbol}{thirdSymbol}{firstSymbol}");
                        }
                    }
                }
            }
        }
    }
}
