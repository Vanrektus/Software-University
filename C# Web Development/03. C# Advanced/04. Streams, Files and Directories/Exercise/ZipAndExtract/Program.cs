using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("../../../FilesToZip", "../../../FilesToUnzip/ZippedFiles.zip");
            ZipFile.ExtractToDirectory("../../../FilesToUnzip/ZippedFiles.zip", "../../../FilesToUnzip");
        }
    }
}
