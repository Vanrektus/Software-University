using System;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        //---------------------------Constructors---------------------------
        public FoodFactory()
        {

        }

        //---------------------------Methods---------------------------
        public Food CreateFood(string foodType, params string[] foodInfo)
        {
            int quantity = int.Parse(foodInfo[1]);

            switch (foodType)
            {
                case "Fruit": return new Fruit(quantity);

                case "Meat": return new Meat(quantity);

                case "Seeds": return new Seeds(quantity);

                case "Vegetable": return new Vegetable(quantity);

                default: throw new ArgumentException("Invalid food type.");
            }
        }
    }
}
