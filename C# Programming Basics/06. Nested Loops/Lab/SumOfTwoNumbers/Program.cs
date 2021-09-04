using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int combinationNumber = 0;
            bool flag = false;

            for (int startNumber = start; startNumber <= finish; startNumber++)
            {
                for (int finishNumber = start; finishNumber <= finish; finishNumber++)
                {
                    combinationNumber++;
                    if (startNumber + finishNumber == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{combinationNumber} ({startNumber} + {finishNumber} = {magicNumber})");

                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"{combinationNumber} combinations - neither equals {magicNumber}");
            }
        }
    }
}
