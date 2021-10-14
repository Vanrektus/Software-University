using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfMovie = Console.ReadLine();

            double totalNumOfTickets = 0;
            double studentTickets = 0;
            double standardTickets = 0;
            double kidsTickets = 0;

            while (nameOfMovie != "Finish")
            {
                int freeSeats = int.Parse(Console.ReadLine());
                string typeOfTicket = Console.ReadLine();

                double ticketCounter = 0;

                while (typeOfTicket != "End")
                {
                    ticketCounter++;

                    switch (typeOfTicket)
                    {
                        case "student":
                            totalNumOfTickets++;
                            studentTickets++;
                            break;
                        case "standard":
                            totalNumOfTickets++;
                            standardTickets++;
                            break;
                        case "kid":
                            totalNumOfTickets++;
                            kidsTickets++;
                            break;
                    }

                    if (ticketCounter >= freeSeats)
                    {
                        break;
                    }

                    typeOfTicket = Console.ReadLine();
                }

                Console.WriteLine($"{nameOfMovie} - {ticketCounter / freeSeats * 100:f2}% full.");
                nameOfMovie = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalNumOfTickets}");
            Console.WriteLine($"{studentTickets / totalNumOfTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{standardTickets / totalNumOfTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{kidsTickets / totalNumOfTickets * 100:f2}% kids tickets.");
        }
    }
}
