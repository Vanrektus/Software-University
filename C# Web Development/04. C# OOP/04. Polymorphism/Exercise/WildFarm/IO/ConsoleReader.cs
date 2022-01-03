using System;

namespace WildFarm.IO
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
