using System;
using System.Linq;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Select(x => (char)(x + 3))
                .ToList()
                .ForEach(x => Console.Write(x));
        }
    }
}
