using System;
using System.Diagnostics;
using System.IO.Compression;

using static System.IO.File;
using static System.Console;

namespace Exercise3
{

    class Program
    {

        private static readonly string fileNameOfFileToCompress = @"C:\Users\bom89\OneDrive - Østfold University College\studier-2019-2020\.Net\exercise\Exercise3\datatext.txt";
        private static readonly string fileNameOfFileToDecompress = @"C:\Users\bom89\OneDrive - Østfold University College\studier-2019-2020\.Net\exercise\Exercise3\datatext.txt.gz.sec";
        public static void Main()
        {
            //Compress();
            Decompress();
        }

        public static void Compress()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            using( var inputStream = OpenRead(fileNameOfFileToCompress))
            {
                using( var outputStream = Create(fileNameOfFileToCompress + ".gz.sec"))
                {
                    using(var compressor = new GZipStream(outputStream, CompressionMode.Compress))
                    {
                        inputStream.CopyTo(compressor);
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Compressed a file and the time in {stopwatch.ElapsedMilliseconds} milliseconds.");
            ReadLine();
        }

       
        public static void Decompress()
        {
           var stopwatch = new Stopwatch();
            stopwatch.Restart();

            using(var inputStream = OpenRead(fileNameOfFileToDecompress))
            {
                using( var outputStream = Create(fileNameOfFileToDecompress + ".txt"))
                {
                    using(var decompressor = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                       decompressor.CopyTo(outputStream);
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Decompressed a file and the time its take is  {stopwatch.ElapsedMilliseconds} in milliseconds.");
            ReadLine();
        }
        
    }
}