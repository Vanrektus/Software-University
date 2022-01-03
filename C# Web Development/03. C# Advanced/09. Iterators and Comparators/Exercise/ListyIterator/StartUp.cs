using System;
using System.Linq;

namespace Iterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> list = null;

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "END")
                {
                    break;
                }

                switch (command[0])
                {
                    case "Create":
                        list = new ListyIterator<string>(command.Skip(1).ToArray());
                        break;

                    case "Move":
                        Console.WriteLine(list.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;

                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
