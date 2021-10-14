using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryTraversal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> filesCollection = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directoryInfo = new DirectoryInfo("../../../FilesToInspect");
            FileInfo[] files = directoryInfo.GetFiles();

            foreach (var currentFile in files)
            {
                if (!filesCollection.ContainsKey(currentFile.Extension))
                {
                    filesCollection.Add(currentFile.Extension, new Dictionary<string, double>());
                }

                filesCollection[currentFile.Extension].Add(currentFile.Name, currentFile.Length);
            }

            using (StreamWriter writer = new StreamWriter(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\report.txt"))
            {
                foreach (var currentFile in filesCollection.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    await writer.WriteLineAsync(currentFile.Key);

                    foreach (var currentFileInfo in currentFile.Value)
                    {
                        await writer.WriteLineAsync($"--{currentFileInfo.Key} - {currentFileInfo.Value}kb");
                    }
                }
            }
        }
    }
}
