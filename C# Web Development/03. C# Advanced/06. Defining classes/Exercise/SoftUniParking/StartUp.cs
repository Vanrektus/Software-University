using System;

namespace SoftUniParking
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car firstCar = new Car("Skoda", "Fabia", 65, "CC1856BG");
            Car secondCar = new Car("Audi", "A3", 110, "EB8787MN");

            Console.WriteLine(firstCar.ToString());

            Parking parking = new Parking(5);

            Console.WriteLine(parking.AddCar(firstCar));

            Console.WriteLine(parking.AddCar(firstCar));

            Console.WriteLine(parking.AddCar(secondCar));

            Console.WriteLine(parking.GetCar("EB8787MN").ToString());

            Console.WriteLine(parking.RemoveCar("EB8787MN"));

            Console.WriteLine(parking.Count);
        }
    }
}
