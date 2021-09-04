using System;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());

            int left = 0;
            int right = 0;

            for (int i = 1; i <= numberOfNumbers; i++)
            {
                int leftNumbers = int.Parse(Console.ReadLine());
                left += leftNumbers;
            }
            for (int i = 1; i <= numberOfNumbers; i++)
            {
                int rightNumbers = int.Parse(Console.ReadLine());
                right += rightNumbers;
            }
            if (left == right)
            {
                Console.WriteLine($"Yes, sum = {left}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(left - right)}");
            }
        }
    }
}
