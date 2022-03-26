using System;

namespace T05._HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();

            Console.WriteLine($"<h1>\n\t{title}\n</h1>");
            Console.WriteLine($"<article>\n\t{content}\n</article>");

            string comment = Console.ReadLine();

            while (comment != "end of comments")
            {
                Console.WriteLine($"<div>\n\t{comment}\n</div>");
                comment = Console.ReadLine();
            }
        }
    }
}
