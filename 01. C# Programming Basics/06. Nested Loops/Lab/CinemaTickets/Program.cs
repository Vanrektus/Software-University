using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            double totalTickets = 0;
            double studentTickets = 0;
            double standardTickets = 0;
            double kidsTickets = 0;

            while (movieName != "Finish")
            {
                double freeSeats = int.Parse(Console.ReadLine());
                string typeOfTicket = Console.ReadLine();
                double currentMovieTickets = 0;

                while (typeOfTicket != "End")
                {
                    totalTickets++;
                    currentMovieTickets++;
                    switch (typeOfTicket)
                    {
                        case "student":
                            studentTickets++;
                            break;
                        case "standard":
                            standardTickets++;
                            break;
                        case "kid":
                            kidsTickets++;
                            break;
                    }
                    if (currentMovieTickets == freeSeats)
                    {
                        break;
                    }
                    typeOfTicket = Console.ReadLine();
                }
                Console.WriteLine($"{movieName} - {currentMovieTickets / freeSeats * 100:f2}% full.");
                currentMovieTickets = 0;
                movieName = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentTickets / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{standardTickets / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{kidsTickets / totalTickets * 100:f2}% kids tickets.");
        }
    }
}
