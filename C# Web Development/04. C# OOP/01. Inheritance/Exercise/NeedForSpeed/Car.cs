namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        //---------------------------Constants---------------------------
        private const double DefaultFuelConsumption = 3;

        //---------------------------Constructors---------------------------
        public Car(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }

        //---------------------------Methods---------------------------
        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
