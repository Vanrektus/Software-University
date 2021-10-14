using System;

namespace ReadText
{
    class Program
    {
        static void Main(string[] args)
        {
            string ifStop = Console.ReadLine();

            while (ifStop != "Stop")
            {
                Console.WriteLine(ifStop);
                ifStop = Console.ReadLine();
            }
        }
    }
}
