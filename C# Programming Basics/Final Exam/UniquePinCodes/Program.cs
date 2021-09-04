using System;

namespace UniquePinCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstCharacterMax = int.Parse(Console.ReadLine());
            int secondCharacterMax = int.Parse(Console.ReadLine());
            int thirdCharacterMax = int.Parse(Console.ReadLine());

            int secondCharacterCounter = 0;

            for (int firstCharacter = 1; firstCharacter <= firstCharacterMax; firstCharacter++)
            {
                for (int secondCharacter = 2; secondCharacter <= secondCharacterMax; secondCharacter++)
                {
                    secondCharacterCounter = 0;
                    for (int secondCharacterPrimeCounter = 1; secondCharacterPrimeCounter <= secondCharacter; secondCharacterPrimeCounter++)
                    {
                        if (secondCharacter % secondCharacterPrimeCounter == 0)
                        {
                            secondCharacterCounter++;
                        }
                    }
                    for (int thirdCharacter = 1; thirdCharacter <= thirdCharacterMax; thirdCharacter++)
                    {
                        if (firstCharacter % 2 == 0 && secondCharacterCounter == 2 && thirdCharacter % 2 == 0)
                        {
                            Console.WriteLine($"{firstCharacter} {secondCharacter} {thirdCharacter}");
                        }
                    }
                }
            }
        }
    }
}
