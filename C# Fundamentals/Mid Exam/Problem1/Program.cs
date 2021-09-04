using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int numberOfBattles = int.Parse(Console.ReadLine());

            int battleCount = 0;

            for (int i = 1; i <= numberOfBattles; i++)
            {
                double currentExperience = double.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    neededExperience -= currentExperience + (currentExperience * 0.15);
                }
                else if (i % 5 == 0)
                {
                    neededExperience -= currentExperience - (currentExperience * 0.10);
                }
                else if (i % 15 == 0)
                {
                    neededExperience -= currentExperience + (currentExperience * 0.10);
                }
                else
                {
                    neededExperience -= currentExperience;
                }

                if (neededExperience <= 0)
                {
                    battleCount = i;
                    break;
                }
            }

            if (neededExperience <= 0)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battleCount} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience:f2} more needed.");
            }
        }
    }
}
