using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());
            string peopleEntering = Console.ReadLine();

            int peopleCounter = 0;
            double totalIncome = 0;
            bool isFull = false;

            while (peopleEntering != "Movie time!")
            {
                peopleCounter += int.Parse(peopleEntering);
                totalIncome += int.Parse(peopleEntering) * 5;

                if (int.Parse(peopleEntering) % 3 == 0)
                {
                    totalIncome -= 5;
                }

                if (peopleCounter > hallCapacity)
                {
                    if (true)
                    {
                        if (int.Parse(peopleEntering) % 3 == 0)
                        {
                            totalIncome += 5;
                        }
                    }
                    isFull = true;
                    peopleCounter -= int.Parse(peopleEntering);
                    totalIncome -= int.Parse(peopleEntering) * 5;
                    break;
                }

                peopleEntering = Console.ReadLine();
            }

            if (isFull)
            {
                Console.WriteLine("The cinema is full.");
            }
            else
            {
                Console.WriteLine($"There are {hallCapacity - peopleCounter} seats left in the cinema.");
            }

            Console.WriteLine($"Cinema income - {totalIncome} lv.");
        }
    }
}
