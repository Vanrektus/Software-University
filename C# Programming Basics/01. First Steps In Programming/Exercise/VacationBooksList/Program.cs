using System;

namespace VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int daysToRead = int.Parse(Console.ReadLine());
            double totalTime = pages / pagesPerHour;
            double hoursPerDay = totalTime / daysToRead;
            Console.WriteLine(hoursPerDay);
        }
    }
}
