namespace WildFarm
{
    public abstract class Food
    {
        //---------------------------Properties---------------------------
        public int Quantity { get; private set; }

        //---------------------------Constructors---------------------------
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
