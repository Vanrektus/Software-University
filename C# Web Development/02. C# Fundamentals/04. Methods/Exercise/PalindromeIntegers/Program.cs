using System;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            IsPalindrome(input);
        }

        static void IsPalindrome(string input)
        {
            while (input != "END")
            {
                int number = int.Parse(input);
                int reminder = 0;
                int sum = 0;
                int numberCopy = number;

                while (number > 0)
                {
                    reminder = number % 10;

                    sum = (sum * 10) + reminder;

                    number = number / 10;
                }

                if (sum == numberCopy)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                input = Console.ReadLine();
            }
        }
    }
}
