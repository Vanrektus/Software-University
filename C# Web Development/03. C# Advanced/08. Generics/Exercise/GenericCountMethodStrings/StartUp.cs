using System;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                box.Add(Console.ReadLine());
            }

            string elementForComparison = Console.ReadLine();

            Console.WriteLine(box.GreaterValueCounter(elementForComparison));
        }
    }
}
