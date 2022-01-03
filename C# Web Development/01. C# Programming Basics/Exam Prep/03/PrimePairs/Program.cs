using System;

namespace PrimePairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPair = int.Parse(Console.ReadLine());
            int secondPair = int.Parse(Console.ReadLine());
            int firstPairEndNumber = int.Parse(Console.ReadLine());
            int secondPairEndNumber = int.Parse(Console.ReadLine());

            int firstPairEnd = firstPair + firstPairEndNumber;
            int secondPairEnd = secondPair + secondPairEndNumber;
            int firstPairCounter = 0;
            int secondPairCounter = 0;

            for (int firstPairCurrentNumber = firstPair; firstPairCurrentNumber <= firstPairEnd; firstPairCurrentNumber++)
            {
                for (int secondPairCurrentNumber = secondPair; secondPairCurrentNumber <= secondPairEnd; secondPairCurrentNumber++)
                {
                    firstPairCounter = 0;
                    for (int firstPairPrimeCounter = 1; firstPairPrimeCounter <= firstPairEnd; firstPairPrimeCounter++)
                    {
                        secondPairCounter = 0;
                        for (int secondPairPrimeCounter = 1; secondPairPrimeCounter <= secondPairEnd; secondPairPrimeCounter++)
                        {
                            if (secondPairCurrentNumber % secondPairPrimeCounter == 0)
                            {
                                secondPairCounter++;
                            }
                        }
                        if (firstPairCurrentNumber % firstPairPrimeCounter == 0)
                        {
                            firstPairCounter++;
                        }
                    }
                    if (firstPairCounter == 2 && secondPairCounter == 2)
                    {
                        Console.WriteLine($"{firstPairCurrentNumber}{secondPairCurrentNumber} ");
                    }
                }
            }
        }
    }
}
