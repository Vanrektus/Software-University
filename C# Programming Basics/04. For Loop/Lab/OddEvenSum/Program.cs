using System;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());

            int odd = 0;
            int even = 0;

            for (int i = 1; i <= numberOfNumbers; i++)
            {
                if (i % 2 != 0)
                {
                    int oddNumbers = int.Parse(Console.ReadLine());
                    odd += oddNumbers;
                }
                else
                {
                    int evenNumbers = int.Parse(Console.ReadLine());
                    even += evenNumbers;
                }
            }
            if (odd == even)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {odd}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(odd - even)}");
            }
        }
    }
}
