using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);

            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);

            Car car = new Car(carFuelQuantity, carFuelConsumption);
            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Drive")
                {
                    double distance = double.Parse(command[2]);

                    if (command[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (command[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }
                else if (command[0] == "Refuel")
                {
                    double liters = double.Parse(command[2]);

                    if (command[1] == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
