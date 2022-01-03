using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKilometer = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars[model] = car;
            }

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                string model = input[1];
                int amountOfKm = int.Parse(input[2]);

                cars[model].Drive(amountOfKm);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars.Values));
        }
    }
}
