using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringToRemove = Console.ReadLine();
            string input = Console.ReadLine();

            while (input.Contains(stringToRemove))
            {
                input = input.Remove(input.IndexOf(stringToRemove), stringToRemove.Length);
            }

            Console.WriteLine(input);
        }
    }
}
