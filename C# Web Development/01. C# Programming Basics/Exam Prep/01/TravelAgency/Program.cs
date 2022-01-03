using System;

namespace TravelAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfDestination = Console.ReadLine();
            string typeOfHoliday = Console.ReadLine();
            string vipDiscount = Console.ReadLine();
            int numOfStays = int.Parse(Console.ReadLine());

            double pricePerDay = 0;
            double totalPrice = 0;

            if (numOfStays < 1)
            {
                Console.WriteLine("Days must be positive number!");
                return;
            }

            if (nameOfDestination != "Bansko" && nameOfDestination != "Borovets" && nameOfDestination != "Varna" && nameOfDestination != "Burgas")
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            if (typeOfHoliday != "withEquipment" && typeOfHoliday != "noEquipment" && typeOfHoliday != "withBreakfast" && typeOfHoliday != "noBreakfast")
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            switch (nameOfDestination)
            {
                case "Bansko":
                case "Borovets":
                    if (typeOfHoliday == "withEquipment")
                    {
                        pricePerDay = 100;
                        if (vipDiscount == "yes")
                        {
                            pricePerDay = pricePerDay * 0.9;
                        }
                    }
                    else if (typeOfHoliday == "noEquipment")
                    {
                        pricePerDay = 80;
                        if (vipDiscount == "yes")
                        {
                            pricePerDay = pricePerDay * 0.95;
                        }
                    }
                    break;
                case "Varna":
                case "Burgas":
                    if (typeOfHoliday == "withBreakfast")
                    {
                        pricePerDay = 130;
                        if (vipDiscount == "yes")
                        {
                            pricePerDay = pricePerDay * 0.88;
                        }
                    }
                    else if (typeOfHoliday == "noBreakfast")
                    {
                        pricePerDay = 100;
                        if (vipDiscount == "yes")
                        {
                            pricePerDay = pricePerDay * 0.93;
                        }
                    }
                    break;
            }

            totalPrice = pricePerDay * numOfStays;
            if (numOfStays > 7)
            {
                totalPrice -= totalPrice / numOfStays;
            }

            Console.WriteLine($"The price is {totalPrice:f2}lv! Have a nice time!");
        }
    }
}
