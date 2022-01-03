namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        //---------------------------Constants---------------------------
        private const double CoffeeMilliliters = 50.0;

        private const decimal CoffePrice = 3.50M;

        //---------------------------Properties---------------------------
        public double Caffeine { get; private set; }

        //---------------------------Constructors---------------------------
        public Coffee(string name, double caffeine)
            : base(name, CoffePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }
    }
}
