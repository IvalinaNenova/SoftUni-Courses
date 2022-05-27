using System.Collections.Generic;
using System.Text;

namespace ExtractBytes
{
    using System;
    using System.IO;
    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using StreamReader sr = new StreamReader(bytesFilePath);
            byte[] fileBytes = File.ReadAllBytes(binaryFilePath);
            List<string> bytesList = new List<string>();
            StringBuilder sb = new StringBuilder();

            while (!sr.EndOfStream)
            {
                bytesList.Add(sr.ReadLine());
            }

            foreach (var item in fileBytes)
            {
                if (bytesList.Contains(item.ToString()))
                {
                    sb.AppendLine(item.ToString());
                }
            }

            using StreamWriter writer = new StreamWriter(outputPath);
            writer.WriteLine(sb.ToString().Trim());




        }
    }
}
