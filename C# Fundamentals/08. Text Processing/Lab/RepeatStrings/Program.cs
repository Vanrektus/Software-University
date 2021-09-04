using System;
using System.Text;

namespace RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StringBuilder joinedStrings = new StringBuilder();

            foreach (var word in input)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    joinedStrings.Append(word);
                }
            }

            Console.WriteLine(joinedStrings);
        }
    }
}
