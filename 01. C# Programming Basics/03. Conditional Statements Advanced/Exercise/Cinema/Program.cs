using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            int totalSeats = rows * columns;

            switch (projection)
            {
                case "Premiere":
                    Console.WriteLine($"{totalSeats * 12:f2} leva");
                    break;
                case "Normal":
                    Console.WriteLine($"{totalSeats * 7.5:f2} leva");
                    break;
                case "Discount":
                    Console.WriteLine($"{totalSeats * 5:f2} leva");
                    break;
            }
        }
    }
}
