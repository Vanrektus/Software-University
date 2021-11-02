namespace WildFarm
{
    public abstract class Feline : Mammal
    {
        //---------------------------Properties---------------------------
        public string Breed { get; private set; }

        //---------------------------Constructors---------------------------
        protected Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        //---------------------------Constructors---------------------------
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
