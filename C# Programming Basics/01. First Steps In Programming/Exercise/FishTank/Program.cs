using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            int aquariumVolume = length * width * height;
            double aquariumCapacity = aquariumVolume * 0.001;
            double percentTotal = percent * 0.01;
            double NeededLiters = aquariumCapacity * (1 - percentTotal);
            Console.WriteLine(NeededLiters);
        }
    }
}
