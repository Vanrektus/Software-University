using WildFarm.Interfaces;

namespace WildFarm
{
    public abstract class Food : IFood
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
