namespace NeedForSpeed
{
    public class Vehicle
    {
        //---------------------------Constants---------------------------
        private const double DefaultFuelConsumption = 1.25;

        //---------------------------Propperties---------------------------
        public int HorsePower { get; private set; }

        public double Fuel { get; private set; }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        //---------------------------Constructors---------------------------
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        //---------------------------Methods---------------------------
        public virtual void Drive(double kilometers)
        {
            if (this.Fuel - kilometers * this.FuelConsumption >= 0)
            {
                this.Fuel -= kilometers * this.FuelConsumption;
            }
        }
    }
}
