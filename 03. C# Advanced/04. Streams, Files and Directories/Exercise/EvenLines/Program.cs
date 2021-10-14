using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

namespace EvenLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                int lineCounter = 0;
                string line = await reader.ReadLineAsync();

                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    while (line != null)
                    {
                        if (lineCounter % 2 == 0)
                        {
                            Regex pattern = new Regex("[-,.!?]");
                            line = pattern.Replace(line, "@");

                            string[] lineArray = line
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Reverse()
                                .ToArray();

                            await writer.WriteLineAsync(string.Join(" ", lineArray));

                        }

                        lineCounter++;
                        line = await reader.ReadLineAsync();
                    }
                }
            }
        }
    }
}
