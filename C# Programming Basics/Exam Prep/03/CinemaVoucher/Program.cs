using System;

namespace CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfVoucher = int.Parse(Console.ReadLine());
            string typeOfBuy = Console.ReadLine();

            double leftVoucher = priceOfVoucher;
            int ticketCounter = 0;
            int otherCounter = 0;

            while (typeOfBuy != "End")
            {
                if (typeOfBuy.Length > 8)
                {
                    if ((typeOfBuy[0] + typeOfBuy[1]) <= leftVoucher)
                    {
                        leftVoucher -= typeOfBuy[0] + typeOfBuy[1];
                        ticketCounter++;
                    }
                    else
                    {
                        Console.WriteLine(ticketCounter);
                        Console.WriteLine(otherCounter);
                        return;
                    }
                }
                else
                {
                    if (typeOfBuy[0] <= leftVoucher)
                    {
                        leftVoucher -= typeOfBuy[0];
                        otherCounter++;
                    }
                    else
                    {
                        Console.WriteLine(ticketCounter);
                        Console.WriteLine(otherCounter);
                        return;
                    }
                }
                typeOfBuy = Console.ReadLine();
            }
            Console.WriteLine(ticketCounter);
            Console.WriteLine(otherCounter);
        }
    }
}
