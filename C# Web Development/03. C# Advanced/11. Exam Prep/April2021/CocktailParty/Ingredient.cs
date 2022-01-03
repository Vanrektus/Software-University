using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        //---------------------------Properties---------------------------
        public string Name { get; private set; }

        public int Alcohol { get; private set; }

        public int Quantity { get; private set; }

        //---------------------------Constructors---------------------------
        public Ingredient(string name, int alcohol, int quantity)
        {
            this.Name = name;
            this.Alcohol = alcohol;
            this.Quantity = quantity;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Ingredient: {this.Name}");
            sb.AppendLine($"Quantity: {this.Quantity}");
            sb.AppendLine($"Alcohol: {this.Alcohol}");

            return sb.ToString().TrimEnd();
        }
    }
}
