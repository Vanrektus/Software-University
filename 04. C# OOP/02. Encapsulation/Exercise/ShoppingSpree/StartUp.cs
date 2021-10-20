using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] peopleArray = Console.ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleArray.Length; i += 2)
            {
                string name = peopleArray[i];
                decimal money = decimal.Parse(peopleArray[i + 1]);

                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            List<Product> products = new List<Product>();
            string[] productsArray = Console.ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productsArray.Length; i += 2)
            {
                string name = productsArray[i];
                decimal cost = decimal.Parse(productsArray[i + 1]);

                try
                {
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            while (true)
            {
                string[] productsToBuy = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (productsToBuy[0] == "END")
                {
                    break;
                }

                string personName = productsToBuy[0];
                string productName = productsToBuy[1];

                Product product = products.FirstOrDefault(p => p.Name == productName);
                people.FirstOrDefault(p => p.Name == personName).AddProduct(product);
            }

            foreach (Person currentPerson in people)
            {
                Console.WriteLine(currentPerson);
            }
        }
    }
}
