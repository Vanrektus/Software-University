using System;
using System.IO;

namespace CalculateFolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileNames = Directory.GetFiles("TestFolder");
            double totalSize = 0;

            foreach (var currentFile in fileNames)
            {
                FileInfo info = new FileInfo(currentFile);
                totalSize += info.Length;
            }

            totalSize = totalSize / 1024 / 1024;

            File.WriteAllText("Output.txt", totalSize.ToString());
        }
    }
}
