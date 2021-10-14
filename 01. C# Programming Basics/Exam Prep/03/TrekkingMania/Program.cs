using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfGroups = int.Parse(Console.ReadLine());

            double peopleGoingToMusala = 0;
            double peopleGoingToMonblan = 0;
            double peopleGoingToKlimandzharo = 0;
            double peopleGoingToK2 = 0;
            double peopleGoingToEverest = 0;
            double totalPeople = 0;

            for (int i = 1; i <= numOfGroups; i++)
            {
                int numOfPeoplePerGroup = int.Parse(Console.ReadLine());
                totalPeople += numOfPeoplePerGroup;

                if (numOfPeoplePerGroup <= 5)
                {
                    peopleGoingToMusala += numOfPeoplePerGroup;
                }
                else if (numOfPeoplePerGroup >= 6 && numOfPeoplePerGroup <= 12)
                {
                    peopleGoingToMonblan += numOfPeoplePerGroup;
                }
                else if (numOfPeoplePerGroup >= 13 && numOfPeoplePerGroup <= 25)
                {
                    peopleGoingToKlimandzharo += numOfPeoplePerGroup;
                }
                else if (numOfPeoplePerGroup >= 26 && numOfPeoplePerGroup <= 40)
                {
                    peopleGoingToK2 += numOfPeoplePerGroup;
                }
                else if (numOfPeoplePerGroup >= 41)
                {
                    peopleGoingToEverest += numOfPeoplePerGroup;
                }
            }

            Console.WriteLine($"{peopleGoingToMusala / totalPeople * 100:f2}%");
            Console.WriteLine($"{peopleGoingToMonblan / totalPeople * 100:f2}%");
            Console.WriteLine($"{peopleGoingToKlimandzharo / totalPeople * 100:f2}%");
            Console.WriteLine($"{peopleGoingToK2 / totalPeople * 100:f2}%");
            Console.WriteLine($"{peopleGoingToEverest / totalPeople * 100:f2}%");
        }
    }
}
