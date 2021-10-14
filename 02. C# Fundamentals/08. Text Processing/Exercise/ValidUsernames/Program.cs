using System;
using System.Linq;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var user in usernames)
            {
                bool isValid = true;

                for (int i = 0; i < user.Length; i++)
                {
                    if (!((user.Length >= 3 && user.Length <= 16) && char.IsLetterOrDigit(user[i]) || user[i] == '-' || user[i] == '_'))
                    {
                        isValid = false;
                    }
                }

                if (isValid == true)
                {
                    Console.WriteLine(user);
                }
            }
        }
    }
}
