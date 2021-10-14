using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfYear = Console.ReadLine();
            double numberOfHolydays = double.Parse(Console.ReadLine());
            double numberOfTravelWeekends = double.Parse(Console.ReadLine());

            double numberOfNonTravelWeekends = 48 - numberOfTravelWeekends;
            double ThreeOutOfFour = numberOfNonTravelWeekends * 3 / 4;
            double TwoOutOfThree = numberOfHolydays * 2 / 3;
            double totalPlayDays = ThreeOutOfFour + numberOfTravelWeekends + TwoOutOfThree;

            if (typeOfYear == "leap")
            {
                totalPlayDays = totalPlayDays + totalPlayDays * 0.15;
            }
            Console.WriteLine(Math.Floor(totalPlayDays));
        }
    }
}
