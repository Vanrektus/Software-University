namespace Restaurant
{
    public class Beverage : Product
    {
        //---------------------------Properties---------------------------
        public double Milliliters { get; private set; }

        //---------------------------Constructors---------------------------
        public Beverage(string name, decimal price, double milliliters)
            : base(name, price)
        {
            this.Milliliters = milliliters;
        }
    }
}
