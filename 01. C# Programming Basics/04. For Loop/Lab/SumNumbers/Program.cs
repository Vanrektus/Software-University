using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < number; i++)
            {
                int number2 = int.Parse(Console.ReadLine());
                sum = sum + number2;
            }
            Console.WriteLine(sum);
        }
    }
}
