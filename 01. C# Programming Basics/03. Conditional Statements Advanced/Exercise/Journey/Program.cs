using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double price = 0.0;
            string destination = "";
            string placeToStay = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        placeToStay = "Camp";
                        price = budget * 0.3;
                        break;
                    case "winter":
                        placeToStay = "Hotel";
                        price = budget * 0.7;
                        break;
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        placeToStay = "Camp";
                        price = budget * 0.4;
                        break;
                    case "winter":
                        placeToStay = "Hotel";
                        price = budget * 0.8;
                        break;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                switch (season)
                {
                    case "summer":
                    case "winter":
                        placeToStay = "Hotel";
                        price = budget * 0.9;
                        break;
                }
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{placeToStay} - {price:f2}");
        }
    }
}
