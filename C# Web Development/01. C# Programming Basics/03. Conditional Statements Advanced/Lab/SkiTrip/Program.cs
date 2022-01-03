using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfStay = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string feedback = Console.ReadLine();

            double roomForOnePerson = 18.00;
            double apartment = 25.00;
            double presidentApartment = 35.00;
            double priceOfRoom = 0;

            daysOfStay = daysOfStay - 1;

            if (daysOfStay < 10)
            {
                switch (typeOfRoom)
                {
                    case "room for one person":
                        priceOfRoom = roomForOnePerson * daysOfStay;
                        switch (feedback)
                        {
                            case "positive":
                                Console.WriteLine($"{priceOfRoom + priceOfRoom * 0.25:f2}");
                                break;
                            case "negative":
                                Console.WriteLine($"{priceOfRoom - priceOfRoom * 0.10:f2}");
                                break;
                        }
                        break;
                    case "apartment":
                        priceOfRoom = (apartment * daysOfStay) * 0.70;
                        switch (feedback)
                        {
                            case "positive":
                                Console.WriteLine($"{priceOfRoom + priceOfRoom * 0.25:f2}");
                                break;
                            case "negative":
                                Console.WriteLine($"{priceOfRoom - priceOfRoom * 0.10:f2}");
                                break;
                        }
                        break;
                    case "president apartment":
                        priceOfRoom = presidentApartment * daysOfStay * 0.90;
                        switch (feedback)
                        {
                            case "positive":
                                Console.WriteLine($"{priceOfRoom + priceOfRoom * 0.25:f2}");
                                break;
                            case "negative":
                                Console.WriteLine($"{priceOfRoom - priceOfRoom * 0.10:f2}");
                                break;
                        }
                        break;
                }
            }
            else if (daysOfStay >= 10 && daysOfStay <= 15)
            {
                switch (typeOfRoom)
                {
                    case "room for one person":
                        priceOfRoom = roomForOnePerson * daysOfStay;
                        switch (feedback)
                        {
                            case "positive":
                                Console.WriteLine($"{priceOfRoom + priceOfRoom * 0.25:f2}");
                                break;
                            case "negative":
                                Console.WriteLine($"{priceOfRoom - priceOfRoom * 0.10:f2}");
                                break;
                        }
                        break;
                    case "apartment":
                        priceOfRoom = (apartment * daysOfStay) * 0.65;
                        switch (feedback)
                        {
                            case "positive":
                                Console.WriteLine($"{priceOfRoom + priceOfRoom * 0.25:f2}");
                                break;
                            case "negative":
                                Console.WriteLine($"{priceOfRoom - priceOfRoom * 0.10:f2}");
                                break;
                        }
                        break;
                    case "president apartment":
                        priceOfRoom = presidentApartment * daysOfStay * 0.85;
                        switch (feedback)
                        {
                            case "positive":
                                Console.WriteLine($"{priceOfRoom + priceOfRoom * 0.25:f2}");
                                break;
                            case "negative":
                                Console.WriteLine($"{priceOfRoom - priceOfRoom * 0.10:f2}");
                                break;
                        }
                        break;
                }
            }
            else if (daysOfStay > 15)
            {
                switch (typeOfRoom)
                {
                    case "room for one person":
                        priceOfRoom = roomForOnePerson * daysOfStay;
                        switch (feedback)
                        {
                            case "positive":
                                Console.WriteLine($"{priceOfRoom + priceOfRoom * 0.25:f2}");
                                break;
                            case "negative":
                                Console.WriteLine($"{priceOfRoom - priceOfRoom * 0.10:f2}");
                                break;
                        }
                        break;
                    case "apartment":
                        priceOfRoom = (apartment * daysOfStay) * 0.50;
                        switch (feedback)
                        {
                            case "positive":
                                Console.WriteLine($"{priceOfRoom + priceOfRoom * 0.25:f2}");
                                break;
                            case "negative":
                                Console.WriteLine($"{priceOfRoom - priceOfRoom * 0.10:f2}");
                                break;
                        }
                        break;
                    case "president apartment":
                        priceOfRoom = presidentApartment * daysOfStay * 0.80;
                        switch (feedback)
                        {
                            case "positive":
                                Console.WriteLine($"{priceOfRoom + priceOfRoom * 0.25:f2}");
                                break;
                            case "negative":
                                Console.WriteLine($"{priceOfRoom - priceOfRoom * 0.10:f2}");
                                break;
                        }
                        break;
                }
            }
        }
    }
}
