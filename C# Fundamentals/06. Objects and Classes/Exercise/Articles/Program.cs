using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            Article article = new Article();

            int n = int.Parse(Console.ReadLine());

            ChangeArticle(article, n);

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }

        static void ChangeArticle(Article article, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] newInput = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                switch (newInput[0])
                {
                    case "Rename":
                        article.Rename(newInput);
                        break;
                    case "Edit":
                        article.Edit(newInput);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(newInput);
                        break;
                }
            }
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article()
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Title = input[0];
            Content = input[1];
            Author = input[2];
        }
        public string Rename(string[] newInput)
        {
            return Title = newInput[1];
        }

        public string Edit(string[] newInput)
        {
            return Content = newInput[1];
        }

        public string ChangeAuthor(string[] newInput)
        {
            return Author = newInput[1];
        }
    }
}
