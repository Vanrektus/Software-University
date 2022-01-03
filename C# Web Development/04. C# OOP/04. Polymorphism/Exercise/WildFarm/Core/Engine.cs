using System;
using System.Collections.Generic;
using WildFarm.Factories;
using WildFarm.IO;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        //---------------------------Fields---------------------------
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<Animal> animals;
        private readonly FoodFactory foodFactory;
        private readonly AnimalFactory animalFactory;

        //---------------------------Constructors---------------------------
        public Engine()
        {
            this.animals = new List<Animal>();
            this.foodFactory = new FoodFactory();
            this.animalFactory = new AnimalFactory();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        //---------------------------Methods---------------------------
        public void Run()
        {
            while (true)
            {
                string[] animalInfo = this.reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (animalInfo[0] == "End")
                {
                    break;
                }

                try
                {
                    Animal animal = this.animalFactory.CreateAnimal(animalInfo[0], animalInfo);

                    this.writer.WriteLine(animal.ProduceSound());

                    this.animals.Add(animal);

                    string[] foodInfo = this.reader.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    Food food = this.foodFactory.CreateFood(foodInfo[0], foodInfo);

                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
            }

            foreach (Animal currentAnimal in this.animals)
            {
                this.writer.WriteLine(currentAnimal.ToString());
            }
        }
    }
}
