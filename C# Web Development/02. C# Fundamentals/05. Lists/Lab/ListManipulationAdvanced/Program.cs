using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            bool isBasic = false;

            while (true)
            {
                string[] command = input.Split();

                List<int> filteredList = new List<int>();

                switch (command[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(command[1]));
                        isBasic = true;
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(command[1]));
                        isBasic = true;
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(command[1]));
                        isBasic = true;
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        isBasic = true;
                        break;
                    case "Contains":
                        if (numbers.Contains(int.Parse(command[1])) == true)
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        foreach (var currentNumber in numbers)
                        {
                            if (currentNumber % 2 == 0)
                            {
                                Console.Write($"{currentNumber} ");
                            }
                        }

                        Console.WriteLine();
                        break;
                    case "PrintOdd":
                        foreach (var currentNumber in numbers)
                        {
                            if (currentNumber % 2 != 0)
                            {
                                Console.Write($"{currentNumber} ");
                            }
                        }

                        Console.WriteLine();
                        break;
                    case "GetSum":
                        int sumOfNumbers = 0;
                        foreach (var currentNumber in numbers)
                        {
                            sumOfNumbers += currentNumber;
                        }

                        Console.WriteLine(sumOfNumbers);
                        break;
                    case "Filter":
                        switch (command[1])
                        {
                            case ">=":
                                foreach (var currentNumber in numbers)
                                {
                                    if (currentNumber >= int.Parse(command[2]))
                                    {
                                        filteredList.Add(currentNumber);
                                    }
                                }

                                Console.WriteLine(string.Join(" ", filteredList));
                                break;
                            case "<=":
                                foreach (var currentNumber in numbers)
                                {
                                    if (currentNumber <= int.Parse(command[2]))
                                    {
                                        filteredList.Add(currentNumber);
                                    }
                                }

                                Console.WriteLine(string.Join(" ", filteredList));
                                break;
                            case ">":
                                foreach (var currentNumber in numbers)
                                {
                                    if (currentNumber > int.Parse(command[2]))
                                    {
                                        filteredList.Add(currentNumber);
                                    }
                                }

                                Console.WriteLine(string.Join(" ", filteredList));
                                break;
                            case "<":
                                foreach (var currentNumber in numbers)
                                {
                                    if (currentNumber < int.Parse(command[2]))
                                    {
                                        filteredList.Add(currentNumber);
                                    }
                                }

                                Console.WriteLine(string.Join(" ", filteredList));
                                break;
                        }
                        break;
                }

                input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
            }

            if (isBasic == true)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
