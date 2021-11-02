using System;

namespace WildFarm
{
    public class FoodFactory
    {
        //---------------------------Constructors---------------------------
        public FoodFactory() { }

        //---------------------------Methods---------------------------
        public Food CreateFood(string foodType, params string[] foodInfo)
        {
            switch (foodType)
            {
                case "Fruit": return new Fruit(int.Parse(foodInfo[1]));

                case "Meat": return new Meat(int.Parse(foodInfo[1]));

                case "Seeds": return new Seeds(int.Parse(foodInfo[1]));

                case "Vegetable": return new Vegetable(int.Parse(foodInfo[1]));

                default: throw new ArgumentException("Invalid food type.");

            }
        }
    }
}
