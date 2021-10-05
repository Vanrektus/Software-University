using System;

namespace GenericThreeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personFullName = $"{firstInput[0]} {firstInput[1]}";
            string personAdress = firstInput[2];
            string personTown = firstInput[3];

            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(personFullName, personAdress, personTown);

            Console.WriteLine(firstTuple);



            string[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personName = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);
            bool drunkOrNot = secondInput[2] == "drunk" ? true : false;

            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(personName, litersOfBeer, drunkOrNot);

            Console.WriteLine(secondTuple);



            string[] thirdInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string anotherName = thirdInput[0];
            double accountBalance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];

            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(anotherName, accountBalance, bankName);

            Console.WriteLine(thirdTuple);
        }
    }
}
