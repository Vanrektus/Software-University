namespace Restaurant
{
    public class Cake : Dessert
    {
        //---------------------------Constants---------------------------
        private new const double Grams = 250.0;

        private new const double Calories = 1000.0;

        private const decimal CakePrice = 5.0M;

        //---------------------------Constructors---------------------------
        public Cake(string name)
            : base(name, CakePrice, Grams, Calories)
        {

        }
    }
}
