using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        //---------------------------Fields---------------------------
        private readonly List<Ingredient> Ingredients;

        //---------------------------Properties---------------------------
        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int MaxAlcoholLevel { get; private set; }

        public int CurrentAlcoholLevel => Ingredients.Sum(i => i.Alcohol);

        //---------------------------Constructors---------------------------
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new List<Ingredient>();
        }

        //---------------------------Methods---------------------------
        public void Add(Ingredient ingredient)
        {
            if (Ingredients.Count < this.Capacity &&
                (CurrentAlcoholLevel + ingredient.Alcohol) <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(i => i.Name == name);

            if (ingredient != null)
            {
                Ingredients.Remove(ingredient);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(i => i.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            if (Ingredients.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

                foreach (Ingredient currentIngredient in Ingredients)
                {
                    sb.AppendLine(currentIngredient.ToString());
                }

                return sb.ToString().TrimEnd();
            }

            return null;
        }
    }
}
