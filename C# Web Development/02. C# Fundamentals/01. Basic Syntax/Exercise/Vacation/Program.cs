using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOfPeople = double.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine();
            string day = Console.ReadLine();

            double currentPrice = 0.0;

            switch (typeOfPeople)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday":
                            currentPrice = 8.45;
                            break;
                        case "Saturday":
                            currentPrice = 9.80;
                            break;
                        case "Sunday":
                            currentPrice = 10.46;
                            break;
                    }
                    break;
                case "Business":
                    switch (day)
                    {
                        case "Friday":
                            currentPrice = 10.90;
                            break;
                        case "Saturday":
                            currentPrice = 15.60;
                            break;
                        case "Sunday":
                            currentPrice = 16.00;
                            break;
                    }
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday":
                            currentPrice = 15.00;
                            break;
                        case "Saturday":
                            currentPrice = 20.00;
                            break;
                        case "Sunday":
                            currentPrice = 22.50;
                            break;
                    }
                    break;
            }

            if (typeOfPeople == "Students" && numberOfPeople >= 30)
            {
                Console.WriteLine($"Total price: {(numberOfPeople * currentPrice) * 0.85:f2}");
            }
            else if (typeOfPeople == "Business" && numberOfPeople >= 100)
            {
                Console.WriteLine($"Total price: {(numberOfPeople * currentPrice) - (currentPrice * 10):f2}");
            }
            else if (typeOfPeople == "Regular" && (numberOfPeople >= 10 && numberOfPeople <= 20))
            {
                Console.WriteLine($"Total price: {(numberOfPeople * currentPrice) * 0.95:f2}");
            }
            else
            {
                Console.WriteLine($"Total price: {numberOfPeople * currentPrice:f2}");
            }
        }
    }
}
