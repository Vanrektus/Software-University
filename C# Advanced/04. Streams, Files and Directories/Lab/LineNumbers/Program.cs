using System;
using System.IO;
using System.Threading.Tasks;

namespace LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("TextFiles/Input.txt"))
            {
                int currentLine = 1;
                string line = await reader.ReadLineAsync();

                using (StreamWriter writer = new StreamWriter("Output.txt"))
                {
                    while (line != null)
                    {
                        await writer.WriteLineAsync($"{currentLine}. {line}");

                        line = await reader.ReadLineAsync();
                        currentLine++;
                    }
                }
            }

            //ANOTHER WAY - FILE CLASS

            string[] lines = await File.ReadAllLinesAsync("TextFiles/Input.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = $"{i + 1}. {lines[i]}";
            }

            await File.WriteAllLinesAsync("OutPut2.txt", lines);
        }
    }
}
