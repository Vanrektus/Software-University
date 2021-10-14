using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carsInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carsInfo[0];
                int engineSpeed = int.Parse(carsInfo[1]);
                int enginePower = int.Parse(carsInfo[2]);
                int cargoWeight = int.Parse(carsInfo[3]);
                string cargoType = carsInfo[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = AddTires(carsInfo);

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string input = Console.ReadLine();

            if (input == "fragile")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tire.Any(t => t.Pressure < 1))
                    .ToList()));
            }
            else if (input == "flammable")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars
                    .Where(c => c.Cargo.Type == "flammable" && c.Engine.EnginePower > 250)
                    .ToList()));
            }
        }

        static Tire[] AddTires(string[] carsInfo)
        {
            List<Tire> currentTires = new List<Tire>();

            for (int i = 0; i < 4; i += 2)
            {
                Tire tire = new Tire(double.Parse(carsInfo[i + 5]), int.Parse(carsInfo[i + 6]));
                currentTires.Add(tire);
            }

            return currentTires.ToArray();
        }
    }
}
