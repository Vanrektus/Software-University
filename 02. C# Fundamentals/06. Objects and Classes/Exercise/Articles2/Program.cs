using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArticleList articleList = new ArticleList();

            int n = int.Parse(Console.ReadLine());

            NewArticle(articleList, n);

            string lastInput = Console.ReadLine();

            PrintArticle(articleList, lastInput);
        }

        static void NewArticle(ArticleList articleList, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] newArticle = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                articleList.ArticlesList.Add(new Article
                {
                    Title = newArticle[0],
                    Content = newArticle[1],
                    Author = newArticle[2]
                });
            }
        }

        static void PrintArticle(ArticleList articleList, string lastInput)
        {
            switch (lastInput)
            {
                case "title":
                    foreach (Article article in articleList.ArticlesList.OrderBy(article => article.Title))
                    {
                        Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                    }
                    break;
                case "content":
                    foreach (Article article in articleList.ArticlesList.OrderBy(article => article.Content))
                    {
                        Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                    }
                    break;
                case "author":
                    foreach (Article article in articleList.ArticlesList.OrderBy(article => article.Author))
                    {
                        Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                    }
                    break;
            }
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }

    class ArticleList
    {
        public List<Article> ArticlesList { get; set; }

        public ArticleList()
        {
            ArticlesList = new List<Article>();
        }
    }
}
