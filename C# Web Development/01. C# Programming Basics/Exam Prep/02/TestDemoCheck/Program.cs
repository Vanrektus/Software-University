using System;

namespace TestDemoCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(2345 % 10);
            //Console.WriteLine(2345 % 100 / 10);
            //Console.WriteLine(2345 % 1000 / 100);
            //Console.WriteLine(2345 / 1000);

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

            //int startNumber = int.Parse(Console.ReadLine());
            //int endNumber = int.Parse(Console.ReadLine());

            //int firstDigit = 0;
            //int secondDigit = 0;
            //int thirdDigit = 0;
            //int fourthDigit = 0;

            //for (int fourthCharacter = startNumber % 10; fourthCharacter <= endNumber % 10; fourthCharacter++)
            //{
            //    for (int thirdCharacter = startNumber % 100 / 10; thirdCharacter <= endNumber % 100 / 10; thirdCharacter++)
            //    {
            //        for (int secondCharacter = startNumber % 1000 / 100; secondCharacter <= endNumber % 1000 / 100; secondCharacter++)
            //        {
            //            for (int firstCharacter = startNumber / 1000; firstCharacter <= endNumber / 1000; firstCharacter++)
            //            {
            //                if (firstCharacter % 2 != 0)
            //                {
            //                    firstDigit = firstCharacter;
            //                    break;
            //                }
            //            }
            //            if (secondCharacter % 2 != 0)
            //            {
            //                secondDigit = secondCharacter;
            //                break;
            //            }
            //        }
            //        if (thirdCharacter % 2 != 0)
            //        {
            //            thirdDigit = thirdCharacter;
            //            break;
            //        }
            //    }
            //    if (fourthCharacter % 2 != 0)
            //    {
            //        fourthDigit = fourthCharacter;
            //        Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit} ");
            //    }
            //}

            //int startNumber = int.Parse(Console.ReadLine());
            //int endNumber = int.Parse(Console.ReadLine());

            //for (int fourthDigit = startNumber % 10; fourthDigit <= endNumber % 10; fourthDigit++)
            //{
            //    int evenCounter = 0;
            //    if (fourthDigit % 2 != 0)
            //    {
            //        evenCounter++;
            //    }
            //    for (int thirdDigit = startNumber % 100 / 10; thirdDigit <= endNumber % 100 / 10; thirdDigit++)
            //    {
            //        if (thirdDigit % 2 != 0)
            //        {
            //            evenCounter++;
            //        }
            //        for (int secondDigit = startNumber % 1000 / 100; secondDigit <= endNumber % 1000 / 100; secondDigit++)
            //        {
            //            if (secondDigit % 2 != 0)
            //            {
            //                evenCounter++;
            //            }
            //            for (int firstDigit = startNumber / 1000; firstDigit <= endNumber / 1000; firstDigit++)
            //            {
            //                if (firstDigit % 2 != 0)
            //                {
            //                    evenCounter++;
            //                }
            //                if (evenCounter == 4)
            //                {
            //                    Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit} ");
            //                }
            //                else
            //                {
            //                    break;
            //                }
            //            }
            //            if (evenCounter != 4)
            //            {
            //                break;
            //            }
            //        }
            //        if (evenCounter != 4)
            //        {
            //            break;
            //        }
            //    }
            //}

        }
    }
}
