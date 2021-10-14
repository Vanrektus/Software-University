using System;

namespace TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfDays = int.Parse(Console.ReadLine());

            double moneyWonPerDay = 0;
            double totalMoneyWon = 0;
            int gamesWonPerDay = 0;
            int gamesLostPerDay = 0;
            int daysWon = 0;
            int daysLost = 0;

            for (int i = 1; i <= numOfDays; i++)
            {

                string sport = Console.ReadLine();
                moneyWonPerDay = 0;
                gamesWonPerDay = 0;
                gamesLostPerDay = 0;
                while (sport != "Finish")
                {
                    string winOrLose = Console.ReadLine();

                    if (winOrLose == "win")
                    {
                        moneyWonPerDay += 20;
                        totalMoneyWon += 20;
                        gamesWonPerDay++;
                    }
                    else if (winOrLose == "lose")
                    {
                        gamesLostPerDay++;
                    }

                    sport = Console.ReadLine();
                }
                if (gamesWonPerDay > gamesLostPerDay)
                {
                    daysWon++;
                    totalMoneyWon += moneyWonPerDay * 0.1;
                }
                else if (gamesWonPerDay < gamesLostPerDay)
                {
                    daysLost++;
                }
            }

            if (daysWon > daysLost)
            {
                totalMoneyWon += totalMoneyWon * 0.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoneyWon:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoneyWon:f2}");
            }
        }
    }
}
