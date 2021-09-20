using System;
using System.IO;
using System.Threading.Tasks;

namespace SliceAFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int parts = 5;
            byte[] buffer = new byte[4096];
            int totalBytes = 0;

            using (FileStream fileStream = new FileStream("TextFiles/sliceMe.txt", FileMode.Open, FileAccess.Read))
            {
                int partSize = (int)Math.Ceiling((decimal)fileStream.Length / parts);

                for (int i = 1; i <= parts; i++)
                {
                    int readBytes = 0;

                    using (FileStream outputFileStream = new FileStream($"Part-{i}.txt", FileMode.Create, FileAccess.Write))
                    {
                        while (readBytes < partSize && totalBytes < fileStream.Length)
                        {
                            int bytestToRead = Math.Min(buffer.Length, partSize - readBytes);
                            int bytes = await fileStream.ReadAsync(buffer, 0, bytestToRead);
                            await outputFileStream.WriteAsync(buffer, 0, bytes);

                            readBytes += bytes;
                            totalBytes += bytes;
                        }
                        
                    }
                }
            }
        }
    }
}
