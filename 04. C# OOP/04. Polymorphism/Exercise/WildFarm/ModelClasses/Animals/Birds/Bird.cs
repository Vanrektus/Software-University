namespace WildFarm
{
    public abstract class Bird : Animal
    {
        //---------------------------Propertiess---------------------------
        public double WingSize { get; private set; }

        //---------------------------Constructors---------------------------
        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
