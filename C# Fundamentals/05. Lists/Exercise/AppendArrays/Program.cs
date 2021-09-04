using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arrays = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToList();

            List<string> result = new List<string>();

            for (int currentArray = 0; currentArray < arrays.Count; currentArray++)
            {
                List<string> values = arrays[currentArray]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                result.AddRange(values);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
