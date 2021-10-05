using System;

namespace GenericTuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personFullName = $"{firstInput[0]} {firstInput[1]}";
            string personAdress = firstInput[2];

            Tuple<string, string> firstTuple = new Tuple<string, string>(personFullName, personAdress);

            Console.WriteLine(firstTuple);



            string[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personName = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);

            Tuple<string, int> secondTuple = new Tuple<string, int>(personName, litersOfBeer);

            Console.WriteLine(secondTuple);



            string[] thirdInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int inputInteger = int.Parse(thirdInput[0]);
            double inputDouble = double.Parse(thirdInput[1]);

            Tuple<int, double> thirdTuple = new Tuple<int, double>(inputInteger, inputDouble);

            Console.WriteLine(thirdTuple);
        }
    }
}
