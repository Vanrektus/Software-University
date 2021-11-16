using System;

namespace CommandPattern.IO
{
    public class ConsoleReader : IReader
    {
        //---------------------------Methods---------------------------
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
