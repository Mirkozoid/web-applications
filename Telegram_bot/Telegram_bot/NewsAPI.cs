using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;
using Telegrambot;

namespace TelegramBot
{
    class NewsAPI
    {
        public static void SearchNews()
        {
            var newsApiClient = new NewsApiClient(System.IO.File.ReadAllText("tokenAPI.txt"));
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "business",
                SortBy = SortBys.Popularity,
                Language = Languages.RU,
                From = DateTime.Now.AddDays(-15)
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                Console.WriteLine(articlesResponse.TotalResults);
                foreach (var article in articlesResponse.Articles)
                {
                    Storage.news.Add(new News() 
                    { 
                        title = article.Title + "\n", 
                        text = article.Description + "\n", 
                        url = article.Url, 
                    });
                    News.textNews.Add(article.Title + "\n" + article.Description + "\n" + article.Url);
                }
            }
        }
    }
}
