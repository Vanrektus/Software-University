using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            foreach (var currentPerson in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine($"{currentPerson.Name} - {currentPerson.Age}");
            }

        }
    }
}
