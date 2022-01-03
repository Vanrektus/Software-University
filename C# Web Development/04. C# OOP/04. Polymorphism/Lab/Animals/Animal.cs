using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        //---------------------------Fields---------------------------
        private readonly string name;
        private readonly string favouriteFood;

        //---------------------------Constructors---------------------------
        public Animal(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }

        //---------------------------Methods---------------------------
        public virtual string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"I am {this.name} and my favourite food is {this.favouriteFood}");

            return sb.ToString().TrimEnd();
        }
    }
}
