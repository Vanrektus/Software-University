using System;

namespace Cars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car seat = new Seat("Leon", "Grey");

            IElectricCar tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat);
            Console.WriteLine(tesla);
        }
    }
}
