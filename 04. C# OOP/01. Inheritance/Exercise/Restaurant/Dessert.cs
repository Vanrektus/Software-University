namespace Restaurant
{
    public class Dessert : Food
    {
        //---------------------------Properties---------------------------
        public double Calories { get; private set; }

        //---------------------------Constructors---------------------------
        public Dessert(string name, decimal price, double grams, double calories)
            : base(name, price, grams)
        {
            this.Calories = calories;
        }
    }
}
