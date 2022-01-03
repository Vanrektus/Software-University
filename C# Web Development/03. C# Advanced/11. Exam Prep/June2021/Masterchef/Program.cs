using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> freshnessLevel = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<int, string> dishes = new Dictionary<int, string>()
            {
                {150, "Dipping sauce"},
                {250, "Green salad"},
                {300, "Chocolate cake"},
                {400, "Lobster"}
            };

            Dictionary<string, int> madeDishes = new Dictionary<string, int>();

            MakingDishes(ingredients, freshnessLevel, dishes, madeDishes);

            OutputPrint(ingredients, madeDishes);
        }

        private static void MakingDishes(Queue<int> ingredients, Stack<int> freshnessLevel, Dictionary<int, string> dishes, Dictionary<string, int> madeDishes)
        {
            while (ingredients.Count > 0 && freshnessLevel.Count > 0)
            {
                int currentIngredient = ingredients.Peek();
                int currentFreshness = freshnessLevel.Peek();

                if (currentIngredient == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int sum = currentIngredient * currentFreshness;

                if (dishes.ContainsKey(sum))
                {
                    if (!madeDishes.ContainsKey(dishes[sum]))
                    {
                        madeDishes[dishes[sum]] = 0;
                    }

                    madeDishes[dishes[sum]]++;
                    ingredients.Dequeue();
                    freshnessLevel.Pop();
                }
                else
                {
                    freshnessLevel.Pop();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }
        }

        private static void OutputPrint(Queue<int> ingredients, Dictionary<string, int> madeDishes)
        {
            if (madeDishes.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var currentDish in madeDishes.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {currentDish.Key} --> {currentDish.Value}");
            }
        }
    }
}
