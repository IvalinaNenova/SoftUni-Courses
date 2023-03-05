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

            //string command = Console.ReadLine();

            //string result = GetBooksByAgeRestriction(db, command);
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

        }
    }
}


