using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();

            Catalogue(catalogue);

            double averageCarHorsepower = AverageCarHorsepower(catalogue);
            double averageTruckHorsepower = AverageTruckHorsepower(catalogue);

            PrintCatalogue(catalogue, averageCarHorsepower, averageTruckHorsepower);
        }

        static void Catalogue(Catalogue catalogue)
        {
            while (true)
            {
                string[] newVehicle = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (newVehicle[0] == "End")
                {
                    break;
                }

                if (newVehicle[0] == "car")
                {
                    catalogue.Cars.Add(new Car
                    {
                        // wanted string of an array (newVehicle[0]) = car -> Car
                        Type = char.ToUpper(newVehicle[0][0]) + newVehicle[0].Substring(1),
                        Model = newVehicle[1],
                        Color = newVehicle[2],
                        Horsepower = int.Parse(newVehicle[3])
                    });
                }
                else if (newVehicle[0] == "truck")
                {
                    catalogue.Trucks.Add(new Truck
                    {
                        // wanted string of an array (newVehicle[0]) = car -> Car
                        Type = char.ToUpper(newVehicle[0][0]) + newVehicle[0].Substring(1),
                        Model = newVehicle[1],
                        Color = newVehicle[2],
                        Horsepower = int.Parse(newVehicle[3])
                    });
                }
            }
        }

        static double AverageCarHorsepower(Catalogue catalogue)
        {
            double averageCarHorsepower = 0;
            double carCounter = 0;

            foreach (Car vehicle in catalogue.Cars)
            {
                carCounter++;
                averageCarHorsepower += vehicle.Horsepower;
            }

            averageCarHorsepower /= carCounter;

            return averageCarHorsepower;
        }

        static double AverageTruckHorsepower(Catalogue catalogue)
        {
            double averageTruckHorsepower = 0;
            double truckCounter = 0;

            foreach (Truck vehicle in catalogue.Trucks)
            {
                truckCounter++;
                averageTruckHorsepower += vehicle.Horsepower;
            }

            averageTruckHorsepower /= truckCounter;

            return averageTruckHorsepower;
        }

        static void PrintCatalogue(Catalogue catalogue, 
            double averageCarHorsepower, 
            double averageTruckHorsepower)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Close the Catalogue")
                {
                    break;
                }

                foreach (Car vehicle in catalogue.Cars)
                {
                    if (vehicle.Model == input)
                    {
                        Console.WriteLine($"Type: {vehicle.Type}");
                        Console.WriteLine($"Model: {vehicle.Model}");
                        Console.WriteLine($"Color: {vehicle.Color}");
                        Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
                    }
                }

                foreach (Truck vehicle in catalogue.Trucks)
                {
                    if (vehicle.Model == input)
                    {
                        Console.WriteLine($"Type: {vehicle.Type}");
                        Console.WriteLine($"Model: {vehicle.Model}");
                        Console.WriteLine($"Color: {vehicle.Color}");
                        Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
                    }
                }
            }

            if (catalogue.Cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarHorsepower:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (catalogue.Trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsepower:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }

    class Car
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }

    class Truck
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }

    class Catalogue
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public Catalogue()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
    }
}
