using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string typeOfAnimal = Console.ReadLine();

                if (typeOfAnimal == "Beast!")
                {
                    break;
                }

                string[] animalInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                Animal animal;

                switch (typeOfAnimal)
                {
                    case "Dog":
                        try
                        {
                            animal = new Dog(name, age, gender);
                            animals.Add(animal);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Frog":
                        try
                        {
                            animal = new Frog(name, age, gender);
                            animals.Add(animal);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Cat":
                        try
                        {
                            animal = new Cat(name, age, gender);
                            animals.Add(animal);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Kitten":
                        try
                        {
                            animal = new Kitten(name, age);
                            animals.Add(animal);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Tomcat":
                        try
                        {
                            animal = new Tomcat(name, age);
                            animals.Add(animal);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    default:
                        continue;
                }
            }

            foreach (Animal currentAnimal in animals)
            {
                Console.WriteLine(currentAnimal);
            }
        }
    }
}
