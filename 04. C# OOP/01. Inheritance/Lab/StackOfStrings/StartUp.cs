using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();

            System.Console.WriteLine(stackOfStrings.IsEmpty());

            stackOfStrings.Push("Ivan");
            System.Console.WriteLine(stackOfStrings.IsEmpty());

            string[] elementsToAdd = new string[5] { "Ivan", "Ani", "Pesho", "Gosho", "Aleks" };
            Stack<string> result = stackOfStrings.AddRange(elementsToAdd);
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
