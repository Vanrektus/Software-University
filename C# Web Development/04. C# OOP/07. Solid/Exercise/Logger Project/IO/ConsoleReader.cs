using System;

namespace LoggerLibrary.IO
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
