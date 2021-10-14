using System;

namespace OscarsWeekInCinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfMovie = Console.ReadLine();
            string typeOfHall = Console.ReadLine();
            int numOfTickets = int.Parse(Console.ReadLine());

            double totalPrice = 0;

            switch (nameOfMovie)
            {
                case "A Star Is Born":
                    switch (typeOfHall)
                    {
                        case "normal":
                            totalPrice += numOfTickets * 7.5;
                            break;
                        case "luxury":
                            totalPrice += numOfTickets * 10.5;
                            break;
                        case "ultra luxury":
                            totalPrice += numOfTickets * 13.5;
                            break;
                    }
                    break;
                case "Bohemian Rhapsody":
                    switch (typeOfHall)
                    {
                        case "normal":
                            totalPrice += numOfTickets * 7.35;
                            break;
                        case "luxury":
                            totalPrice += numOfTickets * 9.45;
                            break;
                        case "ultra luxury":
                            totalPrice += numOfTickets * 12.75;
                            break;
                    }
                    break;
                case "Green Book":
                    switch (typeOfHall)
                    {
                        case "normal":
                            totalPrice += numOfTickets * 8.15;
                            break;
                        case "luxury":
                            totalPrice += numOfTickets * 10.25;
                            break;
                        case "ultra luxury":
                            totalPrice += numOfTickets * 13.25;
                            break;
                    }
                    break;
                case "The Favourite":
                    switch (typeOfHall)
                    {
                        case "normal":
                            totalPrice += numOfTickets * 8.75;
                            break;
                        case "luxury":
                            totalPrice += numOfTickets * 11.55;
                            break;
                        case "ultra luxury":
                            totalPrice += numOfTickets * 13.95;
                            break;
                    }
                    break;
            }
            Console.WriteLine($"{nameOfMovie} -> {totalPrice:f2} lv.");
        }
    }
}
