using System;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args) 
        {
            int number = int.Parse(Console.ReadLine());

            int counter = 0;
            bool isTrue = false;

            for (int rows = 1; rows <= number; rows++)
            {
                for (int columns = 1; columns <= rows; columns++)
                {
                    counter++;
                    Console.Write($"{counter} ");
                    if (counter >= number)
                    {
                        isTrue = true;
                        break;
                    }
                }
                if (isTrue == true)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
