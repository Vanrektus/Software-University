using System;
using System.Collections.Generic;

namespace NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            Collection collection = new Collection();

            Dictionary<string, Dictionary<int, int>> cars = new Dictionary<string, Dictionary<int, int>>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] newCar = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                collection.Cars.Add(new Car
                {
                    Model = newCar[0],
                    Mileage = int.Parse(newCar[1]),
                    Fuel = int.Parse(newCar[2])
                });
            }

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Stop")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "Drive":

                        break;
                    case "Refuel":

                        break;
                    case "Revert":

                        break;
                }
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }

    class Collection
    {
        public List<Car> Cars { get; set; }

        public Collection()
        {
            Cars = new List<Car>();
        }
    }
}
