using System;

namespace BarcodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            for (int firstCharacter = startNumber / 1000; firstCharacter <= endNumber / 1000; firstCharacter++)
            {
                for (int secondCharacter = startNumber % 1000 / 100; secondCharacter <= endNumber % 1000 / 100; secondCharacter++)
                {
                    for (int thirdCharacter = startNumber % 100 / 10; thirdCharacter <= endNumber % 100 / 10; thirdCharacter++)
                    {
                        for (int fourthCharacter = startNumber % 10; fourthCharacter <= endNumber % 10; fourthCharacter++)
                        {
                            if (firstCharacter % 2 != 0 && secondCharacter % 2 != 0 && thirdCharacter % 2 != 0 && fourthCharacter % 2 != 0)
                            {
                                Console.Write($"{firstCharacter}{secondCharacter}{thirdCharacter}{fourthCharacter} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
