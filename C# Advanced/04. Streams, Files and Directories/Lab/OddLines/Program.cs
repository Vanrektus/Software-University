using System;
using System.IO;
using System.Threading.Tasks;

namespace OddLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader str = new StreamReader("Input.txt"))
            {
                int currentLine = 0;
                string line = await str.ReadLineAsync();

                while (line != null)
                {
                    if (currentLine % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    line = await str.ReadLineAsync();
                    currentLine++;
                }
            }
        }
    }
}
