using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            PeopleList peopleList = new PeopleList();

            while (true)
            {
                string[] newPerson = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (newPerson[0] == "End")
                {
                    break;
                }

                peopleList.People.Add(new Person
                {
                    Name = newPerson[0],
                    ID = int.Parse(newPerson[1]),
                    Age = int.Parse(newPerson[2])
                });
            }

            foreach (var currentPerson in peopleList.People.OrderBy(x => x.Age))
            {
                Console.WriteLine($"{currentPerson.Name} with ID: {currentPerson.ID} is {currentPerson.Age} years old.");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }
    }

    class PeopleList
    {
        public List<Person> People { get; set; }

        public PeopleList()
        {
            People = new List<Person>();
        }
    }
}
