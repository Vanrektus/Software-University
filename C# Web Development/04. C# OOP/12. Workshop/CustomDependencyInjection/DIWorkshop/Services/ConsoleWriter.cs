using DIWorkshop.Contracts;
using System;

namespace DIWorkshop.Services
{
    public class ConsoleWriter : IConsoleWriter
    {
        //---------------------------Methods---------------------------
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
