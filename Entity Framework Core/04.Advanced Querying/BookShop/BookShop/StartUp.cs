﻿using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //int command = int.Parse(Console.ReadLine());

            //string result = GetBooksByAgeRestriction(db, command);
            //string result = GetGoldenBooks(db);
            //string result = GetBooksByPrice(db);
            //string result = GetBooksNotReleasedIn(db, command);

            //Console.WriteLine(result);
        }

        //Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction;

            var isParseSuccess = Enum.TryParse<AgeRestriction>(command, true, out ageRestriction);

            if (!isParseSuccess)
            {
                return string.Empty;
            }

            string[] bookTitles = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //Problem 03

        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] goldenBooks = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold &&
                                 b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        //Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var booksByPrice = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var b in booksByPrice)
            {
                output
                    .AppendLine($"{b.BookTitle} - ${b.Price:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //Problem 05

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //Problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {

        }
    }
}


