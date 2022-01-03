namespace Restaurant
{
    public class Food : Product
    {
        //---------------------------Properties---------------------------
        public double Grams { get; private set; }

        //---------------------------Constructors---------------------------
        public Food(string name, decimal price, double grams)
            : base(name, price)
        {
            this.Grams = grams;
        }
    }
}
