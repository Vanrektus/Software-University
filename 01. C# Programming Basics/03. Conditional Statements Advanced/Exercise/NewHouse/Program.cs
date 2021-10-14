using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFlower = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double priceOfFlowers = 0.0;

            switch (typeOfFlower)
            {
                case "Roses":
                    priceOfFlowers = numberOfFlowers * 5.00;
                    if (numberOfFlowers > 80)
                    {
                        priceOfFlowers = priceOfFlowers * 0.90;
                    }
                    break;
                case "Dahlias":
                    priceOfFlowers = numberOfFlowers * 3.80;
                    if (numberOfFlowers > 90)
                    {
                        priceOfFlowers = priceOfFlowers * 0.85;
                    }
                    break;
                case "Tulips":
                    priceOfFlowers = numberOfFlowers * 2.80;
                    if (numberOfFlowers > 80)
                    {
                        priceOfFlowers = priceOfFlowers * 0.85;
                    }
                    break;
                case "Narcissus":
                    priceOfFlowers = numberOfFlowers * 3.00;
                    if (numberOfFlowers < 120)
                    {
                        priceOfFlowers = priceOfFlowers + priceOfFlowers * 0.15;
                    }
                    break;
                case "Gladiolus":
                    priceOfFlowers = numberOfFlowers * 2.50;
                    if (numberOfFlowers < 80)
                    {
                        priceOfFlowers = priceOfFlowers + priceOfFlowers * 0.2;
                    }
                    break;
            }
            if (budget >= priceOfFlowers)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {budget - priceOfFlowers:f2} leva left.");
            }
            else if (budget < priceOfFlowers)
            {
                Console.WriteLine($"Not enough money, you need {priceOfFlowers - budget:f2} leva more.");
            }
        }
    }
}
