using System;

namespace OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());

            double figurines = rent * 0.7;
            double catering = figurines * 0.85;
            double sound = catering / 2;

            Console.WriteLine($"{rent + figurines + catering + sound:f2}");
        }
    }
}
