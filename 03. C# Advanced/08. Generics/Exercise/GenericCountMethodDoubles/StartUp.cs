using System;

namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }

            double elementForComparison = double.Parse(Console.ReadLine());

            Console.WriteLine(box.GreaterValueCounter(elementForComparison));
        }
    }
}
