using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (LengthCheck(password) == true && InvalidCharacters(password) == false && MinDigits(password) == true)
            {
                Console.WriteLine("Password is valid");
                return;
            }

            if (LengthCheck(password) == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (InvalidCharacters(password) == true)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (MinDigits(password) == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        static bool LengthCheck(string password)
        {
            bool lengthCheck = false;

            if (password.Length >= 6 && password.Length <= 10)
            {
                lengthCheck = true;
            }

            return lengthCheck;
        }

        static bool InvalidCharacters(string password)
        {
            bool invalidCharacters = false;

            foreach (char currentChar in password)
            {
                if ((currentChar >= 33 && currentChar <= 47)
                    || (currentChar >= 58 && currentChar <= 64)
                    || (currentChar >= 123 && currentChar <= 127))
                {
                    invalidCharacters = true;
                }
            }

            return invalidCharacters;
        }

        static bool MinDigits(string password)
        {
            bool minDigits = false;
            int digitsCounter = 0;

            foreach (char currentChar in password)
            {
                if (currentChar >= 48 && currentChar <= 57)
                {
                    digitsCounter++;
                }
            }

            if (digitsCounter >= 2)
            {
                minDigits = true;
            }

            return minDigits;
        }
    }
}
