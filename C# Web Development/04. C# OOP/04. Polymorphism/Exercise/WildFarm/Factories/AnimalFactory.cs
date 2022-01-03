using System;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        //---------------------------Constructors---------------------------
        public AnimalFactory()
        {

        }

        //---------------------------Methods---------------------------
        public Animal CreateAnimal(string animalType, params string[] animalInfo)
        {
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            double? wingSize = null;
            string livingRegion = string.Empty;
            string breed = string.Empty;

            switch (animalType)
            {
                case "Owl":
                    wingSize = double.Parse(animalInfo[3]);

                    return new Owl(name, weight, (double)wingSize);

                case "Hen":
                    wingSize = double.Parse(animalInfo[3]);

                    return new Hen(name, weight, (double)wingSize);

                case "Mouse":
                    livingRegion = animalInfo[3];

                    return new Mouse(name, weight, animalInfo[3]);

                case "Dog":
                    livingRegion = animalInfo[3];

                    return new Dog(name, weight, animalInfo[3]);

                case "Cat":
                    livingRegion = animalInfo[3];
                    breed = animalInfo[4];

                    return new Cat(name, weight, livingRegion, breed);

                case "Tiger":
                    livingRegion = animalInfo[3];
                    breed = animalInfo[4];

                    return new Tiger(name, weight, livingRegion, breed);

                default: throw new ArgumentException("Invalid animal type.");

            }
        }
    }
}
