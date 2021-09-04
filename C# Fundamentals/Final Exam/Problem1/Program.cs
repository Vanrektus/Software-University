using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Registration")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "Letters":
                        if (commands[1] == "Upper")
                        {
                            input = input.ToUpper();

                            Console.WriteLine(input);
                        }
                        else if (commands[1] == "Lower")
                        {
                            input = input.ToLower();

                            Console.WriteLine(input);
                        }
                        break;
                    case "Reverse":

                        if (int.Parse(commands[1]) < 0 || int.Parse(commands[2]) >= input.Length)
                        {
                            break;
                        }
                        else if (!(int.Parse(commands[1]) < 0) || !(int.Parse(commands[2]) >= input.Length))
                        {
                            string substringToChange = input.Substring(int.Parse(commands[1]), int.Parse(commands[2]) - int.Parse(commands[1]) + 1);

                            char[] charArray = substringToChange.ToCharArray();
                            Array.Reverse(charArray);

                            Console.WriteLine(string.Join("", charArray));
                        }
                        break;
                    case "Substring":
                        if (input.Contains(commands[1]))
                        {
                            int index = input.IndexOf(commands[1]);
                            input = input.Remove(index, commands[1].Length);

                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine($"The username {input} doesn't contain {commands[1]}.");
                        }
                        break;
                    case "Replace":
                        if (input.Contains(commands[1]))
                        {
                            input = input.Replace(char.Parse(commands[1]), '-');

                            Console.WriteLine(input);
                        }
                        break;
                    case "IsValid":
                        if (input.Contains(commands[1]))
                        {
                            Console.WriteLine("Valid username.");
                        }
                        else
                        {
                            Console.WriteLine($"{commands[1]} must be contained in your username.");
                        }
                        break;
                }
            }
        }
    }
}
