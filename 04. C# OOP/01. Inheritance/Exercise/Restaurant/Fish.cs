namespace Restaurant
{
    public class Fish : MainDish
    {
        //---------------------------Constants---------------------------
        private new const double Grams = 22.0;

        //---------------------------Constructors---------------------------
        public Fish(string name, decimal price)
            : base(name, price, Grams)
        {

        }
    }
}
