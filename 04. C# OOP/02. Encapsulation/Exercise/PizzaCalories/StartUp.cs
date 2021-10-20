using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Pizza pizza = MakePizza();

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        static Pizza MakePizza()
        {
            Pizza pizza = PizzaName();

            PizzaDough(pizza);

            PizzaToppings(pizza);

            return pizza;
        }

        private static Pizza PizzaName()
        {
            string[] pizzaNameInput = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string pizzaName = string.Empty;

            if (pizzaNameInput.Length == 2)
            {
                pizzaName = pizzaNameInput[1];
            }

            Pizza pizza = new Pizza(pizzaName);
            return pizza;
        }

        private static void PizzaDough(Pizza pizza)
        {
            string[] pizzaDoughInput = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string flourType = pizzaDoughInput[1];
            string bakingTechnique = pizzaDoughInput[2];
            double doughWeight = double.Parse(pizzaDoughInput[3]);

            Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
            pizza.Dough = dough;
        }

        private static void PizzaToppings(Pizza pizza)
        {
            while (true)
            {
                string[] pizzaToppingsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (pizzaToppingsInput[0] == "END")
                {
                    break;
                }

                string toppingType = pizzaToppingsInput[1];
                double toppingWeight = double.Parse(pizzaToppingsInput[2]);

                Topping topping = new Topping(toppingType, toppingWeight);
                pizza.AddTopping(topping);
            }
        }
    }
}
