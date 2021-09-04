using System;

namespace TopNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            TopNumber(number);
        }

        static void TopNumber(int number)
        {
            for (int currentNumber = 1; currentNumber <= number; currentNumber++)
            {
                bool isValid = false;
                int numberCopy = currentNumber;
                int secondCopy = currentNumber;
                int sum = 0;

                while (numberCopy > 0)
                {
                    sum += numberCopy % 10;

                    numberCopy /= 10; 
                }

                while (secondCopy > 0)
                {
                    if ((secondCopy % 10) % 2 != 0)
                    {
                        isValid = true;
                    }

                    secondCopy /= 10;
                }

                if (sum % 8 == 0 && isValid == true)
                {
                    Console.WriteLine(currentNumber);
                }
            }
        }
    }
}
