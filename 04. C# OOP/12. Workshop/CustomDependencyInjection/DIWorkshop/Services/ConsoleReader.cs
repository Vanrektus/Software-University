using DIWorkshop.Contracts;
using System;

namespace DIWorkshop.Services
{
    public class ConsoleReader : IReader
    {
        //---------------------------Methods---------------------------
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
