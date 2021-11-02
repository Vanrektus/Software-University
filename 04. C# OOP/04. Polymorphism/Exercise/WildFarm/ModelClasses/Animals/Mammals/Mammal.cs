namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        //---------------------------Propertiess---------------------------
        public string LivingRegion { get; private set; }

        //---------------------------Constructors---------------------------
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
