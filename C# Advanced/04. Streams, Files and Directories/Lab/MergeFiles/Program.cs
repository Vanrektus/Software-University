using System;
using System.IO;
using System.Threading.Tasks;

namespace MergeFiles
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader readerFileOne = new StreamReader("TextFiles/FileOne.txt"))
            using (StreamReader readerFileTwo = new StreamReader("TextFiles/FileTwo.txt"))
            {
                string lineOne = await readerFileOne.ReadToEndAsync();
                string[] lineOneArray = lineOne
                    .Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

                string lineTwo = await readerFileTwo.ReadToEndAsync();
                string[] lineTwoArray = lineTwo
                    .Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

                int shorterLength = Math.Min(lineOneArray.Length, lineTwoArray.Length);
                int longerLength = Math.Max(lineOneArray.Length, lineTwoArray.Length);

                using (StreamWriter writer = new StreamWriter("Output.txt"))
                {
                    for (int i = 0; i < shorterLength; i++)
                    {
                        writer.WriteLine(lineOneArray[i]);
                        writer.WriteLine(lineTwoArray[i]);
                    }

                    for (int i = shorterLength; i < longerLength; i++)
                    {
                        if (lineOneArray.Length == longerLength)
                        {
                            writer.WriteLine(lineOneArray[i]);
                        }
                        else
                        {
                            writer.WriteLine(lineTwoArray[i]);
                        }
                    }
                }
            }
        }
    }
}
