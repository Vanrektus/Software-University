namespace WildFarm.Interfaces
{
    public interface IAnimal
    {
        //---------------------------Properties---------------------------
        public string Name { get; }
        public double Weight { get; }
        public int FoodEaten { get; }

        //---------------------------Methods---------------------------
        public void Eat(Food food);
        public string ProduceSound();
    }
}
