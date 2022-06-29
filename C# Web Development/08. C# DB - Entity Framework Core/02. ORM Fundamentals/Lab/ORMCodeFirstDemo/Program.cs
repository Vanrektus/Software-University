using ORMCodeFirstDemo.Models;
using System;
using System.Linq;

namespace ORMCodeFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            // Add stuff to DB
            /*
            db.Categories.Add(new Category
            {
                Title = "Cars",
                News = new List<News>
                {
                    new News
                    {
                        Title = "New S Class Released!",
                        Content = "Mercedes made the best car ever",
                        Comments = new List<Comment>
                        {
                            new Comment { Author = "Vancho", Content = "Nice!" },
                            new Comment { Author = "Gosho", Content = "Yeah!" },
                        }
                    }
                }
            });
            */

            // Update DB
            /*
            var news = db.News.FirstOrDefault();
            news.Content = "Mercedes are the best!";
            */

            db.SaveChanges();

            Console.WriteLine(db.Comments.Count());

            foreach (var currNews in db.News)
            {
                Console.WriteLine(currNews.Content);
            }
        }
    }
}
