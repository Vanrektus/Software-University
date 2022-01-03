using System;

namespace WildFarm.IO
{
    public class ConsoleWriter : IWriter
    {
        //---------------------------Methods---------------------------
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
