using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string[] personToAdd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (personToAdd[0] == "END")
                {
                    break;
                }

                string name = personToAdd[0];
                int age = int.Parse(personToAdd[1]);
                string town = personToAdd[2];

                people.Add(new Person(name, age, town));
            }

            int positionOfPersonToCompare = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = people[positionOfPersonToCompare];

            int equal = 0;
            int notEqual = 0;

            foreach (Person currentPerson in people)
            {
                if (currentPerson.CompareTo(personToCompare) == 0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }

            Console.WriteLine(equal > 1 ? $"{equal} {notEqual} {people.Count}" : $"No matches");
        }
    }
}
