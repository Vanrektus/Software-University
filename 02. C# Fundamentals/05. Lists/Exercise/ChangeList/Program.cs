using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
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

            while (true)
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "Delete":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] == int.Parse(command[1]))
                            {
                                numbers.Remove(int.Parse(command[1]));
                            }
                        }
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(command[1]);
                        int indexToInsert = int.Parse(command[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        break;
                }

                input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
