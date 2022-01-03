using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string result = MiddleCharacters(input);

            Console.WriteLine(result);
        }

        static string MiddleCharacters(string input)
        {
            string result = "";

            if (input.Length % 2 == 0)
            {
                result = (char)input[input.Length / 2 - 1] + "" + (char)input[input.Length / 2];
            }
            else if (input.Length % 2 != 0)
            {
                result = (char)input[input.Length / 2] + "";
            }

            return result;
        }
    }
}
