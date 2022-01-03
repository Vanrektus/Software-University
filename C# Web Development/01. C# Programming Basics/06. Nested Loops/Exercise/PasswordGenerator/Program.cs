using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int character1 = 1; character1 <= n; character1++)
            {
                for (int character2 = 1; character2 <= n; character2++)
                {
                    for (int character3 = 97; character3 < 97 + l; character3++)
                    {
                        for (int character4 = 97; character4 < 97 + l; character4++)
                        {
                            for (int character5 = 1; character5 <= n; character5++)
                            {
                                if (character5 > character1 && character5 > character2)
                                {
                                    Console.Write($"{character1}{character2}{Convert.ToChar(character3)}{Convert.ToChar(character4)}{character5} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
