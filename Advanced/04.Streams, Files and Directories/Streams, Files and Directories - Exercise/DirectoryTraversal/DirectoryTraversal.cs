using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    using System;
    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] allFiles = Directory.GetFiles(inputFolderPath);
            Dictionary<string, List<FileInfo>> extensions = new Dictionary<string, List<FileInfo>>();
            foreach (var file in allFiles)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;

                if (!extensions.ContainsKey(extension))
                {
                    extensions[extension] = new List<FileInfo>();
                }
                extensions[extension].Add(fileInfo);
            }

            var ordered = extensions.OrderByDescending(entry => entry.Value.Count).ThenBy(entry => entry.Key);
            var sb = new StringBuilder();
            foreach (var extension in ordered)
            {
                sb.AppendLine(extension.Key);
                var orderedList = extension.Value.OrderByDescending(x => x.Length);
                foreach (var fileInfo in orderedList)
                {
                    sb.AppendLine($"--{fileInfo.Name} - {fileInfo.Length / 1024:f3}kb");
                }
            }
            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(path, textContent);
        }

    }
}
