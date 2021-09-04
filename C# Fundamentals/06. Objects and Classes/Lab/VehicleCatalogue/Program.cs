using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            while (true)
            {
                string[] currentVehicle = Console.ReadLine()
                    .Split("/", StringSplitOptions.RemoveEmptyEntries);

                if (currentVehicle[0] == "end")
                {
                    break;
                }

                if (currentVehicle[0] == "Car")
                {
                    catalog.Cars.Add(new Car
                    {
                        Brand = currentVehicle[1],
                        Model = currentVehicle[2],
                        HorsePower = double.Parse(currentVehicle[3])
                    });
                }
                else if (currentVehicle[0] == "Truck")
                {
                    catalog.Trucks.Add(new Truck
                    {
                        Brand = currentVehicle[1],
                        Model = currentVehicle[2],
                        Weight = double.Parse(currentVehicle[3])
                    });
                }
            }

            PrintVehicles(catalog);
        }

        static void PrintVehicles(Catalog catalog)
        {
            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine($"Cars:");

                foreach (Car car in catalog.Cars.OrderBy(car => car.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine($"Trucks:");

                foreach (Truck truck in catalog.Trucks.OrderBy(truck => truck.Brand))
                {
                        Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }

    class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
    }
}
