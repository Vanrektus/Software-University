using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int availableSpace = width * length * height;
            int totalSpaceOfBoxes = 0;

            while (input != "Done")
            {
                int numberOfBoxes = int.Parse(input);
                totalSpaceOfBoxes += numberOfBoxes;
                if (totalSpaceOfBoxes > availableSpace)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if (totalSpaceOfBoxes > availableSpace)
            {
                Console.WriteLine($"No more free space! You need {totalSpaceOfBoxes - availableSpace} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{availableSpace - totalSpaceOfBoxes} Cubic meters left.");
            }
        }
    }
}
