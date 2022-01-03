using System;
using System.Collections.Generic;

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
                try
                {
                    string[] currentPerson = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string firstName = currentPerson[0];
                    string lastName = currentPerson[1];
                    int age = int.Parse(currentPerson[2]);
                    decimal salary = decimal.Parse(currentPerson[3]);

                    Person person = new Person(firstName, lastName, age, salary);
                    people.Add(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            decimal percentage = decimal.Parse(Console.ReadLine());

            people.ForEach(p => p.IncreaseSalary(percentage));

            people.ForEach(p => Console.WriteLine(p));
        }
    }
}
