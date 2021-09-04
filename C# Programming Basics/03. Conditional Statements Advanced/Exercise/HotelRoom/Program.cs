using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            double numberOfStays = double.Parse(Console.ReadLine());

            double totalPriceStudio = 0.0;
            double totalPriceApartment = 0.0;

            switch (month)
            {
                case "May":
                case "October":
                    totalPriceStudio = numberOfStays * 50;
                    totalPriceApartment = numberOfStays * 65;
                    break;
                case "June":
                case "September":
                    totalPriceStudio = numberOfStays * 75.20;
                    totalPriceApartment = numberOfStays * 68.70;
                    break;
                case "July":
                case "August":
                    totalPriceStudio = numberOfStays * 76;
                    totalPriceApartment = numberOfStays * 77;
                    break;
            }
            if (numberOfStays > 7 && numberOfStays <= 14 && (month == "May" || month == "October"))
            {
                totalPriceStudio = totalPriceStudio * 0.95;
            }
            else if (numberOfStays > 14)
            {
                totalPriceApartment = totalPriceApartment * 0.9;
                if (month == "May" || month == "October")
                {
                    totalPriceStudio = totalPriceStudio * 0.70;
                }
                else if (month == "June" || month == "September")
                {
                    totalPriceStudio = totalPriceStudio * 0.80;
                }
            }
            Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
            Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");
        }
    }
}
