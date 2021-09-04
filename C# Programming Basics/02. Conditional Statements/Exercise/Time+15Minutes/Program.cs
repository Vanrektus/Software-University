using System;

namespace TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            double hours = double.Parse(Console.ReadLine());
            double minutes = double.Parse(Console.ReadLine());
            hours = hours * 60;
            double totalTime = hours + minutes;
            double outputTime = totalTime + 15;
            double outputHours = outputTime / 60;
            double outputMinutes = outputTime % 60;

            outputHours = Math.Floor(outputHours);

            if (outputHours >= 24)
            {
                outputHours = outputHours - outputHours;
            }
            if (outputMinutes < 10)
            {
                Console.WriteLine($"{outputHours}:0{outputMinutes}");
            }
            else
            {
                Console.WriteLine($"{outputHours:f0}:{outputMinutes}");
            }
        }
    }
}
