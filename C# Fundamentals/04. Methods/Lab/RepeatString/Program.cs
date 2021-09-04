using System;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string result = JoinStrings(input, n);

            Console.WriteLine(result);
        }

        static string JoinStrings(string str, int count)
        {
            string result = "";

            for (int i = 1; i <= count; i++)
            {
                result += str;
            }

            return result;
        }
    }
}
