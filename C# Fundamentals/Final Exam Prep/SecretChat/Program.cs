using System;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Reveal")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "InsertSpace":
                        input = input.Insert(int.Parse(commands[1]), " ");

                        Console.WriteLine(input);
                        break;
                    case "Reverse":
                        if (input.Contains(commands[1]))
                        {
                            int index = input.IndexOf(commands[1]);
                            input = input.Remove(input.IndexOf(commands[1]), commands[1].Length);

                            char[] charArray = commands[1].ToCharArray();
                            Array.Reverse(charArray);

                            input = input.Insert(input.Length, new string(charArray));

                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        if (input.Contains(commands[1]))
                        {
                            input = input.Replace(commands[1], commands[2]);

                            Console.WriteLine(input);
                        }
                        break;
                }
            }
            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}
