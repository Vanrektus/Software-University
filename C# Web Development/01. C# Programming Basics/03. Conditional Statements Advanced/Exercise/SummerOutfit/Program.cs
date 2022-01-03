﻿using System;

namespace SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int temperature = int.Parse(Console.ReadLine());
            string dayTime = Console.ReadLine();

            string outfit = "";
            string shoes = "";

            if (temperature >= 10 && temperature <= 18)
            {
                switch (dayTime)
                {
                    case "Morning":
                        outfit = "Sweatshirt";
                        shoes = "Sneakers";
                        break;
                    case "Afternoon":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                }
            }
            else if (temperature > 18 && temperature <= 24)
            {
                switch (dayTime)
                {
                    case "Morning":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                    case "Afternoon":
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                        break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                }
            }
            else if (temperature >= 25)
            {
                switch (dayTime)
                {
                    case "Morning":
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                        break;
                    case "Afternoon":
                        outfit = "Swim Suit";
                        shoes = "Barefoot";
                        break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                }
            }

            Console.WriteLine($"It's {temperature} degrees, get your {outfit} and {shoes}.");
        }
    }
}
