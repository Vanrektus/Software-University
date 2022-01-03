using System;
using System.Collections.Generic;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            bigNumber = bigNumber.TrimStart(new char[] { '0' });
            char[] bigNumberChars = bigNumber.ToCharArray();

            if (number == 0)
            {
                Console.WriteLine("0");
                return;
            }

            List<string> newNumber = new List<string>();

            int parse = 0;

            for (int i = bigNumberChars.Length - 1; i >= 0; i--)
            {
                parse = (int.Parse(Convert.ToString(bigNumberChars[i])) * number) + parse;
                newNumber.Insert(0, (parse % 10).ToString());
                parse /= 10;
            }

            if (parse > 0)
            {
                Console.WriteLine($"{parse}{string.Join("", newNumber)}");
            }
            else
            {
                Console.WriteLine($"{string.Join("", newNumber)}");
            }

        }
    }
}
