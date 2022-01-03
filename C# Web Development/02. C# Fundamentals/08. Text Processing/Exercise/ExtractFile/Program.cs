using System;
using System.Linq;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split('\\', StringSplitOptions.RemoveEmptyEntries);

            string[] extractFile = input[input.Length - 1]
                .Split('.', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"File name: {extractFile[0]}");
            Console.WriteLine($"File extension: {extractFile[1]}");
        }
    }
}
