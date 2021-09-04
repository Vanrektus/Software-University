using System;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string password = Console.ReadLine();

            string passwordIsTrue = Console.ReadLine();

            while (password != passwordIsTrue)
            {
                passwordIsTrue = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {name}!");
        }
    }
}
