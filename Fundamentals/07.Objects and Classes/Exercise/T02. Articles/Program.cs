using System;

namespace T02._Articles
{

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Author = author;
            Content = content;
        }
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void EditArticle(string newContent) => Content = newContent;

        public void ChangeAuthor(string newAuthor) => Author = newAuthor;

        public void Rename(string newTitle) => Title = newTitle;

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            Article article = new Article(input[0], input[1], input[2]);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                string action = command[0];
                string change = command[1];

                if (action == "Edit")
                {
                    article.EditArticle(change);
                }
                if (action == "ChangeAuthor")
                {
                    article.ChangeAuthor(change);
                }
                if (action == "Rename")
                {
                    article.Rename(change);
                }
            }

            Console.WriteLine(article);
        }
    }
}
