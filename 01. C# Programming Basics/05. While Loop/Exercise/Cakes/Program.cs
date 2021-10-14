using System;

namespace Cakes
{
    class Program
    {
        static void Main(string[] args)
        {
            int widthOfCake = int.Parse(Console.ReadLine());
            int lengthOfCake = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int totalCake = widthOfCake * lengthOfCake;

            while (input != "STOP")
            {
                int numberOfPieces = int.Parse(input);
                totalCake -= numberOfPieces;
                if (totalCake <= 0)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if (totalCake > 0)
            {
                Console.WriteLine($"{totalCake} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(totalCake)} pieces more.");
            }
        }
    }
}
