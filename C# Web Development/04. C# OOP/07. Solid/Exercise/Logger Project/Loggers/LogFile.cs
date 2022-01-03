using LoggerLibrary.Interfaces;
using System.IO;
using System.Linq;

namespace LoggerLibrary.Loggers
{
    public class LogFile : ILogFile
    {
        //---------------------------Constants---------------------------
        private const string filePath = "log.txt";

        //---------------------------Properties---------------------------
        public int Size
        {
            get
            {
                using (StreamReader stream = new StreamReader(filePath))
                {
                    return stream.ReadToEnd()
                        .ToCharArray()
                        .Where(char.IsLetter)
                        .Sum(x => x);
                }
            }
        }

        //---------------------------Methods---------------------------
        public void Write(string message)
        {
            using (StreamWriter stream = new StreamWriter(filePath, true))
            {
                stream.WriteLine(message);
            }
        }
    }
}
