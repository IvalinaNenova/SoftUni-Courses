namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            float totalSize = GetFolderSize(folderPath, outputPath);
            File.WriteAllText(outputPath,$"{totalSize/1024}");
        }

        public static float GetFolderSize(string folderPath, string outputFilePath)
        {
            float folderSize = 0;

            foreach (var file in Directory.GetFiles(folderPath))
            {
                FileInfo fileInfo = new FileInfo(file);
                folderSize += fileInfo.Length;
            }

            var subDirectories = Directory.GetDirectories(folderPath);

            foreach (var subDirectory in subDirectories)
            {
               folderSize+= GetFolderSize(subDirectory, outputFilePath);
            }


            return folderSize;
        }
    }
}
