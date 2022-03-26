using System;

namespace T03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            int indexOfExtension = filePath.LastIndexOf('.');

            string fileExtension = filePath.Substring(indexOfExtension+1);
            filePath = filePath.Remove(indexOfExtension);

            int indexOfName = filePath.LastIndexOf('\\');
            string fileName = filePath.Substring(indexOfName+1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");

        }
    }
}
