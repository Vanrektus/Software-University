using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BookShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var dbContext = new BookShopContext())
            {
                DbInitializer.ResetDatabase(dbContext);

                int input = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                Console.WriteLine(CountBooks(dbContext, input));
            }
        }

        // 02. - Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestrInput = Enum.Parse<AgeRestriction>(command, true);

            List<string> books = context.Books
                .Where(b => b.AgeRestriction == ageRestrInput)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // 03. - Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            List<string> books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // 04. - Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price,
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var currBook in books)
            {
                sb.AppendLine($"{currBook.Title} - ${currBook.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 05. - Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // 06. - Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // 07. - Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    Edition = b.EditionType,
                    Price = b.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var currBook in books)
            {
                sb.AppendLine($"{currBook.Title} - {currBook.Edition} - ${currBook.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 08. - Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var currAuthor in authors)
            {
                sb.AppendLine(currAuthor.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        // 09. - Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            List<string> books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // 10. - Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Title = b.Title,
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var currBook in books)
            {
                sb.AppendLine($"{currBook.Title} ({currBook.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        }

        // 11. - Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
            //return $"There are {books.Count} books with longer title than {lengthCheck} symbols";
        }

        // 12. - Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            throw new NotImplementedException();
        }

        // 13. - Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            throw new NotImplementedException();
        }

        // 14. - Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            throw new NotImplementedException();
        }

        // 15. - Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            throw new NotImplementedException();
        }

        // 16. - Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            throw new NotImplementedException();
        }
    }
}