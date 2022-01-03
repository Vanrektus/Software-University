using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                int lineNumber = 1;
                string line = await reader.ReadLineAsync();

                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    while (line != null)
                    {
                        await writer.WriteLineAsync($"Line {lineNumber}: {line} ({LetterCount(line)})({PunctMarksCount(line)})");

                        lineNumber++;
                        line = await reader.ReadLineAsync();
                    }
                }
            }
        }
        
        static int LetterCount(string line)
        {
            int letterCounter = 0;

            foreach (char currentChar in line)
            {
                if (char.IsLetter(currentChar))
                {
                    letterCounter++;
                }
            }

            return letterCounter;
        }

        static int PunctMarksCount(string line)
        {
            string pattern = @"[-,.!?';:]";
            MatchCollection matches = Regex.Matches(line, pattern);

            return matches.Count;
        }

    }
}
