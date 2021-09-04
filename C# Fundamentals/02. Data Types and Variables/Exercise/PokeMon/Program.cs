namespace PokeMon
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int pokePowerN = int.Parse(Console.ReadLine());
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionY = int.Parse(Console.ReadLine());

            int pokePowerOriginalValue = pokePowerN;
            int pokeCounter = 0;

            while (pokePowerN >= distanceM)
            {
                pokeCounter++;
                pokePowerN -= distanceM;

                if (pokePowerN == pokePowerOriginalValue * 0.5 && exhaustionY != 0)
                {
                    pokePowerN /= exhaustionY;
                }
            }

            Console.WriteLine(pokePowerN);
            Console.WriteLine(pokeCounter);
        }
    }
}
