using System;
using System.Collections.Generic;
using System.Linq;

namespace Т03._Articles_2._0
{

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }


        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] data = Console.ReadLine().Split(", ");

                Article newArticle = new Article(data[0], data[1], data[2]);
                articles.Add(newArticle);
            }

            //string sortingCriteria = Console.ReadLine();

            //List<Article> sortedList = new List<Article>();

            //if (sortingCriteria == "title")
            //{
            //    sortedList = articles.OrderBy(article => article.Title).ToList();
            //}
            //else if (sortingCriteria == "content")
            //{
            //    sortedList = articles.OrderBy(article => article.Content).ToList();
            //}
            //else if (sortingCriteria == "author")
            //{
            //    sortedList = articles.OrderBy(article => article.Author).ToList();
            //}

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }
}
