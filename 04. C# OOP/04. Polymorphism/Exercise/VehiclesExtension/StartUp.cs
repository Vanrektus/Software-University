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
            double carTankCapactiy = double.Parse(carInfo[3]);

            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapactiy = double.Parse(truckInfo[3]);

            string[] busInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapactiy = double.Parse(busInfo[3]);

            Car car = new Car(carFuelQuantity, carFuelConsumption, carTankCapactiy);
            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapactiy);
            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapactiy);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[1])
                {
                    case "Car":
                        if (command[0] == "Drive")
                        {
                            double distance = double.Parse(command[2]);

                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (command[0] == "Refuel")
                        {
                            double liters = double.Parse(command[2]);

                            car.Refuel(liters);
                        }
                        break;

                    case "Truck":
                        if (command[0] == "Drive")
                        {
                            double distance = double.Parse(command[2]);

                            Console.WriteLine(truck.Drive(distance));
                        }
                        else if (command[0] == "Refuel")
                        {
                            double liters = double.Parse(command[2]);

                            truck.Refuel(liters);
                        }
                        break;

                    case "Bus":
                        switch (command[0])
                        {
                            case "Drive":
                                double distance = double.Parse(command[2]);

                                Console.WriteLine(bus.Drive(distance));
                                break;

                            case "DriveEmpty":
                                double distanceEmpty = double.Parse(command[2]);

                                Console.WriteLine(bus.DriveEmpty(distanceEmpty));
                                break;

                            case "Refuel":
                                double liters = double.Parse(command[2]);

                                bus.Refuel(liters);
                                break;

                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
