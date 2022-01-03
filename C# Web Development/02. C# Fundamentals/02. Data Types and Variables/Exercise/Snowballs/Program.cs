using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());
            BigInteger bestSnowballValue = -1;
            string result = "";

            for (int i = 1; i <= numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (snowballValue > bestSnowballValue)
                {
                    bestSnowballValue = snowballValue;
                    result = $"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})";
                }
            }
            Console.WriteLine(result);
        }
    }
}
