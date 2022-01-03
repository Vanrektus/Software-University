using System;

namespace LoggerLibrary.IO
{
    public class ConsoleWriter : IWriter
    {
        //---------------------------Methods---------------------------
        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
