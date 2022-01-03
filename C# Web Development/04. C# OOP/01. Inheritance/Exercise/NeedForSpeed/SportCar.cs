﻿namespace NeedForSpeed
{
    public class SportCar : Car
    {
        //---------------------------Constants---------------------------
        private const double DefaultFuelConsumption = 10;

        //---------------------------Constructors---------------------------
        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }

        //---------------------------Methods---------------------------
        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
