using System;

namespace AgencyProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfCompany = Console.ReadLine();
            int adultTickets = int.Parse(Console.ReadLine());
            int kidsTickets = int.Parse(Console.ReadLine());
            double adultTicketPrice = double.Parse(Console.ReadLine());
            double serviceFee = double.Parse(Console.ReadLine());

            double kidsTicketPrice = adultTicketPrice * 0.3;
            adultTicketPrice += serviceFee;
            kidsTicketPrice += serviceFee;
            double totalPriceOfTickets = (adultTickets * adultTicketPrice) + (kidsTickets * kidsTicketPrice);

            Console.WriteLine($"The profit of your agency from {nameOfCompany} tickets is {totalPriceOfTickets * 0.2:f2} lv.");
        }
    }
}
