using System;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int totalSolutions = 0;

            for (int comb1 = 0; comb1 <= number; comb1++)
            {
                for (int comb2 = 0; comb2 <= number; comb2++)
                {
                    for (int comb3 = 0; comb3 <= number; comb3++)
                    {
                        if (comb1 + comb2 + comb3 == number)
                        {
                            totalSolutions++;
                        }
                    }
                }
            }
            Console.WriteLine(totalSolutions);
        }
    }
}
