using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double pricePerLightsaber = double.Parse(Console.ReadLine());
            double pricePerRobe = double.Parse(Console.ReadLine());
            double pricePerBelt = double.Parse(Console.ReadLine());

            int totalLightsabersPrice = (int)Math.Ceiling(numberOfStudents * 1.1);
            double totalRobesPrice = numberOfStudents * pricePerRobe;
            double totalBeltsPrice = (numberOfStudents - numberOfStudents / 6) * pricePerBelt;

            double totalPrice = totalLightsabersPrice * pricePerLightsaber + totalRobesPrice + totalBeltsPrice;

            if (budget >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalPrice - budget:f2}lv more.");
            }
        }
    }
}
