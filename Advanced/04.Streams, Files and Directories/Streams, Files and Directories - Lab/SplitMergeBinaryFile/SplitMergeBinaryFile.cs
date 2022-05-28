namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using FileStream reader = new FileStream(sourceFilePath, FileMode.Open);
            using FileStream writer1 = new FileStream(partOneFilePath, FileMode.OpenOrCreate);
            using FileStream writer2 = new FileStream(partTwoFilePath, FileMode.OpenOrCreate);

            long size1 = reader.Length/2;
            long size2 = reader.Length-size1;

            if (size2 > size1)
            {
                (size2, size1) = (size1, size2);
            }

            byte[] buff1 = new byte[size1];
            reader.Read(buff1);
            writer1.Write(buff1);

            byte[] buff2 = new byte[size2];
            reader.Read(buff2);
            writer2.Write(buff2);

        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using FileStream writer = new FileStream(joinedFilePath, FileMode.Create);
            using FileStream reader1 = new FileStream(partOneFilePath, FileMode.Open);
            byte[] buff1 = new byte[reader1.Length];
            reader1.Read(buff1);
            writer.Write(buff1);

            using FileStream reader2 = new FileStream(partTwoFilePath, FileMode.Open);
            byte[] buff2 = new byte[reader2.Length];
            reader2.Read(buff2);
            writer.Write(buff2);


        }
    }
}