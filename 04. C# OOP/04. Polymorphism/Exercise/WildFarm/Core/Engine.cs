using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Engine
    {
        //---------------------------Fields---------------------------
        private readonly List<Animal> animals;
        private readonly FoodFactory foodFactory;
        private readonly AnimalFactory animalFactory;

        //---------------------------Constructors---------------------------
        public Engine()
        {
            this.animals = new List<Animal>();
            this.foodFactory = new FoodFactory();
            this.animalFactory = new AnimalFactory();
        }

        //---------------------------Methods---------------------------
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                try
                {
                    string[] animalInfo = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    Animal animal = this.animalFactory.CreateAnimal(animalInfo[0], animalInfo);

                    animal.ProduceSound();

                    this.animals.Add(animal);

                    string[] foodInfo = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    Food food = this.foodFactory.CreateFood(foodInfo[0], foodInfo);

                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (Animal currentAnimal in this.animals)
            {
                Console.WriteLine(currentAnimal.ToString());
            }
        }
    }
}
