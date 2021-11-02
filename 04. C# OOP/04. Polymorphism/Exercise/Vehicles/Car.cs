namespace Vehicles
{
    public class Car : Vehicle
    {
        //---------------------------Fields---------------------------
        private readonly double fuelConsumption;

        //---------------------------Properties---------------------------
        public double FuelQuantity { get; private set; }

        //---------------------------Constructors---------------------------
        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption + 0.9;
        }

        //---------------------------Methods---------------------------
        public override string Drive(double distance)
        {
            if (distance * this.fuelConsumption <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance * this.fuelConsumption;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return "Car needs refueling";
            }
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
