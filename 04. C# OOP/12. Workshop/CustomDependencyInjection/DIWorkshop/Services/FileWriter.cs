using DIWorkshop.Contracts;
using System.IO;

namespace DIWorkshop.Services
{
    public class FileWriter : IFileWriter
    {
        //---------------------------Methods---------------------------
        public void Write(string text)
        {
            File.WriteAllText("log.txt", text);
        }
    }
}
