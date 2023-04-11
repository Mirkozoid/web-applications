using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;

namespace Telegram_bot
{
    class NewsAPI
    {
        public static void SearchNews()
        {
            var newsApiClient = new NewsApiClient("3f3d1b21c67d428789637f10eca4787d");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "business",
                SortBy = SortBys.Popularity,
                Language = Languages.RU,
                From = new DateTime(2023, 3, 20)
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                Console.WriteLine(articlesResponse.TotalResults);
                foreach (var article in articlesResponse.Articles)
                {
                    Console.WriteLine(article.Title);
                    Console.WriteLine(article.Author);
                    Console.WriteLine(article.Description);
                    Console.WriteLine(article.Url);
                    News.textNews.Add(article.Title + "\n" + article.Description + "\n" + article.Title + "\n" + article.Url);
                }
            }
        }
    }
}
