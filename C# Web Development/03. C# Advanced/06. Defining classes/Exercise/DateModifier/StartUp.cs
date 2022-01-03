using System;

namespace DateModifierExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            Console.WriteLine(dateModifier.GetDaysDifference(startDate, endDate));
        }
    }
}
