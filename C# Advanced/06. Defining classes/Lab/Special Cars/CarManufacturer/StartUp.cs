using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            //Tire[] tires = new Tire[4]
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3),
            //};

            //Engine engine = new Engine(560, 6300);

            //Car car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

            List<Tire[]> newTires = new List<Tire[]>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "No more tires")
                {
                    break;
                }

                string[] commandSplit = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                List<Tire> tiresList = new List<Tire>();

                for (int i = 0; i < commandSplit.Length; i += 2)
                {
                    int year = int.Parse(commandSplit[i]);
                    double pressure = double.Parse(commandSplit[i + 1]);

                    Tire tire = new Tire(year, pressure);
                    tiresList.Add(tire);
                }

                newTires.Add(tiresList.ToArray());
            }

            List<Engine> newEngines = new List<Engine>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Engines done")
                {
                    break;
                }

                string[] commandSplit = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(commandSplit[0]);
                double cubicCapacity = double.Parse(commandSplit[1]);

                Engine currentEngine = new Engine(horsePower, cubicCapacity);
                newEngines.Add(currentEngine);
            }

            List<Car> cars = new List<Car>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Show special")
                {
                    break;
                }

                string[] commandSplit = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = commandSplit[0];
                string model = commandSplit[1];
                int year = int.Parse(commandSplit[2]);
                double fuelQuantity = double.Parse(commandSplit[3]);
                double fuelConsumption = double.Parse(commandSplit[4]);
                int engineIndex = int.Parse(commandSplit[5]);
                int tiresIndex = int.Parse(commandSplit[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, newEngines[engineIndex], newTires[tiresIndex]);
                cars.Add(car);
            }

            Func<Car, bool> filter = c => c.Year >= 2017 &&
                    c.Engine.HorsePower > 330 &&
                    c.Tires.Sum(t => t.Pressure) >= 9 &&
                    c.Tires.Sum(t => t.Pressure) <= 10;

            List<Car> specialCars = new List<Car>();

            foreach (Car currentCar in cars.Where(filter))
            {
                currentCar.Drive(20);
                specialCars.Add(currentCar);
            }

            Console.WriteLine(String.Join("", specialCars));
        }
    }
}
