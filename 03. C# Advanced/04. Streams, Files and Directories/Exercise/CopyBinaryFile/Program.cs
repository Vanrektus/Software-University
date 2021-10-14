using System;
using System.IO;
using System.Threading.Tasks;

namespace CopyBinaryFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (FileStream inputFileStream = new FileStream("copyMe.png", FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[4096];
                int bytes = await inputFileStream.ReadAsync(buffer, 0, buffer.Length);

                using (FileStream outputFileStream = new FileStream("result.png", FileMode.Create, FileAccess.Write))
                {
                    while (bytes != 0)
                    {
                        await outputFileStream.WriteAsync(buffer, 0, bytes);
                        bytes = await inputFileStream.ReadAsync(buffer, 0, buffer.Length);
                    }
                }


            }
        }
    }
}
