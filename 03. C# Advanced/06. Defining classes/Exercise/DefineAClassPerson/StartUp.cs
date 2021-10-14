using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Ivan";
            person.Age = 21;

            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}
