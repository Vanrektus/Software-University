using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] currentPerson = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = currentPerson[0];
                string lastName = currentPerson[1];
                int age = int.Parse(currentPerson[2]);

                Person person = new Person(firstName, lastName, age);
                people.Add(person);
            }

            people.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList()
                .ForEach(p => Console.WriteLine(p.ToString()));

            //foreach (Person currentPerson in people.OrderBy(p => p.FirstName).ThenBy(p => p.Age))
            //{
            //    Console.WriteLine(currentPerson);
            //}
        }
    }
}
