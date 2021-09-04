using System;

namespace MultiplicationTable2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplicationNumber = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine($"{number} X {multiplicationNumber} = {number * multiplicationNumber}");
                multiplicationNumber++;
            } while (multiplicationNumber <= 10);
        }
    }
}
