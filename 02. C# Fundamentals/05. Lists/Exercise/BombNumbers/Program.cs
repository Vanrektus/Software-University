using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> bomb = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int counter = 1;

                if (numbers[i] == bomb[0])
                {
                    for (int k = 0; k < bomb[1]; k++)
                    {
                        if (i + counter > numbers.Count - 1)
                        {
                            break;
                        }
                        else
                        {
                            numbers.RemoveAt(i + 1);
                        }
                    }


                    for (int k = 0; k < bomb[1]; k++)
                    {
                        if (i - counter < 0)
                        {
                            break;
                        }
                        else
                        {
                            numbers.RemoveAt(i - counter);
                            counter++;
                        }
                    }
                }

                
            }

            int sum = 0;

            foreach (var currentNumber in numbers)
            {
                if (currentNumber != bomb[0])
                {
                    sum += currentNumber;
                }
            }

            Console.WriteLine(sum);
            //Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
