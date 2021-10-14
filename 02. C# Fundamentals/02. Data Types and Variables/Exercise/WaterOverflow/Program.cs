using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPours = int.Parse(Console.ReadLine());
            int pouredWater = 0;

            for (int i = 1; i <= numberOfPours; i++)
            {
                int pour = int.Parse(Console.ReadLine());

                if (pour <= 255 - pouredWater)
                {
                    pouredWater += pour;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(pouredWater);
        }
    }
}
