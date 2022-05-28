using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream reader = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
            using FileStream writer = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);

            while (true)
            {
                byte[] buffer = new byte[4096];
                int bytesRead = reader.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                {
                    break;
                }
                writer.Write(buffer, 0, bytesRead);
            }
        }
    }
}
