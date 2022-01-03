using System;

namespace HighJump
{
    class Program
    {
        static void Main(string[] args)
        {
            int wantedHeight = int.Parse(Console.ReadLine());

            int currentHeight = wantedHeight - 30;
            int unsuccessfulJumps = 0;
            int totalJumps = 0;

            while (unsuccessfulJumps != 3)
            {
                int currentJump = int.Parse(Console.ReadLine());

                totalJumps++;

                if (currentHeight >= wantedHeight && currentJump > wantedHeight)
                {
                    break;
                }

                if (currentJump > currentHeight)
                {
                    currentHeight += 5;
                    unsuccessfulJumps = 0;
                }
                else
                {
                    unsuccessfulJumps++;
                }
            }

            if (unsuccessfulJumps == 3)
            {
                Console.WriteLine($"Tihomir failed at {currentHeight}cm after {totalJumps} jumps.");
            }
            else
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {currentHeight}cm after {totalJumps} jumps.");
            }
        }
    }
}
