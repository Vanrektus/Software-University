using System;

namespace ConcatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string string1 = Console.ReadLine();
            string string2 = Console.ReadLine();
            string string3 = Console.ReadLine();

            Console.WriteLine($"{string1}{string3}{string2}");
        }
    }
}
