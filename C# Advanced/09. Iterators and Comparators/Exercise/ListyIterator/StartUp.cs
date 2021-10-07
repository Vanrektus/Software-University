using System;

namespace Iterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] createList = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ListyIterator<string> list = new ListyIterator<string>(createList);

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
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Print":
                        list.Print();
                        break;
                }
            }
        }
    }
}
