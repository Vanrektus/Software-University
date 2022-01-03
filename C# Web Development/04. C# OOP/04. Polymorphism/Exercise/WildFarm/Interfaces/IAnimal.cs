namespace WildFarm.Interfaces
{
    public interface IAnimal
    {
        //---------------------------Properties---------------------------
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        //---------------------------Methods---------------------------
        void Eat(Food food);
        string ProduceSound();
    }
}
