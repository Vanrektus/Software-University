namespace Vehicles
{
    public class Truck : Vehicle
    {
        //---------------------------Fields---------------------------
        private readonly double fuelConsumption;
        private readonly double tankCapacity;

        //---------------------------Properties---------------------------
        public double FuelQuantity { get; private set; }

        //---------------------------Constructors---------------------------
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.fuelConsumption = fuelConsumption + 1.6;
            this.tankCapacity = tankCapacity;

            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
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
                return "Truck needs refueling";
            }
        }

        public override void Refuel(double liters)
        {
            if (liters > 0)
            {
                if (this.FuelQuantity + liters <= this.tankCapacity)
                {
                    this.FuelQuantity += liters * 0.95;
                }
                else
                {
                    System.Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
            }
            else
            {
                System.Console.WriteLine("Fuel must be a positive number");
            }
        }
    }
}
