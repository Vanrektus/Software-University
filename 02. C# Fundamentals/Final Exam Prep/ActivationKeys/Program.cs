using System;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Generate")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "Contains":
                        if (rawActivationKey.Contains(commands[1]))
                        {
                            Console.WriteLine($"{rawActivationKey} contains {commands[1]}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        if (commands[1] == "Upper")
                        {
                            string substringToChange = rawActivationKey.Substring(int.Parse(commands[2]), int.Parse(commands[3]) - int.Parse(commands[2]));
                            string newSubstring = substringToChange.ToUpper();

                            rawActivationKey = rawActivationKey.Replace(substringToChange, newSubstring);

                            Console.WriteLine(rawActivationKey);
                        }
                        else if (commands[1] == "Lower")
                        {
                            string substringToChange = rawActivationKey.Substring(int.Parse(commands[2]), int.Parse(commands[3]) - int.Parse(commands[2]));
                            string newSubstring = substringToChange.ToLower();

                            rawActivationKey = rawActivationKey.Replace(substringToChange, newSubstring);

                            Console.WriteLine(rawActivationKey);
                        }
                        break;
                    case "Slice":
                        rawActivationKey = rawActivationKey.Remove(int.Parse(commands[1]), int.Parse(commands[2]) - int.Parse(commands[1]));

                        Console.WriteLine(rawActivationKey);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }
    }
}
