using System;

namespace FitnessCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfClients = int.Parse(Console.ReadLine());

            int backTrainers = 0;
            int chestTrainers = 0;
            int legsTrainers = 0;
            int absTrainers = 0;
            int proteinShakeBuyers = 0;
            int proteinBarBuyers = 0;
            double numOfTraining = 0;
            double numOfBuyers = 0;

            for (int i = 1; i <= numOfClients; i++)
            {
                string typeOfActivity = Console.ReadLine();
                switch (typeOfActivity)
                {
                    case "Back":
                        backTrainers++;
                        numOfTraining++;
                        break;
                    case "Chest":
                        chestTrainers++;
                        numOfTraining++;
                        break;
                    case "Legs":
                        legsTrainers++;
                        numOfTraining++;
                        break;
                    case "Abs":
                        absTrainers++;
                        numOfTraining++;
                        break;
                    case "Protein shake":
                        proteinShakeBuyers++;
                        numOfBuyers++;
                        break;
                    case "Protein bar":
                        proteinBarBuyers++;
                        numOfBuyers++;
                        break;
                }
            }
            Console.WriteLine($"{backTrainers} - back");
            Console.WriteLine($"{chestTrainers} - chest");
            Console.WriteLine($"{legsTrainers} - legs");
            Console.WriteLine($"{absTrainers} - abs");
            Console.WriteLine($"{proteinShakeBuyers} - protein shake");
            Console.WriteLine($"{proteinBarBuyers} - protein bar");
            Console.WriteLine($"{(numOfTraining / numOfClients) * 100:f2}% - work out");
            Console.WriteLine($"{(numOfBuyers / numOfClients) * 100:f2}% - protein");
        }
    }
}
