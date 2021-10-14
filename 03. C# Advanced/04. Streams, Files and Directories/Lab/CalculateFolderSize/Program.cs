using System;
using System.IO;

namespace CalculateFolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("TestFolder");
            double totalSize = 0;

            foreach (var currentFile in files)
            {
                FileInfo fileInfo = new FileInfo(currentFile);
                totalSize += fileInfo.Length;
            }

            totalSize = totalSize / 1024 / 1024;

            File.WriteAllText("Output.txt", totalSize.ToString());
        }
    }
}
