using System;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                char[] reversedInput = input.ToCharArray();
                Array.Reverse(reversedInput);

                Console.WriteLine($"{input} = {string.Join("", reversedInput)}");
            }
        }
    }

    //          Another way to solve it
    //static void Main(string[] args)
    //{
    //    Dictionary<string, char[]> reverseStrings = new Dictionary<string, char[]>();

    //    while (true)
    //    {
    //        string input = Console.ReadLine();

    //        if (input == "end")
    //        {
    //            break;
    //        }

    //        char[] reversedInput = input.ToCharArray();
    //        Array.Reverse(reversedInput);

    //        reverseStrings.Add(input, reversedInput);
    //    }

    //    foreach (var item in reverseStrings)
    //    {
    //        Console.WriteLine($"{item.Key} = {string.Join("", item.Value)}");
    //    }
    //}
}
