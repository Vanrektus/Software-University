using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<(string name, int age), int, bool> younger = (person, age) => person.age < age;
            Func<(string name, int age), int, bool> older = (person, age) => person.age >= age;

            int n = int.Parse(Console.ReadLine());
            List<(string name, int age)> people = new List<(string name, int age)>();

            for (int i = 0; i < n; i++)
            {
                string[] currentPerson = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people.Add((currentPerson[0], int.Parse(currentPerson[1])));
            }

            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            switch (condition)
            {
                case "younger":
                    people = people
                        .Where(x => younger(x, ageFilter))
                        .ToList();
                    break;
                case "older":
                    people = people
                        .Where(x => older(x, ageFilter))
                        .ToList();
                    break;
            }

            foreach (var currentPerson in people)
            {
                List<string> outputPeopleList = new List<string>();

                if (format.Contains("name"))
                {
                    outputPeopleList.Add(currentPerson.name);
                }

                if (format.Contains("age"))
                {
                    outputPeopleList.Add(currentPerson.age.ToString());
                }

                Console.WriteLine(string.Join(" - ", outputPeopleList));
            }
        }
    }
}
